using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ATX_POS
{
    public partial class PaymentVales : UserControl
    {
        public PaymentVales()
        {
            InitializeComponent();
        }

        private void Banks_Click(object sender, EventArgs e)
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

        private void Banks_Click_1(object sender, EventArgs e)
        {

        }

        private void PaymentVales_Load(object sender, EventArgs e)
        {

        }

        private void BankAccount_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void debittotal_KeyPress(object sender, KeyPressEventArgs e)
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

            if (Regex.IsMatch(debittotal.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }
        }
    }
}
