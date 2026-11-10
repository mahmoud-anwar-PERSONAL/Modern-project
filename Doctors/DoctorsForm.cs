using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic___Doctors_PROJECTMODERN
{
    public partial class DoctorsForm : Form
    {
        public Action<string> NavigationRequested { get; set; }

        public DoctorsForm()
        {
            InitializeComponent();
            WireNavigation();
            dgvDoctors.Rows.Clear();

            dgvDoctors.Rows.Add("D001", "Ahmed Mohamed", "Orthodontist", "01012345678");
            dgvDoctors.Rows.Add("D002", "Sara Ali", "Pediatric Dentist", "01123456789");
            dgvDoctors.Rows.Add("D003", "Omar Hassan", "Oral Surgeon", "01234567890");
            dgvDoctors.Rows.Add("D004", "Mariam Adel", "Endodontist", "01098765432");
            dgvDoctors.Rows.Add("D005", "Youssef Sherif", "General Dentist", "01198765432");
            dgvDoctors.Rows.Add("D006", "Nourhan Ali", "Periodontist", "01298765432");
            dgvDoctors.Rows.Add("D007", "Mohamed Samir", "Prosthodontist", "01055556666");
            dgvDoctors.Rows.Add("D008", "Salma Hassan", "Cosmetic Dentist", "01155556666");
            dgvDoctors.Rows.Add("D009", "Khaled Ibrahim", "Orthodontist", "01255556666");
            dgvDoctors.Rows.Add("D010", "Laila Mostafa", "General Dentist", "01044445555");
            dgvDoctors.Rows.Add("D011", "Amr Khalil", "Oral Surgeon", "01144445555");
            dgvDoctors.Rows.Add("D012", "Hana Mahmoud", "Pediatric Dentist", "01244445555");
            dgvDoctors.Rows.Add("D013", "Tarek Adel", "Endodontist", "01033334444");
            dgvDoctors.Rows.Add("D014", "Farah Samy", "Cosmetic Dentist", "01133334444");
            dgvDoctors.Rows.Add("D015", "Mostafa Nabil", "Periodontist", "01233334444");
            dgvDoctors.Rows.Add("D016", "Rana Ashraf", "General Dentist", "01022223333");
            dgvDoctors.Rows.Add("D017", "Hossam Fathy", "Prosthodontist", "01122223333");
            dgvDoctors.Rows.Add("D018", "Dina Wael", "Orthodontist", "01222223333");
            dgvDoctors.Rows.Add("D019", "Karim Sameh", "Oral Surgeon", "01011112222");
            dgvDoctors.Rows.Add("D020", "Nadia Emad", "Pediatric Dentist", "01111112222");

        }

        private void WireNavigation()
        {
            btnPatients.Click += (s, e) => RequestNavigation("Patients");
            btnAppointments.Click += (s, e) => RequestNavigation("Appointments");
            btnDoctors.Click += (s, e) => RequestNavigation("Doctors");
            btnTreatments.Click += (s, e) => RequestNavigation("Treatments");
            btnReports.Click += (s, e) => RequestNavigation("Reports");
            btnLogout.Click += (s, e) => RequestNavigation("Logout");
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
            if (pnlContent == null || pnlContent.ClientSize.Width < 480)
            {
                return;
            }

            pnlHeader.BackColor = Color.White;
            pnlHeader.Height = 112;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(35, 75, 130);
            lblTitle.Location = new Point(40, 24);

            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            label1.ForeColor = Color.FromArgb(120, 130, 145);
            label1.Location = new Point(40, 82);

            StylePrimaryButton(btnAddDoctor, "+ Add Doctor");
            btnAddDoctor.SetBounds(pnlHeader.ClientSize.Width - 200, 34, 160, 44);

            pnlGDV.SetBounds(40, 32, pnlContent.ClientSize.Width - 80, pnlContent.ClientSize.Height - 64);

            int cardWidth = pnlGDV.ClientSize.Width;
            int cardHeight = pnlGDV.ClientSize.Height;

            lblDoctorslist.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDoctorslist.ForeColor = Color.FromArgb(35, 75, 130);
            lblDoctorslist.Location = new Point(24, 22);

            txtSearchDoctor.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtSearchDoctor.SetBounds(cardWidth - 204, 16, 180, 30);

            StyleActionButton(btnEditDoctor, "Edit Doctor", Color.Green);
            StyleActionButton(btnDeleteDoctor, "Delete Doctor", Color.Brown);
            int actionTop = cardHeight - 56;
            btnDeleteDoctor.SetBounds(cardWidth - 164, actionTop, 140, 36);
            btnEditDoctor.SetBounds(btnDeleteDoctor.Left - 142, actionTop, 130, 36);

            dgvDoctors.SetBounds(24, 64, cardWidth - 48, actionTop - 80);

            colID.FillWeight = 60F;
            colName.FillWeight = 180F;
            colSpec.FillWeight = 180F;
            colPhone.FillWeight = 150F;
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
            pictureBox1.Visible = false;

            pbLogo.BackColor = Color.Transparent;
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pbLogo.SetBounds(20, 12, 120, 120);

            StyleNavButton(btnDashboard, "Dashboard", 0, false);
            StyleNavButton(btnPatients, "Patients", 1, false);
            StyleNavButton(btnAppointments, "Appointments", 2, false);
            StyleNavButton(btnDoctors, "Doctors", 3, true);
            StyleNavButton(btnTreatments, "Treatments", 4, false);
            StyleNavButton(btnReports, "Reports", 5, false);
            StyleLogoutButton(btnLogout);
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dgvDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            RequestNavigation("Dashboard");
        }
    }
}
