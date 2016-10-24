using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;

namespace ATX_POS
{
    using ListBranchNAV;
    using DataBranchNAV;
    public partial class SyncSucursal : MetroFramework.Forms.MetroForm
    {
        public SyncSucursal()
        {
            InitializeComponent();
        }

        private void SyncSucursal_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (SucNames.Text != "")
            {
                UpdateSucData(SucNames.Text.ToString());
                metroButton1.DialogResult = DialogResult.OK;
                this.Close();
               
            }
            else 
            {
                MetroFramework.MetroMessageBox.Show(this, "El Código Almacen no puede ser vacío", "Código Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void UpdateSucData(string sucCode)
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand UpdateSucs = new SqlCommand();
                UpdateSucs.Parameters.Clear();
                UpdateSucs.Connection = con;
                UpdateSucs.CommandText = ("Select TOP 1 [CodeStore] from StoresDetail where [No] <> 0");
                string Exist = UpdateSucs.ExecuteScalar().ToString();
                if (Exist == null)
                {
                    UpdateSucs.Parameters.Clear();
                    UpdateSucs.CommandText = "insert into StoresDetail([CodeStore],[NameStore],[ManagerID],[Location],[Tel],[email],[statemex],[city]) values(@CodeStore, @NameStore, @ManageId, @Address, @Phone,@email,@state,@City)";
                    //@CodeStore, @NameStore, @ManageId, @Address, @Phone,@email,@state,@City
                    UpdateSucs.Parameters.AddWithValue("@CodeStore",sucCode);
                    UpdateSucs.Parameters.AddWithValue("@NameStore", NameSuc.Text.ToString());
                    UpdateSucs.Parameters.AddWithValue("@Address", AdressSuc.Text.ToString());
                    UpdateSucs.Parameters.AddWithValue("@Phone", PhoneSuc.Text.ToString());
                    UpdateSucs.Parameters.AddWithValue("@email", EmailSuc.Text.ToString());
                    UpdateSucs.Parameters.AddWithValue("@state", StateSuc.Text.ToString());
                    UpdateSucs.Parameters.AddWithValue("@City", CitySuc.Text.ToString());
                    UpdateSucs.Parameters.AddWithValue("@ManageId",1);
                    UpdateSucs.ExecuteNonQuery();
                }
                else if (Exist != null)
                {
                    DialogResult result;
                    result = MessageBox.Show("¿Desea Actualizar los datos de la Sucursal?", "Actulizar datos Sucursal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        UpdateSucs.CommandText = "Update StoresDetail set [CodeStore] = @CodeStore, [NameStore] = @NameStore, [Location] = @Address, [Tel] = @Phone, [email] = @email, [statemex] = @state, [city] = @City where [no] <> 0";
                        UpdateSucs.Parameters.AddWithValue("@CodeStore", sucCode);
                        UpdateSucs.Parameters.AddWithValue("@NameStore", NameSuc.Text.ToString());
                        UpdateSucs.Parameters.AddWithValue("@Address", AdressSuc.Text.ToString());
                        UpdateSucs.Parameters.AddWithValue("@Phone", PhoneSuc.Text.ToString());
                        UpdateSucs.Parameters.AddWithValue("@email", EmailSuc.Text.ToString());
                        UpdateSucs.Parameters.AddWithValue("@state", StateSuc.Text.ToString());
                        UpdateSucs.Parameters.AddWithValue("@City", CitySuc.Text.ToString());
                        UpdateSucs.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
        }

        private void metroComboBox1_Click(object sender, EventArgs e)
        {
            if (SucNames.Items.Count == 0)
            {
                GetCodeSucs();
            }
        }

        private void GetCodeSucs()
        {
            ListBranchNAV.ListBranch_Service ListBranchSer = new ListBranch_Service();
            string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
            string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
            var networkcre = new NetworkCredential(userconfigsfile, passconfigsfile);
            ListBranchSer.Credentials = networkcre;
            List<ListBranch_Filter> BranchsFilterArray = new List<ListBranch_Filter>();
            ListBranch[] list = ListBranchSer.ReadMultiple(BranchsFilterArray.ToArray(), null, 100);
            foreach (ListBranch LB in list)
            {
                GetListSBranchFromNav(LB);
            }
            if (SucNames.Items.Count < 1)
            {
                MessageBox.Show("No hay Almacenes Configurados");
            }
        }

        private void GetListSBranchFromNav(ListBranch LB)
        {
            SucNames.Items.Add(LB.Code.ToString());
        }

        private void SucNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codeSuc = SucNames.SelectedItem.ToString();
            getdatasuc(codeSuc);
        }

        private void getdatasuc(string codeSuc)
        {
            DataBranchNAV.DataBranch_Service databranchser = new DataBranch_Service();
            DataBranch_Filter branchfilter = new DataBranch_Filter();
            List<DataBranchNAV.DataBranch_Filter> DatabranchFilterArray = new List<DataBranch_Filter>();
            string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
            string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
            var networkcre = new NetworkCredential(userconfigsfile, passconfigsfile);
            databranchser.Credentials = networkcre;
            branchfilter.Field = DataBranchNAV.DataBranch_Fields.Code;
            branchfilter.Criteria = codeSuc;
            DatabranchFilterArray.Add(branchfilter);
            DataBranchNAV.DataBranch[] listdatabranc = databranchser.ReadMultiple(DatabranchFilterArray.ToArray(), null, 10);
            foreach (DataBranch DBh in listdatabranc)
            {
                GetDetailSuc(DBh);
            }
        }

        private void GetDetailSuc(DataBranch DBh)
        {
            try
            {
                NameSuc.Text = DBh.Name.ToString();
                PhoneSuc.Text = DBh.Phone_No.ToString();
                EmailSuc.Text = DBh.E_Mail.ToString();
                AdressSuc.Text = (DBh.Address.ToString() + " " + DBh.Address_2.ToString());
                StateSuc.Text = DBh.County.ToString();
                CitySuc.Text = DBh.City.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
