using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.Net;
using ATX_POS.WS_NAV;


namespace ATX_POS
{
    using GeneralJournalNAV;
    public partial class RCountingF : MetroFramework.Forms.MetroForm
    {
        public string user;
        public string terminal;
        string datework = DateTime.Today.ToString("MM/dd/yyyy");
        decimal totalcreditsales = 0M;
        decimal totaldebit = 0M;
        decimal totaloutsM = 0M, totalchangescash = 0M, totalOT = 0M;
        decimal salestotalcashing = 0M;
        decimal totalcounUp = 0M;
        decimal cashinBox = 0M;
        ArrayList UsersNoClose = new ArrayList();
        public RCountingF()
        {
            InitializeComponent();
            
        }

        private void RCountingF_Load(object sender, EventArgs e)
        {

        }
        public void GetAllStatics()
        {
            using (SqlConnection CN = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                //LashcutCount(CN);
                TotalCountings(CN);
                TotalSalesCash(CN);
                Totalcreditsales(CN);
                TotalDebitSales(CN);
                TotalOutsTerm(CN);
                LashcutCount(CN);
                Checkconnection(CN);
                GetRealMoney();
            }
        }

        private void GetRealMoney()
        {
            decimal totalcashinmoney = decimal.Parse(estadisticsBox1.salescash.Text.ToString());
            decimal totalcountingUp = decimal.Parse(estadisticsBox1.TotalCasingUps.Text.ToString());

            decimal realmoneycash = totalcashinmoney + totalcountingUp;
            cutBoxs1.RealMoneyCash.Text = realmoneycash.ToString();
        }
        public void checkusr()
        {
            using (SqlConnection CN = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                LashcutCount(CN);
                Checkconnection(CN);
            }
        }
        private void LashcutCount(SqlConnection CN)
        {
            Checkconnection(CN);
            bool checking = CheckSesions(CN);
            if (checking)
            {
                decimal lascount = 0M;
                CN.Open();
                SqlCommand getLastCounting = new SqlCommand();
                getLastCounting.Parameters.Clear();
                getLastCounting.Connection = CN;
                getLastCounting.CommandText = "select top 1 COALESCE(SUM([CashOnBox]),0) from Casing where [TerminalAsig] = @terminal group by [CasingId] order By [CasingId] Desc";
                getLastCounting.Parameters.AddWithValue("@terminal", terminal);
                SqlDataAdapter sqda = new SqlDataAdapter(getLastCounting);
                DataTable sqdatb = new DataTable();
                if (sqda != null)
                {
                    sqda.Fill(sqdatb);
                }
                foreach (DataRow row in sqdatb.Rows)
                {
                    lascount = decimal.Parse(row[0].ToString());
                }
                cutBoxs1.cashfound.Text = lascount.ToString();
            }
            else
            {
                string users = "";
                int userscount = 0;
                foreach (object obj in UsersNoClose)
                {
                    users += (obj+", ");
                    userscount++;
                }
                if (userscount <= 1)
                {
                    MetroFramework.MetroMessageBox.Show(this, "El usuario " + users + "No ha realizado su corte de Turno", "Corte de Turno Faltante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Los Usuarios " + users + "No han realizado su corte de Turno", "Corte de Turno Faltante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //CloseBox.Enabled = false;
            }
            Checkconnection(CN);
        }

        private bool CheckSesions(SqlConnection CN)
        {
            bool allsessionclose = true;
            Checkconnection(CN);
            CN.Open();
            SqlCommand checksessions = new SqlCommand();
            checksessions.Parameters.Clear();
            checksessions.Connection = CN;
            checksessions.CommandText = "select [Cierreturno], [User] from LoginsControl where [DateWork] = @datework and [Terminal] = @Terminal";
            checksessions.Parameters.AddWithValue("@datework", datework);
            checksessions.Parameters.AddWithValue("@Terminal",terminal);
            SqlDataAdapter sdacheck = new SqlDataAdapter(checksessions);
            DataTable checktb = new DataTable();
            if (sdacheck != null)
            {
                sdacheck.Fill(checktb);
            }
            foreach (DataRow row in checktb.Rows)
            {
                bool closeturn = bool.Parse(row[0].ToString());
                if (closeturn == false)
                {
                    UsersNoClose.Add(row[1].ToString());
                    allsessionclose = false;
                }
            }

            CN.Close();
            Checkconnection(CN);
            return allsessionclose;
        }

        private void Checkconnection(SqlConnection CN)
        {
            if (CN.State == ConnectionState.Open)
            {
                CN.Close();
            }
        }

        private void TotalOutsTerm(SqlConnection CN)
        {
            Checkconnection(CN);
            SqlCommand totaloutsterm = new SqlCommand();
            //total manual outs
            #region manualouts
            totaloutsterm.Parameters.Clear();
            CN.Open();
            totaloutsterm.Connection = CN;
            totaloutsterm.CommandText = "select COALESCE(SUM([Total]),0) from CashOut where [Date] = @Datework and [Terminal] = (select [Terminal] from Terminals where [Number] = @Terminal)";
            totaloutsterm.Parameters.AddWithValue("@Datework",datework);
            totaloutsterm.Parameters.AddWithValue("@Terminal", terminal);
            SqlDataAdapter totalDA = new SqlDataAdapter(totaloutsterm);
            DataTable totalouttable = new DataTable();
            if (totalDA != null)
            {
                totalDA.Fill(totalouttable);
            }
            Checkconnection(CN);
            foreach (DataRow row in totalouttable.Rows)
            {
                totaloutsM = decimal.Parse(row[0].ToString());
            }
            #endregion
            //total changes
            #region Totalchanges
            totaloutsterm.Parameters.Clear();
            CN.Open();
            totaloutsterm.CommandText = "select Coalesce(SUM([ChangeCash]),0) FROM PaymentsDetail where [DateReg] = @datework and [terminalUse] = @terminal";
            totaloutsterm.Parameters.AddWithValue("@datework", datework);
            totaloutsterm.Parameters.AddWithValue("@terminal",terminal);
            SqlDataAdapter totalchaDA = new SqlDataAdapter(totaloutsterm);
            DataTable totalchatb = new DataTable();
            if (totalchaDA != null)
            {
                totalchaDA.Fill(totalchatb);
            }
            foreach (DataRow row in totalchatb.Rows)
            {
                totalchangescash = decimal.Parse(row[0].ToString());
            }
            #endregion
            //totalouts
            totalOT = totaloutsM;// +totalchangescash;
            estadisticsBox1.Totalouts.Text = totalOT.ToString();
            Checkconnection(CN);
        }

        private void TotalDebitSales(SqlConnection CN)
        {
            Checkconnection(CN);
            SqlCommand totaldebits = new SqlCommand();
            CN.Open();
            totaldebits.Parameters.Clear();
            totaldebits.CommandText = "select COALESCE (SUM([Total]),0) from CardsDetail where ([Debit] = @Debit OR [Vales] = @Vales) and [DateReg] = @datework and [NumTerm] = @terminal";
            totaldebits.Connection = CN;
            totaldebits.Parameters.AddWithValue("@terminal", terminal);
            totaldebits.Parameters.AddWithValue("@Debit", true);
            totaldebits.Parameters.AddWithValue("@Vales", true);
            totaldebits.Parameters.AddWithValue("@datework", datework);
            SqlDataAdapter debitad = new SqlDataAdapter(totaldebits);
            DataTable debittb = new DataTable();
            if (debitad !=null)
            {
                debitad.Fill(debittb);
            }
            foreach (DataRow row in debittb.Rows)
            {
                totaldebit = decimal.Parse(row[0].ToString());
            }
            estadisticsBox1.debittotal.Text = totaldebit.ToString("N2");
            Checkconnection(CN);
        }

        private void Totalcreditsales(SqlConnection CN)
        {
            Checkconnection(CN);
            SqlCommand totalcredisql = new SqlCommand();
            CN.Open();
            totalcredisql.Parameters.Clear();
            totalcredisql.CommandText = "select COALESCE (SUM([CreditMont]),0) from PaymentsDetail where [DateReg] = @datework and [terminalUse] = @terminal";
            totalcredisql.Connection = CN;
            totalcredisql.Parameters.AddWithValue("@terminal", terminal);
            //totalcredisql.Parameters.AddWithValue("@Credit", true);
            totalcredisql.Parameters.AddWithValue("@datework", datework);
            SqlDataAdapter creditsda = new SqlDataAdapter(totalcredisql);
            DataTable creditb = new DataTable();
            if (creditsda != null)
            {
                creditsda.Fill(creditb);
            }
            foreach (DataRow row in creditb.Rows)
            {
                totalcreditsales = decimal.Parse(row[0].ToString());
            }
            estadisticsBox1.CreditTotal.Text = totalcreditsales.ToString("N2");
            Checkconnection(CN);  
        }

        private void TotalSalesCash(SqlConnection CN)
        {
            Checkconnection(CN);
            SqlCommand salescash = new SqlCommand();
            CN.Open();
            salescash.Parameters.Clear();
            salescash.Connection = CN;
            salescash.CommandText = "select coalesce(SUM([CashMont]),0), coalesce(SUM([ChangeCash]),0) FROM PaymentsDetail where [DateReg] = @datereg and [terminalUse] = @terminal";
            salescash.Parameters.AddWithValue("@terminal",terminal);
            salescash.Parameters.AddWithValue("@datereg",datework);
            SqlDataAdapter salessda = new SqlDataAdapter(salescash);
            DataTable salesdt = new DataTable();
            decimal changesalesconsult = 0M;
            if (salessda != null)
            {
                salessda.Fill(salesdt);
            }
            foreach (DataRow row in salesdt.Rows)
            {
                salestotalcashing = decimal.Parse(row[0].ToString());
                changesalesconsult = decimal.Parse(row[1].ToString());
            }
            decimal totalsin = salestotalcashing - changesalesconsult;
            estadisticsBox1.salescash.Text = totalsin.ToString("N2");
            //estadisticsBox1.salescash.Text = salestotalcashing.ToString("N2");
            Checkconnection(CN);
        }

        private void TotalCountings(SqlConnection CN)
        {
            Checkconnection(CN);
            SqlCommand Totalcountings = new SqlCommand();
            CN.Open();
            Totalcountings.Parameters.Clear();
            Totalcountings.Connection = CN;
            Totalcountings.CommandText = "select COALESCE(SUM([TotalCounting]),0) from CountingUp where [DateCounting] = @datework  and [Teriminal] = (select Terminal from Terminals where Number = @terminal)";
            Totalcountings.Parameters.AddWithValue("@datework", datework);
            Totalcountings.Parameters.AddWithValue("@terminal", terminal);
            SqlDataAdapter countsda = new SqlDataAdapter(Totalcountings);
            DataTable countdt = new DataTable();
            if (countsda != null)
            {
                countsda.Fill(countdt);
            }
            foreach (DataRow row in countdt.Rows)
            {
                totalcounUp = decimal.Parse(row[0].ToString());
            }
            estadisticsBox1.TotalCasingUps.Text = totalcounUp.ToString("N2");
            Checkconnection(CN);
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void metroTextButton1_Click(object sender, EventArgs e)
        {

        }
        private void metroTextButton1_Click_1(object sender, EventArgs e)
        {
            sendpayments();
        }

        private void sendpayments()
        {
            //MetroFramework.Controls.MetroProgressSpinner spiner= new MetroFramework.Controls.MetroProgressSpinner();
            //this.Controls.Add(this.spiner);
            string AccountTermNav = "";
            string Suc = "";
            //GetAccountTerminal(ref AccountTermNav, ref Suc);

            GeneralJournalNAV.GeneralJournalPOS_Service PaymentsService = new GeneralJournalPOS_Service();
            //Credenciales de acceso
            string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
            string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
            string CustomerCodeNAV = System.Configuration.ConfigurationManager.AppSettings["customercode"];
            AccountTermNav = System.Configuration.ConfigurationManager.AppSettings["TerminalAccount"];
            Suc = System.Configuration.ConfigurationManager.AppSettings["SucursalAccount"];
            var networkcre = new NetworkCredential(userconfigsfile, passconfigsfile);
            PaymentsService.Credentials = networkcre;
            GeneralJournalNAV.GeneralJournalPOS payment = new GeneralJournalPOS();
            String BathName = "POS";
            PaymentsService.Create(BathName, ref payment);
            DataTable sales_header = GetSalesHeader();
            int Line = 10000;
            string CorteId = Suc + terminal + DateTime.Today.ToString("MM/dd/yyyy");
            if (sales_header != null)
            {
                foreach (DataRow row in sales_header.Rows)
                {
                    //0[NoVenta], 1[Terminal], 2[SalesTotal], 3[CashPay], 4[NoTicket], 5[CorteReg]
                    //PaymentsService.Create(BathName, ref payment)
                    //payment.Line_No = Line;
                    payment.Posting_Date = DateTime.Today;
                    payment.Document_Type = Document_Type.Payment;
                    payment.Document_No = row[4].ToString();
                    payment.Account_Type = Account_Type.Customer;
                    
                    payment.Account_No = CustomerCodeNAV;
                    payment.External_Document_No = CorteId;
                    decimal totalSalesHeader = decimal.Parse(row[2].ToString());
                    payment.Payment_Method_Code = "01";
                    payment.Amount = (totalSalesHeader * -1M);
                    payment.Bal_Account_Type = Bal_Account_Type.G_L_Account;
                    payment.Bal_Account_No = AccountTermNav;
                    //payment.
                    PaymentsService.Update(BathName, ref payment);
                    test2010.TestWS regjournal = new test2010.TestWS();
                    regjournal.Credentials = networkcre;
                    if (regjournal.PostJournal(payment.Document_No))
                    {
                        UpdatePaymentSales(row);
                    }
                }
                
                
                //PaymentsService.Update(BathName, ref payment);
            }
        }

        private void UpdatePaymentSales(DataRow row)
        {
            using (SqlConnection cone = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                Checkconnection(cone);
                SqlCommand UpdatePaymentSales = new SqlCommand();
                UpdatePaymentSales.Parameters.Clear();
                //0[NoVenta], 1[Terminal], 2[SalesTotal], 3[CashPay], 4[NoTicket], 5[CorteReg]
                UpdatePaymentSales.CommandText = "update Sales set CorteReg = @PostJournalState where NoVenta = @NoVenta";
                UpdatePaymentSales.Parameters.AddWithValue("@PostJournalState", true);
                UpdatePaymentSales.Parameters.AddWithValue("@NoVenta",row[0].ToString());
                UpdatePaymentSales.Connection = cone;
                cone.Open();
                UpdatePaymentSales.ExecuteNonQuery();
                Checkconnection(cone);
            }
        }

        private DataTable GetSalesHeader()
        {
            DataTable SALES_Header = new DataTable();
            using (SqlConnection cone = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                checkConection(cone);
                SqlCommand sales_Headercomand = new SqlCommand();
                sales_Headercomand.Parameters.Clear();
                sales_Headercomand.CommandText = "select [NoVenta], [Terminal], [SalesTotal], [CashPay], [NoTicket], [CorteReg] from Sales where [Terminal] = @Terminal and [CorteReg] = @CorteReg";
                sales_Headercomand.Connection = cone;
                sales_Headercomand.Parameters.AddWithValue("@Terminal", terminal);
                sales_Headercomand.Parameters.AddWithValue("@CorteReg",false);
                SqlDataAdapter SalesSDA = new SqlDataAdapter(sales_Headercomand);
                SALES_Header.Clear();
                if (SalesSDA != null)
                {
                    SalesSDA.Fill(SALES_Header);
                }
                cone.Open();
                checkConection(cone);
            }
            return SALES_Header;
        }

        private void GetAccountTerminal(ref string AccountTermNav, ref string CodeSuc)
        {
            using(SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                checkConection(con);
                SqlCommand checkaccount = new SqlCommand();
                checkaccount.Parameters.Clear();
                checkaccount.CommandText = "select [AccountNAV] from Terminals where [Number] = @Terminal";
                checkaccount.Connection = con;
                con.Open();
                checkaccount.Parameters.AddWithValue("@Terminal", terminal);
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
                GetStoreCode.Parameters.AddWithValue("@Terminal", terminal);
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
        private void 
            etail1_Load(object sender, EventArgs e)
        {

        }

        private void checkConection(SqlConnection cn)
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        private void metroTextButton1_Click_2(object sender, EventArgs e)
        {
            SyncPayments SyncPays = new SyncPayments();
            SyncPays.terminal = terminal;
            SyncPays.username = user;
            SyncPays.ShowDialog(this);
        }

        private void cutBoxs1_Load(object sender, EventArgs e)
        {

        }

        private void metroTextButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void estadisticsBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
