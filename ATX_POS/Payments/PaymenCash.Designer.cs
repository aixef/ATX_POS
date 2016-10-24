namespace ATX_POS
{
    partial class PaymenCash
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TotalRecived = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Remainingtext = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(86, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 35);
            this.label3.TabIndex = 18;
            this.label3.Text = "$";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("NSimSun", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Paga con: ";
            // 
            // TotalRecived
            // 
            this.TotalRecived.Font = new System.Drawing.Font("Perpetua", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalRecived.ForeColor = System.Drawing.Color.MediumBlue;
            this.TotalRecived.Location = new System.Drawing.Point(120, 16);
            this.TotalRecived.Name = "TotalRecived";
            this.TotalRecived.Size = new System.Drawing.Size(121, 29);
            this.TotalRecived.TabIndex = 19;
            this.TotalRecived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalRecived.TextChanged += new System.EventHandler(this.TotalRecived_TextChanged);
            this.TotalRecived.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TotalRecived_KeyPress_1);
            this.TotalRecived.Leave += new System.EventHandler(this.TotalRecived_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("NSimSun", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "Cambio";
            // 
            // Remainingtext
            // 
            this.Remainingtext.Location = new System.Drawing.Point(120, 68);
            this.Remainingtext.MaximumSize = new System.Drawing.Size(121, 30);
            this.Remainingtext.MinimumSize = new System.Drawing.Size(121, 30);
            this.Remainingtext.Name = "Remainingtext";
            this.Remainingtext.Size = new System.Drawing.Size(121, 20);
            this.Remainingtext.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(86, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 35);
            this.label4.TabIndex = 22;
            this.label4.Text = "$";
            // 
            // PaymenCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Remainingtext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TotalRecived);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "PaymenCash";
            this.Size = new System.Drawing.Size(278, 94);
            this.Load += new System.EventHandler(this.PaymenCash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TotalRecived;
        public System.Windows.Forms.TextBox Remainingtext;

    }
}
