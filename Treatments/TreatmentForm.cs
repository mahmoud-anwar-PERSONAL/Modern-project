using System;
using System.Drawing;
using System.Windows.Forms;

namespace dentalclinicprojecttreatments
{
    public partial class TreatmentForm : Form
    {
        public Action<string> NavigationRequested { get; set; }

        public TreatmentForm()
        {
            InitializeComponent();
            WireNavigation();
            dgvTreatments.Rows.Clear();

            dgvTreatments.Rows.Add("T001", "Teeth Cleaning", "Professional dental cleaning", "500", "30", "Available");
            dgvTreatments.Rows.Add("T002", "Teeth Whitening", "Whitening and stain removal", "1500", "60", "Available");
            dgvTreatments.Rows.Add("T003", "Root Canal", "Root canal treatment", "3000", "90", "Available");
            dgvTreatments.Rows.Add("T004", "Dental Filling", "Cavity filling treatment", "800", "45", "Available");
            dgvTreatments.Rows.Add("T005", "Tooth Extraction", "Tooth removal procedure", "1200", "30", "Unavailable");
            dgvTreatments.Rows.Add("T006", "Braces", "Orthodontic teeth alignment", "12000", "120", "Available");
            dgvTreatments.Rows.Add("T007", "Dental Checkup", "General dental examination", "300", "20", "Available");
            dgvTreatments.Rows.Add("T008", "Dental Crown", "Dental crown installation", "4000", "60", "Available");
            dgvTreatments.Rows.Add("T009", "Gum Treatment", "Treatment for gum inflammation", "1000", "45", "Available");
            dgvTreatments.Rows.Add("T010", "Dental Implant", "Replacement of missing tooth", "15000", "120", "Available");
            dgvTreatments.Rows.Add("T011", "Fluoride Treatment", "Strengthens tooth enamel", "400", "20", "Available");
            dgvTreatments.Rows.Add("T012", "Wisdom Tooth Removal", "Surgical wisdom tooth extraction", "2500", "60", "Available");
            dgvTreatments.Rows.Add("T013", "Dental Veneers", "Cosmetic tooth covering", "5000", "60", "Available");
            dgvTreatments.Rows.Add("T014", "Pediatric Dentistry", "Dental care for children", "600", "30", "Available");
            dgvTreatments.Rows.Add("T015", "Deep Cleaning", "Deep periodontal cleaning", "1800", "60", "Available");
            dgvTreatments.Rows.Add("T016", "Dental Bridge", "Replacement of missing teeth", "6500", "90", "Available");
            dgvTreatments.Rows.Add("T017", "Night Guard", "Custom protective dental guard", "2000", "30", "Available");
            dgvTreatments.Rows.Add("T018", "Emergency Dental Care", "Urgent dental examination", "1000", "30", "Available");
            dgvTreatments.Rows.Add("T019", "Orthodontic Consultation", "Braces assessment and consultation", "500", "30", "Available");
            dgvTreatments.Rows.Add("T020", "Retainer", "Custom teeth alignment retainer", "1800", "30", "Available");
            dgvTreatments.Rows.Add("T021", "Laser Gum Treatment", "Laser treatment for gum problems", "3500", "60", "Available");
            dgvTreatments.Rows.Add("T022", "Dental X-Ray", "Dental imaging and diagnosis", "350", "15", "Available");
            dgvTreatments.Rows.Add("T023", "Pulp Therapy", "Treatment of damaged dental pulp", "2200", "60", "Unavailable");
            dgvTreatments.Rows.Add("T024", "Temporary Filling", "Temporary cavity restoration", "400", "20", "Available");
            dgvTreatments.Rows.Add("T025", "Smile Makeover", "Complete cosmetic smile improvement", "20000", "180", "Available");
        }

        private void WireNavigation()
        {
            btnPatients.Click += (s, e) => RequestNavigation("Patients");
            btnAppointments.Click += (s, e) => RequestNavigation("Appointments");
            btnTreatments.Click += (s, e) => RequestNavigation("Treatments");
            btnReports.Click += (s, e) => RequestNavigation("Reports");
            btnLogOut.Click += (s, e) => RequestNavigation("Logout");
        }

