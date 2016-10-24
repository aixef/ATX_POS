namespace ATX_POS
{
    partial class Payments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.Totalling = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SalesCancel = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.metroTextButton1 = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.metroTextButton2 = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.CreditImagen = new System.Windows.Forms.PictureBox();
            this.DebitImagen = new System.Windows.Forms.PictureBox();
            this.EfectivoImagen = new System.Windows.Forms.PictureBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.efectivo = new MetroFramework.Controls.MetroCheckBox();
            this.PaymentsForms = new System.Windows.Forms.GroupBox();
            this.MixPayment = new MetroFramework.Controls.MetroCheckBox();
            this.debito = new MetroFramework.Controls.MetroCheckBox();
            this.credito = new MetroFramework.Controls.MetroCheckBox();
            this.paymentVales2 = new ATX_POS.PaymentVales();
            this.paymentCredit2 = new ATX_POS.PaymentCredit();
            this.paymenCash2 = new ATX_POS.PaymenCash();
            ((System.ComponentModel.ISupportInitialize)(this.CreditImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebitImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EfectivoImagen)).BeginInit();
            this.PaymentsForms.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(180, 58);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(109, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Total a pagar";
            this.metroLabel1.UseStyleColors = true;
            // 
            // Totalling
            // 
            this.Totalling.AcceptsReturn = true;
            this.Totalling.AccessibleName = "TotalVenta";
            this.Totalling.BackColor = System.Drawing.Color.White;
            this.Totalling.Font = new System.Drawing.Font("Microsoft Tai Le", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Totalling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Totalling.Location = new System.Drawing.Point(143, 89);
            this.Totalling.Name = "Totalling";
            this.Totalling.ReadOnly = true;
            this.Totalling.Size = new System.Drawing.Size(189, 41);
            this.Totalling.TabIndex = 10;
            this.Totalling.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Totalling.TextChanged += new System.EventHandler(this.Totalling_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(109, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 35);
            this.label1.TabIndex = 8;
            this.label1.Text = "$";
            // 
            // SalesCancel
            // 
            this.SalesCancel.Image = null;
            this.SalesCancel.Location = new System.Drawing.Point(23, 398);
            this.SalesCancel.Name = "SalesCancel";
            this.SalesCancel.Size = new System.Drawing.Size(101, 23);
            this.SalesCancel.Style = MetroFramework.MetroColorStyle.Red;
            this.SalesCancel.TabIndex = 13;
            this.SalesCancel.Text = "&Cancelar Venta";
            this.SalesCancel.UseSelectable = true;
            this.SalesCancel.UseStyleColors = true;
            this.SalesCancel.UseVisualStyleBackColor = true;
            this.SalesCancel.Click += new System.EventHandler(this.SalesCancel_Click);
            // 
            // metroTextButton1
            // 
            this.metroTextButton1.Image = null;
            this.metroTextButton1.Location = new System.Drawing.Point(318, 398);
            this.metroTextButton1.Name = "metroTextButton1";
            this.metroTextButton1.Size = new System.Drawing.Size(111, 23);
            this.metroTextButton1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTextButton1.TabIndex = 17;
            this.metroTextButton1.Text = "&Registrar Venta";
            this.metroTextButton1.UseSelectable = true;
            this.metroTextButton1.UseVisualStyleBackColor = true;
            this.metroTextButton1.Click += new System.EventHandler(this.metroTextButton1_Click);
            // 
            // metroTextButton2
            // 
            this.metroTextButton2.Image = null;
            this.metroTextButton2.Location = new System.Drawing.Point(172, 398);
            this.metroTextButton2.Name = "metroTextButton2";
            this.metroTextButton2.Size = new System.Drawing.Size(111, 23);
            this.metroTextButton2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextButton2.TabIndex = 18;
            this.metroTextButton2.Text = "&Limpiar";
            this.metroTextButton2.UseSelectable = true;
            this.metroTextButton2.UseVisualStyleBackColor = true;
            this.metroTextButton2.Click += new System.EventHandler(this.metroTextButton2_Click);
            // 
            // CreditImagen
            // 
            this.CreditImagen.Image = global::ATX_POS.Properties.Resources._1469240360_credit_cards1;
            this.CreditImagen.Location = new System.Drawing.Point(354, 307);
            this.CreditImagen.Name = "CreditImagen";
            this.CreditImagen.Size = new System.Drawing.Size(48, 38);
            this.CreditImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CreditImagen.TabIndex = 21;
            this.CreditImagen.TabStop = false;
            this.CreditImagen.Visible = false;
            // 
            // DebitImagen
            // 
            this.DebitImagen.Image = global::ATX_POS.Properties.Resources._1469241184_Credit_Card;
            this.DebitImagen.Location = new System.Drawing.Point(354, 263);
            this.DebitImagen.Name = "DebitImagen";
            this.DebitImagen.Size = new System.Drawing.Size(48, 38);
            this.DebitImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DebitImagen.TabIndex = 20;
            this.DebitImagen.TabStop = false;
            this.DebitImagen.Visible = false;
            // 
            // EfectivoImagen
            // 
            this.EfectivoImagen.Image = global::ATX_POS.Properties.Resources._1469241149_money;
            this.EfectivoImagen.Location = new System.Drawing.Point(354, 219);
            this.EfectivoImagen.Name = "EfectivoImagen";
            this.EfectivoImagen.Size = new System.Drawing.Size(48, 38);
            this.EfectivoImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EfectivoImagen.TabIndex = 19;
            this.EfectivoImagen.TabStop = false;
            this.EfectivoImagen.Visible = false;
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.White;
            this.metroButton1.ForeColor = System.Drawing.Color.White;
            this.metroButton1.Location = new System.Drawing.Point(12, 12);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton1.TabIndex = 22;
            this.metroButton1.Text = "Re&gresar";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // efectivo
            // 
            this.efectivo.AutoSize = true;
            this.efectivo.Location = new System.Drawing.Point(11, 28);
            this.efectivo.Name = "efectivo";
            this.efectivo.Size = new System.Drawing.Size(65, 15);
            this.efectivo.TabIndex = 23;
            this.efectivo.Text = "&Efectivo";
            this.efectivo.UseSelectable = true;
            this.efectivo.CheckedChanged += new System.EventHandler(this.efectivo_CheckedChanged);
            this.efectivo.Click += new System.EventHandler(this.metroCheckBox1_Click);
            // 
            // PaymentsForms
            // 
            this.PaymentsForms.Controls.Add(this.MixPayment);
            this.PaymentsForms.Controls.Add(this.debito);
            this.PaymentsForms.Controls.Add(this.credito);
            this.PaymentsForms.Controls.Add(this.efectivo);
            this.PaymentsForms.Location = new System.Drawing.Point(12, 145);
            this.PaymentsForms.Name = "PaymentsForms";
            this.PaymentsForms.Size = new System.Drawing.Size(417, 56);
            this.PaymentsForms.TabIndex = 24;
            this.PaymentsForms.TabStop = false;
            this.PaymentsForms.Text = "Metodos de Pago";
            // 
            // MixPayment
            // 
            this.MixPayment.AutoSize = true;
            this.MixPayment.Location = new System.Drawing.Point(337, 28);
            this.MixPayment.Name = "MixPayment";
            this.MixPayment.Size = new System.Drawing.Size(53, 15);
            this.MixPayment.TabIndex = 26;
            this.MixPayment.Text = "&Mixto";
            this.MixPayment.UseSelectable = true;
            // 
            // debito
            // 
            this.debito.AutoSize = true;
            this.debito.Location = new System.Drawing.Point(206, 28);
            this.debito.Name = "debito";
            this.debito.Size = new System.Drawing.Size(90, 15);
            this.debito.TabIndex = 25;
            this.debito.Text = "Vales/&Débito";
            this.debito.UseSelectable = true;
            this.debito.CheckedChanged += new System.EventHandler(this.debito_CheckedChanged);
            this.debito.Click += new System.EventHandler(this.metroCheckBox3_Click);
            // 
            // credito
            // 
            this.credito.AutoSize = true;
            this.credito.Location = new System.Drawing.Point(104, 28);
            this.credito.Name = "credito";
            this.credito.Size = new System.Drawing.Size(62, 15);
            this.credito.TabIndex = 24;
            this.credito.Text = "Crédit&o";
            this.credito.UseSelectable = true;
            this.credito.CheckedChanged += new System.EventHandler(this.credito_CheckedChanged);
            this.credito.Click += new System.EventHandler(this.metroCheckBox2_Click);
            // 
            // paymentVales2
            // 
            this.paymentVales2.Location = new System.Drawing.Point(54, 219);
            this.paymentVales2.Name = "paymentVales2";
            this.paymentVales2.Size = new System.Drawing.Size(267, 143);
            this.paymentVales2.TabIndex = 27;
            this.paymentVales2.Load += new System.EventHandler(this.paymentVales2_Load);
            // 
            // paymentCredit2
            // 
            this.paymentCredit2.Location = new System.Drawing.Point(57, 219);
            this.paymentCredit2.Name = "paymentCredit2";
            this.paymentCredit2.Size = new System.Drawing.Size(264, 168);
            this.paymentCredit2.TabIndex = 26;
            // 
            // paymenCash2
            // 
            this.paymenCash2.BackColor = System.Drawing.Color.Transparent;
            this.paymenCash2.Location = new System.Drawing.Point(54, 219);
            this.paymenCash2.Name = "paymenCash2";
            this.paymenCash2.Size = new System.Drawing.Size(278, 94);
            this.paymenCash2.TabIndex = 25;
            this.paymenCash2.Load += new System.EventHandler(this.paymenCash2_Load);
            this.paymenCash2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.paymenCash2_KeyPress_1);
            // 
            // Payments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(457, 443);
            this.ControlBox = false;
            this.Controls.Add(this.paymentVales2);
            this.Controls.Add(this.paymentCredit2);
            this.Controls.Add(this.paymenCash2);
            this.Controls.Add(this.PaymentsForms);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.CreditImagen);
            this.Controls.Add(this.DebitImagen);
            this.Controls.Add(this.EfectivoImagen);
            this.Controls.Add(this.metroTextButton2);
            this.Controls.Add(this.metroTextButton1);
            this.Controls.Add(this.SalesCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Totalling);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.Payments_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Payments_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.CreditImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebitImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EfectivoImagen)).EndInit();
            this.PaymentsForms.ResumeLayout(false);
            this.PaymentsForms.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        public System.Windows.Forms.TextBox Totalling;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton SalesCancel;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton metroTextButton1;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton metroTextButton2;
        private System.Windows.Forms.PictureBox EfectivoImagen;
        private System.Windows.Forms.PictureBox DebitImagen;
        private System.Windows.Forms.PictureBox CreditImagen;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroCheckBox efectivo;
        private System.Windows.Forms.GroupBox PaymentsForms;
        private MetroFramework.Controls.MetroCheckBox debito;
        private MetroFramework.Controls.MetroCheckBox credito;
        private MetroFramework.Controls.MetroCheckBox MixPayment;
        private PaymenCash paymenCash2;
        private PaymentCredit paymentCredit2;
        private PaymentVales paymentVales2;
    }
}