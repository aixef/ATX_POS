namespace ATX_POS
{
    partial class RetiroDinero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetiroDinero));
            this.cashCountOut1 = new ATX_POS.PaymentsCash.CashCountOut();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.RegCashOut = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // cashCountOut1
            // 
            this.cashCountOut1.BackColor = System.Drawing.Color.White;
            this.cashCountOut1.Location = new System.Drawing.Point(46, 63);
            this.cashCountOut1.Name = "cashCountOut1";
            this.cashCountOut1.Size = new System.Drawing.Size(270, 239);
            this.cashCountOut1.TabIndex = 0;
            this.cashCountOut1.Load += new System.EventHandler(this.cashCountOut1_Load);
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.White;
            this.metroButton1.ForeColor = System.Drawing.Color.White;
            this.metroButton1.Location = new System.Drawing.Point(23, 316);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton1.TabIndex = 23;
            this.metroButton1.Text = "Re&gresar";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // RegCashOut
            // 
            this.RegCashOut.BackColor = System.Drawing.Color.White;
            this.RegCashOut.ForeColor = System.Drawing.Color.White;
            this.RegCashOut.Location = new System.Drawing.Point(253, 316);
            this.RegCashOut.Name = "RegCashOut";
            this.RegCashOut.Size = new System.Drawing.Size(89, 23);
            this.RegCashOut.Style = MetroFramework.MetroColorStyle.Blue;
            this.RegCashOut.TabIndex = 24;
            this.RegCashOut.Text = "&Retirar Dinero";
            this.RegCashOut.UseCustomBackColor = true;
            this.RegCashOut.UseSelectable = true;
            this.RegCashOut.UseStyleColors = true;
            this.RegCashOut.Click += new System.EventHandler(this.RegCashOut_Click);
            // 
            // RetiroDinero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 362);
            this.ControlBox = false;
            this.Controls.Add(this.RegCashOut);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.cashCountOut1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "RetiroDinero";
            this.Resizable = false;
            this.Text = "Retiro Efectivo";
            this.Load += new System.EventHandler(this.CashOutManual_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PaymentsCash.CashCountOut cashCountOut1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton RegCashOut;
    }
}