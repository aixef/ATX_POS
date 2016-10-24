using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;

namespace ATX_POS
{
    public partial class PaymenCash : UserControl
    {
        public decimal totalfromform;
        public bool mix = false;
        public PaymenCash()
        {
            InitializeComponent();
        }

        private void TotalRecived_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public void TotalRecived_TextChanged(object sender, EventArgs e)
        {

        }

        private void TotalRecived_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                TotalRemaining();
                return;
            }

            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }

            if (Regex.IsMatch(TotalRecived.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }
        }

        public void TotalRemaining()
        {
            //getnewtotal();
            //MessageBox.Show(totalfromform.ToString());
            if (mix == false)
            {
                var Totals = Convert.ToDecimal(totalfromform, CultureInfo.CreateSpecificCulture("en-US"));
                if (TotalRecived.Text.Length > 0)
                {

                    var PayTotal = Convert.ToDecimal(TotalRecived.Text.ToString(), CultureInfo.CreateSpecificCulture("en-US"));

                    var Remaining = decimal.Subtract(PayTotal, Totals);
                    Remainingtext.Text = Remaining.ToString("0.00");
                }
                else if (TotalRecived.Text.Length == 0)
                {
                    Remainingtext.Text = "";
                }
            }
            if (mix == true)
            {
                Remainingtext.Text = "";
            }

            
        }

        private void PaymenCash_Load(object sender, EventArgs e)
        {
            this.TotalRecived.Focus();
        }

        private void TotalRecived_Leave(object sender, EventArgs e)
        {
            TotalRemaining();
        }

        public void setnewtotal(decimal newtotal)
        {
            totalfromform = newtotal;
        }
        public void getnewtotal()
        {
            
        }
    }
}
