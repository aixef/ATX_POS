using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATX_POS
{
    public partial class 
        SalesInDetail : UserControl
    {
        public SalesInDetail()
        {
            InitializeComponent();
        }

        private void TotalCash_Enter(object sender, EventArgs e)
        {
            TotalCash.Text = "";
        }

        private void TotalMoney_Enter(object sender, EventArgs e)
        {
            TotalMoney.Text = "";
        }

        private void TotalTransfe_Enter(object sender, EventArgs e)
        {
            TotalTransfe.Text = "";
        }

        private void TotalVales_Enter(object sender, EventArgs e)
        {
            TotalVales.Text = "";
        }

        private void TotalOtros_Enter(object sender, EventArgs e)
        {

        }

        private void TotalCash_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0.00";
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.AutoPopDelay = 3000;
            toolTip1.InitialDelay = 3000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.totalManualOuts, "Cantidad Real Calculada por el sistema");
        }

        private void SalesInDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
