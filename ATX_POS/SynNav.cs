using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using MetroFramework.Forms;
using System.Net;

//  using ATX_POS.Service_NAV;
//using ATX_POS.WS_NAV

namespace ATX_POS
{
    using PriceForItems;
    using CatalogoBancos;
    using MesureCodesFromNav;
    using ItemsListNAV;
    using DataCompanyNAV;
    using DataBranchNAV;

    class SynNav
    {
        
        string DateWork = DateTime.Today.ToString("MM/dd/yyyy");
        public void PrintBancos(ProgressBar bar, Form Princi)
        {
            CatalogoBancos.BancosSAT_Service services = new BancosSAT_Service();
            List<CatalogoBancos.BancosSAT_Filter> filter = new List<BancosSAT_Filter>();
            //services.UseDefaultCredentials = true;
            string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
            string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
            var networkcre = new NetworkCredential(userconfigsfile, passconfigsfile);
            services.Credentials = networkcre;
            CatalogoBancos.BancosSAT[] list = services.ReadMultiple(filter.ToArray(), null, 1000);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bancos");
            bar.Value = 0;
            bar.Minimum = 0;
            bar.Maximum = Convert.ToInt32(list.Length.ToString());
            bar.Step = 1;

            foreach (BancosSAT BS in list)
            {
                InsertBanksSQL(BS, Princi);
                bar.PerformStep();
            }
            /*Ban.Credentials = Creden;

            ServicesSat.BancosSAT banks = new ServicesSat.BancosSAT();
            List<ServicesSat.BancosSAT_Filter> filterArray = new List<ServicesSat.BancosSAT_Filter>();
            ServicesSat.BancosSAT_Filter nameFilter = new ServicesSat.BancosSAT_Filter();
            nameFilter.Field = ServicesSat.BancosSAT_Fields.Name;
            nameFilter.Criteria = "*";
            filterArray.Add(nameFilter);
            filterArray.ToArray();

            ServicesSat.BancosSAT[] ListaBancos = BANCOS.ReadMultiple(filterArray,null,1);
            //banks[] list = BankSat.ReadMultiple(filter.ToArray(), null, 100);*/
            // return sb.ToString();

        }

        private void InsertBanksSQL(BancosSAT BS, Form Prin)
        {

            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Parameters.Clear();
                command.Connection = con;

                command.CommandText = ("Select Codebank from BankSAT where Codebank = @CodeBankNav");
                command.Parameters.AddWithValue("@CodeBankNav", BS.Code.ToString());
                int Exist = Convert.ToInt32(command.ExecuteScalar());
                if (Exist == 0)
                {
                    command.Parameters.Clear();
                    command.CommandText = ("Insert into BankSAT(Name,CodeBank,DatePosted) values(@NameBankNav, @CodeBankSATNav,@DatePosted)");
                    command.Parameters.AddWithValue("@CodeBankSATNav", BS.Code.ToString());
                    command.Parameters.AddWithValue("@DatePosted", DateWork);
                    command.Parameters.AddWithValue("@NameBankNav", BS.Name.ToString());
                    command.ExecuteScalar();
                }
                else if (Exist != 0)
                {
                    DialogResult result;
                    result = MessageBox.Show("El Registro ya existe en la base"
                                                                + System.Environment.NewLine
                                                                + "¿Desea Actualizarlo?", "Registro Duplicado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        command.Parameters.Clear();
                        command.CommandText = ("UPDATE BankSAT set Name = @NameBankNav, CodeBank = @CodeBankSATNav, LastModify = @DateModify where CodeBank = @CodeBankSATNav");
                        command.Parameters.AddWithValue("@CodeBankSATNav", BS.Code.ToString());
                        command.Parameters.AddWithValue("@DateModify", DateWork);
                        command.Parameters.AddWithValue("@NameBankNav", BS.Name.ToString());
                        command.ExecuteScalar();
                    }
                }
                con.Close();
            }

        }

