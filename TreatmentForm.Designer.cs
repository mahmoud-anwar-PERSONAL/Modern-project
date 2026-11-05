namespace dentalclinicprojecttreatments
{
    partial class TreatmentForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreatmentForm));
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            pnlSidebar = new Panel();
            btnReports = new Button();
            btnTreatments = new Button();
            btnDoctors = new Button();
            btnAppointments = new Button();
            btnPatients = new Button();
            button2 = new Button();
            btnDashboard = new Button();
            pictureBox1 = new PictureBox();
            pnlHeader = new Panel();
            lblPageSubTitle = new Label();
            btnAddTreatment = new Button();
            lblPageTitle = new Label();
            pnlcontent = new Panel();
            pnlTreatmentsList = new Panel();
            btnDeletTreatment = new Button();
            btnEditTreatment = new Button();
            dgvTreatments = new DataGridView();
            coTreatmentlID = new DataGridViewTextBoxColumn();
            colTreatmentName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colDuration = new DataGridViewTextBoxColumn();
            txtSearchTreatment = new TextBox();
            lblTreatmentsList = new Label();
            picTreatmentsContentBackgrounf = new PictureBox();
            btnLogOut = new Button();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlHeader.SuspendLayout();
            pnlcontent.SuspendLayout();
            pnlTreatmentsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTreatments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTreatmentsContentBackgrounf).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(35, 75, 130);
            pnlSidebar.Controls.Add(btnLogOut);
            pnlSidebar.Controls.Add(btnReports);
            pnlSidebar.Controls.Add(btnTreatments);
            pnlSidebar.Controls.Add(btnDoctors);
            pnlSidebar.Controls.Add(btnAppointments);
            pnlSidebar.Controls.Add(btnPatients);
            pnlSidebar.Controls.Add(button2);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(pictureBox1);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(234, 1055);
            pnlSidebar.TabIndex = 2;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(35, 75, 130);
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReports.ForeColor = Color.Snow;
            btnReports.Location = new Point(45, 560);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(150, 35);
            btnReports.TabIndex = 7;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = false;
            // 
            // btnTreatments
            // 
            btnTreatments.BackColor = Color.FromArgb(35, 75, 130);
            btnTreatments.FlatAppearance.BorderSize = 0;
            btnTreatments.FlatStyle = FlatStyle.Flat;
            btnTreatments.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTreatments.ForeColor = Color.Snow;
            btnTreatments.Location = new Point(45, 490);
            btnTreatments.Name = "btnTreatments";
            btnTreatments.Size = new Size(150, 35);
            btnTreatments.TabIndex = 6;
            btnTreatments.Text = "Treatments";
            btnTreatments.UseVisualStyleBackColor = false;
            // 
            // btnDoctors
            // 
            btnDoctors.BackColor = Color.FromArgb(35, 75, 130);
            btnDoctors.FlatAppearance.BorderSize = 0;
            btnDoctors.FlatStyle = FlatStyle.Flat;
            btnDoctors.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDoctors.ForeColor = Color.Snow;
            btnDoctors.Location = new Point(45, 420);
            btnDoctors.Name = "btnDoctors";
            btnDoctors.Size = new Size(150, 35);
            btnDoctors.TabIndex = 5;
            btnDoctors.Text = "Doctors";
            btnDoctors.UseVisualStyleBackColor = false;
            btnDoctors.Click += btnDoctors_Click;
            // 
            // btnAppointments
            // 
            btnAppointments.BackColor = Color.FromArgb(35, 75, 130);
            btnAppointments.FlatAppearance.BorderSize = 0;
            btnAppointments.FlatStyle = FlatStyle.Flat;
            btnAppointments.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAppointments.ForeColor = Color.Snow;
            btnAppointments.Location = new Point(45, 350);
            btnAppointments.Name = "btnAppointments";
            btnAppointments.Size = new Size(150, 35);
            btnAppointments.TabIndex = 4;
            btnAppointments.Text = "Appointments";
            btnAppointments.UseVisualStyleBackColor = false;
            
            // 
            // btnPatients
            // 
            btnPatients.BackColor = Color.FromArgb(35, 75, 130);
            btnPatients.FlatAppearance.BorderSize = 0;
            btnPatients.FlatStyle = FlatStyle.Flat;
            btnPatients.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPatients.ForeColor = Color.Snow;
            btnPatients.Location = new Point(45, 280);
            btnPatients.Name = "btnPatients";
            btnPatients.Size = new Size(150, 35);
            btnPatients.TabIndex = 3;
            btnPatients.Text = "Patients";
            btnPatients.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.Location = new Point(417, 229);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(35, 75, 130);
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.Snow;
            btnDashboard.Location = new Point(45, 210);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(150, 35);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(35, 75, 130);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(231, 184);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblPageSubTitle);
            pnlHeader.Controls.Add(btnAddTreatment);
            pnlHeader.Controls.Add(lblPageTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(234, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1690, 135);
            pnlHeader.TabIndex = 3;
            // 
            // lblPageSubTitle
            // 
            lblPageSubTitle.AutoSize = true;
            lblPageSubTitle.BackColor = Color.Transparent;
            lblPageSubTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPageSubTitle.ForeColor = Color.FromArgb(120, 130, 145);
            lblPageSubTitle.Location = new Point(89, 88);
            lblPageSubTitle.Name = "lblPageSubTitle";
            lblPageSubTitle.Size = new Size(268, 20);
            lblPageSubTitle.TabIndex = 0;
            lblPageSubTitle.Text = "Manage dental treatments and services";
            // 
            // btnAddTreatment
            // 
            btnAddTreatment.BackColor = Color.FromArgb(35, 75, 130);
            btnAddTreatment.Cursor = Cursors.Hand;
            btnAddTreatment.FlatAppearance.BorderSize = 0;
            btnAddTreatment.FlatStyle = FlatStyle.Flat;
            btnAddTreatment.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddTreatment.ForeColor = Color.White;
            btnAddTreatment.Location = new Point(1455, 40);
            btnAddTreatment.Name = "btnAddTreatment";
            btnAddTreatment.Size = new Size(225, 68);
            btnAddTreatment.TabIndex = 1;
            btnAddTreatment.Text = "+ AddTreatment";
            btnAddTreatment.UseVisualStyleBackColor = false;
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.BackColor = Color.Transparent;
            lblPageTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPageTitle.ForeColor = Color.FromArgb(35, 75, 130);
            lblPageTitle.Location = new Point(89, 40);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(207, 46);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Treatments ";
            // 
            // pnlcontent
            // 
            pnlcontent.BackColor = Color.FromArgb(245, 247, 250);
            pnlcontent.Controls.Add(pnlTreatmentsList);
            pnlcontent.Controls.Add(picTreatmentsContentBackgrounf);
            pnlcontent.Dock = DockStyle.Fill;
            pnlcontent.Location = new Point(234, 135);
            pnlcontent.Name = "pnlcontent";
            pnlcontent.Size = new Size(1690, 920);
            pnlcontent.TabIndex = 4;
            // 
            // pnlTreatmentsList
            // 
            pnlTreatmentsList.BackColor = Color.White;
            pnlTreatmentsList.Controls.Add(btnDeletTreatment);
            pnlTreatmentsList.Controls.Add(btnEditTreatment);
            pnlTreatmentsList.Controls.Add(dgvTreatments);
            pnlTreatmentsList.Controls.Add(txtSearchTreatment);
            pnlTreatmentsList.Controls.Add(lblTreatmentsList);
            pnlTreatmentsList.Location = new Point(223, 35);
            pnlTreatmentsList.Name = "pnlTreatmentsList";
            pnlTreatmentsList.Size = new Size(1234, 672);
            pnlTreatmentsList.TabIndex = 0;
            pnlTreatmentsList.Paint += pnlTreatmentsList_Paint;
            // 
            // btnDeletTreatment
            // 
            btnDeletTreatment.BackColor = Color.Brown;
            btnDeletTreatment.Cursor = Cursors.Hand;
            btnDeletTreatment.FlatAppearance.BorderSize = 0;
            btnDeletTreatment.FlatStyle = FlatStyle.Flat;
            btnDeletTreatment.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeletTreatment.ForeColor = Color.White;
            btnDeletTreatment.Location = new Point(1063, 618);
            btnDeletTreatment.Name = "btnDeletTreatment";
            btnDeletTreatment.Size = new Size(146, 37);
            btnDeletTreatment.TabIndex = 4;
            btnDeletTreatment.Text = "Delete Treatment";
            btnDeletTreatment.UseVisualStyleBackColor = false;
            // 
            // btnEditTreatment
            // 
            btnEditTreatment.BackColor = Color.Green;
            btnEditTreatment.Cursor = Cursors.Hand;
            btnEditTreatment.FlatAppearance.BorderSize = 0;
            btnEditTreatment.FlatStyle = FlatStyle.Flat;
            btnEditTreatment.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditTreatment.ForeColor = Color.White;
            btnEditTreatment.Location = new Point(890, 618);
            btnEditTreatment.Name = "btnEditTreatment";
            btnEditTreatment.Size = new Size(144, 37);
            btnEditTreatment.TabIndex = 3;
            btnEditTreatment.Text = "Edit Treatment";
            btnEditTreatment.UseVisualStyleBackColor = false;
            // 
            // dgvTreatments
            // 
            dgvTreatments.AllowUserToAddRows = false;
            dgvTreatments.AllowUserToDeleteRows = false;
            dgvTreatments.AllowUserToResizeColumns = false;
            dgvTreatments.AllowUserToResizeRows = false;
            dgvTreatments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTreatments.BackgroundColor = Color.White;
            dgvTreatments.BorderStyle = BorderStyle.None;
            dgvTreatments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(35, 75, 130);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvTreatments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvTreatments.ColumnHeadersHeight = 45;
            dgvTreatments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTreatments.Columns.AddRange(new DataGridViewColumn[] { coTreatmentlID, colTreatmentName, colDescription, colPrice, colDuration });
            dgvTreatments.EnableHeadersVisualStyles = false;
            dgvTreatments.GridColor = Color.FromArgb(235, 238, 245);
            dgvTreatments.Location = new Point(23, 77);
            dgvTreatments.Name = "dgvTreatments";
            dgvTreatments.ReadOnly = true;
            dgvTreatments.RowHeadersVisible = false;
            dgvTreatments.RowHeadersWidth = 51;
            dgvTreatments.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            dgvTreatments.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvTreatments.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 72);
            dgvTreatments.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 232, 245);
            dgvTreatments.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(35, 75, 130);
            dgvTreatments.RowTemplate.Height = 50;
            dgvTreatments.ScrollBars = ScrollBars.Vertical;
            dgvTreatments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTreatments.Size = new Size(1186, 522);
            dgvTreatments.TabIndex = 2;
            // 
            // coTreatmentlID
            // 
            coTreatmentlID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            coTreatmentlID.HeaderText = "ID";
            coTreatmentlID.MinimumWidth = 6;
            coTreatmentlID.Name = "coTreatmentlID";
            coTreatmentlID.ReadOnly = true;
            // 
            // colTreatmentName
            // 
            colTreatmentName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTreatmentName.HeaderText = "Treatment Name";
            colTreatmentName.MinimumWidth = 6;
            colTreatmentName.Name = "colTreatmentName";
            colTreatmentName.ReadOnly = true;
            // 
            // colDescription
            // 
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescription.HeaderText = "Description";
            colDescription.MinimumWidth = 6;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPrice.HeaderText = "Price (EGP)";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colDuration
            // 
            colDuration.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDuration.HeaderText = "Duration (Min)";
            colDuration.MinimumWidth = 6;
            colDuration.Name = "colDuration";
            colDuration.ReadOnly = true;
            // 
            // txtSearchTreatment
            // 
            txtSearchTreatment.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchTreatment.ForeColor = Color.FromArgb(45, 55, 72);
            txtSearchTreatment.Location = new Point(1063, 18);
            txtSearchTreatment.Name = "txtSearchTreatment";
            txtSearchTreatment.Size = new Size(146, 30);
            txtSearchTreatment.TabIndex = 1;
            txtSearchTreatment.Text = "Search Treatment";
            txtSearchTreatment.TextChanged += txtSearchTreatment_TextChanged;
            // 
            // lblTreatmentsList
            // 
            lblTreatmentsList.AutoSize = true;
            lblTreatmentsList.BackColor = Color.Transparent;
            lblTreatmentsList.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTreatmentsList.ForeColor = Color.FromArgb(35, 75, 130);
            lblTreatmentsList.Location = new Point(23, 14);
            lblTreatmentsList.Name = "lblTreatmentsList";
            lblTreatmentsList.Size = new Size(169, 31);
            lblTreatmentsList.TabIndex = 0;
            lblTreatmentsList.Text = "All Treatments";
            // 
            // picTreatmentsContentBackgrounf
            // 
            picTreatmentsContentBackgrounf.Dock = DockStyle.Fill;
            picTreatmentsContentBackgrounf.Image = (Image)resources.GetObject("picTreatmentsContentBackgrounf.Image");
            picTreatmentsContentBackgrounf.Location = new Point(0, 0);
            picTreatmentsContentBackgrounf.Name = "picTreatmentsContentBackgrounf";
            picTreatmentsContentBackgrounf.Size = new Size(1690, 920);
            picTreatmentsContentBackgrounf.SizeMode = PictureBoxSizeMode.StretchImage;
            picTreatmentsContentBackgrounf.TabIndex = 2;
            picTreatmentsContentBackgrounf.TabStop = false;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(35, 75, 130);
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.ForeColor = Color.Snow;
            btnLogOut.Location = new Point(45, 670);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(150, 35);
            btnLogOut.TabIndex = 8;
            btnLogOut.Text = "LogOut";
            btnLogOut.UseVisualStyleBackColor = false;
            
            // 
            // TreatmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(pnlcontent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            Name = "TreatmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlcontent.ResumeLayout(false);
            pnlTreatmentsList.ResumeLayout(false);
            pnlTreatmentsList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTreatments).EndInit();
            ((System.ComponentModel.ISupportInitialize)picTreatmentsContentBackgrounf).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlSidebar;
        private PictureBox pictureBox1;
        private Button btnTreatments;
        private Button btnDoctors;
        private Button btnAppointments;
        private Button btnPatients;
        private Button button2;
        private Button btnDashboard;
        private Button btnReports;
        private Panel pnlHeader;
        private Label lblPageTitle;
        private Panel pnlcontent;
        private Button btnAddTreatment;
        private Label lblPageSubTitle;
        private Panel pnlTreatmentsList;
        private TextBox txtSearchTreatment;
        private Label lblTreatmentsList;
        private DataGridView dgvTreatments;
        private DataGridViewTextBoxColumn coTreatmentlID;
        private DataGridViewTextBoxColumn colTreatmentName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colDuration;
        private Button btnDeletTreatment;
        private Button btnEditTreatment;
        private PictureBox picTreatmentsContentBackgrounf;
        private Button btnLogOut;
    }
}
