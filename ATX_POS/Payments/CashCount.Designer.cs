namespace ATX_POS
{
    partial class CashCount
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
            this.FondoCajaTexto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TotalCambios = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.VentasEfectivoTexto = new System.Windows.Forms.TextBox();
            this.RealCash = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FondoCajaTexto
            // 
            this.FondoCajaTexto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FondoCajaTexto.Enabled = false;
            this.FondoCajaTexto.Location = new System.Drawing.Point(160, 3);
            this.FondoCajaTexto.MaximumSize = new System.Drawing.Size(80, 24);
            this.FondoCajaTexto.MinimumSize = new System.Drawing.Size(60, 18);
            this.FondoCajaTexto.Name = "FondoCajaTexto";
            this.FondoCajaTexto.Size = new System.Drawing.Size(60, 13);
            this.FondoCajaTexto.TabIndex = 17;
            this.FondoCajaTexto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Azure;
            this.label4.Location = new System.Drawing.Point(-3, 0);
            this.label4.MaximumSize = new System.Drawing.Size(250, 25);
            this.label4.MinimumSize = new System.Drawing.Size(230, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Fondo en Caja";
            // 
            // TotalCambios
            // 
            this.TotalCambios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TotalCambios.Enabled = false;
            this.TotalCambios.ForeColor = System.Drawing.Color.DarkRed;
            this.TotalCambios.Location = new System.Drawing.Point(160, 52);
            this.TotalCambios.MaximumSize = new System.Drawing.Size(80, 24);
            this.TotalCambios.MinimumSize = new System.Drawing.Size(60, 18);
            this.TotalCambios.Name = "TotalCambios";
            this.TotalCambios.Size = new System.Drawing.Size(60, 13);
            this.TotalCambios.TabIndex = 19;
            this.TotalCambios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.OldLace;
            this.label1.Location = new System.Drawing.Point(-3, 49);
            this.label1.MaximumSize = new System.Drawing.Size(250, 25);
            this.label1.MinimumSize = new System.Drawing.Size(230, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Saldos cambios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Beige;
            this.label2.Location = new System.Drawing.Point(-3, 24);
            this.label2.MaximumSize = new System.Drawing.Size(250, 25);
            this.label2.MinimumSize = new System.Drawing.Size(230, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Saldo Ventas Efectivo";
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(160, 77);
            this.textBox4.MaximumSize = new System.Drawing.Size(80, 24);
            this.textBox4.MinimumSize = new System.Drawing.Size(60, 18);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(60, 13);
            this.textBox4.TabIndex = 23;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VentasEfectivoTexto
            // 
            this.VentasEfectivoTexto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VentasEfectivoTexto.Enabled = false;
            this.VentasEfectivoTexto.Location = new System.Drawing.Point(160, 27);
            this.VentasEfectivoTexto.MaximumSize = new System.Drawing.Size(80, 24);
            this.VentasEfectivoTexto.MinimumSize = new System.Drawing.Size(60, 18);
            this.VentasEfectivoTexto.Name = "VentasEfectivoTexto";
            this.VentasEfectivoTexto.Size = new System.Drawing.Size(60, 13);
            this.VentasEfectivoTexto.TabIndex = 21;
            this.VentasEfectivoTexto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RealCash
            // 
            this.RealCash.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RealCash.Location = new System.Drawing.Point(161, 78);
            this.RealCash.MaximumSize = new System.Drawing.Size(80, 24);
            this.RealCash.MinimumSize = new System.Drawing.Size(60, 18);
            this.RealCash.Name = "RealCash";
            this.RealCash.ReadOnly = true;
            this.RealCash.Size = new System.Drawing.Size(60, 13);
            this.RealCash.TabIndex = 25;
            this.RealCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Azure;
            this.label5.Location = new System.Drawing.Point(-2, 75);
            this.label5.MaximumSize = new System.Drawing.Size(250, 25);
            this.label5.MinimumSize = new System.Drawing.Size(230, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "Saldo Ventas Usuario";
            // 
            // CashCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.RealCash);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.VentasEfectivoTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TotalCambios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FondoCajaTexto);
            this.Controls.Add(this.label4);
            this.Name = "CashCount";
            this.Size = new System.Drawing.Size(229, 102);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox FondoCajaTexto;
        public System.Windows.Forms.TextBox TotalCambios;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox VentasEfectivoTexto;
        public System.Windows.Forms.TextBox RealCash;
        private System.Windows.Forms.Label label5;
    }
}
