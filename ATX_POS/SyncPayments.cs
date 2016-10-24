using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;

namespace ATX_POS
{
    using GeneralJournalNAV;
    public partial class SyncPayments : MetroFramework.Forms.MetroForm
    {
        public ATX_POS.test2010.TestWS test2110 = new test2010.TestWS();
        public string username = "";
        public string terminal = "";
        private string Datefilter = "";
        private string terminalfilter = "";
        private bool datacorrect = false;
        private int errors = 0;
        private DataTable datatablesales = new DataTable();

        public SyncPayments()
        {
            InitializeComponent();
        }

        private void SyncPayments_Load(object sender, EventArgs e)
        {
            SalesSync2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            SalesSync2.RowHeadersVisible = false;

            SalesSync2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ProgressSyncNav.Visible = false;
        }

        private void metroTextButton2_Click(object sender, EventArgs e)
        {

            if (SalesSync2.DataSource != null)
            {
                int totals = 0;
                foreach (DataGridViewRow row in SalesSync2.Rows)
                {
                    string cell = row.Cells[7].Value.ToString();
                    if (bool.Parse(cell) == true)
                        totals = totals + 1;
                }
                if (totals > 0)
                {
                    DialogResult result = MetroFramework.MetroMessageBox.Show(this, "¿Esta Seguro que desea sincronizar los Pagos con NAVonAZURE?", "Sincronización con NAV", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;


                        ProgressSyncNav.Visible = true;
                        ProgressSyncNav.Maximum = totals;
                        ProgressSyncNav.Value = 0;
                        ProgressSyncNav.Step = 1;
                        //ConectionNav();
                        sendpayments();
                        if (SalesSync2.DataSource != null)
                        {
                            DataTable dta = (DataTable)SalesSync2.DataSource;
                            dta.Clear();
                            MetroFramework.MetroMessageBox.Show(this, "Sincronizacion Completa", "Sincronización con NAV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ProgressSyncNav.Visible = false;
                            this.Cursor = Cursors.Arrow;
                            //metroProgressSpinner1.Visible = false;
                        }
                        if (errors > 0)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Los Pagos se han registrado con errors, " + errors.ToString() + " registro(s) no se ha(n) sincronizado", "Sincronización con errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        ProgressSyncNav.Visible = false;
                        //metroProgressSpinner1.Visible = false;
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "No hay pagos correctos por registrar", "Sincronización con errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DataTable dta = (DataTable)SalesSync2.DataSource;
                    dta.Clear();
                }
            }
        }

        private void ConectionNav()
        {

        }
        private void sendpayments()
        {
            //MetroFramework.Controls.MetroProgressSpinner spiner= new MetroFramework.Controls.MetroProgressSpinner();
            //this.Controls.Add(this.spiner);
            string AccountTermNav = "";
            string Suc = "";
            GeneralJournalNAV.GeneralJournalPOS_Service PaymentsService = new GeneralJournalPOS_Service();
            //Credenciales de acceso
            string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
            string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
            string CustomerCodeNAV = System.Configuration.ConfigurationManager.AppSettings["customercode"];
            var networkcre = new NetworkCredential(userconfigsfile, passconfigsfile);
            PaymentsService.Credentials = networkcre;
            GeneralJournalNAV.GeneralJournalPOS payment = new GeneralJournalPOS();
            String BathName = "POS";
            PaymentsService.Create(BathName, ref payment);
            //DataTable sales_header = GetSalesHeader();

            if (SalesSync2 != null)
            {
                test2010.TestWS regjournal = new test2010.TestWS();
                regjournal.Credentials = networkcre;
                foreach (DataGridViewRow row in SalesSync2.Rows)
                {
                    //0[NoVenta], 1[Terminal], 2[SalesTotal], 3[CashPay], 4[NoTicket], 5[CorteReg]
                    //PaymentsService.Create(BathName, ref payment)
                    //payment.Line_No = Line;
                    bool continuereg = bool.Parse(row.Cells[7].Value.ToString());
                    if (continuereg)
                    {
                        //GetAccountTerminal(ref AccountTermNav, ref Suc, row);

                        //Datatable Sales ROWS
                        //0"NoVenta", 1"Fecha Registro", 2"NoTicket", 3"SalesTotal", 4"CorteReg", 5"Number", 6"SyncNav"
                        //
                        AccountTermNav = System.Configuration.ConfigurationManager.AppSettings["TerminalAccount"];
                        Suc = System.Configuration.ConfigurationManager.AppSettings["SucursalAccount"];
                        DateTime DateReg = DateTime.ParseExact(row.Cells[1].Value.ToString(), "MM/dd/yyyy", null);
                        string CorteId = row.Cells[2].Value.ToString() + DateReg.ToString("MM/dd/yyyy");
                        payment.Posting_Date = DateReg;//DateTime.Today;
                        payment.Document_Type = Document_Type.Payment;
                        payment.Document_No = row.Cells[2].Value.ToString();
                        payment.Account_Type = Account_Type.Customer;
                        payment.Account_No = CustomerCodeNAV;
                        payment.External_Document_No = CorteId;
                        decimal totalSalesHeader = decimal.Parse(row.Cells[3].Value.ToString());
                        payment.Payment_Method_Code = "01";
                        payment.Amount = (totalSalesHeader * -1M);
                        payment.Bal_Account_Type = Bal_Account_Type.G_L_Account;
                        payment.Bal_Account_No = AccountTermNav;
                        //payment.
                        PaymentsService.Update(BathName, ref payment);
                        
                        if (regjournal.PostJournal(payment.Document_No))
                        {
                            UpdatePaymentSales(row);
                        }
                    }
                }
                regjournal.ClearJournal();
                
                //PaymentsService.Update(BathName, ref payment);
            }
        }
        private void GetAccountTerminal(ref string AccountTermNav, ref string CodeSuc, DataGridViewRow rowsal)
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                //0"NoVenta", 1"Fecha Registro", 2"NoTicket", 3"SalesTotal", 4"CorteReg", 5"Number", 6"SyncNav"
                checkConection(con);
                SqlCommand checkaccount = new SqlCommand();
                checkaccount.Parameters.Clear();
                checkaccount.CommandText = "select [AccountNAV] from Terminals where [Number] = @Terminal";
                checkaccount.Connection = con;
                con.Open();
                checkaccount.Parameters.AddWithValue("@Terminal", rowsal.Cells[4].Value.ToString());
                SqlDataAdapter AccountNumber = new SqlDataAdapter(checkaccount);
                DataTable AccountTable = new DataTable();
                if (AccountNumber != null)
                {
                    AccountNumber.Fill(AccountTable);
                }
                foreach (DataRow row in AccountTable.Rows)
                {
                    AccountTermNav = row[0].ToString();
                }
                checkConection(con);
                SqlCommand GetStoreCode = new SqlCommand();
                GetStoreCode.Parameters.Clear();
                GetStoreCode.CommandText = "select [AccountNAV] from Terminals where [Number] = @Terminal";
                GetStoreCode.Connection = con;
                con.Open();
                GetStoreCode.Parameters.AddWithValue("@Terminal", rowsal.Cells[4].Value.ToString());
                SqlDataAdapter StoreCodeSDA = new SqlDataAdapter(GetStoreCode);
                DataTable StoreDaT = new DataTable();
                if (StoreCodeSDA != null)
                {
                    StoreCodeSDA.Fill(StoreDaT);
                }
                foreach (DataRow row in StoreDaT.Rows)
                {
                    CodeSuc = row[0].ToString();
                }
                checkConection(con);
            }
        }
        private void UpdatePaymentSales(DataGridViewRow rows)
        {
            using (SqlConnection cone = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                checkConection(cone);
                SqlCommand UpdatePaymentSales = new SqlCommand();
                UpdatePaymentSales.Parameters.Clear();
                //0[NoVenta], 1[Terminal], 2[SalesTotal], 3[CashPay], 4[NoTicket], 5[CorteReg]
                UpdatePaymentSales.CommandText = "update Sales set CorteReg = @PostJournalState where NoVenta = @NoVenta";
                UpdatePaymentSales.Parameters.AddWithValue("@PostJournalState", true);
                UpdatePaymentSales.Parameters.AddWithValue("@NoVenta", rows.Cells[0].Value.ToString());
                UpdatePaymentSales.Connection = cone;
                cone.Open();
                UpdatePaymentSales.ExecuteNonQuery();
                checkConection(cone);
            }
        }

