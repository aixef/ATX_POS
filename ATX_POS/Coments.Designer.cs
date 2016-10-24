namespace ATX_POS
{
    partial class Coments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Coments));
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.Comments = new System.Windows.Forms.TextBox();
            this.letters = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.metroButton1.Location = new System.Drawing.Point(304, 299);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(126, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "Grabar Comentario";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // Comments
            // 
            this.Comments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comments.Location = new System.Drawing.Point(23, 63);
            this.Comments.MaxLength = 150;
            this.Comments.Multiline = true;
            this.Comments.Name = "Comments";
            this.Comments.Size = new System.Drawing.Size(407, 230);
            this.Comments.TabIndex = 1;
            this.Comments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Comments_KeyPress);
            this.Comments.Validating += new System.ComponentModel.CancelEventHandler(this.Comments_Validating);
            // 
            // letters
            // 
            this.letters.AutoSize = true;
            this.letters.Location = new System.Drawing.Point(35, 303);
            this.letters.Name = "letters";
            this.letters.Size = new System.Drawing.Size(28, 19);
            this.letters.Style = MetroFramework.MetroColorStyle.Blue;
            this.letters.TabIndex = 2;
            this.letters.Text = "150";
            this.letters.UseStyleColors = true;
            // 
            // Coments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 345);
            this.ControlBox = false;
            this.Controls.Add(this.letters);
            this.Controls.Add(this.Comments);
            this.Controls.Add(this.metroButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Coments";
            this.Text = "Comentarios Terminal";
            this.Load += new System.EventHandler(this.Coments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.TextBox Comments;
        private MetroFramework.Controls.MetroLabel letters;
    }
}