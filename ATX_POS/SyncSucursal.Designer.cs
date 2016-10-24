namespace ATX_POS
{
    partial class SyncSucursal
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
            this.SucNames = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CitySuc = new System.Windows.Forms.TextBox();
            this.StateSuc = new System.Windows.Forms.TextBox();
            this.AdressSuc = new System.Windows.Forms.TextBox();
            this.EmailSuc = new System.Windows.Forms.TextBox();
            this.PhoneSuc = new System.Windows.Forms.TextBox();
            this.NameSuc = new System.Windows.Forms.TextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SucNames
            // 
            this.SucNames.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SucNames.FormattingEnabled = true;
            this.SucNames.ItemHeight = 23;
            this.SucNames.Location = new System.Drawing.Point(15, 86);
            this.SucNames.Name = "SucNames";
            this.SucNames.Size = new System.Drawing.Size(121, 29);
            this.SucNames.Style = MetroFramework.MetroColorStyle.Orange;
            this.SucNames.TabIndex = 0;
            this.SucNames.UseSelectable = true;
            this.SucNames.UseStyleColors = true;
            this.SucNames.SelectedIndexChanged += new System.EventHandler(this.SucNames_SelectedIndexChanged);
            this.SucNames.Click += new System.EventHandler(this.metroComboBox1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(15, 58);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(118, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Cod. Almacen";
            this.metroLabel1.UseStyleColors = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CitySuc);
            this.groupBox1.Controls.Add(this.StateSuc);
            this.groupBox1.Controls.Add(this.AdressSuc);
            this.groupBox1.Controls.Add(this.EmailSuc);
            this.groupBox1.Controls.Add(this.PhoneSuc);
            this.groupBox1.Controls.Add(this.NameSuc);
            this.groupBox1.Controls.Add(this.metroLabel7);
            this.groupBox1.Controls.Add(this.metroLabel6);
            this.groupBox1.Controls.Add(this.metroLabel5);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Location = new System.Drawing.Point(15, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 157);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Almacen";
            // 
            // CitySuc
            // 
            this.CitySuc.Location = new System.Drawing.Point(287, 114);
            this.CitySuc.Name = "CitySuc";
            this.CitySuc.ReadOnly = true;
            this.CitySuc.Size = new System.Drawing.Size(80, 20);
            this.CitySuc.TabIndex = 11;
            // 
            // StateSuc
            // 
            this.StateSuc.Location = new System.Drawing.Point(190, 114);
            this.StateSuc.Name = "StateSuc";
            this.StateSuc.ReadOnly = true;
            this.StateSuc.Size = new System.Drawing.Size(80, 20);
            this.StateSuc.TabIndex = 10;
            // 
            // AdressSuc
            // 
            this.AdressSuc.Location = new System.Drawing.Point(6, 114);
            this.AdressSuc.Name = "AdressSuc";
            this.AdressSuc.ReadOnly = true;
            this.AdressSuc.Size = new System.Drawing.Size(162, 20);
            this.AdressSuc.TabIndex = 9;
            // 
            // EmailSuc
            // 
            this.EmailSuc.Location = new System.Drawing.Point(255, 58);
            this.EmailSuc.Name = "EmailSuc";
            this.EmailSuc.ReadOnly = true;
            this.EmailSuc.Size = new System.Drawing.Size(127, 20);
            this.EmailSuc.TabIndex = 8;
            // 
            // PhoneSuc
            // 
            this.PhoneSuc.Location = new System.Drawing.Point(161, 58);
            this.PhoneSuc.Name = "PhoneSuc";
            this.PhoneSuc.ReadOnly = true;
            this.PhoneSuc.Size = new System.Drawing.Size(80, 20);
            this.PhoneSuc.TabIndex = 7;
            // 
            // NameSuc
            // 
            this.NameSuc.Location = new System.Drawing.Point(6, 58);
            this.NameSuc.Name = "NameSuc";
            this.NameSuc.ReadOnly = true;
            this.NameSuc.Size = new System.Drawing.Size(134, 20);
            this.NameSuc.TabIndex = 6;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(301, 92);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(51, 19);
            this.metroLabel7.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroLabel7.TabIndex = 5;
            this.metroLabel7.Text = "Ciudad";
            this.metroLabel7.UseStyleColors = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(205, 92);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(48, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroLabel6.TabIndex = 4;
            this.metroLabel6.Text = "Estado";
            this.metroLabel6.UseStyleColors = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(292, 36);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(47, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroLabel5.TabIndex = 3;
            this.metroLabel5.Text = "E-Mail";
            this.metroLabel5.UseStyleColors = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(172, 36);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(58, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroLabel4.TabIndex = 2;
            this.metroLabel4.Text = "Teléfono";
            this.metroLabel4.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(8, 92);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(63, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroLabel3.TabIndex = 1;
            this.metroLabel3.Text = "Dirección";
            this.metroLabel3.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(8, 36);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(102, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "Nombre Tienda";
            this.metroLabel2.UseStyleColors = true;
            this.metroLabel2.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.AutoSize = true;
            this.metroButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.metroButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(270, 92);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(138, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "Actualizar Datos Sucursal";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // SyncSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 306);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.SucNames);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "SyncSucursal";
            this.Resizable = false;
            this.Text = "Datos Sucursal";
            this.Load += new System.EventHandler(this.SyncSucursal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox SucNames;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.TextBox CitySuc;
        private System.Windows.Forms.TextBox StateSuc;
        private System.Windows.Forms.TextBox AdressSuc;
        private System.Windows.Forms.TextBox EmailSuc;
        private System.Windows.Forms.TextBox PhoneSuc;
        private System.Windows.Forms.TextBox NameSuc;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}