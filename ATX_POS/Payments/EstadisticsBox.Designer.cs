namespace ATX_POS
{
    partial class EstadisticsBox
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
            this.TotalCasingUps = new System.Windows.Forms.TextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.salescash = new System.Windows.Forms.TextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.CreditTotal = new System.Windows.Forms.TextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.debittotal = new System.Windows.Forms.TextBox();
            this.Totalouts = new System.Windows.Forms.TextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(76, 57);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(164, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Saldos de Aperturas";
            this.metroLabel1.UseStyleColors = true;
            // 
            // TotalCasingUps
            // 
            this.TotalCasingUps.Location = new System.Drawing.Point(246, 62);
            this.TotalCasingUps.MaxLength = 100;
            this.TotalCasingUps.Name = "TotalCasingUps";
            this.TotalCasingUps.ReadOnly = true;
            this.TotalCasingUps.Size = new System.Drawing.Size(73, 20);
            this.TotalCasingUps.TabIndex = 2;
            this.TotalCasingUps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(91, 104);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(124, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Ventas Efectivo";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel2.UseStyleColors = true;
            // 
            // salescash
            // 
            this.salescash.Location = new System.Drawing.Point(246, 109);
            this.salescash.MaxLength = 100;
            this.salescash.Name = "salescash";
            this.salescash.ReadOnly = true;
            this.salescash.Size = new System.Drawing.Size(73, 20);
            this.salescash.TabIndex = 4;
            this.salescash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.salescash.TextChanged += new System.EventHandler(this.salescash_TextChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(94, 155);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(121, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Ventas Crédito";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel3.UseStyleColors = true;
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // CreditTotal
            // 
            this.CreditTotal.Location = new System.Drawing.Point(246, 155);
            this.CreditTotal.MaxLength = 100;
            this.CreditTotal.Name = "CreditTotal";
            this.CreditTotal.ReadOnly = true;
            this.CreditTotal.Size = new System.Drawing.Size(73, 20);
            this.CreditTotal.TabIndex = 6;
            this.CreditTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(94, 210);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(116, 25);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Ventas Debito";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel4.UseStyleColors = true;
            // 
            // debittotal
            // 
            this.debittotal.Location = new System.Drawing.Point(246, 215);
            this.debittotal.MaxLength = 100;
            this.debittotal.Name = "debittotal";
            this.debittotal.ReadOnly = true;
            this.debittotal.Size = new System.Drawing.Size(73, 20);
            this.debittotal.TabIndex = 10;
            this.debittotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Totalouts
            // 
            this.Totalouts.Location = new System.Drawing.Point(246, 275);
            this.Totalouts.MaxLength = 100;
            this.Totalouts.Name = "Totalouts";
            this.Totalouts.ReadOnly = true;
            this.Totalouts.Size = new System.Drawing.Size(73, 20);
            this.Totalouts.TabIndex = 13;
            this.Totalouts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.Location = new System.Drawing.Point(97, 270);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(103, 25);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Total Salidas";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel5.UseStyleColors = true;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Image = global::ATX_POS.Properties.Resources._1472612285_cash_receiving;
            this.pictureBox5.Location = new System.Drawing.Point(12, 255);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(58, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.Image = global::ATX_POS.Properties.Resources._1472612063_advantage_payment_way;
            this.pictureBox4.Location = new System.Drawing.Point(12, 199);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(58, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = global::ATX_POS.Properties.Resources._1472611953_23;
            this.pictureBox3.Location = new System.Drawing.Point(12, 87);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(58, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = global::ATX_POS.Properties.Resources._1472611814_credit_cards;
            this.pictureBox2.Location = new System.Drawing.Point(12, 143);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::ATX_POS.Properties.Resources._1472611308_Cash_register;
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // EstadisticsBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.Totalouts);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.debittotal);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.CreditTotal);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.salescash);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.TotalCasingUps);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroLabel1);
            this.Name = "EstadisticsBox";
            this.Size = new System.Drawing.Size(322, 324);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox TotalCasingUps;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public System.Windows.Forms.TextBox salescash;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        public System.Windows.Forms.TextBox CreditTotal;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        public System.Windows.Forms.TextBox debittotal;
        private System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.TextBox Totalouts;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}
