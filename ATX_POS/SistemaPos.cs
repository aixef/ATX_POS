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
using System.Media;

using ATX_POS.WS_NAV;

namespace ATX_POS
{
    using CatalogoBancos;

    public partial class SyncPriceLists : MetroFramework.Forms.MetroForm, RegSales, CancelSales, UpdateValues, cashpay, restartApp
    {
        Timer t = new Timer();
        public ATX_POS.test2010.TestWS test2110 = new test2010.TestWS();
        private int rowIndex = 0;
        public int PermisseLevel;
        public decimal cashpay = 0M;
        string datework = "";
        decimal totalcashin = 0M;
        int letterscount = 0, lettersremaing = 0;
        public SyncPriceLists()
        {
            InitializeComponent();
            datework = DateTime.Today.ToString("MM/dd/yyyy");
        }

        private void SistemaPos_Load(object sender, EventArgs e)
        {
            //<<-------------------Reloj----------------->>
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
            TimerLabel.Left = this.Width - 200;
            TimerLabel.Top = (this.Height + 30) - this.Height;
            LogOut.Left = this.Width - 100;
            LogOut.Top = (this.Height + 30) - this.Height;

            //<<<---------------------Posiciones----------------->>>
            TabsPOS.Width = this.Width - 100;
            TabsPOS.Top = (this.Height + 87) - this.Height;
            TabsPOS.Height = this.Height - 100;
            TabsPOS.SizeMode = TabSizeMode.Fixed;
            TabsPOS.SelectedIndex = 0;

            //SubTotalConLabel.Text = "Subtotal";

            Logo.Top = (this.Height + 8) - this.Height;
            Logo.Left = (this.Width - this.Width) + 250;

            labelUser.Left = (this.Width - 500);
            labelUser.Top = (this.Height + 50) - this.Height;
            UserLabel.Top = (this.Height + 50) - this.Height;
            UserLabel.Left = this.Width - 430;

            LabelTerminal.Top = (this.Height + 50) - this.Height;
            LabelTerminal.Left = this.Width - 350;

            NoTerminal.Top = (this.Height + 50) - this.Height;
            NoTerminal.Left = this.Width - 280;

            TabTerminal.Width = TabsPOS.Width - 150;
            TabTerminal.Top = (TabsPOS.Height + 60) - TabsPOS.Height;
            //<<<---------------------Fin Posiciones----------------->>>
            ItemsDataGrid.Width = TabTerminal.Width - 250;
            ItemsDataGrid.Height = TabTerminal.Height - 10;
            ItemsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            ItemsDataGrid.RowHeadersVisible = false;

            //<<-----------------------Etiquetas venta---------------------->>>>

            CodeLabel.Left = TabTerminal.Width - 125;
            CodeLabel.Top = (TabTerminal.Height + 60) - TabTerminal.Height;

            CodeTextbox.Left = TabTerminal.Width - 150;
            CodeTextbox.Top = (TabTerminal.Height + 90) - TabTerminal.Height;
            CodeTextbox.Focus();

            SubTotalLabel.Left = TabTerminal.Width - 125;
            SubTotalLabel.Top = (TabTerminal.Height + 220) - TabTerminal.Height;
            SubTotalConLabel.Left = TabTerminal.Width - 125;
            SubTotalConLabel.Top = (TabTerminal.Height + 250) - TabTerminal.Height;

            IVALabel.Left = TabTerminal.Width - 125;
            IVALabel.Top = (TabTerminal.Height + 290) - TabTerminal.Height;
            IvaConLabel.Left = TabTerminal.Width - 125;
            IvaConLabel.Top = (TabTerminal.Height + 310) - TabTerminal.Height;

            TotalLabel.Left = TabTerminal.Width - 125;
            TotalLabel.Top = (TabTerminal.Height + 350) - TabTerminal.Height;
            TotalConten.Left = TabTerminal.Width - 125;
            TotalConten.Top = (TabTerminal.Height + 370) - TabTerminal.Height;

            RegistrarVenta.Left = TabTerminal.Width - 125;
            RegistrarVenta.Top = (TabTerminal.Height + 450) - TabTerminal.Height;
            //<<-------------------Fin etiquetas Producto-------------->>>>
            //<<<---------------Corte de Caja------------------->>


            ImagenUser.Left = (TabCashOut.Width + 10) - TabCashOut.Width;
            ImagenUser.Top = (TabCashOut.Height + 10) - TabCashOut.Height;

            ListOfUsers.Left = (TabCashOut.Width + 120) - TabCashOut.Width;
            ListOfUsers.Top = (TabCashOut.Height + 30) - TabCashOut.Height;

            UserNameLabel.Left = (TabCashOut.Width + 155) - TabCashOut.Width;
            UserNameLabel.Top = (TabCashOut.Height + 65) - TabCashOut.Height;
            UseTerminal.Left = (TabCashOut.Width + 380) - TabCashOut.Width;
            UseTerminal.Top = (TabCashOut.Height + 65) - TabCashOut.Height;
            TermAsing.Left = (TabCashOut.Width + 395) - TabCashOut.Width;
            TermAsing.Top = (TabCashOut.Height + 90) - TabCashOut.Height;

            NameUserLabelCont.Left = (TabCashOut.Width + 120) - TabCashOut.Width;
            NameUserLabelCont.Top = (TabCashOut.Height + 90) - TabCashOut.Height;
            NameUserLabelCont.Text = "";

            CurrencyPicture.Left = (TabCashOut.Width + 100) - TabCashOut.Width;
            CurrencyPicture.Top = (TabCashOut.Height + 130) - TabCashOut.Height;

            SalesTotalLabel.Left = (TabCashOut.Width + 160) - TabCashOut.Width;
            SalesTotalLabel.Top = (TabCashOut.Height + 140) - TabCashOut.Height;

            SalesLabelContent.Left = (TabCashOut.Width + 280) - TabCashOut.Width;
            SalesLabelContent.Top = (TabCashOut.Height + 140) - TabCashOut.Height;
            SalesLabelContent.Text = "0.00";

            pictureBox2.Left = (TabCashOut.Width + 90) - TabCashOut.Width;
            pictureBox2.Top = (TabCashOut.Height + 200) - TabCashOut.Height;
            metroLabel1.Left = pictureBox2.Right + 50;
            cashCount1.Top = (TabCashOut.Height + 220) - TabCashOut.Height;
            cashCount1.Left = (TabCashOut.Width + 160) - TabCashOut.Width;

            salesInDetail1.Left = (TabCashOut.Width + 580) - TabCashOut.Width;
            salesInDetail1.Top = (TabCashOut.Height + 20) - TabCashOut.Height;

            CorteCaja.Left = (TabCashOut.Width + 655) - TabCashOut.Width;
            CorteCaja.Top = (TabCashOut.Height + 400) - TabCashOut.Height;

            CorteFin.Left = (TabCashOut.Width + 655) - TabCashOut.Width;
            CorteFin.Top = (TabCashOut.Height + 430) - TabCashOut.Height;

            CashManualOut.Left = (TabCashOut.Width + 655) - TabCashOut.Width;
            CashManualOut.Top = (TabCashOut.Height + 470) - TabCashOut.Height;

        }
        //--------------------Apertura de Caja------------------//
        public void InitTerminalCash(string Super)
        {
            string datework = DateTime.Today.ToString("MM/dd/yyyy");
            if (Super != "super")
            {
                try
                {
                    using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                    {
                        //MetroFramework.MetroMessageBox.Show(this, "Bienviendo de Vuelta: " + UserLabel.Text, "Welcome Back", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cn.Open();
                        SqlCommand comando = new SqlCommand("select count(*) " +
                                                                "from LoginsControl where Terminal = '"
                                                                + NoTerminal.Text + "' and [User]= '" +
                                                                  UserLabel.Text + "' and DateWork = '" + datework + "'", cn);
                        int count = Convert.ToInt32(comando.ExecuteScalar());

                        if (count == 0)
                        {
                            FirstLoginSesion LoginfirstSesion = new FirstLoginSesion();
                            LoginfirstSesion.UserLabel.Text = UserLabel.Text;
                            LoginfirstSesion.TerminalLabel.Text = NoTerminal.Text;
                            LoginfirstSesion.GetTerminalDetail();
                            LoginfirstSesion.ShowDialog(this);

                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Bienviendo de Vuelta: " + UserLabel.Text, "Welcome Back", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CodeTextbox.Focus();
                        }

                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                
            }
        }

        public void checkcloseturn()
        {
            bool closeturn = false;
            bool closebox = false;
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                SqlCommand SesionControl = new SqlCommand();
                SesionControl.Parameters.Clear();
                SesionControl.Connection = cn;
                SesionControl.CommandText = "select [Cierreturno], [CierreCaja] from LoginsControl where [User] = @User and [DateWork] = @datework";
                SesionControl.Parameters.AddWithValue("datework", datework);
                SesionControl.Parameters.AddWithValue("@User", UserLabel.Text.ToString());
                SqlDataAdapter sda = new SqlDataAdapter(SesionControl);
                DataTable loginscontroltb = new DataTable();

                if (sda != null)
                {
                    sda.Fill(loginscontroltb);
                }
                foreach (DataRow rows in loginscontroltb.Rows)
                {
                    closeturn = bool.Parse(rows[0].ToString());
                    closebox = bool.Parse(rows[1].ToString());
                }
                if (closeturn || closebox)
                {
                    if (closeturn)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Ya se ha cerrado el turno del usuario: " + UserLabel.Text + ", La aplicacion no puede ser iniciada completamente", "Turno Cerrado", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CodeTextbox.Enabled = false;
                        RegistrarVenta.Enabled = false;
                        CorteCaja.Enabled = false;
                        CashManualOut.Enabled = false;
                        ((Control)this.SyncNav).Enabled = false;
                        //Application.Exit();
                    }
                    if (closebox)
                    {
                        string date = DateTime.Today.AddDays(1).ToString();
                        MetroFramework.MetroMessageBox.Show(this, "El corte de Caja ya se ha realizado, la terminal no se podra usar hasta el dia : " + date + ", ó contacte a su gerente", "Corte de Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }

                cn.Close();
            }
        }

        private void SistemaPos_FormClosed(object sender, FormClosedEventArgs e)
        {


            //this.Close();

            Application.Exit();

        }

        private void LabelTerminal_Click(object sender, EventArgs e)
        {

        }
        private void t_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            string time = "";

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            //update label
            TimerLabel.Text = time;
        }

        private void SubTotalLabel_Click(object sender, EventArgs e)
        {

        }

        private void TabTerminal_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarVenta_Click(object sender, EventArgs e)
        {
            if (TotalConten.Text != "")
            {
                //MessageBox.Show(TotalConten.Text.Length.ToString());
                if (TotalConten.Text.Length > 4)
                {
                    Payments pagos = new Payments();
                    //PaymentForm pagos = new PaymentForm();
                    string Total = TotalConten.Text.ToString().Remove(0, 1);
                    pagos.Totalling.Text = Total;
                    pagos.Username = UserLabel.Text.ToString();
                    pagos.terminaluser = NoTerminal.Text.ToString();
                    //pagos.NoTerminalActual = NoTerminal.Text;
                    pagos.ShowDialog(this);
                }
                else
                    MessageBox.Show("No hay nada que Registrar");
            }
            else
                MessageBox.Show("No hay nada que Registrar");
        }

        private void CodeTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    e.Handled = true;
                    using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                    {
                        cn.Open();
                        if (CodeTextbox.Text != "")
                        {
                            SqlCommand comando = new SqlCommand();
                            comando.Parameters.Clear();
                            comando.Connection = cn;
                            comando.CommandText = "select Items.ItemName,Items.ItemCode,Items.Price, Items.[VAT Prod_ Posting Group],MeasureItem.ItemMeasure from Items INNER JOIN MeasureItem ON Items.IdMeasure = MeasureItem.IdItemMeausere where (BarCode = @Barcode)";
                            comando.Parameters.AddWithValue("@Barcode", CodeTextbox.Text.ToString());
                            var x = comando.ExecuteScalar();
                            //MessageBox.Show(x.ToString());
                            if (x != null)
                            {
                                comando.ExecuteNonQuery();
                                SqlDataAdapter da = new SqlDataAdapter(comando);

                                NuevaLinea(da);
                                ItemsDataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                CodeTextbox.Text = "";

                                SumaTotal();

                                ObtenIva();
                                ObtenTotal();
                                cn.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                CodeTextbox.Text = "";
            }
        }

        private void ObtenTotal()
        {
            /*var SubtotalVenta = Convert.ToDecimal(SubTotalConLabel.Text);
            //var IvaTotal = Convert.ToDecimal(IvaConLabel.Text);
            var totalVenta = SubtotalVenta;// +IvaTotal;
            TotalConten.Text = totalVenta.ToString("\\$.00");*/
            var ivato = decimal.Parse(IvaConLabel.Text.ToString());
            var totalc = TotalConten.Text.ToString().Remove(0, 1);
            var dtotal = decimal.Parse(totalc);
            var subto = dtotal - ivato;
            if (subto >= 0)
            {
                SubTotalConLabel.Text = subto.ToString();
            }
            else
            {
                SubTotalConLabel.Text = "";
            }

        }

        private void ObtenIva()
        {

            decimal sumatoria = 0.0m;
            decimal porcentage = 0.0m;
            decimal ivaitem = 0M;

            foreach (DataGridViewRow row in ItemsDataGrid.Rows)
            {
                porcentage = GetPorcentageIVA(row.Cells["IVA"].Value.ToString());
                decimal priceitem = (Convert.ToDecimal(row.Cells["Price"].Value));
                ivaitem = (((priceitem / porcentage) - priceitem) * -1);
                sumatoria += (ivaitem * Convert.ToDecimal(row.Cells["Cantidad"].Value));
            }
            if (sumatoria > 0)
            {
                /*decimal ivasales = (sumatoria / porcentage);
                decimal.Round(ivasales, 2);
                ivasales = (ivasales - sumatoria) * -1M;*/
                decimal Ivasum = decimal.Round(sumatoria, 2);
                IvaConLabel.Text = Ivasum.ToString();
            }
            else
            {
                IvaConLabel.Text = sumatoria.ToString();
            }
        }

        private decimal GetPorcentageIVA(string p)
        {
            decimal porcentage = 0.0m;
            DataTable IvaPor = new DataTable();
            string ivaConsult = "";
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand IvaPorcen = new SqlCommand();
                IvaPorcen.Parameters.Clear();
                IvaPorcen.Connection = con;
                IvaPorcen.CommandText = "select Porcentage from ConfigIVA where CodeIVA = @IvaCode";
                IvaPorcen.Parameters.AddWithValue("@IvaCode", p);

                SqlDataAdapter sdaI = new SqlDataAdapter(IvaPorcen);
                sdaI.Fill(IvaPor);
                foreach (DataRow RowIVA in IvaPor.Rows)
                {
                    ivaConsult = RowIVA[0].ToString();
                    var ivadecimal = decimal.Parse(ivaConsult);
                    if (ivadecimal > 0)
                    {
                        porcentage = (Convert.ToDecimal(ivaConsult) / 100);
                    }
                    else
                    {
                        porcentage = 0M;
                    }
                }
                porcentage += 1;

            }
            return porcentage;
        }

        private void SumaTotal()
        {
            decimal sumatoria = 0.0M;

            foreach (DataGridViewRow row in ItemsDataGrid.Rows)
            {
                if (row.Cells["Cantidad"].Value.ToString() != "")
                {
                    sumatoria += Convert.ToDecimal(row.Cells["Price"].Value) * Convert.ToDecimal(row.Cells["Cantidad"].Value);
                }
            }
            var totalVenta = sumatoria;// +IvaTotal;
            TotalConten.Text = totalVenta.ToString("\\$.00");
            //SubTotalConLabel.Text = Convert.ToString(sumatoria);
        }

        private void NuevaLinea(SqlDataAdapter da)
        {
            string quantity = "";
            float value = 0;
            int indexcolumn = -1;
            DataTable dt = new DataTable();
            if (ItemsDataGrid.DataSource == null)
            {
                da.Fill(dt);
                ItemsDataGrid.AutoGenerateColumns = false;
                ItemsDataGrid.ColumnCount = 6;
                ItemsDataGrid.Columns[0].Name = "ItemName";
                ItemsDataGrid.Columns[0].HeaderText = "Articulo";
                ItemsDataGrid.Columns[0].DataPropertyName = "ItemName";
                ItemsDataGrid.Columns[0].ReadOnly = true;
                this.ItemsDataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                ItemsDataGrid.Columns[1].Name = "ItemCode";
                ItemsDataGrid.Columns[1].HeaderText = "Codigo Articulo";
                ItemsDataGrid.Columns[1].DataPropertyName = "ItemCode";
                ItemsDataGrid.Columns[1].ReadOnly = true;
                this.ItemsDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                ItemsDataGrid.Columns[2].Name = "Price";
                ItemsDataGrid.Columns[2].HeaderText = "Precio Articulo";
                this.ItemsDataGrid.Columns[2].DefaultCellStyle.Format = "\\$.00";
                ItemsDataGrid.Columns[2].DataPropertyName = "Price";
                ItemsDataGrid.Columns[2].ReadOnly = true;
                this.ItemsDataGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.ItemsDataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                ItemsDataGrid.Columns[3].Name = "Cantidad";
                ItemsDataGrid.Columns[3].HeaderText = "Cantidad";
                ItemsDataGrid.Columns[3].DataPropertyName = "Cantidad";
                ItemsDataGrid.DataSource = dt;
                ItemsDataGrid.Rows[0].Cells[3].Value = 1;
                this.ItemsDataGrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                ItemsDataGrid.Columns[4].Name = "Medida";
                ItemsDataGrid.Columns[4].HeaderText = "Medida";
                ItemsDataGrid.Columns[4].DataPropertyName = "ItemMeasure";
                ItemsDataGrid.Columns[4].ReadOnly = true;
                this.ItemsDataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                ItemsDataGrid.Columns[5].Name = "IVA";
                ItemsDataGrid.Columns[5].HeaderText = "IVA";
                ItemsDataGrid.Columns[5].DataPropertyName = "VAT Prod_ Posting Group";
                ItemsDataGrid.Columns[5].ReadOnly = true;


            }
            else
            {
                bool exist = ItemsDataGrid.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["ItemCode"].Value) == CodeTextbox.Text);

                if (exist)
                {
                    foreach (DataGridViewRow row in ItemsDataGrid.Rows)
                    {
                        if (Convert.ToString(row.Cells[1].Value) == CodeTextbox.Text)
                        {
                            row.Selected = true;
                            indexcolumn = row.Index;
                            row.Selected = false;
                        }
                    }
                    if (indexcolumn > -1)
                    {
                        ItemsDataGrid.Rows[indexcolumn].Cells[3].Value = Convert.ToDecimal(ItemsDataGrid.Rows[indexcolumn].Cells[3].Value) + 1;
                    }
                }
                else
                {
                    dt = ItemsDataGrid.DataSource as DataTable;
                    DataRow row1 = dt.NewRow();
                    da.Fill(dt);
                    ItemsDataGrid.DataSource = dt;
                    indexcolumn = ItemsDataGrid.RowCount - 1;
                    if (ItemsDataGrid.Rows[indexcolumn].Cells[3].Value != null)
                    {
                        quantity = ItemsDataGrid.Rows[indexcolumn].Cells[3].Value.ToString();
                        value = float.Parse(quantity, CultureInfo.InvariantCulture.NumberFormat);
                    }
                    if (!(value > 1f))
                    {
                        ItemsDataGrid.Rows[indexcolumn].Cells[3].Value = 1;
                    }

                }
            }
            //
            this.ItemsDataGrid.DefaultCellStyle.NullValue = "no entry";

        }


