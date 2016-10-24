namespace ATX_POS
{
    partial class PaymentMix
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
            this.paymenCash1 = new ATX_POS.PaymenCash();
            this.paymentVales1 = new ATX_POS.PaymentVales();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.paymentCredit1 = new ATX_POS.PaymentCredit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // paymenCash1
            // 
            this.paymenCash1.BackColor = System.Drawing.Color.Transparent;
            this.paymenCash1.Location = new System.Drawing.Point(0, 19);
            this.paymenCash1.Name = "paymenCash1";
            this.paymenCash1.Size = new System.Drawing.Size(259, 94);
            this.paymenCash1.TabIndex = 0;
            // 
            // paymentVales1
            // 
            this.paymentVales1.Location = new System.Drawing.Point(6, 15);
            this.paymentVales1.Name = "paymentVales1";
            this.paymentVales1.Size = new System.Drawing.Size(267, 113);
            this.paymentVales1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.paymenCash1);
            this.groupBox1.Location = new System.Drawing.Point(3, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 128);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Efectivo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.paymentCredit1);
            this.groupBox2.Location = new System.Drawing.Point(402, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 202);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tarjeta de Crédito";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.paymentVales1);
            this.groupBox3.Location = new System.Drawing.Point(402, 217);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 134);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tarjeta Debito/ Vales";
            // 
            // paymentCredit1
            // 
            this.paymentCredit1.Location = new System.Drawing.Point(9, 19);
            this.paymentCredit1.Name = "paymentCredit1";
            this.paymentCredit1.Size = new System.Drawing.Size(264, 168);
            this.paymentCredit1.TabIndex = 0;
            // 
            // PaymentMix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PaymentMix";
            this.Size = new System.Drawing.Size(721, 360);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PaymenCash paymenCash1;
        private PaymentVales paymentVales1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private PaymentCredit paymentCredit1;
    }
}
