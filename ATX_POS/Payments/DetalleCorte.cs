using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ATX_POS
{
    public partial class DetalleCorte : UserControl
    {
        string credits = "";
        string debits = "";
        string billsuser = "";
        string coinsuser = "";
        public DetalleCorte()
        {
            InitializeComponent();
        }

        private void TotalBill_Click(object sender, EventArgs e)
        {

        }

        private void TotalCash_Click(object sender, EventArgs e)
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

            if (Regex.IsMatch(Coins.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }

        }

        private void Debits_KeyPress(object sender, KeyPressEventArgs e)
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

            if (Regex.IsMatch(Debits.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }
        }

        private void Credits_Enter(object sender, EventArgs e)
        {
            credits = Credits.Text.ToString();
            Credits.Text = "";
        }

        private void Credits_Validating(object sender, CancelEventArgs e)
        {
            if (Credits.Text.ToString() == "")
            {
                Credits.Text = credits;
            }
        }

        private void Debits_Enter(object sender, EventArgs e)
        {
            debits = Debits.Text.ToString();
            Debits.Text = "";
        }

        private void Debits_Validating(object sender, CancelEventArgs e)
        {
            if (Debits.Text.ToString() == "")
            {
                Debits.Text = debits;
            }
        }

        private void Bills_Enter(object sender, EventArgs e)
        {
            billsuser = Bills.Text.ToString();
            Bills.Text = "";
        }

        private void Bills_Validating(object sender, CancelEventArgs e)
        {
            if (Bills.Text.ToString() == "")
            {
                Bills.Text = billsuser;
            }
        }

        private void Bills_KeyPress(object sender, KeyPressEventArgs e)
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

            if (Regex.IsMatch(Bills.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }
        }
    }
}