        private void metroTextButton3_Click(object sender, EventArgs e)
        {
            ProgressSyncNav.Visible = false;
            DateTime timefilter = Calendar.Value;
            Datefilter = timefilter.ToString("MM/dd/yyyy");
            //userfilter = ListOfUsers.Text.ToString();
            terminalfilter = TerminalList.Text.ToString();
            string datefilterfin = "";
            if (DateRange.Checked == true)
            {
                datefilterfin = Findatetime.Value.ToString("MM/dd/yyyy");
            }
            GetSalesGrid(Datefilter, datefilterfin, terminalfilter);
        }

        private void ListOfUsers_Click(object sender, EventArgs e)
        {

        }

        private void TerminalList_Click(object sender, EventArgs e)
        {
            ProgressSyncNav.Visible = false;
            if (TerminalList.Items.Count <= 0)
            {

                DataTable dtT = new DataTable();
                using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    cn.Open();
                    SqlCommand ListTerminals = new SqlCommand();
                    ListTerminals.Parameters.Clear();
                    ListTerminals.Connection = cn;
                    ListTerminals.CommandText = "IF ((Select TOP 1 PermisseLevel from dbo.[Users] where users.PermisseLevel = 1) = (select PermisseLevel from dbo.[Users] where Users.[User] =@User)) select Number from Terminals ELSE select Supervisor from Terminals where Supervisor = (select ID from Users where [Name] = @User)";
                    ListTerminals.Parameters.AddWithValue("@User", username);
                    ListTerminals.ExecuteNonQuery();

                    SqlDataReader sdr = ListTerminals.ExecuteReader();
                    try
                    {
                        while (sdr.Read())
                        {
                            TerminalList.Items.Add(sdr["Number"].ToString());
                        }
                        cn.Close();

                    }
                    catch (SqlException sq)
                    {
                        MessageBox.Show(sq.Message.ToString());
                    }
                }
            }
        }

