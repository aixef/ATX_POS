namespace ATX_POS
{
    partial class FirstLoginSesion
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
            this.UserLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.TerminalLabel = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroButton2= new MetroFramework.Controls.MetroButton();
            this.detailCashCount_21 = new ATX_POS.DetailCashCount_2();
            this.detailCashCount1 = new ATX_POS.DetailCashCount();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(329, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(60, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Usuario: ";
            this.metroLabel1.UseStyleColors = true;
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Location = new System.Drawing.Point(395, 60);
            this.UserLabel.MinimumSize = new System.Drawing.Size(80, 20);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(0, 0);
            this.UserLabel.Style = MetroFramework.MetroColorStyle.Purple;
            this.UserLabel.TabIndex = 1;
            this.UserLabel.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(481, 61);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(58, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Terminal";
            this.metroLabel3.UseStyleColors = true;
            // 
            // TerminalLabel
            // 
            this.TerminalLabel.AutoSize = true;
            this.TerminalLabel.Location = new System.Drawing.Point(545, 61);
            this.TerminalLabel.MinimumSize = new System.Drawing.Size(30, 20);
            this.TerminalLabel.Name = "TerminalLabel";
            this.TerminalLabel.Size = new System.Drawing.Size(0, 0);
            this.TerminalLabel.Style = MetroFramework.MetroColorStyle.Purple;
            this.TerminalLabel.TabIndex = 3;
            this.TerminalLabel.UseStyleColors = true;
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.Transparent;
            this.metroButton1.Location = new System.Drawing.Point(481, 354);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(96, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "&Registrar Inicio";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(142, 358);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(36, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "Total";
            this.metroLabel2.UseStyleColors = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(184, 354);
            this.metroLabel4.MinimumSize = new System.Drawing.Size(100, 25);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(0, 0);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel4.UseStyleColors = true;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(142, 309);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(101, 23);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroButton2.TabIndex = 9;
            this.metroButton2.Text = "&Calcular Total";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.UseStyleColors = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // detailCashCount_21
            // 
            this.detailCashCount_21.Location = new System.Drawing.Point(330, 117);
            this.detailCashCount_21.Name = "detailCashCount_21";
            this.detailCashCount_21.Size = new System.Drawing.Size(209, 215);
            this.detailCashCount_21.TabIndex = 6;
            // 
            // detailCashCount1
            // 
            this.detailCashCount1.Location = new System.Drawing.Point(12, 82);
            this.detailCashCount1.Name = "detailCashCount1";
            this.detailCashCount1.Size = new System.Drawing.Size(231, 185);
            this.detailCashCount1.TabIndex = 5;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(142, 82);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(16, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "0";
            this.metroLabel5.UseStyleColors = true;
            // 
            // FirstLoginSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.ControlBox = false;
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.detailCashCount_21);
            this.Controls.Add(this.detailCashCount1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.TerminalLabel);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FirstLoginSesion";
            this.Text = "Inicio Turno";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        public MetroFramework.Controls.MetroLabel UserLabel;
        public MetroFramework.Controls.MetroLabel TerminalLabel;
        private MetroFramework.Controls.MetroButton metroButton1;
        private DetailCashCount detailCashCount1;
        private DetailCashCount_2 detailCashCount_21;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel5;
    }
}