using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATX_POS
{
    public partial class PaymentCredit : UserControl
    {
        public PaymentCredit()
        {
            InitializeComponent();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            if (Banks.Items.Count <= 0)
            {
                DataTable dt = new DataTable();
                using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    cn.Open();
                    SqlCommand UserList = new SqlCommand();
                    UserList.Parameters.Clear();
                    UserList.Connection = cn;
                    UserList.CommandText = "Select Name from BankSAT";
                    UserList.ExecuteNonQuery();

                    SqlDataReader sdr = UserList.ExecuteReader();
                    try
                    {
                        while (sdr.Read())
                        {
                            Banks.Items.Add(sdr["Name"].ToString());
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

        private void metroLabel4_Click(object sender, EventArgs e)
        {

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

            if (Regex.IsMatch(Credit.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }
        }

        private void BankAccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void BankAccount_Leave(object sender, EventArgs e)
        {

        }

        private void BankAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57))
            {
                e.Handled = true;
                return;
            }
        }

        private void comision_KeyPress(object sender, KeyPressEventArgs e)
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

            /*if (Regex.IsMatch(comision.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }*/
        }

        private void AutCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
