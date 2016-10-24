namespace ATX_POS
{
    partial class PaymentCredit
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
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.Banks = new System.Windows.Forms.ComboBox();
            this.BankAccount = new System.Windows.Forms.TextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.Credit = new System.Windows.Forms.TextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.AutCod = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(32, 3);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(45, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroLabel1.TabIndex = 24;
            this.metroLabel1.Text = "Banco";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(19, 33);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(72, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel2.TabIndex = 25;
            this.metroLabel2.Text = "No. Tarjeta";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel2.UseStyleColors = true;
            // 
            // Banks
            // 
            this.Banks.FormattingEnabled = true;
            this.Banks.Location = new System.Drawing.Point(138, 3);
            this.Banks.Name = "Banks";
            this.Banks.Size = new System.Drawing.Size(121, 21);
            this.Banks.TabIndex = 29;
            this.Banks.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // BankAccount
            // 
            this.BankAccount.Location = new System.Drawing.Point(138, 33);
            this.BankAccount.MaxLength = 4;
            this.BankAccount.Name = "BankAccount";
            this.BankAccount.Size = new System.Drawing.Size(121, 20);
            this.BankAccount.TabIndex = 30;
            this.BankAccount.TextChanged += new System.EventHandler(this.BankAccount_TextChanged);
            this.BankAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BankAccount_KeyPress);
            this.BankAccount.Leave += new System.EventHandler(this.BankAccount_Leave);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(29, 62);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(48, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel5.TabIndex = 33;
            this.metroLabel5.Text = "Monto";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel5.UseStyleColors = true;
            // 
            // Credit
            // 
            this.Credit.Location = new System.Drawing.Point(138, 62);
            this.Credit.MaxLength = 100;
            this.Credit.Name = "Credit";
            this.Credit.Size = new System.Drawing.Size(121, 20);
            this.Credit.TabIndex = 34;
            this.Credit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(3, 92);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(114, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel6.TabIndex = 35;
            this.metroLabel6.Text = "Cod. Autorización";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel6.UseStyleColors = true;
            // 
            // AutCod
            // 
            this.AutCod.Location = new System.Drawing.Point(138, 90);
            this.AutCod.MaxLength = 5;
            this.AutCod.Name = "AutCod";
            this.AutCod.Size = new System.Drawing.Size(121, 20);
            this.AutCod.TabIndex = 36;
            this.AutCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AutCod_KeyPress);
            // 
            // PaymentCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AutCod);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.Credit);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.BankAccount);
            this.Controls.Add(this.Banks);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "PaymentCredit";
            this.Size = new System.Drawing.Size(264, 119);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        public System.Windows.Forms.ComboBox Banks;
        public System.Windows.Forms.TextBox BankAccount;
        public System.Windows.Forms.TextBox Credit;
        public System.Windows.Forms.TextBox AutCod;
    }
}
