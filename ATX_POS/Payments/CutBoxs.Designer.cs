namespace ATX_POS
{
    partial class CutBoxs
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
            this.cashfound = new System.Windows.Forms.TextBox();
            this.RealMoneyCash = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(3, 44);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(216, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Fondo en caja último corte";
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(53, 109);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(117, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Saldo Efectivo";
            this.metroLabel2.UseStyleColors = true;
            // 
            // cashfound
            // 
            this.cashfound.Location = new System.Drawing.Point(54, 72);
            this.cashfound.MaxLength = 100;
            this.cashfound.Name = "cashfound";
            this.cashfound.ReadOnly = true;
            this.cashfound.Size = new System.Drawing.Size(116, 20);
            this.cashfound.TabIndex = 3;
            this.cashfound.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RealMoneyCash
            // 
            this.RealMoneyCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RealMoneyCash.ForeColor = System.Drawing.Color.Red;
            this.RealMoneyCash.Location = new System.Drawing.Point(54, 137);
            this.RealMoneyCash.MaxLength = 100;
            this.RealMoneyCash.Name = "RealMoneyCash";
            this.RealMoneyCash.ReadOnly = true;
            this.RealMoneyCash.Size = new System.Drawing.Size(116, 26);
            this.RealMoneyCash.TabIndex = 4;
            this.RealMoneyCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CutBoxs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.RealMoneyCash);
            this.Controls.Add(this.cashfound);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "CutBoxs";
            this.Size = new System.Drawing.Size(226, 183);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public System.Windows.Forms.TextBox cashfound;
        public System.Windows.Forms.TextBox RealMoneyCash;
    }
}
