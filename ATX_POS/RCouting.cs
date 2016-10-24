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

namespace ATX_POS
{
    public partial class RCoutingFinalc : MetroFramework.Forms.MetroForm
    {
        public string user;
        public string terminal;
        int idcomment = 0;
        string datework = DateTime.Today.ToString("MM/dd/yyyy");
        decimal totalcreditsales = 0M;
        decimal totaldebitsales = 0M;
        decimal totalouts = 0M;
        decimal totaloutschange = 0M;
        decimal totalcashbox = 0M;
        decimal totalSystem = 0M;
        decimal salestotallingall = 0M;
        string cashinboxing = "";
        public RCoutingFinalc()
        {
            InitializeComponent();
            
        }

        private void RCouting_Load(object sender, EventArgs e)
        {

        }
        public void GetAllStatics()
        {
            getSales();
            getcreditsales();
            getdebitsales();
            getcashouts();
            getrealchas();
        }

        private void getrealchas()
        {
            decimal totalincashmoney = decimal.Parse(salesInDetail1.TotalMoney.Text.ToString());
            decimal totaloutscashchange = decimal.Parse(salesInDetail1.cashout.Text.ToString());
            decimal totalcountingupcash = decimal.Parse(detalleCorte1.Apertura.Text.ToString());

            decimal realmoneycashinbox = ((totalincashmoney + totalcountingupcash) - totaloutscashchange);
            salesInDetail1.TotalMoneyBox.Text = realmoneycashinbox.ToString();
        }

        private void getcashouts()
        {

            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                //Salidas cambio
                getcashsalesout(con);
                //Retiros de efectivo
                getadmincashout(con);
                decimal countingup = decimal.Parse(detalleCorte1.Apertura.Text.ToString());
                decimal TOTALEFECT = ((salestotallingall + countingup) - (totaloutschange + totalouts));
                detalleCorte1.efectivo.Text = TOTALEFECT.ToString();
                
                salesInDetail1.TotalMoney.Text = salestotallingall.ToString();
                salesInDetail1.cashout.Text = totaloutschange.ToString();
            }

        }

