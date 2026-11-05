namespace DentalClinicManagementSystem
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnTreatments = new System.Windows.Forms.Button();
            this.btnPatients = new System.Windows.Forms.Button();
            this.btnAppointments = new System.Windows.Forms.Button();
            this.btnDoctors = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pictlogo = new System.Windows.Forms.PictureBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlQuickActions = new System.Windows.Forms.Panel();
            this.btnViewReports = new System.Windows.Forms.Button();
            this.btnAddDoctor = new System.Windows.Forms.Button();
            this.btnBookAppointment = new System.Windows.Forms.Button();
            this.btnAddPatient = new System.Windows.Forms.Button();
            this.lblQuickActions = new System.Windows.Forms.Label();
            this.pnlRecentAppointments = new System.Windows.Forms.Panel();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTreatment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRecentAppointments = new System.Windows.Forms.Label();
            this.pnlTreatments = new System.Windows.Forms.Panel();
            this.picTreatments = new System.Windows.Forms.PictureBox();
            this.lblTreatmentsCount = new System.Windows.Forms.Label();
            this.lblTreatmentsTitle = new System.Windows.Forms.Label();
            this.pnlAppointments = new System.Windows.Forms.Panel();
            this.picAppointments = new System.Windows.Forms.PictureBox();
            this.lblAppointmentsCount = new System.Windows.Forms.Label();
            this.lblAppointmentsTitle = new System.Windows.Forms.Label();
            this.pnlTotalPatients = new System.Windows.Forms.Panel();
            this.picPatients = new System.Windows.Forms.PictureBox();
            this.lblPatientsCount = new System.Windows.Forms.Label();
            this.lblPatientsTitle = new System.Windows.Forms.Label();
            this.picContentBackground = new System.Windows.Forms.PictureBox();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictlogo)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlQuickActions.SuspendLayout();
            this.pnlRecentAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.pnlTreatments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTreatments)).BeginInit();
            this.pnlAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAppointments)).BeginInit();
            this.pnlTotalPatients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPatients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picContentBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.btnTreatments);
            this.pnlSidebar.Controls.Add(this.btnPatients);
            this.pnlSidebar.Controls.Add(this.btnAppointments);
            this.pnlSidebar.Controls.Add(this.btnDoctors);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.pictlogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(500, 1977);
            this.pnlSidebar.TabIndex = 0;
            this.pnlSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSidebar_Paint);
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(60, 1600);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(400, 80);
            this.btnLogout.TabIndex = 14;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReports
            // 
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(60, 1300);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(400, 80);
            this.btnReports.TabIndex = 13;
            this.btnReports.Text = "Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            // 
            // btnTreatments
            // 
            this.btnTreatments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTreatments.FlatAppearance.BorderSize = 0;
            this.btnTreatments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.btnTreatments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTreatments.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTreatments.ForeColor = System.Drawing.Color.White;
            this.btnTreatments.Location = new System.Drawing.Point(60, 1150);
            this.btnTreatments.Name = "btnTreatments";
            this.btnTreatments.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTreatments.Size = new System.Drawing.Size(400, 80);
            this.btnTreatments.TabIndex = 12;
            this.btnTreatments.Text = "Treatments";
            this.btnTreatments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTreatments.UseVisualStyleBackColor = false;
            // 
            // btnPatients
            // 
            this.btnPatients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPatients.FlatAppearance.BorderSize = 0;
            this.btnPatients.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.btnPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatients.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatients.ForeColor = System.Drawing.Color.White;
            this.btnPatients.Location = new System.Drawing.Point(60, 700);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPatients.Size = new System.Drawing.Size(400, 80);
            this.btnPatients.TabIndex = 11;
            this.btnPatients.Text = "Patients";
            this.btnPatients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatients.UseVisualStyleBackColor = false;
            // 
            // btnAppointments
            // 
            this.btnAppointments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAppointments.FlatAppearance.BorderSize = 0;
            this.btnAppointments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.btnAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppointments.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppointments.ForeColor = System.Drawing.Color.White;
            this.btnAppointments.Location = new System.Drawing.Point(60, 850);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAppointments.Size = new System.Drawing.Size(400, 80);
            this.btnAppointments.TabIndex = 10;
            this.btnAppointments.Text = "Appointments";
            this.btnAppointments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppointments.UseVisualStyleBackColor = false;
            // 
            // btnDoctors
            // 
            this.btnDoctors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoctors.FlatAppearance.BorderSize = 0;
            this.btnDoctors.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.btnDoctors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoctors.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoctors.ForeColor = System.Drawing.Color.White;
            this.btnDoctors.Location = new System.Drawing.Point(60, 1000);
            this.btnDoctors.Name = "btnDoctors";
            this.btnDoctors.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDoctors.Size = new System.Drawing.Size(400, 80);
            this.btnDoctors.TabIndex = 9;
            this.btnDoctors.Text = "Doctors";
            this.btnDoctors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoctors.UseVisualStyleBackColor = false;
            this.btnDoctors.Click += new System.EventHandler(this.btnDoctors_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(95)))), ((int)(((byte)(155)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(60, 550);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(400, 80);
            this.btnDashboard.TabIndex = 8;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // pictlogo
            // 
            this.pictlogo.BackColor = System.Drawing.Color.Transparent;
            this.pictlogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictlogo.Image = ((System.Drawing.Image)(resources.GetObject("pictlogo.Image")));
            this.pictlogo.Location = new System.Drawing.Point(-12, 0);
            this.pictlogo.Name = "pictlogo";
            this.pictlogo.Size = new System.Drawing.Size(515, 447);
            this.pictlogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictlogo.TabIndex = 1;
            this.pictlogo.TabStop = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTime);
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(500, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(3153, 280);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.lblTime.Location = new System.Drawing.Point(2918, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(235, 62);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "07:30 PM";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.lblDate.Location = new System.Drawing.Point(60, 169);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(495, 50);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Tuesday, November 03, 2026";
            this.lblDate.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.lblPageTitle.Location = new System.Drawing.Point(36, 51);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(712, 106);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Welcome Admin !";
            this.lblPageTitle.Click += new System.EventHandler(this.lblPageTitle_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlContent.Controls.Add(this.pnlQuickActions);
            this.pnlContent.Controls.Add(this.pnlRecentAppointments);
            this.pnlContent.Controls.Add(this.pnlTreatments);
            this.pnlContent.Controls.Add(this.pnlAppointments);
            this.pnlContent.Controls.Add(this.pnlTotalPatients);
            this.pnlContent.Controls.Add(this.picContentBackground);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(500, 280);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(3153, 1697);
            this.pnlContent.TabIndex = 2;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // pnlQuickActions
            // 
            this.pnlQuickActions.BackColor = System.Drawing.Color.White;
            this.pnlQuickActions.Controls.Add(this.btnViewReports);
            this.pnlQuickActions.Controls.Add(this.btnAddDoctor);
            this.pnlQuickActions.Controls.Add(this.btnBookAppointment);
            this.pnlQuickActions.Controls.Add(this.btnAddPatient);
            this.pnlQuickActions.Controls.Add(this.lblQuickActions);
            this.pnlQuickActions.Location = new System.Drawing.Point(2300, 476);
            this.pnlQuickActions.Name = "pnlQuickActions";
            this.pnlQuickActions.Size = new System.Drawing.Size(700, 960);
            this.pnlQuickActions.TabIndex = 6;
            // 
            // btnViewReports
            // 
            this.btnViewReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.btnViewReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewReports.FlatAppearance.BorderSize = 0;
            this.btnViewReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReports.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReports.ForeColor = System.Drawing.Color.White;
            this.btnViewReports.Location = new System.Drawing.Point(35, 765);
            this.btnViewReports.Name = "btnViewReports";
            this.btnViewReports.Size = new System.Drawing.Size(640, 120);
            this.btnViewReports.TabIndex = 4;
            this.btnViewReports.Text = "View Reports";
            this.btnViewReports.UseVisualStyleBackColor = false;
            // 
            // btnAddDoctor
            // 
            this.btnAddDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.btnAddDoctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDoctor.FlatAppearance.BorderSize = 0;
            this.btnAddDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDoctor.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDoctor.ForeColor = System.Drawing.Color.White;
            this.btnAddDoctor.Location = new System.Drawing.Point(35, 565);
            this.btnAddDoctor.Name = "btnAddDoctor";
            this.btnAddDoctor.Size = new System.Drawing.Size(640, 120);
            this.btnAddDoctor.TabIndex = 3;
            this.btnAddDoctor.Text = "+ Add Doctor";
            this.btnAddDoctor.UseVisualStyleBackColor = false;
            // 
            // btnBookAppointment
            // 
            this.btnBookAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.btnBookAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBookAppointment.FlatAppearance.BorderSize = 0;
            this.btnBookAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookAppointment.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookAppointment.ForeColor = System.Drawing.Color.White;
            this.btnBookAppointment.Location = new System.Drawing.Point(35, 365);
            this.btnBookAppointment.Name = "btnBookAppointment";
            this.btnBookAppointment.Size = new System.Drawing.Size(640, 120);
            this.btnBookAppointment.TabIndex = 2;
            this.btnBookAppointment.Text = "+ Book Appointment";
            this.btnBookAppointment.UseVisualStyleBackColor = false;
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.btnAddPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPatient.FlatAppearance.BorderSize = 0;
            this.btnAddPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPatient.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPatient.ForeColor = System.Drawing.Color.White;
            this.btnAddPatient.Location = new System.Drawing.Point(35, 165);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(640, 120);
            this.btnAddPatient.TabIndex = 1;
            this.btnAddPatient.Text = "+ Add Patient";
            this.btnAddPatient.UseVisualStyleBackColor = false;
            // 
            // lblQuickActions
            // 
            this.lblQuickActions.AutoSize = true;
            this.lblQuickActions.Font = new System.Drawing.Font("Segoe UI", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuickActions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.lblQuickActions.Location = new System.Drawing.Point(208, 60);
            this.lblQuickActions.Name = "lblQuickActions";
            this.lblQuickActions.Size = new System.Drawing.Size(331, 62);
            this.lblQuickActions.TabIndex = 0;
            this.lblQuickActions.Text = "Quick Actions";
            // 
            // pnlRecentAppointments
            // 
            this.pnlRecentAppointments.BackColor = System.Drawing.Color.White;
            this.pnlRecentAppointments.Controls.Add(this.dgvAppointments);
            this.pnlRecentAppointments.Controls.Add(this.lblRecentAppointments);
            this.pnlRecentAppointments.Location = new System.Drawing.Point(300, 476);
            this.pnlRecentAppointments.Name = "pnlRecentAppointments";
            this.pnlRecentAppointments.Size = new System.Drawing.Size(1700, 967);
            this.pnlRecentAppointments.TabIndex = 5;
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AllowUserToResizeColumns = false;
            this.dgvAppointments.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.dgvAppointments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppointments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAppointments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAppointments.ColumnHeadersHeight = 60;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colPatientName,
            this.colTreatment,
            this.colStatus});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppointments.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAppointments.EnableHeadersVisualStyles = false;
            this.dgvAppointments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.dgvAppointments.Location = new System.Drawing.Point(20, 126);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersVisible = false;
            this.dgvAppointments.RowHeadersWidth = 102;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvAppointments.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAppointments.RowTemplate.Height = 45;
            this.dgvAppointments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(1656, 817);
            this.dgvAppointments.TabIndex = 1;
            this.dgvAppointments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointments_CellContentClick);
            // 
            // colTime
            // 
            this.colTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTime.FillWeight = 78.84818F;
            this.colTime.HeaderText = "Time";
            this.colTime.MinimumWidth = 80;
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // colPatientName
            // 
            this.colPatientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPatientName.FillWeight = 129.0007F;
            this.colPatientName.HeaderText = "Patient Name";
            this.colPatientName.MinimumWidth = 80;
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;
            // 
            // colTreatment
            // 
            this.colTreatment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTreatment.FillWeight = 133.3277F;
            this.colTreatment.HeaderText = "Treatment";
            this.colTreatment.MinimumWidth = 80;
            this.colTreatment.Name = "colTreatment";
            this.colTreatment.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(120)))), ((int)(((byte)(75)))));
            this.colStatus.DefaultCellStyle = dataGridViewCellStyle3;
            this.colStatus.FillWeight = 58.82353F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 80;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // lblRecentAppointments
            // 
            this.lblRecentAppointments.AutoSize = true;
            this.lblRecentAppointments.BackColor = System.Drawing.Color.Transparent;
            this.lblRecentAppointments.Font = new System.Drawing.Font("Segoe UI", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentAppointments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.lblRecentAppointments.Location = new System.Drawing.Point(23, 39);
            this.lblRecentAppointments.Name = "lblRecentAppointments";
            this.lblRecentAppointments.Size = new System.Drawing.Size(503, 62);
            this.lblRecentAppointments.TabIndex = 0;
            this.lblRecentAppointments.Text = "Recent Appointments";
            // 
            // pnlTreatments
            // 
            this.pnlTreatments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.pnlTreatments.Controls.Add(this.picTreatments);
            this.pnlTreatments.Controls.Add(this.lblTreatmentsCount);
            this.pnlTreatments.Controls.Add(this.lblTreatmentsTitle);
            this.pnlTreatments.Location = new System.Drawing.Point(2300, 65);
            this.pnlTreatments.Name = "pnlTreatments";
            this.pnlTreatments.Size = new System.Drawing.Size(700, 328);
            this.pnlTreatments.TabIndex = 4;
            // 
            // picTreatments
            // 
            this.picTreatments.BackColor = System.Drawing.Color.Transparent;
            this.picTreatments.Image = ((System.Drawing.Image)(resources.GetObject("picTreatments.Image")));
            this.picTreatments.Location = new System.Drawing.Point(67, 64);
            this.picTreatments.Name = "picTreatments";
            this.picTreatments.Size = new System.Drawing.Size(285, 212);
            this.picTreatments.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTreatments.TabIndex = 3;
            this.picTreatments.TabStop = false;
            // 
            // lblTreatmentsCount
            // 
            this.lblTreatmentsCount.AutoSize = true;
            this.lblTreatmentsCount.Font = new System.Drawing.Font("Segoe UI", 24.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTreatmentsCount.ForeColor = System.Drawing.Color.White;
            this.lblTreatmentsCount.Location = new System.Drawing.Point(459, 64);
            this.lblTreatmentsCount.Name = "lblTreatmentsCount";
            this.lblTreatmentsCount.Size = new System.Drawing.Size(143, 110);
            this.lblTreatmentsCount.TabIndex = 2;
            this.lblTreatmentsCount.Text = "18";
            // 
            // lblTreatmentsTitle
            // 
            this.lblTreatmentsTitle.AutoSize = true;
            this.lblTreatmentsTitle.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTreatmentsTitle.ForeColor = System.Drawing.Color.White;
            this.lblTreatmentsTitle.Location = new System.Drawing.Point(404, 214);
            this.lblTreatmentsTitle.Name = "lblTreatmentsTitle";
            this.lblTreatmentsTitle.Size = new System.Drawing.Size(267, 46);
            this.lblTreatmentsTitle.TabIndex = 0;
            this.lblTreatmentsTitle.Text = "Total Treatments";
            // 
            // pnlAppointments
            // 
            this.pnlAppointments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(184)))), ((int)(((byte)(130)))));
            this.pnlAppointments.Controls.Add(this.picAppointments);
            this.pnlAppointments.Controls.Add(this.lblAppointmentsCount);
            this.pnlAppointments.Controls.Add(this.lblAppointmentsTitle);
            this.pnlAppointments.Location = new System.Drawing.Point(1300, 65);
            this.pnlAppointments.Name = "pnlAppointments";
            this.pnlAppointments.Size = new System.Drawing.Size(700, 328);
            this.pnlAppointments.TabIndex = 1;
            // 
            // picAppointments
            // 
            this.picAppointments.BackColor = System.Drawing.Color.Transparent;
            this.picAppointments.Image = ((System.Drawing.Image)(resources.GetObject("picAppointments.Image")));
            this.picAppointments.Location = new System.Drawing.Point(32, 64);
            this.picAppointments.Name = "picAppointments";
            this.picAppointments.Size = new System.Drawing.Size(251, 216);
            this.picAppointments.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAppointments.TabIndex = 3;
            this.picAppointments.TabStop = false;
            // 
            // lblAppointmentsCount
            // 
            this.lblAppointmentsCount.AutoSize = true;
            this.lblAppointmentsCount.Font = new System.Drawing.Font("Segoe UI", 24.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsCount.ForeColor = System.Drawing.Color.White;
            this.lblAppointmentsCount.Location = new System.Drawing.Point(425, 64);
            this.lblAppointmentsCount.Name = "lblAppointmentsCount";
            this.lblAppointmentsCount.Size = new System.Drawing.Size(191, 110);
            this.lblAppointmentsCount.TabIndex = 2;
            this.lblAppointmentsCount.Text = "320";
            // 
            // lblAppointmentsTitle
            // 
            this.lblAppointmentsTitle.AutoSize = true;
            this.lblAppointmentsTitle.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppointmentsTitle.Location = new System.Drawing.Point(362, 214);
            this.lblAppointmentsTitle.Name = "lblAppointmentsTitle";
            this.lblAppointmentsTitle.Size = new System.Drawing.Size(314, 46);
            this.lblAppointmentsTitle.TabIndex = 0;
            this.lblAppointmentsTitle.Text = "Total Appointments";
            // 
            // pnlTotalPatients
            // 
            this.pnlTotalPatients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlTotalPatients.Controls.Add(this.picPatients);
            this.pnlTotalPatients.Controls.Add(this.lblPatientsCount);
            this.pnlTotalPatients.Controls.Add(this.lblPatientsTitle);
            this.pnlTotalPatients.Location = new System.Drawing.Point(300, 65);
            this.pnlTotalPatients.Name = "pnlTotalPatients";
            this.pnlTotalPatients.Size = new System.Drawing.Size(700, 328);
            this.pnlTotalPatients.TabIndex = 0;
            this.pnlTotalPatients.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTotalPatients_Paint);
            // 
            // picPatients
            // 
            this.picPatients.BackColor = System.Drawing.Color.Transparent;
            this.picPatients.Image = ((System.Drawing.Image)(resources.GetObject("picPatients.Image")));
            this.picPatients.Location = new System.Drawing.Point(34, 42);
            this.picPatients.Name = "picPatients";
            this.picPatients.Size = new System.Drawing.Size(242, 238);
            this.picPatients.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPatients.TabIndex = 3;
            this.picPatients.TabStop = false;
            // 
            // lblPatientsCount
            // 
            this.lblPatientsCount.AutoSize = true;
            this.lblPatientsCount.Font = new System.Drawing.Font("Segoe UI", 24.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientsCount.ForeColor = System.Drawing.Color.White;
            this.lblPatientsCount.Location = new System.Drawing.Point(376, 64);
            this.lblPatientsCount.Name = "lblPatientsCount";
            this.lblPatientsCount.Size = new System.Drawing.Size(261, 110);
            this.lblPatientsCount.TabIndex = 2;
            this.lblPatientsCount.Text = "1,250";
            this.lblPatientsCount.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblPatientsTitle
            // 
            this.lblPatientsTitle.AutoSize = true;
            this.lblPatientsTitle.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientsTitle.ForeColor = System.Drawing.Color.White;
            this.lblPatientsTitle.Location = new System.Drawing.Point(404, 214);
            this.lblPatientsTitle.Name = "lblPatientsTitle";
            this.lblPatientsTitle.Size = new System.Drawing.Size(219, 46);
            this.lblPatientsTitle.TabIndex = 0;
            this.lblPatientsTitle.Text = "Total Patients";
            // 
            // picContentBackground
            // 
            this.picContentBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picContentBackground.Image = ((System.Drawing.Image)(resources.GetObject("picContentBackground.Image")));
            this.picContentBackground.Location = new System.Drawing.Point(0, 0);
            this.picContentBackground.Name = "picContentBackground";
            this.picContentBackground.Size = new System.Drawing.Size(3153, 1697);
            this.picContentBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picContentBackground.TabIndex = 7;
            this.picContentBackground.TabStop = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(3653, 1977);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dental Clinic Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictlogo)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlQuickActions.ResumeLayout(false);
            this.pnlQuickActions.PerformLayout();
            this.pnlRecentAppointments.ResumeLayout(false);
            this.pnlRecentAppointments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.pnlTreatments.ResumeLayout(false);
            this.pnlTreatments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTreatments)).EndInit();
            this.pnlAppointments.ResumeLayout(false);
            this.pnlAppointments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAppointments)).EndInit();
            this.pnlTotalPatients.ResumeLayout(false);
            this.pnlTotalPatients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPatients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picContentBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.PictureBox pictlogo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnTreatments;
        private System.Windows.Forms.Button btnPatients;
        private System.Windows.Forms.Button btnAppointments;
        private System.Windows.Forms.Button btnDoctors;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlTotalPatients;
        private System.Windows.Forms.Label lblPatientsTitle;
        private System.Windows.Forms.Label lblPatientsCount;
        private System.Windows.Forms.Panel pnlAppointments;
        private System.Windows.Forms.Label lblAppointmentsCount;
        private System.Windows.Forms.Label lblAppointmentsTitle;
        private System.Windows.Forms.Panel pnlTreatments;
        private System.Windows.Forms.Label lblTreatmentsCount;
        private System.Windows.Forms.Label lblTreatmentsTitle;
        private System.Windows.Forms.Panel pnlRecentAppointments;
        private System.Windows.Forms.Label lblRecentAppointments;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.PictureBox picPatients;
        private System.Windows.Forms.PictureBox picAppointments;
        private System.Windows.Forms.PictureBox picTreatments;
        private System.Windows.Forms.Panel pnlQuickActions;
        private System.Windows.Forms.Label lblQuickActions;
        private System.Windows.Forms.Button btnViewReports;
        private System.Windows.Forms.Button btnAddDoctor;
        private System.Windows.Forms.Button btnBookAppointment;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTreatment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.PictureBox picContentBackground;
    }
}

