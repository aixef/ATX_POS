using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ATX_POS
{
    public partial class FirstLoginSesion : MetroFramework.Forms.MetroForm
    {
        int idcomment = 0;
        public FirstLoginSesion()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void GetTerminalDetail()
        {
            string datework = DateTime.Today.ToString("MM/dd/yyyy");
            string timework = DateTime.Today.ToString("HH:mm:ss");
            try
            {
                using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    //MetroFramework.MetroMessageBox.Show(this, "Bienviendo de Vuelta: " + UserLabel.Text, "Welcome Back", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.Parameters.Clear();
                    comando.CommandText = "Select TOP 1 COALESCE ([CashOnBox],0) " +
                    "from Casing where TerminalAsig = @Number and DateReg = @datework order by [TimeCasing] Desc";
                    comando.Connection = cn;
                    comando.Parameters.AddWithValue("@Number", TerminalLabel.Text.ToString());
                    comando.Parameters.AddWithValue("@datework", datework);
                    int count = Convert.ToInt32(comando.ExecuteScalar());

                    if (count > 0)
                    {
                        SqlDataAdapter sdacount = new SqlDataAdapter(comando);
                        DataTable sdacotb = new DataTable();
                        sdacount.Fill(sdacotb);
                        decimal lastcasing = 0M;
                        foreach (DataRow row in sdacotb.Rows)
                        {
                            lastcasing = decimal.Parse(row[0].ToString());
                        }

                        /*comando.ExecuteNonQuery();
                        DataSet ds2 = new DataSet();
                        SqlDataAdapter da2 = new SqlDataAdapter(comando);
                        da2.Fill(ds2, "Casing");
                        DataRow DR2;
                        DR2 = ds2.Tables["Casing"].Rows[0];*/

                        metroLabel5.Text = lastcasing.ToString("N2");
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "No hubo corte de caja anterior registrado o el usuario no dejo dinero en Caja", "No hubo fondo en caja registrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        metroLabel5.Text = "0.00";
                    }

                    cn.Close();
                }
            }
            catch (SqlException exsql)
            {
                MetroFramework.MetroMessageBox.Show(this, exsql.Message.ToString(), "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            bool opecorrect = false;
            decimal TotalSum = 0;
            decimal totalInCasing = 0;
            if (metroLabel5.Text != "")
            {
                TotalSum = Convert.ToDecimal(metroLabel5.Text);
            }
            if (metroLabel4.Text != "")
            {
                totalInCasing = Convert.ToDecimal(metroLabel4.Text.Remove(0, 1));
                if (TotalSum > totalInCasing)
                {
                    opecorrect = InsertcommentInit();

                }
                if (TotalSum < totalInCasing)
                {
                    opecorrect = InsertcommentInit();

                }
                if (TotalSum == totalInCasing)
                {
                    opecorrect = true;
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Primero calcule su total en Caja", "Falta calcular total", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (opecorrect)
            {
                InsertCountingUP();
                this.Close();
            }
        }

        private void InsertCountingUP()
        {
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                try
                {
                    cn.Open();
                    string datework = DateTime.Today.ToString("MM/dd/yyyy");
                    SqlCommand CashIn = new SqlCommand();
                    CashIn.Parameters.Clear();
                    CashIn.Connection = cn;
                    CashIn.CommandText = "Insert into CountingUp (Code,TotalCounting,DateCounting,Teriminal,IDreg,[IdComment]) " +
                                                                 "values(@CodeControl," +
                                                                 "@TotalCash," +
                                                                 "@Datework," +
                                                                 "(select Terminal from Terminals where Number=@Terminal)," +
                                                                 "(Select ID from dbo.[Users] where [Users].[User]=@User),@IdComment) " +
                                                                 "SELECT SCOPE_IDENTITY()";
                    CashIn.Parameters.AddWithValue("@User", UserLabel.Text.ToString());
                    CashIn.Parameters.AddWithValue("@Terminal", TerminalLabel.Text.ToString());
                    CashIn.Parameters.AddWithValue("@Datework", datework);
                    CashIn.Parameters.AddWithValue("@TotalCash", metroLabel4.Text.Remove(0, 1));
                    CashIn.Parameters.AddWithValue("@CodeControl", datework + UserLabel.Text.ToString() + TerminalLabel.Text.ToString());
                    CashIn.Parameters.AddWithValue("@IdComment", idcomment);
                    int CashID = Convert.ToInt32(CashIn.ExecuteScalar());
                    if (CashID > 0)
                    {
                        SqlCommand SesionControl = new SqlCommand();
                        SesionControl.Parameters.Clear();
                        SesionControl.Connection = cn;
                        SesionControl.CommandText = "Insert into LoginsControl (DateWork,Terminal,[User],InitCountingUp,[Cierreturno],[CierreCaja]) values (@Datework,@Terminal,@User,@InitCountingUp,@closeturn,@closebox)";
                        SesionControl.Parameters.AddWithValue("Datework", datework);
                        SesionControl.Parameters.AddWithValue("@Terminal", TerminalLabel.Text.ToString());
                        SesionControl.Parameters.AddWithValue("@User", UserLabel.Text.ToString());
                        SesionControl.Parameters.AddWithValue("@InitCountingUp", 1);
                        SesionControl.Parameters.AddWithValue("@closeturn", 0);
                        SesionControl.Parameters.AddWithValue("@closebox", 0);
                        SesionControl.ExecuteNonQuery();
                        SqlCommand updatecomment = new SqlCommand();
                        updatecomment.Parameters.Clear();
                        updatecomment.Connection = cn;
                        updatecomment.CommandText = "Update Comments set [IdCountingUp] = @IdCounting, [UserReg] = @User, [RegTerminal] = @Terminal where [IdComment] = @Idcomment";
                        updatecomment.Parameters.AddWithValue("@Idcomment", idcomment);
                        updatecomment.Parameters.AddWithValue("@IdCounting", CashID);
                        updatecomment.Parameters.AddWithValue("@User", UserLabel.Text.ToString());
                        updatecomment.Parameters.AddWithValue("@Terminal", TerminalLabel.Text.ToString());
                        updatecomment.ExecuteNonQuery();
                    }
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show(sqlex.ToString());
                }
                cn.Close();
            }
        }

        private bool InsertcommentInit()
        {
            bool ans = false;
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "El salo inicial de la caja no coincide con el total calculado" +
                                                                     System.Environment.NewLine + "Seleccione NO para verificar la cantidad en caja." +
                                                                     System.Environment.NewLine + "Seleccione Yes para crear una nota", "Los saldos no coinciden",
                                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Coments coments = new Coments();
                coments.countingup = true;
                DialogResult res = coments.ShowDialog();
                if (res == DialogResult.OK)
                {
                    idcomment = coments.idcomment;
                }
                ans = true;

            }
            if (result == DialogResult.No)
            {
                ans = false;
            }
            return ans;

        }
        public void getidcomment(int idcoment)
        {
            idcomment = idcoment;
        }

        private void metroLabel6_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            decimal totalInitCash;
            decimal totalInitCashBill;
            decimal totalInitCashCoin;
            decimal Bill1000 = (Convert.ToDecimal(detailCashCount1.textBox1.Text) * 1000);
            decimal Bill500 = (Convert.ToDecimal(detailCashCount1.textBox2.Text) * 500);
            decimal Bill200 = (Convert.ToDecimal(detailCashCount1.textBox3.Text) * 200);
            decimal Bill100 = (Convert.ToDecimal(detailCashCount1.textBox4.Text) * 100);
            decimal Bill50 = (Convert.ToDecimal(detailCashCount1.textBox5.Text) * 50);
            decimal Bill20 = (Convert.ToDecimal(detailCashCount1.textBox6.Text) * 20);
            totalInitCashBill = Bill1000 + Bill500 + Bill200 + Bill100 + Bill50 + Bill20;
            decimal coin100 = (Convert.ToDecimal(detailCashCount_21.textBox1.Text) * 100);
            decimal coin20 = (Convert.ToDecimal(detailCashCount_21.textBox3.Text) * 20);
            decimal coin10 = (Convert.ToDecimal(detailCashCount_21.textBox4.Text) * 10);
            decimal coin5 = (Convert.ToDecimal(detailCashCount_21.textBox5.Text) * 5);
            decimal coin2 = (Convert.ToDecimal(detailCashCount_21.textBox6.Text) * 2);
            decimal coin1 = (Convert.ToDecimal(detailCashCount_21.textBox7.Text) * 1);
            decimal coin05 = (Convert.ToDecimal(detailCashCount_21.textBox8.Text) * .5M);
            decimal coin02 = (Convert.ToDecimal(detailCashCount_21.textBox9.Text) * .2M);
            decimal coin01 = (Convert.ToDecimal(detailCashCount_21.textBox10.Text) * .1M);
            totalInitCashCoin = coin100 + coin20 + coin10 + coin5 + coin2 + coin1 + coin05 + coin02 + coin01;

            totalInitCash = totalInitCashBill + totalInitCashCoin;

            metroLabel4.Text = totalInitCash.ToString("$0.00");
        }
    }
}