        private void getadmincashout(SqlConnection con)
        {
            con.Open();
            SqlCommand admincash = new SqlCommand();
            admincash.Parameters.Clear();
            admincash.Connection = con;
            admincash.CommandText = "select COALESCE (SUM([Total]),0) FROM CashOut where [Terminal] = (select Terminal from Terminals where Number = @Terminal) and [CasingAsigned]= (select ID from Users where [User] =@user) and [Date] = @Datework";
            admincash.Parameters.AddWithValue("@Terminal", terminal);
            admincash.Parameters.AddWithValue("@user", user);
            admincash.Parameters.AddWithValue("@Datework", datework);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(admincash);
                DataTable admincashtable = new DataTable();
                if (sda != null)
                {
                    sda.Fill(admincashtable);
                }
                foreach (DataRow row in admincashtable.Rows)
                {
                    totalouts = Decimal.Parse(row[0].ToString());
                }
            }
            catch (SqlException sqle)
            {
                MessageBox.Show(sqle.Message.ToString());

            }
            con.Close();
            salesInDetail1.totalManualOuts.Text = totalouts.ToString();
        }

        private void getcashsalesout(SqlConnection con)
        {
            con.Open();
            SqlCommand cashsalesout = new SqlCommand();
            cashsalesout.Parameters.Clear();
            cashsalesout.Connection = con;
            cashsalesout.CommandText = "select COALESCE (SUM([ChangeCash]),0) FROM PaymentsDetail where [terminalUse] = @Terminal and [UserName]= @user and [DateReg] = @Datework";
            cashsalesout.Parameters.AddWithValue("@Terminal", terminal);
            cashsalesout.Parameters.AddWithValue("@user", user);
            cashsalesout.Parameters.AddWithValue("@Datework", datework);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cashsalesout);
                DataTable cashsalestable = new DataTable();
                if (sda != null)
                {
                    sda.Fill(cashsalestable);
                }
                foreach (DataRow row in cashsalestable.Rows)
                {
                    totaloutschange = Decimal.Parse(row[0].ToString());
                    
                }
            }
            catch (SqlException sqle)
            {
                MessageBox.Show(sqle.Message.ToString());

            }
            con.Close();
        }

        private void getdebitsales()
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand getcreditsales = new SqlCommand();
                getcreditsales.Parameters.Clear();
                getcreditsales.Connection = con;
                getcreditsales.CommandText = "select COALESCE (SUM([Total]),0) from CardsDetail where [NumTerm] = @Terminal and [UserReg] =@user and [DateReg]=@datework and ([Debit] = @debit OR [Vales] = @Vales)";
                getcreditsales.Parameters.AddWithValue("@Terminal", terminal);
                getcreditsales.Parameters.AddWithValue("@user", user);
                getcreditsales.Parameters.AddWithValue("@datework", datework);
                getcreditsales.Parameters.AddWithValue("@Vales", true);
                getcreditsales.Parameters.AddWithValue("@debit",true);
                SqlDataAdapter sda = new SqlDataAdapter(getcreditsales);
                DataTable creditsalestable = new DataTable();

                if (sda != null)
                {
                    sda.Fill(creditsalestable);
                }
                foreach (DataRow row in creditsalestable.Rows)
                {
                    totaldebitsales = Decimal.Parse(row[0].ToString());
                }
                detalleCorte1.Debits.Text = totaldebitsales.ToString();
                salesInDetail1.TotalVales.Text = totaldebitsales.ToString();
                con.Close();
            }
        }

        private void getcreditsales()
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand getcreditsales = new SqlCommand();
                getcreditsales.Parameters.Clear();
                getcreditsales.Connection = con;
                getcreditsales.CommandText = "select COALESCE (SUM([Total]),0) from CardsDetail where [NumTerm] = @Terminal and [UserReg] =@user and [DateReg]=@datework and [Credit] = @credit";
                getcreditsales.Parameters.AddWithValue("@Terminal", terminal);
                getcreditsales.Parameters.AddWithValue("@user", user);
                getcreditsales.Parameters.AddWithValue("@datework", datework);
                getcreditsales.Parameters.AddWithValue("@credit",true);
                SqlDataAdapter sda = new SqlDataAdapter(getcreditsales);
                DataTable creditsalestable = new DataTable();

                if (sda != null)
                {
                    sda.Fill(creditsalestable);
                }
                foreach (DataRow row in creditsalestable.Rows)
                {
                    totalcreditsales = Decimal.Parse(row[0].ToString());
                }
                detalleCorte1.Credits.Text = totalcreditsales.ToString();
                salesInDetail1.TotalTransfe.Text = totalcreditsales.ToString();

                con.Close();
            }
        }

        private void getSales()
        {
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                string datework = DateTime.Today.ToString("MM/dd/yyyy");
                cn.Open();
                //Efectivo.
                SqlCommand SalesbyUser = new SqlCommand();
                SalesbyUser.Parameters.Clear();
                SalesbyUser.Connection = cn;
                //La función COALESCE recibe varios argumentos y retorna la primer expresión distinta de nulo de la lista de dichos argumentos, en este caso asigna 0 a todo los elementos NULL
                SalesbyUser.CommandText = "Select COALESCE (SUM(CashMont),0) as TOTAL from PaymentsDetail where PaymentsDetail.[UserName] =@User and "
                                         + "PaymentsDetail.[DateReg]=@DateWork";

                SalesbyUser.Parameters.AddWithValue("@User", user);
                SalesbyUser.Parameters.AddWithValue("@DateWork", datework);
                SalesbyUser.ExecuteNonQuery();
                SqlDataReader sdr = SalesbyUser.ExecuteReader();
                //SqlException.E();
                try
                {
                    while (sdr.Read())
                    {
                        salestotallingall = decimal.Parse(sdr["TOTAL"].ToString());
                        /*detalleCorte1.efectivo.Text = sdr["TOTAL"].ToString();
                        salesInDetail1.TotalMoney.Text = sdr["TOTAL"].ToString();*/
                    }

                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message.ToString());
                }
                //Credito
                sdr.Close();
                SalesbyUser.Parameters.Clear();
                SalesbyUser.Connection = cn;
                //La función COALESCE recibe varios argumentos y retorna la primer expresión distinta de nulo de la lista de dichos argumentos, en este caso asigna 0 a todo los elementos NULL
                SalesbyUser.CommandText = "Select COALESCE (SUM(CreditMont),0) as TOTAL from PaymentsDetail where PaymentsDetail.[UserName] =@User and "
                                         + "PaymentsDetail.[DateReg]=@DateWork";
                SalesbyUser.Parameters.AddWithValue("@User", user);
                SalesbyUser.Parameters.AddWithValue("@DateWork", datework);
                SalesbyUser.ExecuteNonQuery();
                SqlDataReader sdcr = SalesbyUser.ExecuteReader();
                //SqlException.E();
                try
                {
                    while (sdcr.Read())
                    {
                        //detalleCorte1.efectivo.Text = sdcr["TOTAL"].ToString();
                        salesInDetail1.TotalTransfe.Text = sdcr["TOTAL"].ToString();
                    }

                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message.ToString());
                }
                //Debit
                sdcr.Close();
                SalesbyUser.Parameters.Clear();
                SalesbyUser.Connection = cn;
                //La función COALESCE recibe varios argumentos y retorna la primer expresión distinta de nulo de la lista de dichos argumentos, en este caso asigna 0 a todo los elementos NULL
                SalesbyUser.CommandText = "Select COALESCE (SUM(DebitMont),0) as TOTAL from PaymentsDetail where PaymentsDetail.[UserName] =@User and "
                                         + "PaymentsDetail.[DateReg]=@DateWork";
                SalesbyUser.Parameters.AddWithValue("@User", user);
                SalesbyUser.Parameters.AddWithValue("@DateWork", datework);
                SalesbyUser.ExecuteNonQuery();
                SqlDataReader sdrd = SalesbyUser.ExecuteReader();
                //SqlException.E();
                try
                {
                    while (sdrd.Read())
                    {
                        //detalleCorte1.efectivo.Text = sdrd["TOTAL"].ToString();
                        salesInDetail1.TotalVales.Text = sdrd["TOTAL"].ToString();
                    }

                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message.ToString());
                }
                //Fondo Caja
                sdrd.Close();
                SalesbyUser.Parameters.Clear();
                SalesbyUser.Connection = cn;
                //La función COALESCE recibe varios argumentos y retorna la primer expresión distinta de nulo de la lista de dichos argumentos, en este caso asigna 0 a todo los elementos NULL
                SalesbyUser.CommandText = "Select COALESCE (SUM(TotalCounting),0) as TOTAL from CountingUp where DateCounting = @Datework and " +
                                        "Teriminal = (Select Terminal from Terminals where Number=@NumeroTerminal) and "
                                         + "IDreg=(Select ID from Users where [User]=@UserTerminal)";
                SalesbyUser.Parameters.AddWithValue("@UserTerminal", user);
                SalesbyUser.Parameters.AddWithValue("@DateWork", datework);
                SalesbyUser.Parameters.AddWithValue("@NumeroTerminal", terminal);
                SalesbyUser.ExecuteNonQuery();
                SqlDataReader sdi = SalesbyUser.ExecuteReader();
                //SqlException.E();
                try
                {
                    while (sdi.Read())
                    {
                        //detalleCorte1.efectivo.Text = sdrd["TOTAL"].ToString();
                        detalleCorte1.Apertura.Text = sdi["TOTAL"].ToString();
                    }

                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message.ToString());
                }

                //TotalVentas
                var totalvales = Convert.ToDecimal(salesInDetail1.TotalVales.Text.ToString());
                var totalCredit = Convert.ToDecimal(salesInDetail1.TotalTransfe.Text.ToString());
                var totalCash = Convert.ToDecimal(salesInDetail1.TotalMoney.Text.ToString());
                var Sumtotal = totalCash + totalCredit + totalvales;
                using (SqlConnection conn = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    conn.Open();
                    SqlCommand SalesbyUserTerm = new SqlCommand();
                    SalesbyUserTerm.Parameters.Clear();
                    SalesbyUserTerm.Connection = conn;
                    //La función COALESCE recibe varios argumentos y retorna la primer expresión distinta de nulo de la lista de dichos argumentos, en este caso asigna 0 a todo los elementos NULL
                    SalesbyUserTerm.CommandText = "Select COALESCE (SUM(SalesTotal),0) as TOTAL from Sales where Sales.[User] =(select id from dbo.[Users] where Users.[User] =@UserContingUp) and Sales.[Date]=@datework";
                    SalesbyUserTerm.Parameters.AddWithValue("@UserContingUp", user);
                    SalesbyUserTerm.Parameters.AddWithValue("@datework", datework);
                    SalesbyUserTerm.ExecuteNonQuery();
                    SqlDataReader sdra = SalesbyUserTerm.ExecuteReader();
                    //SqlException.E();
                    try
                    {
                        while (sdra.Read())
                        {
                            salesInDetail1.TotalCash.Text = sdra["TOTAL"].ToString();
                        }

                    }
                    catch (SqlException se)
                    {
                        MessageBox.Show(se.Message.ToString());
                    }

                    conn.Close();
                }
                //salesInDetail1.TotalCash.Text = Sumtotal.ToString("0.00");
                cn.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
            if (Regex.IsMatch(cashuserbox.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }
        }

        private void metroTextButton1_Click(object sender, EventArgs e)
        {
            bool correct = false;
            
            var totalUser = GetTotal();
            totalSystem = GetTotalSystem();

            if (totalUser != totalSystem)
            {
                var diferencecash = totalUser - totalSystem;
                MetroFramework.MetroMessageBox.Show(this, "Existe una difirencia de: "+ diferencecash.ToString() + " en los saldos", "Saldos Diferentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DialogResult response = MetroFramework.MetroMessageBox.Show(this, "Una vez cerrado el turno este usuario no podra iniciar nuevamente sesion durante este dia, salvo registrar el corte de caja, ¿Esta seguro de que desea registrar su corte de turno?", "Cierre de turno", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (response == DialogResult.OK)
            {
                
                if (totalUser > 0)
                {
                    if (totalUser != totalSystem)
                    {
                        DialogResult saldobilletesuser = MetroFramework.MetroMessageBox.Show(this, "El saldo total introducido por el usuario: " +totalUser.ToString() + " no coinciden con el calculado por el sistema: "+ totalSystem.ToString()+ ", ¿Esta seguro de registrar corte de turno?", "Cierre de turno", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        if (saldobilletesuser == DialogResult.OK)
                        {
                            Coments comen = new Coments();
                            comen.commentfrom = "CutDay";
                            comen.daycut = true;
                            DialogResult res = comen.ShowDialog(this);
                            if (res == DialogResult.OK)
                            {
                                idcomment = comen.idcomment;

                            }
                            correct = InsertCasing();
                            this.Close();
                        }
                        else
                        {
                            this.Close();
                        }
                       
                    }
                    else
                    {
                        correct = InsertCasing();
                        this.Close();
                    }
                    if (correct)
                        closeturn();
                }
            }
        }

        private void closeturn()
        {
            using (SqlConnection cone = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                SqlCommand updatecontrolsesion = new SqlCommand();
                updatecontrolsesion.Parameters.Clear();
                cone.Open();
                updatecontrolsesion.Connection = cone;
                updatecontrolsesion.CommandText = "Update LoginsControl set [Cierreturno] = @cierre where [DateWork] = @datework and [User]= @user";
                updatecontrolsesion.Parameters.AddWithValue("@datework", datework);
                updatecontrolsesion.Parameters.AddWithValue("@user",user);
                updatecontrolsesion.Parameters.AddWithValue("@cierre",true);
                updatecontrolsesion.ExecuteNonQuery();
                DialogResult re = MetroFramework.MetroMessageBox.Show(this, "El cierre de turno se ha registrado correctamente, la aplicación se cerrara a continuación", "Cierre de turno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (re == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private bool InsertCasing()
        {
            bool correct = false;
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                string datework = DateTime.Today.ToString("MM/dd/yyyy");
                cn.Open();
                //Efectivo.
                SqlCommand InsertCasing = new SqlCommand();
                InsertCasing.Parameters.Clear();
                InsertCasing.Connection = cn;
                InsertCasing.CommandText = "Insert into Casing ([InitCash],[FinishCash],[DateReg],[UserReg],[TerminalAsig],[BillTotals],[TotalCredit],[TotalDebit],[TimeCasing],[FinishCashTurn],[Idreg],[CashOnBox]) " +
                    "values (@InitCash,@FinishCash,@Datework,@UserReg,@Terminal,@BillsTotal,@TotalCredit,@TotalDebit,@TimeCasing,@FinishCashturn,(select [ID] from Users where [User] = @UserReg),@cashOnbox) SELECT SCOPE_IDENTITY()";

                InsertCasing.Parameters.AddWithValue("@InitCash", detalleCorte1.Apertura.Text.ToString());
                //saldo final en caja
                InsertCasing.Parameters.AddWithValue("@FinishCash", totalSystem);
                InsertCasing.Parameters.AddWithValue("@Datework", datework);
                InsertCasing.Parameters.AddWithValue("@UserReg", user);
                InsertCasing.Parameters.AddWithValue("@Terminal", terminal);
                InsertCasing.Parameters.AddWithValue("@BillsTotal", detalleCorte1.Bills.Text.ToString());
                InsertCasing.Parameters.AddWithValue("@TotalCredit", detalleCorte1.Credits.Text.ToString());
                InsertCasing.Parameters.AddWithValue("@TotalDebit", detalleCorte1.Debits.Text.ToString());
                string hour = DateTime.Now.ToString("HH:mm:ss");
                InsertCasing.Parameters.AddWithValue("@TimeCasing", hour);
                GetTotalCashturn();
                InsertCasing.Parameters.AddWithValue("@FinishCashturn", totalcashbox);
                InsertCasing.Parameters.AddWithValue("@cashOnbox", cashuserbox.Text.ToString());
                

                int idcorte = Convert.ToInt32(InsertCasing.ExecuteScalar());
                correct = true;
                if (idcorte > 0)
                {
                    SqlCommand insertcontroluser = new SqlCommand();
                    insertcontroluser.Parameters.Clear();
                    insertcontroluser.Connection = cn;
                    insertcontroluser.CommandText = "";
                    insertcontroluser.Parameters.AddWithValue("","");
                }

                cn.Close();
            }
            return correct;

        }

        private void GetTotalCashturn()
        {
            var apertura = decimal.Parse(detalleCorte1.Apertura.Text.ToString());
            var efectivo = decimal.Parse(detalleCorte1.efectivo.Text.ToString());
            var totaltransfe = decimal.Parse(salesInDetail1.TotalTransfe.Text.ToString());
            var totalvales = decimal.Parse(salesInDetail1.TotalVales.Text.ToString());
            var totalcashouit = decimal.Parse(salesInDetail1.cashout.Text.ToString()) ;
            totalcashbox = ((apertura+efectivo+totaltransfe+totalvales)-totalcashouit);
        }

        private decimal GetTotalSystem()
        {
            
            decimal totalsystem = 0M;
            var totalinit = Convert.ToDecimal(detalleCorte1.Apertura.Text.ToString());
            var totalcoinsSystem = Convert.ToDecimal(salesInDetail1.TotalMoney.Text.ToString());
            var totalCreditSystem = Convert.ToDecimal(salesInDetail1.TotalTransfe.Text.ToString());
            var totalvalesSystem = Convert.ToDecimal(salesInDetail1.TotalVales.Text.ToString());
            var totalChangeSales = Convert.ToDecimal(salesInDetail1.cashout.Text.ToString());
            var totalcashoutssystem = Convert.ToDecimal(salesInDetail1.totalManualOuts.Text.ToString());
            decimal totalsalessystemposted = decimal.Parse(salesInDetail1.TotalCash.Text.ToString());
            ///totalsystem = (totalinit + totalcoinsSystem + totalCreditSystem + totalvalesSystem) - (totalChangeSales + totalcashoutssystem);
            totalsystem = totalinit + totalsalessystemposted;
            return totalsystem;
        }

        private decimal GetTotal()
        {
            bool checkvaluesuser = checkvaluser();
            decimal totalbyUser = -1M;
            if (checkvaluesuser)
            {

                var totalinit = Convert.ToDecimal(detalleCorte1.Apertura.Text.ToString());
                var totalbill = Convert.ToDecimal(detalleCorte1.Bills.Text.ToString());
                var totalcoins = Convert.ToDecimal(detalleCorte1.Coins.Text.ToString());
                var totalCredit = Convert.ToDecimal(detalleCorte1.Credits.Text.ToString());
                var totaldebir = Convert.ToDecimal(detalleCorte1.Debits.Text.ToString());
                totalbyUser = totalbill + totalcoins + totalCredit + totaldebir;
            }
            return totalbyUser;
        }

        private bool checkvaluser()
        {
            bool correct = true;
            if (detalleCorte1.Bills.Text.ToString() == "")
            {
                correct = false;
                MetroFramework.MetroMessageBox.Show(this, "El total en billetes no puede ser vacio", "Total Billetes Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (detalleCorte1.Coins.Text.ToString() == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "El total en monedas no puede ser vacio", "Total Monedas Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                correct = false;
            }
            if (cashuserbox.Text.ToString() == "")
            {
                correct = false;
                MetroFramework.MetroMessageBox.Show(this, "El Fonde en caja no puede ser vacio", "Total Fondos Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return correct;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            cashinboxing = cashuserbox.Text.ToString();
            cashuserbox.Text = "";
        }

        private void cashuserbox_Validating(object sender, CancelEventArgs e)
        {
            if (cashuserbox.Text == "")
            {
                cashuserbox.Text = cashinboxing;
            }
        }

        private void detalleCorte1_Load(object sender, EventArgs e)
        {

        }
    }
}