        private void GetSalesGrid(string Datefilter, string datefilterfin, string terminalfilter)
        {

            if (SalesSync2.DataSource != null)
            {
                DataTable dta = (DataTable)SalesSync2.DataSource;
                dta.Clear();
            }

            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                SqlCommand salescommand = new SqlCommand();
                salescommand.Parameters.Clear();
                salescommand.Connection = cn;
                #region Commands
                if (DateRange.Checked == true)
                {
                    if (terminalfilter != "" && (SalesIdNo.Text.ToString() == ""))
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], sales.[NoTicket], sales.[SalesTotal], Terminals.Number, Sales.SyncNav, Sales.[CorteReg] from Sales INNER JOIN Terminals on Sales.Terminal = Terminals.Terminal  where (Sales.[Fecha Registro] Between @Initdate and @Findate) and Sales.[Terminal] =(select Terminal from Terminals where Number = @Number))";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
                        salescommand.Parameters.AddWithValue("@Findate", datefilterfin);
                        salescommand.Parameters.AddWithValue("@Number", terminal);
                    }
                    else if (SalesIdNo.Text.ToString() != "" && (terminalfilter == ""))
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], sales.[NoTicket], sales.[NoTicket], sales.[SalesTotal],Terminals.Number, Sales.SyncNav, Sales.[CorteReg] from Sales INNER JOIN Terminals on Sales.Terminal = Terminals.Terminal  where (Sales.[Fecha Registro] Between @Initdate and @Findate) and Sales.[NoVenta] = @salesid)";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
                        salescommand.Parameters.AddWithValue("@Findate", datefilterfin);
                        salescommand.Parameters.AddWithValue("@salesid", SalesIdNo.Text.ToString());
                    }
                    else if (terminalfilter == "" && SalesIdNo.Text == "")
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], sales.[NoTicket], sales.[SalesTotal],Terminals.Number, Sales.SyncNav, Sales.[CorteReg] from Sales INNER JOIN Terminals on Sales.Terminal = Terminals.Terminal  where Sales.[Fecha Registro] Between @Initdate and @Findate)";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
                        salescommand.Parameters.AddWithValue("@Findate", datefilterfin);
                    }
                }
                else if (DateRange.Checked == false)
                {
                    if (terminalfilter != "" && (SalesIdNo.Text.ToString() == ""))
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], sales.[NoTicket], sales.[SalesTotal],Terminals.Number, Sales.SyncNav, Sales.[CorteReg] from Sales INNER JOIN Terminals on Sales.Terminal = Terminals.Terminal  where (Sales.[Fecha Registro] = @Initdate) and Sales.[Terminal] =(select Terminal from Terminals where Number = @Number))";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
                        salescommand.Parameters.AddWithValue("@Number", terminal);
                    }
                    else if (SalesIdNo.Text.ToString() != "" && (terminalfilter == ""))
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], sales.[NoTicket], sales.[SalesTotal],Terminals.Number, Sales.SyncNav, Sales.[CorteReg] from Sales INNER JOIN Terminals on Sales.Terminal = Terminals.Terminal  where (Sales.[Fecha Registro] = @Initdate) and Sales.[NoVenta] = @salesid)";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
                        salescommand.Parameters.AddWithValue("@salesid", SalesIdNo.Text.ToString());
                    }
                    else if (terminalfilter == "" && SalesIdNo.Text == "")
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], sales.[NoTicket], sales.[SalesTotal],Terminals.Number, Sales.SyncNav, Sales.[CorteReg] from Sales INNER JOIN Terminals on Sales.Terminal = Terminals.Terminal  where (Sales.[Fecha Registro] = @Initdate))";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
                        //salescommand.Parameters.AddWithValue("@salesid", SalesIdNo.Text.ToString());
                    }
                }
                #endregion
                SqlDataAdapter da = new SqlDataAdapter(salescommand);
                if (da != null)
                {

                    da.Fill(datatablesales);
                    SalesSync2.AutoGenerateColumns = false;
                    SalesSync2.Columns[0].DataPropertyName = "NoVenta";
                    SalesSync2.Columns[1].DataPropertyName = "Fecha Registro";
                    SalesSync2.Columns[2].DataPropertyName = "NoTicket";
                    SalesSync2.Columns[3].DataPropertyName = "SalesTotal";
                    SalesSync2.Columns[4].DataPropertyName = "Number";
                    SalesSync2.Columns[5].DataPropertyName = "SyncNav";
                    SalesSync2.Columns[6].DataPropertyName = "CorteReg";
                    SalesSync2.DataSource = datatablesales;
                }
                checkConection(cn);
                foreach (DataGridViewRow row in SalesSync2.Rows)
                {
                    bool Navsyn = false, PaySync = false;
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[7];
                    string roowbool = row.Cells[5].Value.ToString();
                    string roowboolpayment = row.Cells[6].Value.ToString();
                    if (roowbool != "")
                        Navsyn = bool.Parse(roowbool);

                    if (roowboolpayment != "")
                        PaySync = bool.Parse(roowboolpayment);

                    if (Navsyn == true && PaySync == false)
                    {
                        chk.Value = true;//!(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
                    }
                    else if (Navsyn == false || PaySync == true)
                    {
                        chk.Value = false;
                        row.Cells[7].ReadOnly = true;
                    }
                }
            }

        }
        private void checkConection(SqlConnection cn)
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        private void SalesIdNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }

        private void metroTextButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (DateRange.Checked == true)
            {
                Findatetime.Enabled = true;
            }
            else
            {
                Findatetime.Enabled = false;
            }
        }

        private void SalesIdNo_TextChanged(object sender, EventArgs e)
        {
            TerminalList.SelectedIndex = -1;
        }
    }
}
