namespace ATX_POS
{
    partial class RCoutingFinalc
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
            this.metroTextButton1 = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cashuserbox = new System.Windows.Forms.TextBox();
            this.salesInDetail1 = new ATX_POS.SalesInDetail();
            this.detalleCorte1 = new ATX_POS.DetalleCorte();
            this.SuspendLayout();
            // 
            // metroTextButton1
            // 
            this.metroTextButton1.Image = null;
            this.metroTextButton1.Location = new System.Drawing.Point(194, 435);
            this.metroTextButton1.Name = "metroTextButton1";
            this.metroTextButton1.Size = new System.Drawing.Size(179, 27);
            this.metroTextButton1.TabIndex = 2;
            this.metroTextButton1.Text = "Cerrar Turno";
            this.metroTextButton1.UseSelectable = true;
            this.metroTextButton1.UseVisualStyleBackColor = true;
            this.metroTextButton1.Click += new System.EventHandler(this.metroTextButton1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(153, 382);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(108, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Fondo para Caja";
            this.metroLabel1.UseStyleColors = true;
            // 
            // cashuserbox
            // 
            this.cashuserbox.Location = new System.Drawing.Point(291, 381);
            this.cashuserbox.Name = "cashuserbox";
            this.cashuserbox.Size = new System.Drawing.Size(122, 20);
            this.cashuserbox.TabIndex = 6;
            this.cashuserbox.Text = "0.00";
            this.cashuserbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cashuserbox.Enter += new System.EventHandler(this.textBox1_Enter);
            this.cashuserbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.cashuserbox.Validating += new System.ComponentModel.CancelEventHandler(this.cashuserbox_Validating);
            // 
            // salesInDetail1
            // 
            this.salesInDetail1.Location = new System.Drawing.Point(319, 63);
            this.salesInDetail1.Name = "salesInDetail1";
            this.salesInDetail1.Size = new System.Drawing.Size(210, 259);
            this.salesInDetail1.TabIndex = 1;
            // 
            // detalleCorte1
            // 
            this.detalleCorte1.Location = new System.Drawing.Point(23, 63);
            this.detalleCorte1.Name = "detalleCorte1";
            this.detalleCorte1.Size = new System.Drawing.Size(279, 290);
            this.detalleCorte1.TabIndex = 0;
            this.detalleCorte1.Load += new System.EventHandler(this.detalleCorte1_Load);
            // 
            // RCoutingFinalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 488);
            this.Controls.Add(this.cashuserbox);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTextButton1);
            this.Controls.Add(this.salesInDetail1);
            this.Controls.Add(this.detalleCorte1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RCoutingFinalc";
            this.Resizable = false;
            this.Text = "Corte Turno";
            this.Load += new System.EventHandler(this.RCouting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox.MetroTextButton metroTextButton1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TextBox cashuserbox;
        public DetalleCorte detalleCorte1;
        public SalesInDetail salesInDetail1;

    }
}