namespace ATX_POS
{
    partial class AddTerminal
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
            this.NewUser = new MetroFramework.Controls.MetroButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.TermNo = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TermPic = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TermPic)).BeginInit();
            this.SuspendLayout();
            // 
            // NewUser
            // 
            this.NewUser.BackColor = System.Drawing.Color.White;
            this.NewUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewUser.ForeColor = System.Drawing.Color.White;
            this.NewUser.Location = new System.Drawing.Point(61, 136);
            this.NewUser.Name = "NewUser";
            this.NewUser.Size = new System.Drawing.Size(95, 23);
            this.NewUser.Style = MetroFramework.MetroColorStyle.Teal;
            this.NewUser.TabIndex = 2;
            this.NewUser.Text = "Nueva Terminal";
            this.NewUser.UseCustomBackColor = true;
            this.NewUser.UseSelectable = true;
            this.NewUser.UseStyleColors = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.TermNo);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Location = new System.Drawing.Point(23, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 167);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Terminal";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(26, 31);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(130, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Brown;
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Número de Terminal";
            this.metroLabel1.UseStyleColors = true;
            // 
            // TermNo
            // 
            this.TermNo.Location = new System.Drawing.Point(38, 53);
            this.TermNo.MaxLength = 2;
            this.TermNo.Name = "TermNo";
            this.TermNo.ReadOnly = true;
            this.TermNo.Size = new System.Drawing.Size(100, 20);
            this.TermNo.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(195, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(215, 31);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(56, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Brown;
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Sucursal";
            this.metroLabel2.UseStyleColors = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(38, 121);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(257, 20);
            this.textBox3.TabIndex = 5;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(93, 99);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(155, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Brown;
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Código Autirización NAV";
            this.metroLabel3.UseStyleColors = true;
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.White;
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.ForeColor = System.Drawing.Color.White;
            this.metroButton1.Location = new System.Drawing.Point(223, 136);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(95, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroButton1.TabIndex = 5;
            this.metroButton1.Text = "Activar Terminal";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::ATX_POS.Properties.Resources._1472866876_rotate_locked;
            this.pictureBox1.Location = new System.Drawing.Point(223, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::ATX_POS.Properties.Resources._1472867052_Key;
            this.pictureBox2.Location = new System.Drawing.Point(56, 91);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // TermPic
            // 
            this.TermPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TermPic.Image = global::ATX_POS.Properties.Resources._1472866314_Computer_Add;
            this.TermPic.Location = new System.Drawing.Point(61, 86);
            this.TermPic.Name = "TermPic";
            this.TermPic.Size = new System.Drawing.Size(95, 50);
            this.TermPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TermPic.TabIndex = 3;
            this.TermPic.TabStop = false;
            // 
            // AddTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 379);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TermPic);
            this.Controls.Add(this.NewUser);
            this.Name = "AddTerminal";
            this.Text = "Nueva Terminal";
            this.Load += new System.EventHandler(this.AddTerminal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TermPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox TermPic;
        private MetroFramework.Controls.MetroButton NewUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.TextBox textBox2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.TextBox TermNo;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}