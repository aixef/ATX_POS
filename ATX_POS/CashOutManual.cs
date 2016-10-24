using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using ATX_POS.WS_NAV;
using System.Net;
using System.Globalization;

namespace ATX_POS
{
    using GeneralJournalNAV;
    public partial class RetiroDinero : MetroFramework.Forms.MetroForm, cashout
    {
        public ATX_POS.test2010.TestWS test2110 = new test2010.TestWS();
        public RetiroDinero()
        {
            InitializeComponent();
            cashCountOut1.TotalCashOut.Focus();
        }
        public string user = "";
        public string terminal = "";
        DataTable inittablecash = new DataTable();
        private DataTable cashsalestable = new DataTable();
        private DataTable cashouttable = new DataTable();
        private decimal totalcashfromsales = 0M;
        private decimal totalchangecashfromsales = 0M;
        private decimal totalouts = 0M;
        private decimal totalinitcash = 0M;
        private decimal totalend = 0M;
        string CodeCashOut = "";
        private string datework = DateTime.Now.ToString("MM/dd/yyyy");


        private void CashOutManual_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                GetInitcash(con);
                GetSalescash(con);
                GetCashOut(con);
                TotalCashInBox();
                checkConection(con);
            }
        }


        private void TotalCashInBox()
        {
            totalend = (totalcashfromsales + totalinitcash) - totalouts;
            cashCountOut1.TotalinBox.Text = totalend.ToString("N2");
        }

        private void GetCashOut(SqlConnection con)
        {
            SqlCommand GetCashOuts = new SqlCommand();
            con.Open();
            GetCashOuts.Parameters.Clear();
            GetCashOuts.Connection = con;
            GetCashOuts.CommandText = "select COALESCE (SUM([Total]),0) FROM CashOut where [Terminal] = (select Terminal from Terminals where Number = @Terminal) and [CasingAsigned]= (select ID from Users where [User] =@user) and [Date] = @Datework";
            GetCashOuts.Parameters.AddWithValue("@Terminal", terminal);
            GetCashOuts.Parameters.AddWithValue("@user", user);
            GetCashOuts.Parameters.AddWithValue("@Datework", datework);

            SqlDataAdapter cashoutstotals = new SqlDataAdapter(GetCashOuts);

            if (cashoutstotals != null)
            {
                cashoutstotals.Fill(cashouttable);
            }
            foreach (DataRow row in cashouttable.Rows)
            {
                totalouts = totalchangecashfromsales + decimal.Parse(row[0].ToString());
            }
            cashCountOut1.CashOut.Text = totalouts.ToString("N2");
            con.Close();
        }

        private void GetSalescash(SqlConnection con)
        {
            SqlCommand GetSales = new SqlCommand();
            con.Open();
            GetSales.Parameters.Clear();
            GetSales.Connection = con;
            GetSales.CommandText = "select COALESCE (SUM([CashMont]),0), COALESCE (SUM([ChangeCash]),0) from PaymentsDetail where [terminalUse] = @Terminal and [UserName] =@user and [DateReg] = @datework";
            GetSales.Parameters.AddWithValue("@Terminal", terminal);
            GetSales.Parameters.AddWithValue("@user", user);
            GetSales.Parameters.AddWithValue("@datework", datework);
            SqlDataAdapter GetSalesDA = new SqlDataAdapter(GetSales);

            if (GetSalesDA != null)
            {
                GetSalesDA.Fill(cashsalestable);
            }

            foreach (DataRow row in cashsalestable.Rows)
            {
                totalcashfromsales = totalcashfromsales + decimal.Parse(row[0].ToString());
                totalchangecashfromsales = totalchangecashfromsales + decimal.Parse(row[1].ToString());
            }
            cashCountOut1.SalesCash.Text = totalcashfromsales.ToString("N2");
            con.Close();
        }

        private void GetInitcash(SqlConnection con)
        {
            SqlCommand GetInitCounting = new SqlCommand();
            con.Open();
            GetInitCounting.Parameters.Clear();
            GetInitCounting.Connection = con;
            GetInitCounting.CommandText = "select COALESCE (SUM([TotalCounting]),0) from CountingUp where [Teriminal] = (select Terminal from Terminals where Number = @Terminal) and [IDreg]= (select ID from Users where [User] =@user) and [DateCounting] = @Datework";
            GetInitCounting.Parameters.AddWithValue("@Terminal", terminal);
            GetInitCounting.Parameters.AddWithValue("@user", user);
            GetInitCounting.Parameters.AddWithValue("@Datework", datework);

            SqlDataAdapter initcash = new SqlDataAdapter(GetInitCounting);

            if (initcash != null)
            {
                initcash.Fill(inittablecash);
            }
            foreach (DataRow row in inittablecash.Rows)
            {

                totalinitcash = decimal.Parse(row[0].ToString());
            }
            cashCountOut1.InitCash.Text = totalinitcash.ToString("N2");
            con.Close();
        }

        private void checkConection(SqlConnection cn)
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cashCountOut1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_Leave(object sender, System.EventArgs e)
        {
        }
        private void RegCashOut_Click(object sender, EventArgs e)
        {
            if ((cashCountOut1.TotalCashOut.Text.ToString() != ""))
            {
                if ((decimal.Parse(cashCountOut1.TotalCashOut.Text.ToString())) <= (decimal.Parse(cashCountOut1.TotalinBox.Text.ToString())))
                {
                    Credentials credens = new Credentials();
                    credens.ShowDialog(this);
                    this.Cursor = Cursors.WaitCursor;
                }
                else
                    MetroFramework.MetroMessageBox.Show(this, "La cantidad a retirar es superior al total en caja", "Se excece el monto en caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((cashCountOut1.TotalCashOut.Text.ToString() == ""))
            {
                MetroFramework.MetroMessageBox.Show(this, "No ha introducido un monto a retirar", "Monto a retirar vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cashCountOut1.TotalCashOut.Text = "";
                cashCountOut1.Focus();
            }
        }
        #region cashout Members
        public int aceptcashout(string userreg)
        {
            int idreg = 0;
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                string datetimeposting = DateTime.Now.ToString("MM/dd/yyyy");
                CodeCashOut = terminal + user + datetimeposting;
                con.Open();
                SqlCommand regcashout = new SqlCommand();
                regcashout.Parameters.Clear();
                regcashout.Connection = con;
                regcashout.CommandText = "insert into CashOut([Total],[Date],[Terminal],[Idreg],[CasingAsigned],[CodeCashOut], [SyncNAV]) values " +
                "(@TotalCashOut,@Datework,(select Terminal from Terminals where Number = @Terminal),(select ID from Users where [User]=@User), (select ID from Users where [User] = @UserAsigned),@CodeCashOut, @SyncNAV) SELECT SCOPE_IDENTITY()";
                regcashout.Parameters.AddWithValue("@TotalCashOut", cashCountOut1.TotalCashOut.Text.ToString());
                regcashout.Parameters.AddWithValue("@Datework", datework);
                regcashout.Parameters.AddWithValue("@Terminal", terminal);
                regcashout.Parameters.AddWithValue("@User", userreg);
                regcashout.Parameters.AddWithValue("@UserAsigned", user.ToString());
                regcashout.Parameters.AddWithValue("@CodeCashOut", CodeCashOut);
                regcashout.Parameters.AddWithValue("@SyncNAV", false);
                idreg = Convert.ToInt32(regcashout.ExecuteScalar());
            }
            if (idreg > 0)
            {
                string totalcashout = cashCountOut1.TotalCashOut.Text.ToString();

                SendGeneralJournal(CodeCashOut, totalcashout, idreg);
                this.Close();
            }
            return idreg;
            //metroProgressSpinner1.Visible = ;
        }

        private void SendGeneralJournal(string CodeCashOut, string totalcashout, int idreg)
        {
            decimal totalcashOut = 0M;
            string cashoutcode = "";
            string datereg = "";
            GeneralJournalNAV.GeneralJournalPOS_Service JournalService = new GeneralJournalPOS_Service();
            //Credenciales de acceso
            string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
            string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
            var networkcre = new NetworkCredential(userconfigsfile, passconfigsfile);

            test2010.TestWS regjournal = new test2010.TestWS();
            regjournal.Credentials = networkcre;

            JournalService.Credentials = networkcre;
            //test2010
            GeneralJournalPOS GeneralJour = new GeneralJournalPOS();
            try
            {
                regjournal.ClearJournal();
                JournalService.Create("POS", ref GeneralJour);
                DataTable datatbacashout = DataCashOut(idreg);
                //0[OutId], 1[Total], 2[Date], 3[Terminal], 4[CodeCashOut]
                string terminalreg = "";
                foreach (DataRow row in datatbacashout.Rows)
                {
                    string totalstring = row[1].ToString();
                    totalcashOut = decimal.Parse(totalstring);
                    datereg = row[2].ToString();
                    cashoutcode = row[4].ToString()+idreg.ToString();
                    terminalreg = row[3].ToString();
                }
                //DataTable datatermaccounts = DataAccountsTerm(terminalreg);
                string CashOutAccount = "";
                string TermAccount = "";
                //[AccountNAV], [CashOutsAccount]
                /*foreach (DataRow rows in datatermaccounts.Rows)
                {
                    CashOutAccount = rows[1].ToString();
                    TermAccount = rows[0].ToString();
                }
                */
                CashOutAccount = System.Configuration.ConfigurationManager.AppSettings["SucursalAccount"];
                TermAccount = System.Configuration.ConfigurationManager.AppSettings["TerminalAccount"];

                DateTime dateregtime = DateTime.ParseExact(datereg, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                GeneralJour.Document_Type = Document_Type._blank_;
                GeneralJour.Document_No = cashoutcode;
                GeneralJour.Account_Type = Account_Type.G_L_Account;
                GeneralJour.Posting_Date = dateregtime;
                //GeneralJour.Account_Type = Account_Type.G_L_Account;
                GeneralJour.Account_No = CashOutAccount;
                GeneralJour.Amount = totalcashOut;
                GeneralJour.Bal_Account_Type = Bal_Account_Type.G_L_Account;
                GeneralJour.Bal_Account_No = TermAccount;
                ////GeneralJour.Recipient_Bank_Account = "0001102";
                //GeneralJour.Payment_Method_Code = "01";
                GeneralJour.External_Document_No = terminalreg + '-' + cashoutcode;
                JournalService.Update("POS", ref GeneralJour);
                regjournal.PostJournal(GeneralJour.Document_No);
                regjournal.ClearJournal();
                updatecashout(idreg);
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message.ToString());
            }
            catch (WebException webex)
            {
                MessageBox.Show(webex.Message.ToString());
            }
            catch (FormatException formatex)
            {
                MessageBox.Show(formatex.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void updatecashout(int idreg)
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                checkConection(con);
                SqlCommand updateCashOut = new SqlCommand();
                updateCashOut.Parameters.Clear();
                updateCashOut.Connection = con;
                con.Open();
                updateCashOut.CommandText = "Update CashOut set [SyncNAV] = @SyncNAV WHERE [OutId] = @idreg";
                updateCashOut.Parameters.AddWithValue("@idreg", idreg);
                updateCashOut.Parameters.AddWithValue("@SyncNAV", true);
                updateCashOut.ExecuteNonQuery();
                checkConection(con);
            }
        }

        private DataTable DataAccountsTerm(string terminalreg)
        {
            DataTable datatb = new DataTable();
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                checkConection(con);

                SqlCommand selectAccounts = new SqlCommand();
                selectAccounts.Parameters.Clear();
                selectAccounts.Connection = con;
                con.Open();
                selectAccounts.CommandText = "select [AccountNAV], [CashOutsAccount] from Terminals where [Terminal] = @idTerm";
                selectAccounts.Parameters.AddWithValue("@idTerm", terminalreg);
                SqlDataAdapter dtcashout = new SqlDataAdapter(selectAccounts);
                if (dtcashout != null)
                {
                    dtcashout.Fill(datatb);
                }
                con.Close();
                checkConection(con);
            }

            return datatb;
        }

        private DataTable DataCashOut(int idreg)
        {
            DataTable datatb = new DataTable();
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand selectcashout = new SqlCommand();
                selectcashout.Parameters.Clear();
                selectcashout.Connection = con;
                selectcashout.CommandText = "select [OutId], [Total], [Date], [Terminal], [CodeCashOut] from CashOut where [OutId] = @idreg";
                selectcashout.Parameters.AddWithValue("@idreg", idreg);
                SqlDataAdapter dtcashout = new SqlDataAdapter(selectcashout);
                if (dtcashout != null)
                {
                    dtcashout.Fill(datatb);
                }
                con.Close();
            }
            return datatb;
        }
        #endregion
    }
}
