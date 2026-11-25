namespace DentalClinicManagementSystem
{
    partial class ReportsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPageSubtitle = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlMonthlySummary = new System.Windows.Forms.Panel();
            this.dgvMonthlySummary = new System.Windows.Forms.DataGridView();
            this.colMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppointments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTreatments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRevenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMonthlySummary = new System.Windows.Forms.Label();
            this.pnlRevenue = new System.Windows.Forms.Panel();
            this.lblRevenueValue = new System.Windows.Forms.Label();
            this.lblRevenueTitle = new System.Windows.Forms.Label();
            this.pnlTreatments = new System.Windows.Forms.Panel();
            this.lblTreatmentsValue = new System.Windows.Forms.Label();
            this.lblTreatmentsTitle = new System.Windows.Forms.Label();
            this.pnlAppointments = new System.Windows.Forms.Panel();
            this.lblAppointmentsValue = new System.Windows.Forms.Label();
            this.lblAppointmentsTitle = new System.Windows.Forms.Label();
            this.pnlPatients = new System.Windows.Forms.Panel();
            this.lblPatientsValue = new System.Windows.Forms.Label();
            this.lblPatientsTitle = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlMonthlySummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlySummary)).BeginInit();
            this.pnlRevenue.SuspendLayout();
            this.pnlTreatments.SuspendLayout();
            this.pnlAppointments.SuspendLayout();
            this.pnlPatients.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.pnlSidebar.Controls.Add(this.lblBrandSub);
            this.pnlSidebar.Controls.Add(this.lblBrand);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(320, 900);
            this.pnlSidebar.TabIndex = 0;
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.AutoSize = true;
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(235)))));
            this.lblBrandSub.Location = new System.Drawing.Point(42, 88);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(166, 20);
            this.lblBrandSub.TabIndex = 2;
            this.lblBrandSub.Text = "Management System";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(40, 45);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(205, 37);
            this.lblBrand.TabIndex = 1;
            this.lblBrand.Text = "DENTAL CLINIC";
            // 
            // btnDashboard
            // 
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(30, 170);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(260, 48);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Back to Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblPageSubtitle);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(320, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1280, 140);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblPageSubtitle
            // 
            this.lblPageSubtitle.AutoSize = true;
            this.lblPageSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblPageSubtitle.Location = new System.Drawing.Point(48, 92);
            this.lblPageSubtitle.Name = "lblPageSubtitle";
            this.lblPageSubtitle.Size = new System.Drawing.Size(247, 23);
            this.lblPageSubtitle.TabIndex = 1;
            this.lblPageSubtitle.Text = "Clinic performance overview";
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.lblPageTitle.Location = new System.Drawing.Point(44, 32);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(164, 54);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Reports";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlContent.Controls.Add(this.pnlMonthlySummary);
            this.pnlContent.Controls.Add(this.pnlRevenue);
            this.pnlContent.Controls.Add(this.pnlTreatments);
            this.pnlContent.Controls.Add(this.pnlAppointments);
            this.pnlContent.Controls.Add(this.pnlPatients);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(320, 140);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1280, 760);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlMonthlySummary
            // 
            this.pnlMonthlySummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMonthlySummary.BackColor = System.Drawing.Color.White;
            this.pnlMonthlySummary.Controls.Add(this.dgvMonthlySummary);
            this.pnlMonthlySummary.Controls.Add(this.lblMonthlySummary);
            this.pnlMonthlySummary.Location = new System.Drawing.Point(40, 230);
            this.pnlMonthlySummary.Name = "pnlMonthlySummary";
            this.pnlMonthlySummary.Size = new System.Drawing.Size(1200, 480);
            this.pnlMonthlySummary.TabIndex = 4;
            // 
            // dgvMonthlySummary
            // 
            this.dgvMonthlySummary.AllowUserToAddRows = false;
            this.dgvMonthlySummary.AllowUserToDeleteRows = false;
            this.dgvMonthlySummary.AllowUserToResizeColumns = false;
            this.dgvMonthlySummary.AllowUserToResizeRows = false;
            this.dgvMonthlySummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMonthlySummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonthlySummary.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonthlySummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMonthlySummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonthlySummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMonthlySummary.ColumnHeadersHeight = 50;
            this.dgvMonthlySummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMonthlySummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMonth,
            this.colPatients,
            this.colAppointments,
            this.colTreatments,
            this.colRevenue});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMonthlySummary.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMonthlySummary.EnableHeadersVisualStyles = false;
            this.dgvMonthlySummary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.dgvMonthlySummary.Location = new System.Drawing.Point(20, 86);
            this.dgvMonthlySummary.Name = "dgvMonthlySummary";
            this.dgvMonthlySummary.ReadOnly = true;
            this.dgvMonthlySummary.RowHeadersVisible = false;
            this.dgvMonthlySummary.RowHeadersWidth = 51;
            this.dgvMonthlySummary.RowTemplate.Height = 45;
            this.dgvMonthlySummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMonthlySummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonthlySummary.Size = new System.Drawing.Size(1160, 374);
            this.dgvMonthlySummary.TabIndex = 1;
            // 
            // colMonth
            // 
            this.colMonth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMonth.FillWeight = 140F;
            this.colMonth.HeaderText = "Month";
            this.colMonth.MinimumWidth = 80;
            this.colMonth.Name = "colMonth";
            this.colMonth.ReadOnly = true;
            // 
            // colPatients
            // 
            this.colPatients.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPatients.HeaderText = "Patients";
            this.colPatients.MinimumWidth = 80;
            this.colPatients.Name = "colPatients";
            this.colPatients.ReadOnly = true;
            // 
            // colAppointments
            // 
            this.colAppointments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAppointments.HeaderText = "Appointments";
            this.colAppointments.MinimumWidth = 80;
            this.colAppointments.Name = "colAppointments";
            this.colAppointments.ReadOnly = true;
            // 
            // colTreatments
            // 
            this.colTreatments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTreatments.HeaderText = "Treatments";
            this.colTreatments.MinimumWidth = 80;
            this.colTreatments.Name = "colTreatments";
            this.colTreatments.ReadOnly = true;
            // 
            // colRevenue
            // 
            this.colRevenue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRevenue.HeaderText = "Revenue";
            this.colRevenue.MinimumWidth = 80;
            this.colRevenue.Name = "colRevenue";
            this.colRevenue.ReadOnly = true;
            // 
            // lblMonthlySummary
            // 
            this.lblMonthlySummary.AutoSize = true;
            this.lblMonthlySummary.BackColor = System.Drawing.Color.Transparent;
            this.lblMonthlySummary.Font = new System.Drawing.Font("Segoe UI", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthlySummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.lblMonthlySummary.Location = new System.Drawing.Point(23, 26);
            this.lblMonthlySummary.Name = "lblMonthlySummary";
            this.lblMonthlySummary.Size = new System.Drawing.Size(226, 32);
            this.lblMonthlySummary.TabIndex = 0;
            this.lblMonthlySummary.Text = "Monthly Summary";
            // 
            // pnlRevenue
            // 
            this.pnlRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.pnlRevenue.Controls.Add(this.lblRevenueValue);
            this.pnlRevenue.Controls.Add(this.lblRevenueTitle);
            this.pnlRevenue.Location = new System.Drawing.Point(910, 40);
            this.pnlRevenue.Name = "pnlRevenue";
            this.pnlRevenue.Size = new System.Drawing.Size(270, 160);
            this.pnlRevenue.TabIndex = 3;
            // 
            // lblRevenueValue
            // 
            this.lblRevenueValue.AutoSize = true;
            this.lblRevenueValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueValue.ForeColor = System.Drawing.Color.White;
            this.lblRevenueValue.Location = new System.Drawing.Point(24, 54);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(187, 46);
            this.lblRevenueValue.TabIndex = 1;
            this.lblRevenueValue.Text = "48,500 EGP";
            // 
            // lblRevenueTitle
            // 
            this.lblRevenueTitle.AutoSize = true;
            this.lblRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 9.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueTitle.ForeColor = System.Drawing.Color.White;
            this.lblRevenueTitle.Location = new System.Drawing.Point(26, 118);
            this.lblRevenueTitle.Name = "lblRevenueTitle";
            this.lblRevenueTitle.Size = new System.Drawing.Size(140, 23);
            this.lblRevenueTitle.TabIndex = 0;
            this.lblRevenueTitle.Text = "Monthly Revenue";
            // 
            // pnlTreatments
            // 
            this.pnlTreatments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.pnlTreatments.Controls.Add(this.lblTreatmentsValue);
            this.pnlTreatments.Controls.Add(this.lblTreatmentsTitle);
            this.pnlTreatments.Location = new System.Drawing.Point(620, 40);
            this.pnlTreatments.Name = "pnlTreatments";
            this.pnlTreatments.Size = new System.Drawing.Size(270, 160);
            this.pnlTreatments.TabIndex = 2;
            // 
            // lblTreatmentsValue
            // 
            this.lblTreatmentsValue.AutoSize = true;
            this.lblTreatmentsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTreatmentsValue.ForeColor = System.Drawing.Color.White;
            this.lblTreatmentsValue.Location = new System.Drawing.Point(24, 54);
            this.lblTreatmentsValue.Name = "lblTreatmentsValue";
            this.lblTreatmentsValue.Size = new System.Drawing.Size(57, 46);
            this.lblTreatmentsValue.TabIndex = 1;
            this.lblTreatmentsValue.Text = "18";
            // 
            // lblTreatmentsTitle
            // 
            this.lblTreatmentsTitle.AutoSize = true;
            this.lblTreatmentsTitle.Font = new System.Drawing.Font("Segoe UI", 9.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTreatmentsTitle.ForeColor = System.Drawing.Color.White;
            this.lblTreatmentsTitle.Location = new System.Drawing.Point(26, 118);
            this.lblTreatmentsTitle.Name = "lblTreatmentsTitle";
            this.lblTreatmentsTitle.Size = new System.Drawing.Size(128, 23);
            this.lblTreatmentsTitle.TabIndex = 0;
            this.lblTreatmentsTitle.Text = "Total Treatments";
            // 
            // pnlAppointments
            // 
            this.pnlAppointments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(184)))), ((int)(((byte)(130)))));
            this.pnlAppointments.Controls.Add(this.lblAppointmentsValue);
            this.pnlAppointments.Controls.Add(this.lblAppointmentsTitle);
            this.pnlAppointments.Location = new System.Drawing.Point(330, 40);
            this.pnlAppointments.Name = "pnlAppointments";
            this.pnlAppointments.Size = new System.Drawing.Size(270, 160);
            this.pnlAppointments.TabIndex = 1;
            // 
            // lblAppointmentsValue
            // 
            this.lblAppointmentsValue.AutoSize = true;
            this.lblAppointmentsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsValue.ForeColor = System.Drawing.Color.White;
            this.lblAppointmentsValue.Location = new System.Drawing.Point(24, 54);
            this.lblAppointmentsValue.Name = "lblAppointmentsValue";
            this.lblAppointmentsValue.Size = new System.Drawing.Size(73, 46);
            this.lblAppointmentsValue.TabIndex = 1;
            this.lblAppointmentsValue.Text = "320";
            // 
            // lblAppointmentsTitle
            // 
            this.lblAppointmentsTitle.AutoSize = true;
            this.lblAppointmentsTitle.Font = new System.Drawing.Font("Segoe UI", 9.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppointmentsTitle.Location = new System.Drawing.Point(26, 118);
            this.lblAppointmentsTitle.Name = "lblAppointmentsTitle";
            this.lblAppointmentsTitle.Size = new System.Drawing.Size(155, 23);
            this.lblAppointmentsTitle.TabIndex = 0;
            this.lblAppointmentsTitle.Text = "Total Appointments";
            // 
            // pnlPatients
            // 
            this.pnlPatients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlPatients.Controls.Add(this.lblPatientsValue);
            this.pnlPatients.Controls.Add(this.lblPatientsTitle);
            this.pnlPatients.Location = new System.Drawing.Point(40, 40);
            this.pnlPatients.Name = "pnlPatients";
            this.pnlPatients.Size = new System.Drawing.Size(270, 160);
            this.pnlPatients.TabIndex = 0;
            // 
            // lblPatientsValue
            // 
            this.lblPatientsValue.AutoSize = true;
            this.lblPatientsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientsValue.ForeColor = System.Drawing.Color.White;
            this.lblPatientsValue.Location = new System.Drawing.Point(24, 54);
            this.lblPatientsValue.Name = "lblPatientsValue";
            this.lblPatientsValue.Size = new System.Drawing.Size(108, 46);
            this.lblPatientsValue.TabIndex = 1;
            this.lblPatientsValue.Text = "1,250";
            // 
            // lblPatientsTitle
            // 
            this.lblPatientsTitle.AutoSize = true;
            this.lblPatientsTitle.Font = new System.Drawing.Font("Segoe UI", 9.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientsTitle.ForeColor = System.Drawing.Color.White;
            this.lblPatientsTitle.Location = new System.Drawing.Point(26, 118);
            this.lblPatientsTitle.Name = "lblPatientsTitle";
            this.lblPatientsTitle.Size = new System.Drawing.Size(100, 23);
            this.lblPatientsTitle.TabIndex = 0;
            this.lblPatientsTitle.Text = "Total Patients";
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dental Clinic - Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlMonthlySummary.ResumeLayout(false);
            this.pnlMonthlySummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlySummary)).EndInit();
            this.pnlRevenue.ResumeLayout(false);
            this.pnlRevenue.PerformLayout();
            this.pnlTreatments.ResumeLayout(false);
            this.pnlTreatments.PerformLayout();
            this.pnlAppointments.ResumeLayout(false);
            this.pnlAppointments.PerformLayout();
            this.pnlPatients.ResumeLayout(false);
            this.pnlPatients.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlPatients;
        private System.Windows.Forms.Label lblPatientsValue;
        private System.Windows.Forms.Label lblPatientsTitle;
        private System.Windows.Forms.Panel pnlAppointments;
        private System.Windows.Forms.Label lblAppointmentsValue;
        private System.Windows.Forms.Label lblAppointmentsTitle;
        private System.Windows.Forms.Panel pnlTreatments;
        private System.Windows.Forms.Label lblTreatmentsValue;
        private System.Windows.Forms.Label lblTreatmentsTitle;
        private System.Windows.Forms.Panel pnlRevenue;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Label lblRevenueTitle;
        private System.Windows.Forms.Panel pnlMonthlySummary;
        private System.Windows.Forms.Label lblMonthlySummary;
        private System.Windows.Forms.DataGridView dgvMonthlySummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppointments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTreatments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRevenue;
    }
}
