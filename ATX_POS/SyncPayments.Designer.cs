namespace ATX_POS
{
    partial class SyncPayments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SalesSync2 = new MetroFramework.Controls.MetroGrid();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sync = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SalesIdNo = new System.Windows.Forms.TextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.DateRange = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.Findatetime = new MetroFramework.Controls.MetroDateTime();
            this.metroTextButton3 = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.TerminalList = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.Calendar = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTextButton2 = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.metroTextButton1 = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.ProgressSyncNav = new MetroFramework.Controls.MetroProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSync2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SalesSync2
            // 
            this.SalesSync2.AllowUserToAddRows = false;
            this.SalesSync2.AllowUserToDeleteRows = false;
            this.SalesSync2.AllowUserToResizeColumns = false;
            this.SalesSync2.AllowUserToResizeRows = false;
            this.SalesSync2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SalesSync2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SalesSync2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.SalesSync2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SalesSync2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.SalesSync2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SalesSync2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Date,
            this.NoTicket,
            this.Total,
            this.Terminals,
            this.Status,
            this.Payment,
            this.Sync});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SalesSync2.DefaultCellStyle = dataGridViewCellStyle8;
            this.SalesSync2.EnableHeadersVisualStyles = false;
            this.SalesSync2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SalesSync2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SalesSync2.Location = new System.Drawing.Point(23, 74);
            this.SalesSync2.MinimumSize = new System.Drawing.Size(461, 321);
            this.SalesSync2.MultiSelect = false;
            this.SalesSync2.Name = "SalesSync2";
            this.SalesSync2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SalesSync2.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.SalesSync2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.SalesSync2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SalesSync2.Size = new System.Drawing.Size(642, 397);
            this.SalesSync2.TabIndex = 11;
            // 
            // No
            // 
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Fecha";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // NoTicket
            // 
            this.NoTicket.HeaderText = "No. Ticket";
            this.NoTicket.Name = "NoTicket";
            this.NoTicket.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total Venta";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Terminals
            // 
            this.Terminals.HeaderText = "Terminal";
            this.Terminals.Name = "Terminals";
            this.Terminals.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Enviado a NAV";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Payment
            // 
            this.Payment.HeaderText = "Pago Pendiente";
            this.Payment.Name = "Payment";
            this.Payment.ReadOnly = true;
            // 
            // Sync
            // 
            this.Sync.HeaderText = "Sincronizar";
            this.Sync.Name = "Sync";
            this.Sync.TrueValue = "true";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SalesIdNo);
            this.groupBox1.Controls.Add(this.metroLabel6);
            this.groupBox1.Controls.Add(this.DateRange);
            this.groupBox1.Controls.Add(this.metroLabel5);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.Findatetime);
            this.groupBox1.Controls.Add(this.metroTextButton3);
            this.groupBox1.Controls.Add(this.TerminalList);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.Calendar);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Location = new System.Drawing.Point(679, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 368);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // SalesIdNo
            // 
            this.SalesIdNo.Location = new System.Drawing.Point(98, 240);
            this.SalesIdNo.Name = "SalesIdNo";
            this.SalesIdNo.Size = new System.Drawing.Size(130, 20);
            this.SalesIdNo.TabIndex = 15;
            this.SalesIdNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SalesIdNo.TextChanged += new System.EventHandler(this.SalesIdNo_TextChanged);
            this.SalesIdNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SalesIdNo_KeyPress);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(6, 240);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(66, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel6.TabIndex = 14;
            this.metroLabel6.Text = "No. Venta";
            this.metroLabel6.UseStyleColors = true;
            // 
            // DateRange
            // 
            this.DateRange.AutoSize = true;
            this.DateRange.Location = new System.Drawing.Point(115, 46);
            this.DateRange.Name = "DateRange";
            this.DateRange.Size = new System.Drawing.Size(112, 15);
            this.DateRange.TabIndex = 13;
            this.DateRange.Text = "Rango de Fechas";
            this.DateRange.UseSelectable = true;
            this.DateRange.CheckedChanged += new System.EventHandler(this.DateRange_CheckedChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(6, 46);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(39, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Inicio";
            this.metroLabel5.UseStyleColors = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(6, 100);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(26, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel4.TabIndex = 11;
            this.metroLabel4.Text = "Fin";
            this.metroLabel4.UseStyleColors = true;
            // 
            // Findatetime
            // 
            this.Findatetime.Enabled = false;
            this.Findatetime.Location = new System.Drawing.Point(6, 122);
            this.Findatetime.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.Findatetime.MinDate = new System.DateTime(1991, 12, 31, 0, 0, 0, 0);
            this.Findatetime.MinimumSize = new System.Drawing.Size(0, 29);
            this.Findatetime.Name = "Findatetime";
            this.Findatetime.Size = new System.Drawing.Size(222, 29);
            this.Findatetime.Style = MetroFramework.MetroColorStyle.Teal;
            this.Findatetime.TabIndex = 10;
            this.Findatetime.UseStyleColors = true;
            // 
            // metroTextButton3
            // 
            this.metroTextButton3.Image = null;
            this.metroTextButton3.Location = new System.Drawing.Point(85, 339);
            this.metroTextButton3.Name = "metroTextButton3";
            this.metroTextButton3.Size = new System.Drawing.Size(75, 23);
            this.metroTextButton3.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTextButton3.TabIndex = 9;
            this.metroTextButton3.Text = "&Buscar";
            this.metroTextButton3.UseSelectable = true;
            this.metroTextButton3.UseStyleColors = true;
            this.metroTextButton3.UseVisualStyleBackColor = true;
            this.metroTextButton3.Click += new System.EventHandler(this.metroTextButton3_Click);
            // 
            // TerminalList
            // 
            this.TerminalList.FormattingEnabled = true;
            this.TerminalList.ItemHeight = 23;
            this.TerminalList.Location = new System.Drawing.Point(6, 186);
            this.TerminalList.MinimumSize = new System.Drawing.Size(200, 0);
            this.TerminalList.Name = "TerminalList";
            this.TerminalList.Size = new System.Drawing.Size(222, 29);
            this.TerminalList.Style = MetroFramework.MetroColorStyle.Teal;
            this.TerminalList.TabIndex = 8;
            this.TerminalList.UseSelectable = true;
            this.TerminalList.UseStyleColors = true;
            this.TerminalList.Click += new System.EventHandler(this.TerminalList_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(6, 164);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(58, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Terminal";
            this.metroLabel3.UseStyleColors = true;
            // 
            // Calendar
            // 
            this.Calendar.Location = new System.Drawing.Point(6, 68);
            this.Calendar.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.Calendar.MinDate = new System.DateTime(1991, 12, 31, 0, 0, 0, 0);
            this.Calendar.MinimumSize = new System.Drawing.Size(0, 29);
            this.Calendar.Name = "Calendar";
            this.Calendar.Size = new System.Drawing.Size(222, 29);
            this.Calendar.Style = MetroFramework.MetroColorStyle.Teal;
            this.Calendar.TabIndex = 1;
            this.Calendar.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(6, 21);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(114, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Fecha de Registro";
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroTextButton2
            // 
            this.metroTextButton2.Image = null;
            this.metroTextButton2.Location = new System.Drawing.Point(819, 448);
            this.metroTextButton2.Name = "metroTextButton2";
            this.metroTextButton2.Size = new System.Drawing.Size(75, 23);
            this.metroTextButton2.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTextButton2.TabIndex = 13;
            this.metroTextButton2.Text = "&Registrar";
            this.metroTextButton2.UseSelectable = true;
            this.metroTextButton2.UseStyleColors = true;
            this.metroTextButton2.UseVisualStyleBackColor = false;
            this.metroTextButton2.Click += new System.EventHandler(this.metroTextButton2_Click);
            // 
            // metroTextButton1
            // 
            this.metroTextButton1.Image = null;
            this.metroTextButton1.Location = new System.Drawing.Point(706, 448);
            this.metroTextButton1.Name = "metroTextButton1";
            this.metroTextButton1.Size = new System.Drawing.Size(75, 23);
            this.metroTextButton1.TabIndex = 12;
            this.metroTextButton1.Text = "&Cancelar";
            this.metroTextButton1.UseSelectable = true;
            this.metroTextButton1.UseVisualStyleBackColor = false;
            this.metroTextButton1.Click += new System.EventHandler(this.metroTextButton1_Click);
            // 
            // ProgressSyncNav
            // 
            this.ProgressSyncNav.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.ProgressSyncNav.HideProgressText = false;
            this.ProgressSyncNav.Location = new System.Drawing.Point(23, 250);
            this.ProgressSyncNav.Name = "ProgressSyncNav";
            this.ProgressSyncNav.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Blocks;
            this.ProgressSyncNav.Size = new System.Drawing.Size(642, 34);
            this.ProgressSyncNav.Step = 1;
            this.ProgressSyncNav.Style = MetroFramework.MetroColorStyle.Green;
            this.ProgressSyncNav.TabIndex = 14;
            this.ProgressSyncNav.UseWaitCursor = true;
            // 
            // SyncPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 489);
            this.ControlBox = false;
            this.Controls.Add(this.ProgressSyncNav);
            this.Controls.Add(this.metroTextButton2);
            this.Controls.Add(this.metroTextButton1);
            this.Controls.Add(this.SalesSync2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SyncPayments";
            this.Text = "Sincronizar Pagos";
            this.Load += new System.EventHandler(this.SyncPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SalesSync2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroGrid SalesSync2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox SalesIdNo;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroCheckBox DateRange;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroDateTime Findatetime;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton metroTextButton3;
        private MetroFramework.Controls.MetroComboBox TerminalList;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime Calendar;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton metroTextButton2;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton metroTextButton1;
        private MetroFramework.Controls.MetroProgressBar ProgressSyncNav;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminals;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sync;
    }
}