        #region CancelSales Members
        public void cleardatagrid()
        {
            DataTable dta = (DataTable)ItemsDataGrid.DataSource;
            dta.Clear();
        }
        #endregion
        private void LineaMarcada(object sender, EventArgs e)
        {
            if (!this.ItemsDataGrid.Rows[this.rowIndex].IsNewRow)
            {
                this.ItemsDataGrid.Rows.RemoveAt(this.rowIndex);
            }
            UpdateValues();
        }

        private void ItemsDataGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (ItemsDataGrid.Rows.Count > 0)
                {
                    this.ItemsDataGrid.Rows[e.RowIndex].Selected = true;
                    this.rowIndex = e.RowIndex;
                    this.ItemsDataGrid.CurrentCell = this.ItemsDataGrid.Rows[e.RowIndex].Cells[1];
                    this.MenuGrid.Show(this.ItemsDataGrid, e.Location);
                    MenuGrid.Show(Cursor.Position);
                }

            }
        }

        #region UpdateValues Members
        public void UpdateValues()
        {
            SumaTotal();
            ObtenTotal();
            ObtenIva();
        }
        #endregion

        private void ItemsDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ItemsDataGrid.Rows[e.RowIndex].ErrorText = String.Empty;
            UpdateValues();
        }

        #region RegSales Members
        public int RegisterSales(string Totalling, string Remainingtext, string codePayment, bool mixpayment)
        {
            string datework = DateTime.Today.ToString("MM/dd/yyyy");
            int SalesID = 1;
            if (ItemsDataGrid.RowCount != 0)
            {
                #region SinglePayment
                if (mixpayment == false)
                {
                    try
                    {
                        using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                        {
                            cn.Open();
                            DateTime today = DateTime.Today;
                            DateTime TimeRegister = DateTime.Now;
                            //string Total = TotalConten.Text.ToString().Remove(0, 1);
                            string Total = Totalling;
                            decimal remaing = Convert.ToDecimal(Remainingtext);
                            #region Registrar ventas
                            SqlCommand InsertSales = new SqlCommand();
                            InsertSales.Parameters.Clear();
                            InsertSales.Connection = cn;
                            string timework = DateTime.Now.ToString("HH:mm:ss.ffffff");

                            InsertSales.CommandText = "Insert into dbo.[Sales] (Sales.[Date], Sales.[Time], Sales.[User], Terminal, SalesTotal,SalesSubtotal,IVA,ChangeSales,[Fecha Registro],codePayment,Mixpayment,TotalItems,CashPay,[SyncNav],[CorteReg])" +
                                                                        "values(@Dateworkd, @Timework," +
                                                                        "(Select ID from dbo.[Users] where Users.[User] = @User), " +
                                                                        "(Select Terminal from dbo.[Terminals] where Number = @NoTerminal), @Total, " +
                                                                        "@Subtotal, @IVA, @Remaing, @Dateworkd, @Codepayment, @mixpayment,@TotalItems,@CashPay,@SyncNav, @Payment) SELECT SCOPE_IDENTITY()";
                            InsertSales.Parameters.AddWithValue("@User", UserLabel.Text.ToString());
                            InsertSales.Parameters.AddWithValue("@NoTerminal", NoTerminal.Text.ToString());
                            InsertSales.Parameters.AddWithValue("@Timework", timework);
                            InsertSales.Parameters.AddWithValue("@Total", Total);
                            InsertSales.Parameters.AddWithValue("@Subtotal", SubTotalConLabel.Text.ToString());
                            InsertSales.Parameters.AddWithValue("@IVA", IvaConLabel.Text.ToString());
                            InsertSales.Parameters.AddWithValue("@Remaing", remaing);
                            InsertSales.Parameters.AddWithValue("@Dateworkd", datework);
                            InsertSales.Parameters.AddWithValue("@Codepayment", codePayment);
                            InsertSales.Parameters.AddWithValue("@mixpayment", mixpayment);
                            InsertSales.Parameters.AddWithValue("@Payment", false);
                            InsertSales.Parameters.AddWithValue("@SyncNav", false);

                            var totalItems = 0M;
                            string valuetotalintems = "";
                            foreach (DataGridViewRow rowdata in ItemsDataGrid.Rows)
                            {
                                valuetotalintems = rowdata.Cells["Cantidad"].Value.ToString();
                                totalItems += Convert.ToDecimal(valuetotalintems);
                            }
                            InsertSales.Parameters.AddWithValue("@TotalItems", totalItems);
                            InsertSales.Parameters.AddWithValue("@CashPay", cashpay);

                            SalesID = Convert.ToInt32(InsertSales.ExecuteScalar());
                            #endregion
                            #region Detalle ventas
                            foreach (DataGridViewRow rows in ItemsDataGrid.Rows)
                            {
                                SqlCommand SalesDetail = new SqlCommand();
                                SalesDetail.Parameters.Clear();
                                SalesDetail.Connection = cn;
                                SalesDetail.CommandText = "Insert into dbo.[SalesDetail] (SalesID,ItemCode,Price,Quantity,ProductName) "
                                                                        + "values(@SalesID, @ItemCode, @Price, @Cantidad, @ItemName)";
                                SalesDetail.Parameters.AddWithValue("@SalesID", SalesID);
                                SalesDetail.Parameters.AddWithValue("@ItemCode", rows.Cells["ItemCode"].Value.ToString());
                                SalesDetail.Parameters.AddWithValue("@Price", rows.Cells["Price"].Value.ToString());
                                SalesDetail.Parameters.AddWithValue("@Cantidad", rows.Cells["Cantidad"].Value.ToString());
                                SalesDetail.Parameters.AddWithValue("@ItemName", rows.Cells["ItemName"].Value.ToString());
                                SalesDetail.ExecuteNonQuery();
                            }
                            #endregion
                            cleardatagrid();
                            UpdateValues();
                            clearTotalLabels();

                            if (cn.State == ConnectionState.Open)
                            {
                                cn.Close();
                            }
                        }
                    }
                    catch (SqlException sq)
                    {
                        MessageBox.Show(sq.Message.ToString());
                    }

                }
                else
                    if (mixpayment)
                    {
                        string codepay = "100";
                        try
                        {
                            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                            {
                                cn.Open();
                                DateTime today = DateTime.Today;
                                string TimeRegister = DateTime.Now.ToString("HH:mm:ss.ffffff");
                                //string Total = TotalConten.Text.ToString().Remove(0, 1);
                                string Total = Totalling;
                                decimal remaing = Convert.ToDecimal(Remainingtext);
                                #region Registrar ventas
                                SqlCommand InsertSales = new SqlCommand();
                                InsertSales.Parameters.Clear();
                                InsertSales.Connection = cn;
                                InsertSales.CommandText = "Insert into dbo.[Sales] (Sales.[Date], Sales.[Time], Sales.[User], Terminal, SalesTotal,SalesSubtotal,IVA,ChangeSales,[Fecha Registro],codePayment,Mixpayment,TotalItems,CashPay,CustomCode,[SyncNav],[CorteReg]) " +
                                                                            "values(@Dateworkd, @Timework," +
                                                                            "(Select ID from dbo.[Users] where Users.[User] = @User), " +
                                                                            "(Select Terminal from dbo.[Terminals] where Number = @NoTerminal), @Total, " +
                                                                            "@Subtotal, @IVA, @Remaing, @Dateworkd, @Codepayment, @mixpayment,@TotalItems,@CashPay,@CustomCode,@SyncNav,@Payment) SELECT SCOPE_IDENTITY()";
                                InsertSales.Parameters.AddWithValue("@User", UserLabel.Text.ToString());
                                InsertSales.Parameters.AddWithValue("@NoTerminal", NoTerminal.Text.ToString());
                                InsertSales.Parameters.AddWithValue("@Timework", TimeRegister);
                                InsertSales.Parameters.AddWithValue("@Total", Total);
                                InsertSales.Parameters.AddWithValue("@Subtotal", SubTotalConLabel.Text.ToString());
                                InsertSales.Parameters.AddWithValue("@IVA", IvaConLabel.Text.ToString());
                                InsertSales.Parameters.AddWithValue("@Remaing", remaing);
                                InsertSales.Parameters.AddWithValue("@Dateworkd", datework);
                                InsertSales.Parameters.AddWithValue("@Codepayment", codepay);
                                InsertSales.Parameters.AddWithValue("@mixpayment", mixpayment);
                                InsertSales.Parameters.AddWithValue("@CustomCode", codePayment);
                                InsertSales.Parameters.AddWithValue("@Payment", false);
                                InsertSales.Parameters.AddWithValue("@SyncNav", false);


                                var totalItems = 0M;
                                string valuetotalintems = "";
                                foreach (DataGridViewRow rowdata in ItemsDataGrid.Rows)
                                {
                                    valuetotalintems = rowdata.Cells["Cantidad"].Value.ToString();
                                    totalItems += Convert.ToDecimal(valuetotalintems);
                                }
                                InsertSales.Parameters.AddWithValue("@TotalItems", totalItems);
                                InsertSales.Parameters.AddWithValue("@CashPay", cashpay);

                                SalesID = Convert.ToInt32(InsertSales.ExecuteScalar());
                                #endregion
                                #region Detalle ventas
                                foreach (DataGridViewRow rows in ItemsDataGrid.Rows)
                                {
                                    SqlCommand SalesDetail = new SqlCommand();
                                    SalesDetail.Parameters.Clear();
                                    SalesDetail.Connection = cn;
                                    SalesDetail.CommandText = "Insert into dbo.[SalesDetail] (SalesID,ItemCode,Price,Quantity,ProductName) "
                                                                            + "values(@SalesID, @ItemCode, @Price, @Cantidad, @ItemName)";
                                    SalesDetail.Parameters.AddWithValue("@SalesID", SalesID);
                                    SalesDetail.Parameters.AddWithValue("@ItemCode", rows.Cells["ItemCode"].Value.ToString());
                                    SalesDetail.Parameters.AddWithValue("@Price", rows.Cells["Price"].Value.ToString());
                                    SalesDetail.Parameters.AddWithValue("@Cantidad", rows.Cells["Cantidad"].Value.ToString());
                                    SalesDetail.Parameters.AddWithValue("@ItemName", rows.Cells["ItemName"].Value.ToString());
                                    SalesDetail.ExecuteNonQuery();
                                }
                                #endregion
                                cleardatagrid();
                                UpdateValues();
                                clearTotalLabels();

                                if (cn.State == ConnectionState.Open)
                                {
                                    cn.Close();
                                }
                            }
                        }
                        catch (SqlException sq)
                        {
                            MessageBox.Show(sq.Message.ToString());
                        }

                    }
            }
            else
            {
                MessageBox.Show("No hay Productos a registrar");
            }

            return SalesID;
                #endregion
        }

        private void clearTotalLabels()
        {
            SubTotalConLabel.Text = "";
            TotalConten.Text = "";
            IvaConLabel.Text = "";

        }

        #endregion

        //<<<<<-------------------------Pestaña Corte de Caja----------------->>>>>>>>>>

        private void ValidaUser(object sender, EventArgs e)
        {
            if (ListOfUsers.Items.Count <= 0)
            {

                DataTable dt = new DataTable();
                using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    cn.Open();
                    SqlCommand UserList = new SqlCommand();
                    UserList.Parameters.Clear();
                    UserList.Connection = cn;
                    //IF ((Select TOP 1 PermisseLevel from dbo.[Users] where users.PermisseLevel = 1) = (select PermisseLevel from dbo.[Users] where Users.[User] ='ro ')) select Users.[User] from dbo.[Users] ELSE IF ((Select TOP 1 PermisseLevel from dbo.[Users] where users.PermisseLevel = 2) = (select PermisseLevel from dbo.[Users] where Users.[User] ='rog )) select Users.[User] from dbo.[Users] where Users.Termina = (select Terminal from dbo.Terminals where Terminals.[Number] = 1)         Else select Users.[User] from dbo.[Users] where Users.[User] = 'pablo'
                    UserList.CommandText = "IF ((Select TOP 1 PermisseLevel from dbo.[Users] where users.PermisseLevel = 1) = (select PermisseLevel from dbo.[Users] where Users.[User] =@User)) select Users.[User] from dbo.[Users] ELSE IF ((Select TOP 1 PermisseLevel from dbo.[Users] where users.PermisseLevel = 2) = (select PermisseLevel from dbo.[Users] where Users.[User] =@User)) select Users.[User] from dbo.[Users] where Users.Termina = (select Terminal from dbo.Terminals where Terminals.[Number] = @Terminal) ELSE select Users.[User] from dbo.[Users] where Users.[User] = @User";
                    UserList.Parameters.AddWithValue("@User", UserLabel.Text.ToString());
                    UserList.Parameters.AddWithValue("@Terminal", NoTerminal.Text.ToString());
                    //UserList.Parameters.AddWithValue("@active",true);
                    UserList.ExecuteNonQuery();

                    SqlDataReader sdr = UserList.ExecuteReader();
                    try
                    {
                        while (sdr.Read())
                        {
                            ListOfUsers.Items.Add(sdr["User"].ToString());
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

        private void CountingUp_Click(object sender, EventArgs e)
        {
            if (ListOfUsers.SelectedItem != null)
            {
                string comboval = ListOfUsers.SelectedItem.ToString();
                GetTotalSalesByUser(comboval);
                GetNameandTerminal(comboval);
                cashCount1.Total(comboval);
            }
        }

        private void GetNameandTerminal(string comboval)
        {

            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                cn.Open();
                SqlCommand SalesbyUser = new SqlCommand();
                SalesbyUser.Parameters.Clear();
                SalesbyUser.Connection = cn;
                SalesbyUser.CommandText = "select Users.Name, Terminals.Number from Users INNER JOIN Terminals ON Users.Termina = Terminals.Terminal where Users.[User] = @UserContingUp";
                SalesbyUser.Parameters.Add("@UserContingUp", System.Data.SqlDbType.VarChar);
                SalesbyUser.Parameters["@UserContingUp"].Value = comboval;
                SalesbyUser.ExecuteNonQuery();
                SqlDataReader sdr = SalesbyUser.ExecuteReader();
                try
                {
                    while (sdr.Read())
                    {
                        NameUserLabelCont.Text = sdr["Name"].ToString();
                        TermAsing.Text = sdr["Number"].ToString();
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message.ToString());
                }
            }
        }

        private void GetTotalSalesByUser(string comboval)
        {
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                string datework = DateTime.Today.ToString("MM/dd/yyyy");
                cn.Open();
                SqlCommand SalesbyUser = new SqlCommand();
                SalesbyUser.Parameters.Clear();
                SalesbyUser.Connection = cn;
                //La función COALESCE recibe varios argumentos y retorna la primer expresión distinta de nulo de la lista de dichos argumentos, en este caso asigna 0 a todo los elementos NULL
                SalesbyUser.CommandText = "Select COALESCE (SUM(SalesTotal),0) as TOTAL from Sales where Sales.[User] =(select id from dbo.[Users] where Users.[User] =@UserContingUp) and Sales.[Date]=@datework";

                SalesbyUser.Parameters.AddWithValue("@UserContingUp", comboval);
                SalesbyUser.Parameters.AddWithValue("@datework", datework);
                SalesbyUser.ExecuteNonQuery();
                SqlDataReader sdr = SalesbyUser.ExecuteReader();
                //SqlException.E();
                try
                {
                    while (sdr.Read())
                    {
                        SalesLabelContent.Text = sdr["TOTAL"].ToString();
                        salesInDetail1.TotalCash.Text = sdr["TOTAL"].ToString();
                    }

                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message.ToString());
                }

                cn.Close();
            }
        }

        private void metroLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void cashCount1_Load(object sender, EventArgs e)
        {

        }

        private void TabCashOut_Click(object sender, EventArgs e)
        {

        }

        private void ListOfUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListOfUsers.SelectedItem != null)
            {
                //Obtiene valores del usuario seleccionado
                string ComboboxVal = ListOfUsers.SelectedItem.ToString();
                //obtiene Nombre y terminal asignada 
                GetNameandTerminal(ComboboxVal);
                //Obtiene ventas del dia por usuario
                GetTotalSalesByUser(ComboboxVal);
                //Obtiene estadtisticas del usuario seleccionado
                GetStatistics(ComboboxVal);
                //GetCashOuts(ComboboxVal);
                gettotalmoney();
            }

        }

        private void gettotalmoney()
        {
            decimal totalcountingup = decimal.Parse(cashCount1.FondoCajaTexto.Text.ToString());
            decimal totalsalesMoney = decimal.Parse(cashCount1.RealCash.Text.ToString());
            decimal realmoney = totalcountingup + totalsalesMoney;
            salesInDetail1.TotalMoneyBox.Text = realmoney.ToString("N2");
        }

        private void GetCashOuts(string ComboboxVal)
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {

            }
        }

        private void GetStatistics(string ComboboxVal)
        {
            string datework = DateTime.Today.ToString("MM/dd/yyyy"); 
            decimal totalreal = 0M;
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                try
                {
                    //efectivo en caja
                    #region efectivo caja
                    cn.Open();
                    SqlCommand SalesStatistics = new SqlCommand();
                    SalesStatistics.Parameters.Clear();
                    SalesStatistics.Connection = cn;
                    //La función COALESCE recibe varios argumentos y retorna la primer expresión distinta de nulo de la lista de dichos argumentos, en este caso asigna 0 a todo los elementos NULL
                    SalesStatistics.CommandText = "Select COALESCE (SUM(TotalCounting),0) as TOTALCAJA from CountingUp where [IDreg] = (select [ID] from Users where [User] = @IdUser ) and [DateCounting] = @datework";
                    //SalesStatistics.Parameters.AddWithValue("@CodeReg", datework + datework + UserLabel.Text.ToString() + NoTerminal.Text.ToString());
                    SalesStatistics.Parameters.AddWithValue("@IdUser", ComboboxVal);
                    SalesStatistics.Parameters.AddWithValue("@datework", datework);

                    SalesStatistics.ExecuteNonQuery();
                    SqlDataReader sdr = SalesStatistics.ExecuteReader();
                    //SqlException.E();
                    try
                    {
                        while (sdr.Read())
                        {
                            cashCount1.FondoCajaTexto.Text = sdr["TOTALCAJA"].ToString();
                        }

                    }
                    catch (SqlException se)
                    {
                        MessageBox.Show(se.Message.ToString());
                    }
                    cn.Close();
                }
                catch (SqlException exp)
                {
                    MessageBox.Show(exp.Message.ToString());
                }
                    #endregion
                //Ventas Efectivo
                #region efectivoestadisticas
                cn.Open();
                SqlCommand SalesCash = new SqlCommand();
                SalesCash.Parameters.Clear();
                SalesCash.Connection = cn;
                //La función COALESCE recibe varios argumentos y retorna la primer expresión distinta de nulo de la lista de dichos argumentos, en este caso asigna 0 a todo los elementos NULL
                SalesCash.CommandText = "Select COALESCE (SUM(CashMont),0) as TOTALSALES , COALESCE (SUM(ChangeCash),0) as TOTALSALESOUT  from PaymentsDetail where PaymentsDetail.[DateReg]= @Workdate " +
                                        "and UserName = @UserLabel";

                SalesCash.Parameters.AddWithValue("@UserLabel", ComboboxVal);
                SalesCash.Parameters.AddWithValue("@Workdate", datework);
                //SalesCash.Parameters.AddWithValue("@UserLabel", UserLabel.Text.ToString());
                SalesCash.ExecuteNonQuery();
                SqlDataReader scr = SalesCash.ExecuteReader();
                //SqlException.E();
                try
                {
                    while (scr.Read())
                    {
                        totalcashin = decimal.Parse(scr["TOTALSALES"].ToString());
                        decimal totalcashoutspayments = decimal.Parse(scr["TOTALSALESOUT"].ToString());
                        totalreal = totalcashin - totalcashoutspayments;
                        salesInDetail1.TotalMoney.Text = scr["TOTALSALES"].ToString();
                    }

                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message.ToString());
                }

                cn.Close();
                #endregion

                //Salidas de Efectivo
                #region salidas efectivo
                cn.Open();
                SqlCommand SalesOutCash = new SqlCommand();
                SalesOutCash.Parameters.Clear();
                SalesOutCash.Connection = cn;
                //La función COALESCE recibe varios argumentos y retorna la primer expresión distinta de nulo de la lista de dichos argumentos, en este caso asigna 0 a todo los elementos NULL
                SalesOutCash.CommandText = "Select COALESCE (SUM(ChangeSales),0) as TOTALOutSALES from Sales where [Fecha Registro] = @Datework " +
                                        "and [User] = (select ID from Users where Users.[User]=@UserLabel)";
                SalesOutCash.Parameters.AddWithValue("@UserLabel", ComboboxVal);
                SalesOutCash.Parameters.AddWithValue("@Datework", datework);
                SalesOutCash.ExecuteNonQuery();
                SqlDataReader socr = SalesOutCash.ExecuteReader();
                //SqlException.E();
                decimal totaloutchange = 0M;
                try
                {
                    while (socr.Read())
                    {
                        //cashCount1.textBox2.Text = socr["TOTALOutSALES"].ToString();
                        totaloutchange = decimal.Parse(socr["TOTALOutSALES"].ToString());
                    }
                }
                catch (SqlException se2)
                {
                    MessageBox.Show(se2.Message.ToString());
                }
                decimal saleswithchange = totalcashin - totaloutchange;
                cashCount1.VentasEfectivoTexto.Text = saleswithchange.ToString("N2");
                cn.Close();
                SqlCommand cashouts2 = new SqlCommand();
                cashouts2.Parameters.Clear();
                cn.Open();
                cashouts2.Connection = cn;
                cashouts2.CommandText = "select COALESCE (SUM([Total]),0) FROM CashOut where [CasingAsigned] = (select [ID] from Users where [User] = @User) and [Date] = @Datework";
                cashouts2.Parameters.AddWithValue("@User", ComboboxVal);
                cashouts2.Parameters.AddWithValue("@Datework", datework);
                SqlDataAdapter sda = new SqlDataAdapter(cashouts2);
                DataTable sdacashout = new DataTable();
                if (sda != null)
                {
                    sda.Fill(sdacashout);
                }
                decimal cashcountouts = 0M;
                foreach (DataRow row in sdacashout.Rows)
                {
                    cashcountouts = decimal.Parse(row[0].ToString());
                }
                //decimal totalcashout = cashcountouts + totaloutchange;
                cashCount1.TotalCambios.Text = totaloutchange.ToString("N2");
                salesInDetail1.cashout.Text = totaloutchange.ToString("N2");
                salesInDetail1.totalManualOuts.Text = cashcountouts.ToString("N2");
                cn.Close();
                #endregion
                //Ventas Reales
                #region ventasreales
                //RealCash
                cn.Open();
                SqlCommand SalesReal = new SqlCommand();
                SalesReal.Parameters.Clear();
                SalesReal.Connection = cn;
                //La función COALESCE recibe varios argumentos y retorna la primer expresión distinta de nulo de la lista de dichos argumentos, en este caso asigna 0 a todo los elementos NULL
                SalesReal.CommandText = "Select COALESCE (SUM([SalesTotal]),0) as TOTALsales from PaymentsDetail where [DateReg] = @datework and [UserName] = @User";
                //SalesStatistics.Parameters.AddWithValue("@CodeReg", datework + datework + UserLabel.Text.ToString() + NoTerminal.Text.ToString());
                SalesReal.Parameters.AddWithValue("@User", ComboboxVal);
                SalesReal.Parameters.AddWithValue("@datework", datework);

                SalesReal.ExecuteNonQuery();
                SqlDataReader ssdr = SalesReal.ExecuteReader();
                //SqlException.E();
                try
                {
                    while (ssdr.Read())
                    {
                        cashCount1.RealCash.Text = ssdr["TOTALsales"].ToString();
                    }

                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message.ToString());
                }
                cn.Close();
                #endregion
                //Ventas Credito
                #region ventas credito
                cn.Open();
                SqlCommand salescredit = new SqlCommand();
                salescredit.Parameters.Clear();
                salescredit.Connection = cn;
                salescredit.CommandText = "select COALESCE(SUM([Total]),0) from CardsDetail where [Credit] = @credit and [DateReg] = @datework and [UserReg] = @User and [NumTerm] = @Number";
                salescredit.Parameters.AddWithValue("@credit", true);
                salescredit.Parameters.AddWithValue("@datework", datework);
                salescredit.Parameters.AddWithValue("@User", ComboboxVal);
                salescredit.Parameters.AddWithValue("@Number", TermAsing.Text.ToString());
                SqlDataAdapter sdacre = new SqlDataAdapter(salescredit);
                DataTable salescredits = new DataTable();
                if (sdacre != null)
                {
                    sdacre.Fill(salescredits);
                }
                decimal totalcreditssales = 0M;
                foreach (DataRow row in salescredits.Rows)
                {
                    totalcreditssales = decimal.Parse(row[0].ToString());
                }
                salesInDetail1.TotalTransfe.Text = totalcreditssales.ToString("N2");
                cn.Close();
                #endregion
                //Ventas Debito
                #region ventas Debito
                cn.Open();
                SqlCommand salesdebit = new SqlCommand();
                salesdebit.Parameters.Clear();
                salesdebit.Connection = cn;
                salesdebit.CommandText = "select COALESCE(SUM([Total]),0) from CardsDetail where ([Debit] = @debit OR [Vales] = @vales) and [DateReg] = @datework and [UserReg] = @User and [NumTerm] = @Number";
                salesdebit.Parameters.AddWithValue("@debit", true);
                salesdebit.Parameters.AddWithValue("@datework", datework);
                salesdebit.Parameters.AddWithValue("@vales", true);
                salesdebit.Parameters.AddWithValue("@User", ComboboxVal);
                salesdebit.Parameters.AddWithValue("@Number", TermAsing.Text.ToString());
                SqlDataAdapter sdadeb = new SqlDataAdapter(salesdebit);
                DataTable salesdebits = new DataTable();
                if (sdadeb != null)
                {
                    sdadeb.Fill(salesdebits);
                }
                decimal totaldebitsales = 0M;
                foreach (DataRow row in salesdebits.Rows)
                {
                    totaldebitsales = decimal.Parse(row[0].ToString());
                }
                salesInDetail1.TotalVales.Text = totaldebitsales.ToString("N2");
                cn.Close();
                #endregion
            }
        }
        #region cashpay
        public void cash(decimal cashfrompayment)
        {
            cashpay = cashfrompayment;
        }
        #endregion
        public void creditcardsdetail()
        {

        }
        private void ItemsDataGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (ItemsDataGrid.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    if (tb != null)
                    {
                        //ItemsDataGrid.Rows[0].Cells[3].Value = 1;
                    }
                }
                else
                {
                    //ItemsDataGrid.Rows[0].Cells[3].Value = 1;
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CorteCaja_Click(object sender, EventArgs e)
        {
            RCoutingFinalc cortecaja = new RCoutingFinalc();
            cortecaja.user = UserLabel.Text.ToString();
            cortecaja.terminal = NoTerminal.Text.ToString();
            /*cortecaja.detalleCorte1.Apertura.Text = cashCount1.textBox1.Text;
            cortecaja.detalleCorte1.efectivo.Text = cashCount1.textBox3.Text;
            cortecaja.salesInDetail1.TotalMoney.Text = salesInDetail1.TotalMoney.Text;*/
            cortecaja.GetAllStatics();
            cortecaja.Show();
        }

        private void metroTextButton1_Click(object sender, EventArgs e)
        {
            SyncSales SalesToNav = new SyncSales();
            SalesToNav.username = UserLabel.Text.ToString();
            SalesToNav.terminal = NoTerminal.Text.ToString();
            SalesToNav.Show(this);
        }
        public void ConectionNav()
        {

            // Create Service Reference
            WS_NAV.SalesOrder_Service service = new WS_NAV.SalesOrder_Service();
            string userconfigsfile = System.Configuration.ConfigurationManager.AppSettings["UserNav"];
            string passconfigsfile = System.Configuration.ConfigurationManager.AppSettings["PasswordNav"];
            string CustomerCodeNAV = System.Configuration.ConfigurationManager.AppSettings["customercode"];
            NetworkCredential Creden = new NetworkCredential(userconfigsfile, passconfigsfile);
            service.Credentials = Creden;

            // Create the Order header 
            SalesOrder newOrder = new SalesOrder();

            // Update Order header 
            newOrder.Status = WS_NAV.Status.Open;

            service.Create(ref newOrder);
            newOrder.Sell_to_Customer_No = CustomerCodeNAV;
            newOrder.Sell_to_Customer_Name = "Test Post3 " + DateTime.Now.ToString("HH:mm:ss");
            newOrder.Document_Date = DateTime.Today;
            // Create Order lines 
            Sales_Order_Line[] SalesOrderLines = new Sales_Order_Line[1];
            //for (int idx = 0; idx < 1; idx++)
            SalesOrderLines[0] = new Sales_Order_Line();
            service.Update(ref newOrder);
            // Update Order lines
            SalesOrderLines[0].Line_No = 1000;
            //SalesOrderLines[0].Line_NoSpecified = true;
            SalesOrderLines[0].Type = WS_NAV.Type.Item;
            SalesOrderLines[0].TypeSpecified = true;
            SalesOrderLines[0].No = "1000";
            SalesOrderLines[0].Document_No = newOrder.No;
            //SalesOrderLines[0].Location_Code = "BLUE";
            //SalesOrderLines[0].Key = "Nothing";
            SalesOrderLines[0].Quantity = 3;
            SalesOrderLines[0].QuantitySpecified = true;
            newOrder.SalesLines = SalesOrderLines;
            service.Update(ref newOrder);
            service.IsUpdated(newOrder.Key);
            //test2010.TestWS test2211 = new test2010.TestWS();
            test2110.Credentials = Creden;
            test2110.Registrar2(newOrder.No);

            string hola = test2110.Hola();

            MessageBox.Show("La Nota de Remision correspondiente a la orden:" + newOrder.No + " Se ha registrado.");


        }

        private void TabNAV_Click(object sender, EventArgs e)
        {

        }

        private void metroTextButton2_Click(object sender, EventArgs e)
        {
            SynNav SincronizaNav = new SynNav();
            Form F = new Form();
            F.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            F.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            F.Owner = this;
            SincronizaNav.PrintBancos(ProgressNavBanks, F);
        }

        private void ProgressNavBanks_Click(object sender, EventArgs e)
        {
        }

        private void metroTextButton3_Click(object sender, EventArgs e)
        {
            SynPrices SynListItems = new SynPrices();
            SynListItems.items(progressItemsPrice);
        }

        private void metroTextButton4_Click(object sender, EventArgs e)
        {
            SyncMesureCodes SyncMesures = new SyncMesureCodes();
            SyncMesures.MesureCodes(MesureBar);
        }

        private void ItemsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CashManualOut_Click(object sender, EventArgs e)
        {
            RetiroDinero outcash = new RetiroDinero();
            outcash.terminal = NoTerminal.Text.ToString();
            outcash.user = UserLabel.Text.ToString();
            outcash.ShowDialog(this);
        }

        private void ItemsDataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                ItemsDataGrid.Rows[e.RowIndex].ErrorText =
                    "La cantidad no puede ser 0 ni estar vacia";
                e.Cancel = true;
            }
        }

        private void CorteFin_Click(object sender, EventArgs e)
        {
            RCountingF cortedia = new RCountingF();
            cortedia.terminal = NoTerminal.Text.ToString();
            cortedia.user = UserLabel.Text.ToString();
            cortedia.GetAllStatics();
            //cortedia.checkusr();
            cortedia.ShowDialog(this);

        }

        private void metroTextButton5_Click(object sender, EventArgs e)
        {
            Coments comenttest = new Coments();
            comenttest.ShowDialog(this);
        }

        private void GetDataComp_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "¿Desea Descargar los datos de la compañia de NAVonAzure?", "Actualizar Compañia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SyncCompany syncCom = new SyncCompany();
                syncCom.DatCompanyFromNav();
                Application.Restart();
            }
        }

        private void GetDatSuc_Click(object sender, EventArgs e)
        {
            SyncSucursal synsucnav = new SyncSucursal();
            DialogResult result = synsucnav.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                MetroFramework.MetroMessageBox.Show(this, "Datos Actualizados" + System.Environment.NewLine + "La aplicación se reiniciara para tomar los cambios", "Actualización Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                updatesession();
                Application.Restart();
            }

        }

        private void Config_Click(object sender, EventArgs e)
        {

        }

        private void TabsPOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabsPOS.SelectedTab == TabsPOS.TabPages["Config"])//your specific tabname
            {
                CheckDataSuc();
                CheckDataStore();
                Enabledconfigs();
            }
        }

        private void CheckDataStore()
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                SqlCommand getdatasuc = new SqlCommand();
                getdatasuc.Parameters.Clear();
                con.Open();
                getdatasuc.Connection = con;
                getdatasuc.CommandText = "select TOP 1 [NameStore], [Location], [Tel], [CodeStore], [FooterTicket] from StoresDetail WHERE [no] <> 0";
                SqlDataAdapter sucda = new SqlDataAdapter(getdatasuc);
                DataTable sucdt = new DataTable();
                if (sucda != null)
                {
                    sucda.Fill(sucdt);
                }
                foreach (DataRow row in sucdt.Rows)
                {
                    SucNameText.Text = row[0].ToString();
                    LocSucText.Text = row[1].ToString();
                    PhoneSuc.Text = row[2].ToString();
                    CodeNavStore.Text = row[3].ToString();
                    Footer.Text = row[4].ToString();
                }
                con.Close();
            }
        }

        private void Enabledconfigs()
        {
            if (PermisseLevel > 1)
            {
                TerminalConfig.Enabled = false;
                ConfigUsersboton.Enabled = false;
            }
        }

        private void CheckDataSuc()
        {
            if (RFC.Text == "")
            {
                using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    SqlCommand getdatacompany = new SqlCommand();
                    getdatacompany.Parameters.Clear();
                    con.Open();
                    getdatacompany.Connection = con;
                    getdatacompany.CommandText = "select TOP 1 [NameCompany], [Location], [RFC], [Phone] from Company WHERE [no] <> 0";
                    SqlDataAdapter COMSDA = new SqlDataAdapter(getdatacompany);
                    DataTable comdt = new DataTable();
                    if (COMSDA != null)
                    {
                        COMSDA.Fill(comdt);
                    }
                    foreach (DataRow row in comdt.Rows)
                    {
                        NameCompany.Text = row[0].ToString();
                        CompanyLocation.Text = row[1].ToString();
                        RFC.Text = row[2].ToString();
                        CompanyPhone.Text = row[3].ToString();
                    }
                    con.Close();
                }
            }
        }

        private void ConfigUsers_Click(object sender, EventArgs e)
        {
            ConfigUsers configus = new ConfigUsers();
            configus.useruse = UserLabel.Text.ToString();
            configus.ShowDialog(this);
        }
        #region restartApp Members
        public void RestartAplication()
        {
            Application.Restart();
        }
        #endregion

        private void SyncPriceLists_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Sistemapos_FormClosing(object sender, FormClosingEventArgs e)
        {
            updatesession();
        }

        private void updatesession()
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                SqlCommand updatesesionsqlc = new SqlCommand();
                updatesesionsqlc.Parameters.Clear();
                updatesesionsqlc.CommandText = "Update Users set [Active] = @Active where [User]=@User";
                updatesesionsqlc.Parameters.AddWithValue("@Active", false);
                updatesesionsqlc.Parameters.AddWithValue("@User", UserLabel.Text.ToString());
                con.Open();
                updatesesionsqlc.Connection = con;
                updatesesionsqlc.ExecuteNonQuery();
                con.Close();
            }
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            updatesession();
            Application.Exit();
        }

        private void TerminalConfig_Click(object sender, EventArgs e)
        {
            AddTerminal terms = new AddTerminal();
            terms.ShowDialog(this);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            letterscount = Footer.Text.ToString().Length;
            lettersremaing = 499 - letterscount;
            metroLabel11.Text = lettersremaing.ToString();
        }

        private void metroTextButton2_Click_1(object sender, EventArgs e)
        {
            Footer.ReadOnly = false;
            metroLabel12.Visible = true;
            int remaingt = (499 - int.Parse(Footer.Text.ToString().Length.ToString()));
            metroLabel11.Visible = true;
            metroLabel11.Text = remaingt.ToString();
            
        }

        private void metroTextButton1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand comand = new SqlCommand();
                comand.Parameters.Clear();
                comand.CommandText = "Update StoresDetail set [FooterTicket] = @Footer where [CodeStore] = @CodeStore";
                comand.Connection = con;
                comand.Parameters.AddWithValue("@Footer", Footer.Text.ToString());
                comand.Parameters.AddWithValue("@CodeStore", CodeNavStore.Text.ToString());
                comand.ExecuteNonQuery();
                con.Close();
            }
            Footer.ReadOnly = true;
            metroLabel12.Visible = false;
            metroLabel11.Visible = false;
        }

        private void metroTextButton4_Click_1(object sender, EventArgs e)
        {
            AccountsConfig accountsGeneralJourn = new AccountsConfig();
            accountsGeneralJourn.ShowDialog(this);
        }

        private void MenuGrid_Opening(object sender, CancelEventArgs e)
        {

        }

        public void SuperSession()
        {
            CodeTextbox.Focus();
            ((Control)this.SyncNav).Enabled = false;
            ((Control)this.TabTerminal).Enabled = false;
            ((Control)this.TabCashOut).Enabled = false;
        }

        private void metroTextButton4_Click_2(object sender, EventArgs e)
        {
            RePrintTicket printtickets = new RePrintTicket();
            printtickets.TicketCode.Focus();
            printtickets.ShowDialog(this);
        }
    }
}