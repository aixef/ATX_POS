namespace ATX_POS
{
    partial class ActiveSessions
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
            this.UserList = new System.Windows.Forms.ComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.Status = new MetroFramework.Controls.MetroLabel();
            this.Updatestatus = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.SuspendLayout();
            // 
            // UserList
            // 
            this.UserList.FormattingEnabled = true;
            this.UserList.Location = new System.Drawing.Point(115, 86);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(152, 21);
            this.UserList.TabIndex = 0;
            this.UserList.SelectedIndexChanged += new System.EventHandler(this.UserList_SelectedIndexChanged);
            this.UserList.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 88);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(53, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Usuario";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(28, 130);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(48, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Estado";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(163, 130);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(41, 19);
            this.Status.Style = MetroFramework.MetroColorStyle.Blue;
            this.Status.TabIndex = 3;
            this.Status.Text = "None";
            this.Status.UseStyleColors = true;
            // 
            // Updatestatus
            // 
            this.Updatestatus.Image = null;
            this.Updatestatus.Location = new System.Drawing.Point(83, 186);
            this.Updatestatus.Name = "Updatestatus";
            this.Updatestatus.Size = new System.Drawing.Size(111, 23);
            this.Updatestatus.TabIndex = 4;
            this.Updatestatus.Text = "Liberar Sesión";
            this.Updatestatus.UseSelectable = true;
            this.Updatestatus.UseVisualStyleBackColor = true;
            this.Updatestatus.Click += new System.EventHandler(this.metroTextButton1_Click);
            // 
            // ActiveSessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 304);
            this.Controls.Add(this.Updatestatus);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.UserList);
            this.Name = "ActiveSessions";
            this.Text = "Sesiones Activas";
            this.Load += new System.EventHandler(this.ActiveSessions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox UserList;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel Status;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton Updatestatus;
    }
}