        private void RequestNavigation(string page)
        {
            Action<string> handler = NavigationRequested;
            if (handler != null)
            {
                handler(page);
                return;
            }

            if (page == "Dashboard" || page == "Logout")
            {
                this.Close();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyUnifiedSidebar();
            ApplyPageLayout();
            Resize += (s, args) => ApplyPageLayout();
        }

        private void ApplyPageLayout()
        {
            if (pnlcontent == null || pnlcontent.ClientSize.Width < 480)
            {
                return;
            }

            pnlHeader.BackColor = Color.White;
            pnlHeader.Height = 112;

            lblPageTitle.AutoSize = true;
            lblPageTitle.Text = "Treatments";
            lblPageTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.FromArgb(35, 75, 130);
            lblPageTitle.Location = new Point(40, 24);

            lblPageSubTitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblPageSubTitle.ForeColor = Color.FromArgb(120, 130, 145);
            lblPageSubTitle.Location = new Point(40, 82);

            StylePrimaryButton(btnAddTreatment, "+ Add Treatment");
            btnAddTreatment.SetBounds(pnlHeader.ClientSize.Width - 210, 34, 170, 44);

            pnlTreatmentsList.SetBounds(40, 32, pnlcontent.ClientSize.Width - 80, pnlcontent.ClientSize.Height - 64);

            int cardWidth = pnlTreatmentsList.ClientSize.Width;
            int cardHeight = pnlTreatmentsList.ClientSize.Height;

            lblTreatmentsList.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTreatmentsList.ForeColor = Color.FromArgb(35, 75, 130);
            lblTreatmentsList.Location = new Point(24, 22);

            txtSearchTreatment.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtSearchTreatment.SetBounds(cardWidth - 204, 16, 180, 30);

            StyleActionButton(btnEditTreatment, "Edit Treatment", Color.Green);
            StyleActionButton(btnDeletTreatment, "Delete Treatment", Color.Brown);
            int actionTop = cardHeight - 56;
            btnDeletTreatment.SetBounds(cardWidth - 174, actionTop, 150, 36);
            btnEditTreatment.SetBounds(btnDeletTreatment.Left - 142, actionTop, 130, 36);

            dgvTreatments.SetBounds(24, 64, cardWidth - 48, actionTop - 80);

            coTreatmentlID.FillWeight = 60F;
            colTreatmentName.FillWeight = 180F;
            colDescription.FillWeight = 260F;
            colPrice.FillWeight = 100F;
            colDuration.FillWeight = 110F;
        }

        private static void StylePrimaryButton(Button button, string text)
        {
            button.Text = text;
            button.AutoSize = false;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.BackColor = Color.FromArgb(23, 100, 192);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 88, 167);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(17, 74, 142);
            button.UseVisualStyleBackColor = false;
            button.Cursor = Cursors.Hand;
        }

        private static void StyleActionButton(Button button, string text, Color backColor)
        {
            button.Text = text;
            button.AutoSize = false;
            button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.UseVisualStyleBackColor = false;
            button.Cursor = Cursors.Hand;
        }

        private void ApplyUnifiedSidebar()
        {
            pnlSidebar.Width = 240;
            pnlSidebar.BackColor = Color.FromArgb(35, 75, 130);
            button2.Visible = false;

            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pictureBox1.SetBounds(20, 12, 120, 120);

            StyleNavButton(btnDashboard, "Dashboard", 0, false);
            StyleNavButton(btnPatients, "Patients", 1, false);
            StyleNavButton(btnAppointments, "Appointments", 2, false);
            StyleNavButton(btnDoctors, "Doctors", 3, false);
            StyleNavButton(btnTreatments, "Treatments", 4, true);
            StyleNavButton(btnReports, "Reports", 5, false);
            StyleLogoutButton(btnLogOut);
        }

        private void StyleNavButton(Button button, string text, int index, bool active)
        {
            button.Text = text;
            button.AutoSize = false;
            button.Dock = DockStyle.None;
            button.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            button.SetBounds(0, 144 + (index * 46), 240, 44);
            button.Margin = Padding.Empty;
            button.Padding = new Padding(24, 0, 0, 0);
            button.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.ForeColor = Color.White;
            button.BackColor = active ? Color.FromArgb(38, 95, 155) : Color.FromArgb(35, 75, 130);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = active ? Color.FromArgb(38, 95, 155) : Color.FromArgb(55, 105, 170);
            button.FlatAppearance.MouseDownBackColor = active ? Color.FromArgb(38, 95, 155) : Color.FromArgb(31, 78, 134);
            button.UseVisualStyleBackColor = false;
            button.Cursor = Cursors.Hand;
            button.Visible = true;
        }

        private void StyleLogoutButton(Button button)
        {
            button.Text = "Log Out";
            button.AutoSize = false;
            button.Dock = DockStyle.None;
            button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button.SetBounds(0, pnlSidebar.ClientSize.Height - 64, 240, 48);
            button.Margin = Padding.Empty;
            button.Padding = new Padding(24, 0, 0, 0);
            button.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.ForeColor = Color.White;
            button.BackColor = Color.FromArgb(35, 75, 130);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 105, 170);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(31, 78, 134);
            button.UseVisualStyleBackColor = false;
            button.Cursor = Cursors.Hand;
            button.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            RequestNavigation("Doctors");
        }

        private void txtSearchTreatment_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlTreatmentsList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            RequestNavigation("Dashboard");
        }
    }
}
