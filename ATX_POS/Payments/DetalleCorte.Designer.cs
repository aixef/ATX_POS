namespace ATX_POS
{
    partial class DetalleCorte
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.Apertura = new MetroFramework.Controls.MetroLabel();
            this.TotalBill = new MetroFramework.Controls.MetroLabel();
            this.TotalCash = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.efectivo = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Coins = new System.Windows.Forms.TextBox();
            this.Bills = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Debits = new System.Windows.Forms.TextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.Credits = new System.Windows.Forms.TextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(59, 71);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(102, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Efectivo en Caja";
            this.metroLabel1.UseStyleColors = true;
            // 
            // Apertura
            // 
            this.Apertura.Location = new System.Drawing.Point(172, 35);
            this.Apertura.MinimumSize = new System.Drawing.Size(83, 19);
            this.Apertura.Name = "Apertura";
            this.Apertura.Size = new System.Drawing.Size(83, 19);
            this.Apertura.TabIndex = 1;
            this.Apertura.Text = "0.00";
            this.Apertura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalBill
            // 
            this.TotalBill.AutoSize = true;
            this.TotalBill.Location = new System.Drawing.Point(59, 119);
            this.TotalBill.Name = "TotalBill";
            this.TotalBill.Size = new System.Drawing.Size(86, 19);
            this.TotalBill.Style = MetroFramework.MetroColorStyle.Orange;
            this.TotalBill.TabIndex = 2;
            this.TotalBill.Text = "Saldo Billetes";
            this.TotalBill.UseStyleColors = true;
            this.TotalBill.Click += new System.EventHandler(this.TotalBill_Click);
            // 
            // TotalCash
            // 
            this.TotalCash.AutoSize = true;
            this.TotalCash.Location = new System.Drawing.Point(59, 147);
            this.TotalCash.Name = "TotalCash";
            this.TotalCash.Size = new System.Drawing.Size(100, 19);
            this.TotalCash.Style = MetroFramework.MetroColorStyle.Orange;
            this.TotalCash.TabIndex = 3;
            this.TotalCash.Text = "Saldo Monedas";
            this.TotalCash.UseStyleColors = true;
            this.TotalCash.Click += new System.EventHandler(this.TotalCash_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(59, 35);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(99, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel5.TabIndex = 6;
            this.metroLabel5.Text = "Saldo Apertura";
            this.metroLabel5.UseStyleColors = true;
            // 
            // efectivo
            // 
            this.efectivo.Location = new System.Drawing.Point(172, 71);
            this.efectivo.MinimumSize = new System.Drawing.Size(83, 19);
            this.efectivo.Name = "efectivo";
            this.efectivo.Size = new System.Drawing.Size(83, 19);
            this.efectivo.TabIndex = 7;
            this.efectivo.Text = "0.00";
            this.efectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Coins);
            this.groupBox1.Controls.Add(this.Bills);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.metroLabel5);
            this.groupBox1.Controls.Add(this.efectivo);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.Apertura);
            this.groupBox1.Controls.Add(this.TotalBill);
            this.groupBox1.Controls.Add(this.TotalCash);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 175);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ventas Turno";
            // 
            // Coins
            // 
            this.Coins.Location = new System.Drawing.Point(172, 146);
            this.Coins.Name = "Coins";
            this.Coins.Size = new System.Drawing.Size(83, 20);
            this.Coins.TabIndex = 10;
            this.Coins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Coins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Bills
            // 
            this.Bills.Location = new System.Drawing.Point(172, 119);
            this.Bills.Name = "Bills";
            this.Bills.Size = new System.Drawing.Size(83, 20);
            this.Bills.TabIndex = 9;
            this.Bills.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Bills.Enter += new System.EventHandler(this.Bills_Enter);
            this.Bills.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Bills_KeyPress);
            this.Bills.Validating += new System.ComponentModel.CancelEventHandler(this.Bills_Validating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ATX_POS.Properties.Resources._1469240780_coins;
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.Debits);
            this.groupBox2.Controls.Add(this.metroLabel2);
            this.groupBox2.Controls.Add(this.Credits);
            this.groupBox2.Controls.Add(this.metroLabel3);
            this.groupBox2.Location = new System.Drawing.Point(3, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 78);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ATX_POS.Properties.Resources._1469240360_credit_cards;
            this.pictureBox2.Location = new System.Drawing.Point(6, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // Debits
            // 
            this.Debits.Location = new System.Drawing.Point(172, 43);
            this.Debits.Name = "Debits";
            this.Debits.Size = new System.Drawing.Size(83, 20);
            this.Debits.TabIndex = 12;
            this.Debits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Debits.Enter += new System.EventHandler(this.Debits_Enter);
            this.Debits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Debits_KeyPress);
            this.Debits.Validating += new System.ComponentModel.CancelEventHandler(this.Debits_Validating);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(59, 16);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(101, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel2.TabIndex = 11;
            this.metroLabel2.Text = "Saldo a Crédito";
            this.metroLabel2.UseStyleColors = true;
            // 
            // Credits
            // 
            this.Credits.Location = new System.Drawing.Point(172, 16);
            this.Credits.Name = "Credits";
            this.Credits.Size = new System.Drawing.Size(83, 20);
            this.Credits.TabIndex = 11;
            this.Credits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Credits.Enter += new System.EventHandler(this.Credits_Enter);
            this.Credits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.Credits.Validating += new System.ComponentModel.CancelEventHandler(this.Credits_Validating);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(59, 44);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(103, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Saldo en Débito";
            this.metroLabel3.UseStyleColors = true;
            // 
            // DetalleCorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DetalleCorte";
            this.Size = new System.Drawing.Size(270, 283);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel TotalBill;
        private MetroFramework.Controls.MetroLabel TotalCash;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public MetroFramework.Controls.MetroLabel Apertura;
        public MetroFramework.Controls.MetroLabel efectivo;
        public System.Windows.Forms.TextBox Coins;
        public System.Windows.Forms.TextBox Bills;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox Debits;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public System.Windows.Forms.TextBox Credits;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        public MetroFramework.Controls.MetroLabel metroLabel5;
    }
}
