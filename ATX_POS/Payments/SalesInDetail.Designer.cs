namespace ATX_POS
{
    partial class 
        SalesInDetail
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.TotalCash = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.TotalMoney = new MetroFramework.Controls.MetroLabel();
            this.TotalTransfe = new MetroFramework.Controls.MetroLabel();
            this.TotalVales = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cashout = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.totalManualOuts = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TotalMoneyBox = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(75, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(94, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Detalles ventas";
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(33, 50);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(83, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Saldo Ventas";
            this.metroLabel2.UseStyleColors = true;
            // 
            // TotalCash
            // 
            this.TotalCash.Location = new System.Drawing.Point(138, 50);
            this.TotalCash.MinimumSize = new System.Drawing.Size(26, 19);
            this.TotalCash.Name = "TotalCash";
            this.TotalCash.Size = new System.Drawing.Size(61, 19);
            this.TotalCash.Style = MetroFramework.MetroColorStyle.Green;
            this.TotalCash.TabIndex = 2;
            this.TotalCash.Text = "0.0";
            this.TotalCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TotalCash.UseStyleColors = true;
            this.TotalCash.Enter += new System.EventHandler(this.TotalCash_Enter);
            this.TotalCash.Validated += new System.EventHandler(this.TotalCash_Validated);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(33, 79);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(106, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Efectivo Entrante";
            this.metroLabel3.UseStyleColors = true;
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(33, 107);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(53, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel4.TabIndex = 4;
            this.metroLabel4.Text = "Crédito";
            this.metroLabel4.UseStyleColors = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(33, 137);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(81, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel5.TabIndex = 5;
            this.metroLabel5.Text = "Vales/Débito";
            this.metroLabel5.UseStyleColors = true;
            // 
            // TotalMoney
            // 
            this.TotalMoney.Location = new System.Drawing.Point(138, 79);
            this.TotalMoney.MinimumSize = new System.Drawing.Size(26, 19);
            this.TotalMoney.Name = "TotalMoney";
            this.TotalMoney.Size = new System.Drawing.Size(61, 19);
            this.TotalMoney.Style = MetroFramework.MetroColorStyle.Green;
            this.TotalMoney.TabIndex = 7;
            this.TotalMoney.Text = "0.0";
            this.TotalMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TotalMoney.UseStyleColors = true;
            this.TotalMoney.Enter += new System.EventHandler(this.TotalMoney_Enter);
            this.TotalMoney.Validated += new System.EventHandler(this.TotalCash_Validated);
            // 
            // TotalTransfe
            // 
            this.TotalTransfe.Location = new System.Drawing.Point(138, 107);
            this.TotalTransfe.MinimumSize = new System.Drawing.Size(26, 19);
            this.TotalTransfe.Name = "TotalTransfe";
            this.TotalTransfe.Size = new System.Drawing.Size(61, 19);
            this.TotalTransfe.Style = MetroFramework.MetroColorStyle.Green;
            this.TotalTransfe.TabIndex = 8;
            this.TotalTransfe.Text = "0.0";
            this.TotalTransfe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TotalTransfe.UseStyleColors = true;
            this.TotalTransfe.Enter += new System.EventHandler(this.TotalTransfe_Enter);
            this.TotalTransfe.Validated += new System.EventHandler(this.TotalCash_Validated);
            // 
            // TotalVales
            // 
            this.TotalVales.Location = new System.Drawing.Point(138, 137);
            this.TotalVales.MinimumSize = new System.Drawing.Size(26, 19);
            this.TotalVales.Name = "TotalVales";
            this.TotalVales.Size = new System.Drawing.Size(61, 19);
            this.TotalVales.Style = MetroFramework.MetroColorStyle.Green;
            this.TotalVales.TabIndex = 9;
            this.TotalVales.Text = "0.0";
            this.TotalVales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TotalVales.UseStyleColors = true;
            this.TotalVales.Enter += new System.EventHandler(this.TotalVales_Enter);
            this.TotalVales.Validated += new System.EventHandler(this.TotalCash_Validated);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ATX_POS.Properties.Resources._1469240837_line_chart;
            this.pictureBox1.Location = new System.Drawing.Point(17, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // cashout
            // 
            this.cashout.Location = new System.Drawing.Point(138, 166);
            this.cashout.MinimumSize = new System.Drawing.Size(26, 19);
            this.cashout.Name = "cashout";
            this.cashout.Size = new System.Drawing.Size(61, 19);
            this.cashout.Style = MetroFramework.MetroColorStyle.Green;
            this.cashout.TabIndex = 12;
            this.cashout.Text = "0.0";
            this.cashout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cashout.UseStyleColors = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(17, 166);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(131, 19);
            this.metroLabel7.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel7.TabIndex = 11;
            this.metroLabel7.Text = "Total Salidas Cambio";
            this.metroLabel7.UseStyleColors = true;
            // 
            // totalManualOuts
            // 
            this.totalManualOuts.Location = new System.Drawing.Point(138, 195);
            this.totalManualOuts.MinimumSize = new System.Drawing.Size(26, 19);
            this.totalManualOuts.Name = "totalManualOuts";
            this.totalManualOuts.Size = new System.Drawing.Size(61, 19);
            this.totalManualOuts.Style = MetroFramework.MetroColorStyle.Green;
            this.totalManualOuts.TabIndex = 14;
            this.totalManualOuts.Text = "0.0";
            this.totalManualOuts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.totalManualOuts.UseStyleColors = true;
            this.totalManualOuts.MouseHover += new System.EventHandler(this.metroLabel6_MouseHover);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(33, 195);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(80, 19);
            this.metroLabel8.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel8.TabIndex = 13;
            this.metroLabel8.Text = "Total Retiros";
            this.metroLabel8.UseStyleColors = true;
            // 
            // TotalMoneyBox
            // 
            this.TotalMoneyBox.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.TotalMoneyBox.Location = new System.Drawing.Point(125, 225);
            this.TotalMoneyBox.MinimumSize = new System.Drawing.Size(26, 19);
            this.TotalMoneyBox.Name = "TotalMoneyBox";
            this.TotalMoneyBox.Size = new System.Drawing.Size(74, 25);
            this.TotalMoneyBox.Style = MetroFramework.MetroColorStyle.Teal;
            this.TotalMoneyBox.TabIndex = 16;
            this.TotalMoneyBox.Text = "0.0";
            this.TotalMoneyBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TotalMoneyBox.UseStyleColors = true;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel9.Location = new System.Drawing.Point(17, 225);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(102, 25);
            this.metroLabel9.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel9.TabIndex = 15;
            this.metroLabel9.Text = "Total Dinero";
            this.metroLabel9.UseStyleColors = true;
            // 
            // SalesInDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TotalMoneyBox);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.totalManualOuts);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.cashout);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TotalMoney);
            this.Controls.Add(this.TotalVales);
            this.Controls.Add(this.TotalTransfe);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.TotalCash);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "SalesInDetail";
            this.Size = new System.Drawing.Size(216, 261);
            this.Load += new System.EventHandler(this.SalesInDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        public MetroFramework.Controls.MetroLabel TotalMoney;
        public MetroFramework.Controls.MetroLabel TotalCash;
        public MetroFramework.Controls.MetroLabel TotalTransfe;
        public MetroFramework.Controls.MetroLabel TotalVales;
        private System.Windows.Forms.PictureBox pictureBox1;
        public MetroFramework.Controls.MetroLabel cashout;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        public MetroFramework.Controls.MetroLabel totalManualOuts;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private System.Windows.Forms.ToolTip toolTip1;
        public MetroFramework.Controls.MetroLabel TotalMoneyBox;
        private MetroFramework.Controls.MetroLabel metroLabel9;
    }
}
