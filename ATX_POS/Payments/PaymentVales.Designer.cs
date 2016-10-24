namespace ATX_POS
{
    partial class PaymentVales
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
            this.AutCod = new System.Windows.Forms.TextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.debittotal = new System.Windows.Forms.TextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.BankAccount = new System.Windows.Forms.TextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.Type = new System.Windows.Forms.ComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.Banks = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AutCod
            // 
            this.AutCod.Location = new System.Drawing.Point(142, 115);
            this.AutCod.MaxLength = 5;
            this.AutCod.Name = "AutCod";
            this.AutCod.Size = new System.Drawing.Size(121, 20);
            this.AutCod.TabIndex = 48;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(3, 113);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(114, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel6.TabIndex = 47;
            this.metroLabel6.Text = "Cod. Autorización";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel6.UseStyleColors = true;
            // 
            // debittotal
            // 
            this.debittotal.Location = new System.Drawing.Point(142, 89);
            this.debittotal.Name = "debittotal";
            this.debittotal.Size = new System.Drawing.Size(121, 20);
            this.debittotal.TabIndex = 46;
            this.debittotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.debittotal_KeyPress);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(33, 89);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(48, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel5.TabIndex = 45;
            this.metroLabel5.Text = "Monto";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel5.UseStyleColors = true;
            // 
            // BankAccount
            // 
            this.BankAccount.Location = new System.Drawing.Point(142, 60);
            this.BankAccount.MaxLength = 4;
            this.BankAccount.Name = "BankAccount";
            this.BankAccount.Size = new System.Drawing.Size(121, 20);
            this.BankAccount.TabIndex = 42;
            this.BankAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BankAccount_KeyPress);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 60);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(72, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel2.TabIndex = 38;
            this.metroLabel2.Text = "No. Tarjeta";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel2.UseStyleColors = true;
            // 
            // Type
            // 
            this.Type.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Type.FormattingEnabled = true;
            this.Type.Items.AddRange(new object[] {
            "Vales",
            "Debito"});
            this.Type.Location = new System.Drawing.Point(142, 3);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(121, 21);
            this.Type.TabIndex = 50;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(43, 5);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(35, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel3.TabIndex = 51;
            this.metroLabel3.Text = "Tipo";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel3.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(36, 30);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(45, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroLabel1.TabIndex = 37;
            this.metroLabel1.Text = "Banco";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.UseStyleColors = true;
            // 
            // Banks
            // 
            this.Banks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Banks.FormattingEnabled = true;
            this.Banks.Location = new System.Drawing.Point(142, 33);
            this.Banks.Name = "Banks";
            this.Banks.Size = new System.Drawing.Size(121, 21);
            this.Banks.TabIndex = 49;
            this.Banks.Click += new System.EventHandler(this.Banks_Click);
            // 
            // PaymentVales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.Type);
            this.Controls.Add(this.Banks);
            this.Controls.Add(this.AutCod);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.debittotal);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.BankAccount);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "PaymentVales";
            this.Size = new System.Drawing.Size(267, 141);
            this.Load += new System.EventHandler(this.PaymentVales_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public System.Windows.Forms.TextBox BankAccount;
        public System.Windows.Forms.TextBox debittotal;
        public System.Windows.Forms.TextBox AutCod;
        public System.Windows.Forms.ComboBox Type;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        public System.Windows.Forms.ComboBox Banks;
    }
}
