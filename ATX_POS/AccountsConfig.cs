using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ATX_POS
{
    using GeneralJounsNAV;
    using AccountsFromNav;
    //using BatchsNameFromNav;
    public partial class AccountsConfig : MetroFramework.Forms.MetroForm
    {
        public AccountsConfig()
        {
            InitializeComponent();
        }

        private void AccountsConfig_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        

        private void comboBox1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count <= 0)
            {
                GeneralJounsNAV.GeneralJourns_Service JournalSessionsService = new GeneralJourns_Service();
                string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
                string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
                var networkcre = new NetworkCredential(userconfigsfile, passconfigsfile);
                //PriceForItems.PriceItems_Filter ItemsFilter = new PriceForItems.PriceItems_Filter();
                GeneralJounsNAV.GeneralJourns_Filter GeneralNamesFilter = new GeneralJourns_Filter();
                GeneralNamesFilter.Field = GeneralJounsNAV.GeneralJourns_Fields.Name;
                //GeneralNamesFilter.Criteria = "''";
                JournalSessionsService.Credentials = networkcre;
                List<GeneralJourns_Filter> BranchsFilterArray = new List<GeneralJourns_Filter>();
                BranchsFilterArray.Add(GeneralNamesFilter);
                GeneralJounsNAV.GeneralJourns[] list = JournalSessionsService.ReadMultiple(BranchsFilterArray.ToArray(), null, 1000);
                foreach (GeneralJourns GJ in list)
                {
                    GetsectionJournal(GJ);
                }
                if (comboBox1.Items.Count < 1)
                {
                    MessageBox.Show("No hay Secciones Configuradas");
                }
            }
        }
        private void GetsectionJournal(GeneralJourns GJ)
        {
            comboBox1.Items.Add(GJ.Description.ToString());
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count <= 0)
            {
                AccountsFromNav.CatalogoCuentasNav_Service ServiceAccounts = new CatalogoCuentasNav_Service();
                string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
                string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
                var networkcre = new NetworkCredential(userconfigsfile, passconfigsfile);
                AccountsFromNav.CatalogoCuentasNav_Filter AccountsFilter = new CatalogoCuentasNav_Filter();
                ServiceAccounts.Credentials = networkcre;
                List<CatalogoCuentasNav_Filter> AccountsFilterArray = new List<CatalogoCuentasNav_Filter>();
                AccountsFilterArray.Add(AccountsFilter);
                CatalogoCuentasNav[] list = ServiceAccounts.ReadMultiple(AccountsFilterArray.ToArray(), null, 1000);
                foreach (CatalogoCuentasNav AcN in list)
                {
                    AddAccounts(AcN);
                }

                if (AccountsList.Items.Count < 1)
                {
                    MessageBox.Show("No hay Cuentas Configuradas para usar en el POS");
                }
            }
        }

        private void AddAccounts(CatalogoCuentasNav AcN)
        {
            comboBox1.Items.Add(AcN.No.ToString());

        }

        private void AccountsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccountsFromNav.CatalogoCuentasNav_Service ServiceAccounts = new CatalogoCuentasNav_Service();
            string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
            string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
            var networkcre = new NetworkCredential(userconfigsfile, passconfigsfile);
            AccountsFromNav.CatalogoCuentasNav_Filter AccountsFilter = new CatalogoCuentasNav_Filter();
            ServiceAccounts.Credentials = networkcre;
            List<CatalogoCuentasNav_Filter> AccountsFilterArray = new List<CatalogoCuentasNav_Filter>();
            AccountsFilter.Field = CatalogoCuentasNav_Fields.No;
            AccountsFilter.Criteria = AccountsList.SelectedItem.ToString();
            AccountsFilterArray.Add(AccountsFilter);
            CatalogoCuentasNav[] list = ServiceAccounts.ReadMultiple(AccountsFilterArray.ToArray(), null, 1000);
            foreach (CatalogoCuentasNav AcN in list)
            {
                AddAccounts(AcN);
            }

        }
    }
}
