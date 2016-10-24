namespace ATX_POS
{
    partial class RCountingF
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
            this.metroTextButton2 = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.cutBoxs1 = new ATX_POS.CutBoxs();
            this.estadisticsBox1 = new ATX_POS.EstadisticsBox();
            this.metroTextButton3 = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.SuspendLayout();
            // 
            // metroTextButton1
            // 
            this.metroTextButton1.Image = null;
            this.metroTextButton1.Location = new System.Drawing.Point(361, 450);
            this.metroTextButton1.Name = "metroTextButton1";
            this.metroTextButton1.Size = new System.Drawing.Size(157, 27);
            this.metroTextButton1.TabIndex = 12;
            this.metroTextButton1.Text = "Sincronizar Pagos";
            this.metroTextButton1.UseSelectable = true;
            this.metroTextButton1.UseVisualStyleBackColor = true;
            this.metroTextButton1.Click += new System.EventHandler(this.metroTextButton1_Click_2);
            // 
            // metroTextButton2
            // 
            this.metroTextButton2.Image = null;
            this.metroTextButton2.Location = new System.Drawing.Point(523, 63);
            this.metroTextButton2.Name = "metroTextButton2";
            this.metroTextButton2.Size = new System.Drawing.Size(64, 27);
            this.metroTextButton2.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroTextButton2.TabIndex = 13;
            this.metroTextButton2.Text = "Cancelar";
            this.metroTextButton2.UseSelectable = true;
            this.metroTextButton2.UseVisualStyleBackColor = true;
            this.metroTextButton2.Click += new System.EventHandler(this.metroTextButton2_Click);
            // 
            // cutBoxs1
            // 
            this.cutBoxs1.BackColor = System.Drawing.Color.Transparent;
            this.cutBoxs1.Location = new System.Drawing.Point(361, 120);
            this.cutBoxs1.Name = "cutBoxs1";
            this.cutBoxs1.Size = new System.Drawing.Size(226, 198);
            this.cutBoxs1.TabIndex = 11;
            this.cutBoxs1.Load += new System.EventHandler(this.cutBoxs1_Load);
            // 
            // estadisticsBox1
            // 
            this.estadisticsBox1.BackColor = System.Drawing.Color.Transparent;
            this.estadisticsBox1.Location = new System.Drawing.Point(23, 63);
            this.estadisticsBox1.Name = "estadisticsBox1";
            this.estadisticsBox1.Size = new System.Drawing.Size(326, 324);
            this.estadisticsBox1.TabIndex = 10;
            this.estadisticsBox1.Load += new System.EventHandler(this.estadisticsBox1_Load);
            // 
            // metroTextButton3
            // 
            this.metroTextButton3.Enabled = false;
            this.metroTextButton3.Image = null;
            this.metroTextButton3.Location = new System.Drawing.Point(110, 450);
            this.metroTextButton3.Name = "metroTextButton3";
            this.metroTextButton3.Size = new System.Drawing.Size(146, 27);
            this.metroTextButton3.TabIndex = 14;
            this.metroTextButton3.Text = "Imprimir Corte";
            this.metroTextButton3.UseSelectable = true;
            this.metroTextButton3.UseVisualStyleBackColor = true;
            // 
            // RCountingF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 552);
            this.ControlBox = false;
            this.Controls.Add(this.metroTextButton3);
            this.Controls.Add(this.metroTextButton2);
            this.Controls.Add(this.metroTextButton1);
            this.Controls.Add(this.cutBoxs1);
            this.Controls.Add(this.estadisticsBox1);
            this.Name = "RCountingF";
            this.Resizable = false;
            this.Text = "Corte de Caja";
            this.Load += new System.EventHandler(this.RCountingF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EstadisticsBox estadisticsBox1;
        private CutBoxs cutBoxs1;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton metroTextButton1;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton metroTextButton2;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton metroTextButton3;
    }
}