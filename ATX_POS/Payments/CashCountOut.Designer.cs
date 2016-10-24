namespace ATX_POS.PaymentsCash
{
    partial class CashCountOut
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
            this.fondolabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.InitCash = new System.Windows.Forms.TextBox();
            this.SalesCash = new System.Windows.Forms.TextBox();
            this.CashOut = new System.Windows.Forms.TextBox();
            this.TotalCashOut = new System.Windows.Forms.TextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.TotalinBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fondolabel
            // 
            this.fondolabel.AutoSize = true;
            this.fondolabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.fondolabel.Location = new System.Drawing.Point(3, 14);
            this.fondolabel.Name = "fondolabel";
            this.fondolabel.Size = new System.Drawing.Size(119, 25);
            this.fondolabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.fondolabel.TabIndex = 0;
            this.fondolabel.Text = "Fondo en caja";
            this.fondolabel.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(3, 53);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(148, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Ventas en Efectivo";
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(3, 90);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(64, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Salidas";
            this.metroLabel2.UseStyleColors = true;
            this.metroLabel2.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(3, 180);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(144, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Cantidad a retirar";
            this.metroLabel3.UseStyleColors = true;
            // 
            // InitCash
            // 
            this.InitCash.Location = new System.Drawing.Point(160, 19);
            this.InitCash.Name = "InitCash";
            this.InitCash.ReadOnly = true;
            this.InitCash.Size = new System.Drawing.Size(100, 20);
            this.InitCash.TabIndex = 4;
            this.InitCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SalesCash
            // 
            this.SalesCash.Location = new System.Drawing.Point(160, 58);
            this.SalesCash.Name = "SalesCash";
            this.SalesCash.ReadOnly = true;
            this.SalesCash.Size = new System.Drawing.Size(100, 20);
            this.SalesCash.TabIndex = 5;
            this.SalesCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CashOut
            // 
            this.CashOut.Location = new System.Drawing.Point(160, 90);
            this.CashOut.Name = "CashOut";
            this.CashOut.ReadOnly = true;
            this.CashOut.Size = new System.Drawing.Size(100, 20);
            this.CashOut.TabIndex = 6;
            this.CashOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TotalCashOut
            // 
            this.TotalCashOut.Location = new System.Drawing.Point(160, 185);
            this.TotalCashOut.Name = "TotalCashOut";
            this.TotalCashOut.Size = new System.Drawing.Size(100, 20);
            this.TotalCashOut.TabIndex = 7;
            this.TotalCashOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalCashOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(3, 132);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(102, 25);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Brown;
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Total Dinero";
            this.metroLabel4.UseStyleColors = true;
            // 
            // TotalinBox
            // 
            this.TotalinBox.Location = new System.Drawing.Point(160, 137);
            this.TotalinBox.Name = "TotalinBox";
            this.TotalinBox.ReadOnly = true;
            this.TotalinBox.Size = new System.Drawing.Size(100, 20);
            this.TotalinBox.TabIndex = 9;
            this.TotalinBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CashCountOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.TotalinBox);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.TotalCashOut);
            this.Controls.Add(this.CashOut);
            this.Controls.Add(this.SalesCash);
            this.Controls.Add(this.InitCash);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.fondolabel);
            this.Name = "CashCountOut";
            this.Size = new System.Drawing.Size(270, 233);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel fondolabel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        public System.Windows.Forms.TextBox InitCash;
        public System.Windows.Forms.TextBox TotalinBox;
        public System.Windows.Forms.TextBox SalesCash;
        public System.Windows.Forms.TextBox CashOut;
        public System.Windows.Forms.TextBox TotalCashOut;
    }
}
