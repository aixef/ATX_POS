using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ATX_POS.WS_NAV;
using System.Net;

namespace ATX_POS
{
    public partial class SyncSales : MetroFramework.Forms.MetroForm
    {
        public ATX_POS.test2010.TestWS test2110 = new test2010.TestWS();
        public string username = "";
        public string terminal = "";
        private string Datefilter = "";
        private string userfilter = "";
        private string terminalfilter = "";
        private bool datacorrect = false;
        private int errors = 0;
        private DataTable datatablesales = new DataTable();
        public SyncSales()
        {
            InitializeComponent();
        }

        private void SyncSales_Load(object sender, EventArgs e)
        {
            SalesSync2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            SalesSync2.RowHeadersVisible = false;

            SalesSync2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ProgressSyncNav.Visible = false;
            //metroProgressSpinner1.Visible = false;
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ListOfUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListOfUsers.SelectedItem != null)
            {
                if (TerminalList.Text != "")
                {
                    TerminalList.SelectedIndex = -1;
                }
            }
        }

        private void ListOfUsers_Click(object sender, EventArgs e)
        {
            ProgressSyncNav.Visible = false;
            if (ListOfUsers.Items.Count <= 0)
            {

                DataTable dt = new DataTable();
                using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    cn.Open();
                    SqlCommand UserList = new SqlCommand();
                    UserList.Parameters.Clear();
                    UserList.Connection = cn;
                    UserList.CommandText = "IF ((Select TOP 1 PermisseLevel from dbo.[Users] where users.PermisseLevel = 1) = (select PermisseLevel from dbo.[Users] where Users.[User] =@User)) select Users.[User] from dbo.[Users] ELSE select Users.[User] from dbo.[Users] where Users.Termina = (select Terminal from dbo.Terminals where Terminals.[Number] = @NoTerminal)";
                    UserList.Parameters.AddWithValue("@User", username);
                    UserList.Parameters.AddWithValue("@NoTerminal", terminal);
                    UserList.ExecuteNonQuery();

                    SqlDataReader sdr = UserList.ExecuteReader();
                    try
                    {
                        while (sdr.Read())
                        {
                            ListOfUsers.Items.Add(sdr["User"].ToString());
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

        private void metroTextButton3_Click(object sender, EventArgs e)
        {
            ProgressSyncNav.Visible = false;
            DateTime timefilter = Calendar.Value;
            Datefilter = timefilter.ToString("MM/dd/yyyy");
            userfilter = ListOfUsers.Text.ToString();
            terminalfilter = TerminalList.Text.ToString();
            string datefilterfin = "";
            if (DateRange.Checked == true)
            {
                datefilterfin = Findatetime.Value.ToString("MM/dd/yyyy");
            }
            GetSalesGrid(Datefilter, datefilterfin, userfilter, terminalfilter);
        }

        private void GetSalesGrid(string Datefilter, string datefilterfin, string userfilter, string terminalfilter)
        {
           //SalesSync2.DataSource = datatablesales;
           if (SalesSync2.DataSource != null )
            {
                DataTable dta = (DataTable)SalesSync2.DataSource;
                dta.Clear();
                //SalesSync2.DataSource = dta;
            }

            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                SqlCommand salescommand = new SqlCommand();
                salescommand.Parameters.Clear();
                salescommand.Connection = cn;
                #region Commands
                if (DateRange.Checked == true)
                {
                    if (userfilter != "")
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], Users.[User],Terminals.Number, Sales.SyncNav from Sales INNER JOIN Users ON Sales.[User] = Users.[ID] inner join Terminals on Sales.Terminal = Terminals.Terminal  where (Sales.[Fecha Registro] Between @Initdate and @Findate) and Sales.[User] =(select ID from Users where [user] = @User))";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
                        salescommand.Parameters.AddWithValue("@Findate", datefilterfin);
                        salescommand.Parameters.AddWithValue("@User", userfilter);
                    }
                    else if (terminalfilter != "")
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], Users.[User],Terminals.Number, Sales.SyncNav from Sales INNER JOIN Users ON Sales.[User] = Users.[ID] inner join Terminals on Sales.Terminal = Terminals.Terminal  where (Sales.[Fecha Registro] Between @Initdate and @Findate) and Sales.[Terminal] =(select Terminal from Terminals where Number = @Number))";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
                        salescommand.Parameters.AddWithValue("@Findate", datefilterfin);
                        salescommand.Parameters.AddWithValue("@Number", terminalfilter);
                    }
                    else if (SalesIdNo.Text.ToString() != "")
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], Users.[User],Terminals.Number, Sales.SyncNav from Sales INNER JOIN Users ON Sales.[User] = Users.[ID] inner join Terminals on Sales.Terminal = Terminals.Terminal  where (Sales.[Fecha Registro] Between @Initdate and @Findate) and Sales.[NoVenta] = @salesid)";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
                        salescommand.Parameters.AddWithValue("@Findate", datefilterfin);
                        salescommand.Parameters.AddWithValue("@salesid", SalesIdNo.Text.ToString());
                    }
                    else if (userfilter == "" && terminalfilter == "" && SalesIdNo.Text == "")
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], Users.[User],Terminals.Number, Sales.SyncNav from Sales INNER JOIN Users ON Sales.[User] = Users.[ID] inner join Terminals on Sales.Terminal = Terminals.Terminal  where Sales.[Fecha Registro] Between @Initdate and @Findate)";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
                        salescommand.Parameters.AddWithValue("@Findate", datefilterfin);
                    }
                }
                else if (DateRange.Checked == false)
                {
                    if (userfilter != "")
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], Users.[User],Terminals.Number, Sales.SyncNav from Sales INNER JOIN Users ON Sales.[User] = Users.[ID] inner join Terminals on Sales.Terminal = Terminals.Terminal  where (Sales.[Fecha Registro] = @Initdate) and Sales.[User] =(select ID from Users where [user] = @User))";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
                        salescommand.Parameters.AddWithValue("@User", userfilter);
                    }
                    else if (terminalfilter != "")
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], Users.[User],Terminals.Number, Sales.SyncNav from Sales INNER JOIN Users ON Sales.[User] = Users.[ID] inner join Terminals on Sales.Terminal = Terminals.Terminal  where (Sales.[Fecha Registro] = @Initdate) and Sales.[Terminal] =(select Terminal from Terminals where Number = @Number))";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
                        salescommand.Parameters.AddWithValue("@Number", terminalfilter);
                    }
                    else if (SalesIdNo.Text.ToString() != "")
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], Users.[User],Terminals.Number, Sales.SyncNav from Sales INNER JOIN Users ON Sales.[User] = Users.[ID] inner join Terminals on Sales.Terminal = Terminals.Terminal  where (Sales.[Fecha Registro] = @Initdate) and Sales.[NoVenta] = @salesid)";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
                        salescommand.Parameters.AddWithValue("@salesid", SalesIdNo.Text.ToString());
                    }
                    else if (userfilter == "" && terminalfilter == "")
                    {
                        salescommand.CommandText = "(select Sales.NoVenta, sales.[Fecha Registro], Users.[User],Terminals.Number, Sales.SyncNav from Sales INNER JOIN Users ON Sales.[User] = Users.[ID] inner join Terminals on Sales.Terminal = Terminals.Terminal  where Sales.[Fecha Registro] = @Initdate)";
                        salescommand.Parameters.AddWithValue("@Initdate", Datefilter);
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
                    SalesSync2.Columns[2].DataPropertyName = "User";
                    SalesSync2.Columns[3].DataPropertyName = "Number";
                    SalesSync2.Columns[4].DataPropertyName = "SyncNav";
                    SalesSync2.DataSource = datatablesales;
                }
                checkConection(cn);
                foreach (DataGridViewRow row in SalesSync2.Rows)
                {
                    bool Navsyn = false;
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[5];
                    string roowbool = row.Cells[4].Value.ToString();
                    if (roowbool != "")
                        Navsyn = bool.Parse(roowbool);
                    if (Navsyn == false)
                    {
                        chk.Value = true;//!(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
                    }
                    else
                    {
                        chk.Value = false;
                        row.Cells[5].ReadOnly = true;
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

        private void TerminalList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TerminalList.SelectedItem != null)
            {
                if (ListOfUsers.Text != "")
                {
                    ListOfUsers.SelectedIndex = -1;
                }
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
        private static void ConvertToDateTime(string value)
        {
            DateTime convertedDate;
            try
            {
                convertedDate = Convert.ToDateTime(value);
                Console.WriteLine("'{0}' converts to {1} {2} time.",
                                  value, convertedDate,
                                  convertedDate.Kind.ToString());
            }
            catch (FormatException)
            {
                Console.WriteLine("'{0}' is not in the proper format.", value);
            }
        }

        private void Findatetime_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateinit = Calendar.Value;
            DateTime datefin = Findatetime.Value;
            if (datefin < dateinit)
            {
                MetroFramework.MetroMessageBox.Show(this, "La fecha final no puede ser menor a la fecha de inicio ", "Error Rango de Fechas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datacorrect = false;
                Findatetime.Value = DateTime.Today;
            }
        }

        private void metroTextButton2_Click(object sender, EventArgs e)
        {
            if (SalesSync2.DataSource != null)
            {
                DialogResult result = MetroFramework.MetroMessageBox.Show(this, "¿Esta Seguro que desea sincronizar las ventas con NAVonAZURE?", "Sincronización con NAV", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int totals = 0;
                    foreach (DataGridViewRow row in SalesSync2.Rows)
                    {
                        string cell = row.Cells[5].Value.ToString();
                        if (bool.Parse(cell) == true)
                            totals = totals + 1;
                    }
                    ProgressSyncNav.Visible = true;
                    ProgressSyncNav.Maximum = totals;
                    ProgressSyncNav.Value = 0;
                    ProgressSyncNav.Step = 1;
                    ConectionNav();
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
                        MetroFramework.MetroMessageBox.Show(this, "Las ventas se han registrado con errors, " + errors.ToString() + " registro(s) no se ha(n) sincronizado", "Sincronización con errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    ProgressSyncNav.Visible = false;
                    //metroProgressSpinner1.Visible = false;
                }
            }
        }

        public void ConectionNav()
        {
            string codeSucursal = "";

            //Datos Sucursal
            GetCodeSucursal(ref codeSucursal);
            DataTable salesdetailtable = new DataTable();
            DataTable SalesHeader = new DataTable();
            // Create Service Reference
            WS_NAV.SalesOrder_Service service = new WS_NAV.SalesOrder_Service();
            string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
            string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
            string CustomerCodeNAV = System.Configuration.ConfigurationManager.AppSettings["customercode"];
            NetworkCredential Creden = new NetworkCredential(userconfigsfile, passconfigsfile);
            service.Credentials = Creden;
            //service.UseDefaultCredentials = true;
            bool Navsyn = false;
            test2110.Credentials = Creden;
            foreach (DataGridViewRow rows in SalesSync2.Rows)
            {
                bool SalesHeaderRegCorrect = false;
                string roowbool = rows.Cells[5].Value.ToString();
                if (roowbool != "")
                {
                    Navsyn = bool.Parse(roowbool);
                }
                // Create the Order header 
                if (Navsyn)
                {
                    if (CheckAccessNet())
                    {
                    SalesOrder newOrder = new SalesOrder();

                    // Update Order header
                 
                        try
                        {
                            newOrder.Status = WS_NAV.Status.Open;
                            string DocExtern = "";

                            service.Create(ref newOrder);

                            newOrder.Sell_to_Customer_No = CustomerCodeNAV;
                            SalesHeader.Clear();
                            SalesHeader = GetSalesHeader(rows);
                            DateTime DateReg = new DateTime();
                            #region salesheader
                            foreach (DataRow rowss in SalesHeader.Rows)
                            {
                                string dateregsales = rowss[0].ToString();
                                DateReg = DateTime.ParseExact(dateregsales, "MM/dd/yyyy", null);
                                DocExtern = rowss[2].ToString();
                            }
                            #endregion

                            newOrder.External_Document_No = DocExtern;
                            newOrder.Document_Date = DateReg;
                            //Detalles de linea
                            salesdetailtable.Clear();
                            salesdetailtable = GetSalesHeaderDetail(rows);
                            
                            int lines = Convert.ToInt32(salesdetailtable.Rows.Count.ToString());
                            WS_NAV.Sales_Order_Line[] SalesOrderLines = new Sales_Order_Line[lines];
                            //Llenar lineas venta
                            int salesline = 1000;
                            int line = 0;
                            decimal quantity = 0M;
                            if (CheckAccessNet())
                            //bool linesCorrects = false;
                            #region DetailLines
                            foreach (DataRow row in salesdetailtable.Rows)
                            {
                                //Sales Lines NAV
                                SalesOrderLines[line] = new Sales_Order_Line();
                                quantity = Convert.ToDecimal(row[1].ToString());
                                SalesOrderLines[line].Line_No = salesline;
                                SalesOrderLines[line].Type = WS_NAV.Type.Item;
                                SalesOrderLines[line].TypeSpecified = true;
                                string codeItemNo = test2110.GetNoItem(row[0].ToString());
                                SalesOrderLines[line].No = codeItemNo;
                                SalesOrderLines[line].Cross_Reference_No = row[0].ToString();
                                SalesOrderLines[line].Document_No = newOrder.No;
                                SalesOrderLines[line].Location_Code = codeSucursal;
                                SalesOrderLines[line].Quantity = quantity;
                                SalesOrderLines[line].QuantitySpecified = true;
                                SalesOrderLines[line].Unit_of_Measure_Code = row[2].ToString();
                                newOrder.SalesLines = SalesOrderLines;
                                salesline += 1000;
                                line++;
                                
                            }
                            #endregion
                            service.Update(ref newOrder);
                            //Actualizar datos de facturacion
                            if (CheckAccessNet())
                            {
                                bool allcorrect = false;
                                if (CheckAccessNet())
                                {
                                    service.Update(ref newOrder);
                                    allcorrect = service.IsUpdated(newOrder.Key);
                                }
                                
                                if ((allcorrect == false) && (CheckAccessNet()))
                                {
                                    SalesHeaderRegCorrect = test2110.Registrar2(newOrder.No);
                                    if (SalesHeaderRegCorrect)
                                    {
                                        UpdeteSalesHeader(rows);
                                    }
                                    else
                                    {
                                        errors++;
                                    }
                                }
                            }
                        }
                        catch (SqlException sqlex)
                        {
                            MessageBox.Show(sqlex.Message);
                        }
                        catch (HttpListenerException httpex)
                        {
                            MessageBox.Show(httpex.Message);
                        }
                        catch (TimeoutException timex)
                        {
                            MessageBox.Show(timex.Message);
                        }
                        catch (WebException wex)
                        {
                            MessageBox.Show(wex.Message);
                            bool noconec = false;
                            do
                            {
                                ErrorConectionSync();
                                noconec = CheckAccessNet();
                            } while (noconec == false);

                            MessageBox.Show("El registro no se se sincronizo" + Environment.NewLine, "Vulva a sincronizar el registro faltante");
                            if (newOrder.Key != null)
                            {
                                //service.Update(ref newOrder);
                                test2110.Credentials = Creden;
                                if (newOrder.No != null)
                                {
                                    bool access = CheckAccessNet();
                                    if (access)
                                    {
                                        test2110.DeleteBadPost(newOrder.No);
                                    }
                                }
                                //service.Delete(newOrder.Key);
                            }
                            errors++;
                        }
                    }
                    else
                    {
                        ErrorConection();
                        break;
                    }
                }
                ProgressSyncNav.PerformStep();
            }
        }

        private void UpdeteSalesHeader(DataGridViewRow rows)
        {
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                checkConection(cn);
                SqlCommand updatesales = new SqlCommand();
                updatesales.Parameters.Clear();
                cn.Open();
                updatesales.CommandText = "Update Sales SET [SyncNav]=1 where [NoVenta] =@salesId";
                updatesales.Parameters.AddWithValue("@salesId", rows.Cells[0].Value.ToString());
                updatesales.Connection = cn;
                updatesales.ExecuteNonQuery();
                checkConection(cn);
            }
        }

        private DataTable GetSalesHeaderDetail(DataGridViewRow rows)
        {
            DataTable SalesHeaderDetailCon = new DataTable();
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                checkConection(cn);
                SqlCommand details = new SqlCommand();
                details.Parameters.Clear();
                cn.Open();
                details.Connection = cn;
                details.CommandText = "select SalesDetail.[ItemCode], SalesDetail.[Quantity], Items.[IdMeasure] from SalesDetail INNER JOIN Items ON SalesDetail.[ItemCode] = Items.[ItemCode] where [SalesID] = @IdSales";
                details.Parameters.AddWithValue("@IdSales", rows.Cells[0].Value.ToString());
                SqlDataAdapter sqa = new SqlDataAdapter(details);
                if (sqa != null)
                {
                    SalesHeaderDetailCon.Clear();
                    sqa.Fill(SalesHeaderDetailCon);
                }
                checkConection(cn);
            }
            return SalesHeaderDetailCon;
        }
        private DataTable GetSalesHeader(DataGridViewRow rows)
        {
            DataTable salesHeadesCon = new DataTable();
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                checkConection(cn);
                cn.Open();
                SqlCommand salesh = new SqlCommand();
                salesh.Parameters.Clear();
                salesh.Connection = cn;
                salesh.CommandText = "select [Fecha Registro], [SyncNav],[NoTicket] from Sales where [NoVenta] = @IdSales";
                salesh.Parameters.AddWithValue("@IdSales", rows.Cells[0].Value.ToString());
                SqlDataAdapter sqa = new SqlDataAdapter(salesh);
                if (sqa != null)
                {
                    salesHeadesCon.Clear();
                    sqa.Fill(salesHeadesCon);
                }
                checkConection(cn);
            }
            return
                salesHeadesCon;

        }

        private void GetCodeSucursal(ref string codeSucursal)
        {
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                DataTable suc = new DataTable();
                SqlCommand datasurcursal = new SqlCommand();
                checkConection(cn);
                cn.Open();
                datasurcursal.Connection = cn;
                datasurcursal.CommandText = "select CodeStore from StoresDetail where [No] = 1";
                SqlDataAdapter sda = new SqlDataAdapter(datasurcursal);
                if (sda != null)
                    sda.Fill(suc);
                foreach (DataRow row in suc.Rows)
                {
                    codeSucursal = row[0].ToString();
                }
                checkConection(cn);
            }
        }

        private void ErrorConectionSync()
        {
            MessageBox.Show("Se perdio la conexión a internet" + Environment.NewLine + "Verifique su conexion para contiuar el proceso.");

        }

        private void ErrorConection()
        {
            MessageBox.Show("No hay conexión a internet");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SalesIdNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;

            }

        }

        private void SalesIdNo_TextChanged(object sender, EventArgs e)
        {
            ListOfUsers.SelectedIndex = -1;
            TerminalList.SelectedIndex = -1;
        }

        private void Calendar_MouseCaptureChanged(object sender, EventArgs e)
        {
            ProgressSyncNav.Visible = false;
        }

        private void SalesIdNo_Click(object sender, EventArgs e)
        {
            ProgressSyncNav.Visible = false;
        }
        private bool CheckAccessNet()
        {

            try
            {
                IPHostEntry host = Dns.GetHostEntry("www.atx.com.mx");
                return true;

            }
            catch (Exception es)
            {
                return false;
            }
        }
    }
}
