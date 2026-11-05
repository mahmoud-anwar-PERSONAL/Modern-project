namespace WinFormsApp2
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelSidebar = new Panel();
            pnlSeparator = new Panel();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            picLogo = new PictureBox();
            pnlContent = new Panel();
            panel1 = new Panel();
            button10 = new Button();
            label1 = new Label();
            button9 = new Button();
            button8 = new Button();
            dgvPatients = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colRoom = new DataGridViewTextBoxColumn();
            colTreatment = new DataGridViewTextBoxColumn();
            colInsurance = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            pictureBox1 = new PictureBox();
            pnlHeader = new Panel();
            btnAddPatient = new Button();
            lblTitle = new Label();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlContent.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(35, 75, 130);
            panelSidebar.Controls.Add(pnlSeparator);
            panelSidebar.Controls.Add(button7);
            panelSidebar.Controls.Add(button6);
            panelSidebar.Controls.Add(button5);
            panelSidebar.Controls.Add(button4);
            panelSidebar.Controls.Add(button3);
            panelSidebar.Controls.Add(button2);
            panelSidebar.Controls.Add(button1);
            panelSidebar.Controls.Add(picLogo);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(273, 1570);
            panelSidebar.TabIndex = 0;
            // 
            // pnlSeparator
            // 
            pnlSeparator.Location = new Point(0, 198);
            pnlSeparator.Name = "pnlSeparator";
            pnlSeparator.Size = new Size(190, 10);
            pnlSeparator.TabIndex = 8;
            // 
            // button7
            // 
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button7.ForeColor = Color.White;
            button7.Location = new Point(0, 666);
            button7.Margin = new Padding(7);
            button7.Name = "button7";
            button7.Size = new Size(273, 48);
            button7.TabIndex = 7;
            button7.Text = "Logout";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button6.ForeColor = Color.White;
            button6.Location = new Point(0, 574);
            button6.Name = "button6";
            button6.Size = new Size(273, 48);
            button6.TabIndex = 6;
            button6.Text = "Reports";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Location = new Point(0, 501);
            button5.Margin = new Padding(7);
            button5.Name = "button5";
            button5.Size = new Size(273, 48);
            button5.TabIndex = 5;
            button5.Text = "Treatments";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(0, 439);
            button4.Margin = new Padding(7);
            button4.Name = "button4";
            button4.Size = new Size(273, 48);
            button4.TabIndex = 4;
            button4.Text = "Doctors";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(0, 381);
            button3.Margin = new Padding(7);
            button3.Name = "button3";
            button3.Size = new Size(273, 44);
            button3.TabIndex = 3;
            button3.Text = "Appointments";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(0, 308);
            button2.Margin = new Padding(7);
            button2.Name = "button2";
            button2.Size = new Size(273, 50);
            button2.TabIndex = 2;
            button2.Text = "Patients";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(0, 233);
            button1.Margin = new Padding(7);
            button1.Name = "button1";
            button1.Size = new Size(273, 61);
            button1.TabIndex = 1;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(12, 4);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(235, 219);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(panel1);
            pnlContent.Controls.Add(pictureBox1);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(273, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(2291, 1570);
            pnlContent.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button10);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(dgvPatients);
            panel1.Location = new Point(263, 155);
            panel1.Name = "panel1";
            panel1.Size = new Size(1798, 1092);
            panel1.TabIndex = 1;
            // 
            // button10
            // 
            button10.BackColor = Color.FromArgb(23, 100, 192);
            button10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button10.ForeColor = Color.White;
            button10.Location = new Point(1533, 30);
            button10.Name = "button10";
            button10.Size = new Size(126, 44);
            button10.TabIndex = 4;
            button10.Text = "Search";
            button10.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(16, 47, 85);
            label1.Location = new Point(90, 26);
            label1.Name = "label1";
            label1.Size = new Size(125, 45);
            label1.TabIndex = 3;
            label1.Text = "Patient";
            // 
            // button9
            // 
            button9.BackColor = Color.Red;
            button9.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.White;
            button9.Location = new Point(1650, 1031);
            button9.Name = "button9";
            button9.Size = new Size(112, 34);
            button9.TabIndex = 2;
            button9.Text = "Delete";
            button9.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.Green;
            button8.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.White;
            button8.Location = new Point(1493, 1031);
            button8.Name = "button8";
            button8.Size = new Size(122, 34);
            button8.TabIndex = 1;
            button8.Text = "Edit";
            button8.UseVisualStyleBackColor = false;
            // 
            // dgvPatients
            // 
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AllowUserToDeleteRows = false;
            dgvPatients.AllowUserToResizeColumns = false;
            dgvPatients.AllowUserToResizeRows = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.BackgroundColor = Color.White;
            dgvPatients.BorderStyle = BorderStyle.None;
            dgvPatients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(35, 75, 130);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPatients.ColumnHeadersHeight = 45;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPatients.Columns.AddRange(new DataGridViewColumn[] { colName, colDate, colRoom, colTreatment, colInsurance, colStatus });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(45, 55, 72);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(220, 232, 245);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(35, 75, 130);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvPatients.DefaultCellStyle = dataGridViewCellStyle4;
            dgvPatients.EnableHeadersVisualStyles = false;
            dgvPatients.GridColor = Color.FromArgb(235, 238, 242);
            dgvPatients.Location = new Point(30, 99);
            dgvPatients.Margin = new Padding(10);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.RowHeadersWidth = 62;
            dgvPatients.RowTemplate.Height = 50;
            dgvPatients.ScrollBars = ScrollBars.Vertical;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(1732, 907);
            dgvPatients.TabIndex = 0;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.FillWeight = 120F;
            colName.HeaderText = "Name";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 8;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colRoom
            // 
            colRoom.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoom.FillWeight = 55F;
            colRoom.HeaderText = "Room";
            colRoom.MinimumWidth = 8;
            colRoom.Name = "colRoom";
            colRoom.ReadOnly = true;
            // 
            // colTreatment
            // 
            colTreatment.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTreatment.FillWeight = 150F;
            colTreatment.HeaderText = "Treatment";
            colTreatment.MinimumWidth = 8;
            colTreatment.Name = "colTreatment";
            colTreatment.ReadOnly = true;
            // 
            // colInsurance
            // 
            colInsurance.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colInsurance.HeaderText = "Insurance";
            colInsurance.MinimumWidth = 8;
            colInsurance.Name = "colInsurance";
            colInsurance.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStatus.FillWeight = 110F;
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(2291, 1570);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(btnAddPatient);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(273, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(2291, 112);
            pnlHeader.TabIndex = 0;
            pnlHeader.Paint += pnlHeader_Paint;
            // 
            // btnAddPatient
            // 
            btnAddPatient.BackColor = Color.FromArgb(23, 100, 192);
            btnAddPatient.FlatStyle = FlatStyle.Flat;
            btnAddPatient.ForeColor = Color.White;
            btnAddPatient.Location = new Point(2041, 31);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Size = new Size(200, 76);
            btnAddPatient.TabIndex = 1;
            btnAddPatient.Text = "+ Add Patient";
            btnAddPatient.UseVisualStyleBackColor = false;
            btnAddPatient.Click += btnAddPatient_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(16, 47, 85);
            lblTitle.Location = new Point(263, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(210, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Patients";
            lblTitle.Click += lblTitle_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2564, 1570);
            Controls.Add(pnlHeader);
            Controls.Add(pnlContent);
            Controls.Add(panelSidebar);
            Font = new Font("Segoe UI", 10F);
            Name = "MainForm";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dental clinic - patients";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlContent.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private PictureBox picLogo;
        private Panel pnlContent;
        private Panel pnlHeader;
        private Button btnAddPatient;
        private Label lblTitle;
        private Panel pnlSeparator;
        private Panel panel1;
        private DataGridView dgvPatients;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colRoom;
        private DataGridViewTextBoxColumn colTreatment;
        private DataGridViewTextBoxColumn colInsurance;
        private DataGridViewTextBoxColumn colStatus;
        private Button button9;
        private Button button8;
        private PictureBox pictureBox1;
        private Label label1;
        private Button button10;
    }
}