        static string GetBank(BancosSAT BS)
        {
            return "Nombre Banco: " + BS.Name;
        }
    }


    class SynPrices
    {
        string DateWork = DateTime.Today.ToString("MM/dd/yyyy");
        bool remplaceall = false;
        bool continueprocess = true;
        bool yesone = false;
        bool noall = false;

        public void items(ProgressBar BarItems)
        {
            PriceForItems.PriceItems_Service ItemsPricesNav = new PriceForItems.PriceItems_Service();
            PriceForItems.PriceItems_Filter ItemsFilter = new PriceForItems.PriceItems_Filter();
            string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
            string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
            var networkcre = new NetworkCredential(userconfigsfile, passconfigsfile);
            ItemsPricesNav.Credentials = networkcre;
            //ItemsPricesNav.UseDefaultCredentials = true;
            List<PriceForItems.PriceItems_Filter> FilterItemsArray = new List<PriceForItems.PriceItems_Filter>();
            ItemsFilter.Field = PriceForItems.PriceItems_Fields.Bar_Code;
            ItemsFilter.Criteria = "=''";
            FilterItemsArray.Add(ItemsFilter);
            ItemsFilter.Field = PriceForItems.PriceItems_Fields.Sales_Type;
            ItemsFilter.Criteria = PriceForItems.Sales_Type.All_Customers.ToString();
            FilterItemsArray.Add(ItemsFilter);

            //ItemsFilter.Field = 
            //
            PriceForItems.PriceItems[] ListItems = ItemsPricesNav.ReadMultiple(FilterItemsArray.ToArray(), null, 10000);
            BarItems.Value = 0;
            BarItems.Minimum = 0;
            BarItems.Maximum = Convert.ToInt32(ListItems.Length.ToString());
            BarItems.Step = 1;

            foreach (PriceItems PI in ListItems)
            {
               bool cancel = InsertItemPrice(PI);
               if (cancel == false)
               {
                   BarItems.PerformStep();
               }
               else
               {
                   BarItems.Value = Convert.ToInt32(ListItems.Length.ToString());
                   break;
               }
            }
            MessageBox.Show("Completo");
        }

        private bool InsertItemPrice(PriceItems PI)
        {
            bool ignoreres = true;
            bool cancelling = false;
            
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Parameters.Clear();
                command.Connection = con;
                try
                {
                    if (PI.Bar_Code != null)
                    {
                        command.CommandText = ("Select BarCode from Items where BarCode = @CodeRefNAV");
                        command.Parameters.AddWithValue("@CodeRefNAV", PI.Bar_Code);
                        string Exist = (string)command.ExecuteScalar();
                        if (Exist == null)
                        {
                            command.Parameters.Clear();
                            command.CommandText = "Insert into Items(ItemName,ItemCode,Barcode,Price,IdMeasure,LastDateModified,[VAT Prod_ Posting Group],NoCodeNAV) values(@ItemName, @ItemCode,@Barcode,@Price,(select IdItemMeausere from MeasureItem where ItemMeasure=@IdMeasure),@LastDateModified,@VATPG,@NoCodeNAV)";
                            string vatIvaGrup = "";
                            string NameDescription = GetItemNameDescrip(PI.Item_No, ref vatIvaGrup);

                            command.Parameters.AddWithValue("@ItemName", NameDescription);
                            command.Parameters.AddWithValue("@ItemCode", PI.Bar_Code);
                            command.Parameters.AddWithValue("@BarCode", PI.Bar_Code);
                            command.Parameters.AddWithValue("@Price", PI.Unit_Price);
                            command.Parameters.AddWithValue("@IdMeasure", PI.Unit_of_Measure_Code);
                            command.Parameters.AddWithValue("@LastDateModified", DateWork);
                            command.Parameters.AddWithValue("@NoCodeNAV", PI.Item_No);
                            command.Parameters.AddWithValue("@VATPG", vatIvaGrup);
                            //command.Parameters.AddWithValue("@Alias","" );


                            //command.Parameters.AddWithValue("@NameBankNav", PI.Name.ToString());
                            command.ExecuteScalar();
                        }
                        else if (Exist != null)
                        {
                            if (continueprocess)
                            {
                                if (remplaceall == false)
                                {
                                    YesAllNoAll yestoall = new YesAllNoAll();
                                    DialogResult resultYesall = yestoall.ShowDialog();
                                    if (resultYesall == DialogResult.Cancel)
                                    {
                                        continueprocess = false;
                                        cancelling = true;
                                    }
                                    if (resultYesall == DialogResult.Yes)
                                    {
                                        remplaceall = true;
                                    }
                                    if (resultYesall == DialogResult.Ignore)
                                    {
                                        ignoreres = false;
                                    }
                                    if (resultYesall == DialogResult.OK)
                                    {
                                        yesone = true;
                                    }
                                    if (resultYesall == DialogResult.No)
                                    {
                                        noall = true;
                                        cancelling = true;
                                    }

                                }
                                if (continueprocess)
                                {
                                    if (remplaceall && (noall == false))
                                    {
                                        command.Parameters.Clear();
                                        command.CommandText = ("UPDATE Items set Price = @Price, IdMeasure =(select IdItemMeausere from MeasureItem where ItemMeasure = @ItemMeasure), LastDateModified = @LastDateModified where BarCode = @BarCode");
                                        command.Parameters.AddWithValue("@Price", PI.Unit_Price);
                                        command.Parameters.AddWithValue("@ItemMeasure", PI.Unit_of_Measure_Code);
                                        command.Parameters.AddWithValue("@LastDateModified", DateWork);
                                        command.Parameters.AddWithValue("@BarCode", PI.Bar_Code);
                                        command.ExecuteScalar();

                                    }
                                    else if (yesone && ignoreres && (noall == false))
                                    {
                                        command.Parameters.Clear();
                                        command.CommandText = ("UPDATE Items set Price = @Price, IdMeasure =(select IdItemMeausere from MeasureItem where ItemMeasure = @ItemMeasure), LastDateModified = @LastDateModified where BarCode = @BarCode");
                                        command.Parameters.AddWithValue("@Price", PI.Unit_Price);
                                        command.Parameters.AddWithValue("@ItemMeasure", PI.Unit_of_Measure_Code);
                                        command.Parameters.AddWithValue("@LastDateModified", DateWork);
                                        command.Parameters.AddWithValue("@BarCode", PI.Bar_Code);
                                        command.ExecuteScalar();

                                    }
                                }
                            }
                        }
                        con.Close();
                    }
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show(sqlex.Message);
                }
                catch (WebException webex)
                {
                    MessageBox.Show(webex.Message);
                }

            }
            return cancelling;
        }

        private string GetVatIvaGrup(string p)
        {
            throw new NotImplementedException();
        }

        private string GetItemNameDescrip(string p, ref string VatIVA)
        {
            string Description = "";
            ItemsListNAV.ItemsList_Service ItemListServ = new ItemsListNAV.ItemsList_Service();
            ItemsListNAV.ItemsList_Filter ItemListFilter = new ItemsListNAV.ItemsList_Filter();
            //            ItemListServ.UseDefaultCredentials = true;
            string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
            string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
            var networkcre = new NetworkCredential(userconfigsfile, passconfigsfile);
            ItemListServ.Credentials = networkcre;


            ItemListFilter.Field = ItemsListNAV.ItemsList_Fields.No;
            ItemListFilter.Criteria = "=" + p;
            List<ItemsListNAV.ItemsList_Filter> ItemsListFilterArray = new List<ItemsListNAV.ItemsList_Filter>();
            ItemsListFilterArray.Add(ItemListFilter);

            //ItemsFilter.Field = 
            //
            ItemsListNAV.ItemsList[] ListItems = ItemListServ.ReadMultiple(ItemsListFilterArray.ToArray(), null, 1);
            foreach (ItemsList IL in ListItems)
            {
                Description = IL.Description;
                VatIVA = IL.VAT_Prod_Posting_Group;
            }

            return Description;
        }
    }

    class SyncMesureCodes
    {
        string DateWork = DateTime.Today.ToString("MM/dd/yyyy");
        bool remplaceall = false;
        bool continueprocess = true;
        bool yesone = false;
        bool noall = false;
        public void MesureCodes(ProgressBar BarMesure)
        {
            //ItemMeasure
            MesureCodesFromNav.MesureC_Service MesureCodeServices = new MesureC_Service();
            string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
            string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
            var networkcre = new NetworkCredential(userconfigsfile, passconfigsfile);
            MesureCodeServices.Credentials = networkcre;
            List<MesureC_Filter> MesureFilterArray = new List<MesureC_Filter>();

            MesureC[] list = MesureCodeServices.ReadMultiple(MesureFilterArray.ToArray(), null, 100);

            BarMesure.Minimum = 0;
            BarMesure.Maximum = Convert.ToInt32(list.Length);
            BarMesure.Step = 1;

            foreach (MesureC MC in list)
            {
                InsertMesureCodes(MC);
                BarMesure.PerformStep();
            }

        }
        public bool InsertMesureCodes(MesureC MesureCs)
        {
            bool ignoreres = true;
            bool cancelling = false;
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand();
                    command.Parameters.Clear();
                    command.Connection = con;

                    command.CommandText = ("Select COUNT(ItemMeasure) from MeasureItem where ItemMeasure = @CodeMesureNav");
                    command.Parameters.AddWithValue("@CodeMesureNav", MesureCs.Code.ToString());
                    int Exist = (int)command.ExecuteScalar();// command.ExecuteNonQuery().ToString();
                    if (Exist == 0)
                    {
                        command.Parameters.Clear();
                        command.CommandText = ("Insert into MeasureItem(IdItemMeausere,ItemMeasure,Description, DateInserted) values(@IdItemMeausere,@ItemCodeNav, @DesciptionNAV, @DatePosted)");
                        command.Parameters.AddWithValue("@IdItemMeausere", MesureCs.Code.ToString());
                        command.Parameters.AddWithValue("@ItemCodeNav", MesureCs.Code.ToString());
                        command.Parameters.AddWithValue("@DesciptionNAV", MesureCs.Description.ToString());
                        //command.Parameters.AddWithValue("@InternationalCode", MesureCs.International_Standard_Code.ToString());
                        command.Parameters.AddWithValue("@DatePosted", DateWork);
                        command.ExecuteScalar();
                    }
                    else if (Exist != 0)
                    {

                        if (continueprocess)
                        {
                            if (remplaceall == false)
                            {
                                YesAllNoAll yestoall = new YesAllNoAll();
                                DialogResult resultYesall = yestoall.ShowDialog();
                                if (resultYesall == DialogResult.Cancel)
                                {
                                    continueprocess = false;
                                    cancelling = true;
                                }
                                if (resultYesall == DialogResult.Yes)
                                {
                                    remplaceall = true;
                                }
                                if (resultYesall == DialogResult.Ignore)
                                {
                                    ignoreres = false;
                                }
                                if (resultYesall == DialogResult.OK)
                                {
                                    yesone = true;
                                }
                                if (resultYesall == DialogResult.No)
                                {
                                    noall = true;
                                    cancelling = true;
                                }

                            }
                            if (continueprocess)
                            {
                                if (noall == false)
                                {
                                    if (remplaceall && (noall == false))
                                    {

                                        command.Parameters.Clear();
                                        command.CommandText = ("UPDATE MeasureItem set ItemMeasure = @ItemCodeNav, Description = @DesciptionNAV, LastModify = @DateModify where IdItemMeausere = @ItemCodeNav");
                                        //command.CommandText = ("Insert into MeasureItem(ItemMeasure,Description,International_Code) values(@ItemCodeNav, @DesciptionNAV, @InternationalCode)");
                                        command.Parameters.AddWithValue("@ItemCodeNav", MesureCs.Code.ToString());
                                        command.Parameters.AddWithValue("@DesciptionNAV", MesureCs.Description.ToString());
                                        //command.Parameters.AddWithValue("@InternationalCode", MesureCs.International_Standard_Code.ToString());
                                        command.Parameters.AddWithValue("@DateModify", DateWork);
                                        command.ExecuteScalar();
                                    }
                                    else if (yesone && ignoreres && (noall == false))
                                    {
                                        command.Parameters.Clear();
                                        command.CommandText = ("UPDATE MeasureItem set ItemMeasure = @ItemCodeNav, Description = @DesciptionNAV, LastModify = @DateModify where IdItemMeausere = @ItemCodeNav");
                                        //command.CommandText = ("Insert into MeasureItem(ItemMeasure,Description,International_Code) values(@ItemCodeNav, @DesciptionNAV, @InternationalCode)");
                                        command.Parameters.AddWithValue("@ItemCodeNav", MesureCs.Code.ToString());
                                        command.Parameters.AddWithValue("@DesciptionNAV", MesureCs.Description.ToString());
                                        //command.Parameters.AddWithValue("@InternationalCode", MesureCs.International_Standard_Code.ToString());
                                        command.Parameters.AddWithValue("@DateModify", DateWork);
                                        command.ExecuteScalar();
                                    }
                                }
                            }
                        }
                    }
                    con.Close();
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show(sqlex.Message);
                }
                catch (WebException webex)
                {
                    MessageBox.Show(webex.Message);
                }

            }
            return cancelling;

            }

        }

    class SyncCompany
    {
        private bool updatecorrectcompany = false;
        string DateWork = DateTime.Today.ToString("MM/dd/yyyy");
        public void DatCompanyFromNav()
        {
            //ItemMeasure
            DataCompanyNAV.DataCompany_Service DataComNavSer = new DataCompany_Service();
            string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
            string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
            var networkcre = new NetworkCredential(userconfigsfile, passconfigsfile);
            DataComNavSer.Credentials = networkcre;
            List<DataCompany_Filter> CompanyFilterArray = new List<DataCompany_Filter>();
            try
            {
                DataCompany[] list = DataComNavSer.ReadMultiple(CompanyFilterArray.ToArray(), null, 100);
                foreach (DataCompany DC in list)
                {
                    UpdateDatacompany(DC);
                }
            }
            catch (WebException webex)
            {
                MessageBox.Show(webex.Message.ToString() +", por favor revise su usuario de acceso a NAV");
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message.ToString());
            }
            catch(HttpListenerException httpex)
            {
                MessageBox.Show(httpex.Message.ToString() + ", Revise Su conexión a Internet");
            }
        }

        private void UpdateDatacompany(DataCompany DC)
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Parameters.Clear();
                command.Connection = con;

                command.CommandText = ("Select TOP 1 [NameCompany] from Company where [no] <> 0");
                string Exist = command.ExecuteScalar().ToString();
                if (Exist == null)
                {
                    command.Parameters.Clear();
                    command.CommandText = ("Insert into Company ([NameCompany],[Location],[RFC],[PCode],[City],[StateMex],[Email],[Phone]) values(@NameCompany,@Location,@RFC,@PCode,@City,@StateMex,@Email,@Phone)");
                    command.Parameters.AddWithValue("@NameCompany", DC.Name.ToString());
                    command.Parameters.AddWithValue("@Location", (DC.Address.ToString() + ", " + DC.Address_2.ToString()));
                    command.Parameters.AddWithValue("@RFC", DC.VAT_Registration_No.ToString());
                    command.Parameters.AddWithValue("@PCode", DC.Post_Code.ToString());
                    command.Parameters.AddWithValue("@City", DC.City.ToString());
                    command.Parameters.AddWithValue("@StateMex", DC.County.ToString());
                    command.Parameters.AddWithValue("@Email", DC.E_Mail.ToString());
                    command.Parameters.AddWithValue("@Phone", DC.Phone_No.ToString());
                    command.ExecuteScalar();
                    MessageBox.Show("Datos Actualizados, La aplicación se reiniciara para tomar los cambios", "Actualización Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Exist != null)
                {
                    DialogResult result;
                    result = MessageBox.Show("Se modificaran los datos de la empresa en la base local"
                                                                + System.Environment.NewLine
                                                                + "¿Desea continuar?", "Registro Duplicado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        command.Parameters.Clear();
                        command.CommandText = ("UPDATE Company set [NameCompany] = @NameCompany,[Location] = @Location,[RFC] = @RFC,[PCode] = @PCode,[City] = @City,[StateMex] = @StateMex,[Email] = @Email,[Phone] = @Phone where [no] > 0");
                        command.Parameters.AddWithValue("@NameCompany", DC.Name.ToString());
                        command.Parameters.AddWithValue("@Location", (DC.Address.ToString() +", "+ DC.Address_2.ToString()));
                        command.Parameters.AddWithValue("@RFC", DC.VAT_Registration_No.ToString());
                        command.Parameters.AddWithValue("@PCode", DC.Post_Code.ToString());
                        command.Parameters.AddWithValue("@City", DC.City.ToString());
                        command.Parameters.AddWithValue("@StateMex", DC.County.ToString());
                        command.Parameters.AddWithValue("@Email", DC.E_Mail.ToString());
                        command.Parameters.AddWithValue("@Phone", DC.Phone_No.ToString());
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Datos Actualizados, La aplicación se reiniciara para tomar los cambios", "Actualización Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            updatecorrectcompany = true;
                        }
                        catch (SqlException sqle)
                        {
                            MessageBox.Show(sqle.Message);
                        }

                    }
                }
                con.Close();
            }
        }
    }

}
