using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentsForm
{
    public partial class AppointmentsForm: Form
    {
        public Action<string> NavigationRequested { get; set; }

        public AppointmentsForm()
        {
            InitializeComponent();
            WireNavigation();
        }

        private void WireNavigation()
        {
            btnPatients.Click += (s, e) => RequestNavigation("Patients");
            btnAppointments.Click += (s, e) => RequestNavigation("Appointments");
            btnTreatments.Click += (s, e) => RequestNavigation("Treatments");
            btnReports.Click += (s, e) => RequestNavigation("Reports");
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

        private Panel pnlTopBand;
        private Panel pnlTableCard;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            WindowState = FormWindowState.Maximized;
            ApplyUnifiedSidebar();
            ApplyPageLayout();
            Resize += (s, args) => ApplyPageLayout();
        }

        private void ApplyPageLayout()
        {
            if (pnlMain == null || pnlMain.ClientSize.Width < 480)
            {
                return;
            }

            if (pnlTopBand == null)
            {
                pnlTopBand = new Panel();
                pnlTopBand.Name = "pnlTopBand";
                pnlTopBand.Dock = DockStyle.Top;
                pnlTopBand.BackColor = Color.White;
                pnlMain.Controls.Add(pnlTopBand);
                pnlTopBand.BringToFront();

                pnlTopBand.Controls.Add(lblTitle);
                pnlTopBand.Controls.Add(btnNewAppointment);

                pnlTableCard = new Panel();
                pnlTableCard.Name = "pnlTableCard";
                pnlTableCard.BackColor = Color.White;
                pnlMain.Controls.Add(pnlTableCard);
                pnlTableCard.BringToFront();
                pnlTableCard.Controls.Add(dgvAppointments);

                pnlMain.Controls.SetChildIndex(pictureBox1, pnlMain.Controls.Count - 1);
            }

            label1.Visible = false;
            pnlTopBand.Height = 112;

            lblTitle.Text = "Appointments";
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(35, 75, 130);
            lblTitle.Location = new Point(40, 24);

            StylePrimaryButton(btnNewAppointment, "+ New Appointment");
            btnNewAppointment.SetBounds(pnlTopBand.ClientSize.Width - 210, 34, 170, 44);

            pnlTableCard.SetBounds(40, 144, pnlMain.ClientSize.Width - 80, pnlMain.ClientSize.Height - 184);
            dgvAppointments.SetBounds(16, 16, pnlTableCard.ClientSize.Width - 32, pnlTableCard.ClientSize.Height - 32);

            dgvAppointments.DefaultCellStyle.BackColor = Color.White;
            dgvAppointments.DefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 72);
            dgvAppointments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 232, 245);
            dgvAppointments.DefaultCellStyle.SelectionForeColor = Color.FromArgb(35, 75, 130);
            dgvAppointments.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvAppointments.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 72);

            ID.FillWeight = 60F;
            Patient.FillWeight = 200F;
            Doctor.FillWeight = 170F;
            Date.FillWeight = 110F;
            Time.FillWeight = 100F;
            Status.FillWeight = 120F;
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

        private void ApplyUnifiedSidebar()
        {
            pnlSidebar.Width = 240;
            pnlSidebar.BackColor = Color.FromArgb(35, 75, 130);

            picLogo.BackColor = Color.Transparent;
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            picLogo.SetBounds(20, 12, 120, 120);

            StyleNavButton(btnDashboard, "Dashboard", 0, false);
            StyleNavButton(btnPatients, "Patients", 1, false);
            StyleNavButton(btnAppointments, "Appointments", 2, true);
            StyleNavButton(btnDoctors, "Doctors", 3, false);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RequestNavigation("Doctors");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RequestNavigation("Logout");
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AppointmentsForm_Load(object sender, EventArgs e)
        {



            dgvAppointments.Rows.Add("A001", "Mahmoud Anwar", "Ahmed Mohamed", "05/11/2026", "09:00 AM", "Confirmed");
            dgvAppointments.Rows.Add("A002", "Mona Hassan", "Sara Ali", "05/11/2026", "09:30 AM", "Pending");
            dgvAppointments.Rows.Add("A003", "Omar Khaled", "Omar Hassan", "05/11/2026", "10:00 AM", "Completed");
            dgvAppointments.Rows.Add("A004", "Salma Adel", "Mariam Adel", "05/11/2026", "10:30 AM", "Confirmed");
            dgvAppointments.Rows.Add("A005", "Youssef Ali", "Youssef Sherif", "05/11/2026", "11:00 AM", "Cancelled");
            dgvAppointments.Rows.Add("A006", "Nour Ahmed", "Nourhan Ali", "05/11/2026", "11:30 AM", "Confirmed");
            dgvAppointments.Rows.Add("A007", "Karim Samir", "Mohamed Samir", "05/11/2026", "12:00 PM", "Pending");
            dgvAppointments.Rows.Add("A008", "Farah Mohamed", "Salma Hassan", "05/11/2026", "12:30 PM", "Confirmed");
            dgvAppointments.Rows.Add("A009", "Hana Mostafa", "Khaled Ibrahim", "05/11/2026", "01:00 PM", "Completed");
            dgvAppointments.Rows.Add("A010", "Amr Nabil", "Laila Mostafa", "05/11/2026", "01:30 PM", "Confirmed");
            dgvAppointments.Rows.Add("A011", "Dina Ashraf", "Amr Khalil", "06/11/2026", "09:00 AM", "Pending");
            dgvAppointments.Rows.Add("A012", "Tarek Sameh", "Hana Mahmoud", "06/11/2026", "09:30 AM", "Confirmed");
            dgvAppointments.Rows.Add("A013", "Rana Fathy", "Tarek Adel", "06/11/2026", "10:00 AM", "Confirmed");
            dgvAppointments.Rows.Add("A014", "Laila Emad", "Farah Samy", "06/11/2026", "10:30 AM", "Cancelled");
            dgvAppointments.Rows.Add("A015", "Hossam Wael", "Mostafa Nabil", "06/11/2026", "11:00 AM", "Confirmed");
            dgvAppointments.Rows.Add("A016", "Nadia Ibrahim", "Rana Ashraf", "06/11/2026", "11:30 AM", "Completed");
            dgvAppointments.Rows.Add("A017", "Mariam Sameh", "Hossam Fathy", "06/11/2026", "12:00 PM", "Pending");
            dgvAppointments.Rows.Add("A018", "Ali Mahmoud", "Dina Wael", "06/11/2026", "12:30 PM", "Confirmed");
            dgvAppointments.Rows.Add("A019", "Sara Khalil", "Karim Sameh", "06/11/2026", "01:00 PM", "Confirmed");
            dgvAppointments.Rows.Add("A020", "Ahmed Nabil", "Nadia Emad", "06/11/2026", "01:30 PM", "Pending");
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            RequestNavigation("Dashboard");
        }
    }
}

