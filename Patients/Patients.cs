using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class MainForm : Form
    {
        public Action<string> NavigationRequested { get; set; }

        public MainForm()
        {
            InitializeComponent();
            WireNavigation();
            dgvPatients.Rows.Add(
              "Grand Rapids",
              "02 Sep 2024",
              "101",
              "Root Canal Therapy",
               "PYBJ89RW",
              "Discharge"
             );

            dgvPatients.Rows.Add(
                "Bell Gardens",
                "01 Sep 2024",
                "203",
                "Teeth Whitening",
                "WA3A4U3C",
                "In Surgery"
            );

            dgvPatients.Rows.Add(
                "Broomfield",
                "30 Aug 2024",
                "204",
                "Tooth Extractions",
                "RX10QYE0",
                "Discharge"
            );
            dgvPatients.Rows.Add(
             "Yakima", "29 Aug 2024", "205",
              "Dental Sealants", "GZXXJHT5", "Expected Stay"
);

            dgvPatients.Rows.Add(
                "Springfield", "29 Aug 2024", "104",
                "Teeth Cleanings", "IT5H5I2R", "Discharge"
            );

            dgvPatients.Rows.Add(
                "Alexandria", "29 Aug 2024", "206",
                "Cosmetic Fillings", "WA3A4U3C", "Discharge"
            );

            dgvPatients.Rows.Add(
                "Kalamazoo", "29 Aug 2024", "108",
                "Dental Crowns", "IT5H5I2R", "Expected Stay"
            );

            dgvPatients.Rows.Add(
                "Grand Rapids", "29 Aug 2024", "302",
                "Scaling Teeth", "F1JY92OJ", "In Surgery"
            );

            dgvPatients.Rows.Add(
                "Bell Gardens", "28 Aug 2024", "405",
                "Children Dentistry", "GZXXJHT5", "Discharge"
            );

            dgvPatients.Rows.Add(
                "Broomfield", "28 Aug 2024", "505",
                "General Checkup", "F1JY92OJ", "Expected Stay"
            );
            dgvPatients.Rows.Add(
             "Yakima", "29 Aug 2024", "205",
              "Dental Sealants", "GZXXJHT5", "Expected Stay"
);

            dgvPatients.Rows.Add(
                "Springfield", "29 Aug 2024", "104",
                "Teeth Cleanings", "IT5H5I2R", "Discharge"
            );

            dgvPatients.Rows.Add(
                "Alexandria", "29 Aug 2024", "206",
                "Cosmetic Fillings", "WA3A4U3C", "Discharge"
            );

            dgvPatients.Rows.Add(
                "Kalamazoo", "29 Aug 2024", "108",
                "Dental Crowns", "IT5H5I2R", "Expected Stay"
            );

            dgvPatients.Rows.Add(
                "Grand Rapids", "29 Aug 2024", "302",
                "Scaling Teeth", "F1JY92OJ", "In Surgery"
            );

            dgvPatients.Rows.Add(
                "Bell Gardens", "28 Aug 2024", "405",
                "Children Dentistry", "GZXXJHT5", "Discharge"
            );

            dgvPatients.Rows.Add(
                "Broomfield", "28 Aug 2024", "505",
                "General Checkup", "F1JY92OJ", "Expected Stay"
            );
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

            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(35, 75, 130);
            lblTitle.Location = new Point(40, 24);

            StylePrimaryButton(btnAddPatient, "+ Add Patient");
            btnAddPatient.SetBounds(pnlHeader.ClientSize.Width - 200, 34, 160, 44);

            int contentWidth = pnlContent.ClientSize.Width;
            int contentHeight = pnlContent.ClientSize.Height;
            int contentTop = pnlHeader.Height;
            panel1.SetBounds(40, contentTop + 32, contentWidth - 80, contentHeight - contentTop - 64);

            int cardWidth = panel1.ClientSize.Width;
            int cardHeight = panel1.ClientSize.Height;

            label1.Text = "All Patients";
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(35, 75, 130);
            label1.Location = new Point(24, 22);

            StylePrimaryButton(button10, "Search");
            button10.SetBounds(cardWidth - 144, 18, 120, 36);

            StyleActionButton(button8, "Edit", Color.Green);
            StyleActionButton(button9, "Delete", Color.Red);
            int actionTop = cardHeight - 56;
            button9.SetBounds(cardWidth - 144, actionTop, 120, 36);
            button8.SetBounds(button9.Left - 122, actionTop, 110, 36);

            dgvPatients.SetBounds(24, 68, cardWidth - 48, actionTop - 84);

            colName.FillWeight = 140F;
            colDate.FillWeight = 110F;
            colRoom.FillWeight = 60F;
            colTreatment.FillWeight = 180F;
            colInsurance.FillWeight = 120F;
            colStatus.FillWeight = 120F;
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
            panelSidebar.Width = 240;
            panelSidebar.BackColor = Color.FromArgb(35, 75, 130);
            pnlSeparator.Visible = false;

            picLogo.BackColor = Color.Transparent;
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            picLogo.SetBounds(20, 12, 120, 120);

            StyleNavButton(button1, "Dashboard", 0, false);
            StyleNavButton(button2, "Patients", 1, true);
            StyleNavButton(button3, "Appointments", 2, false);
            StyleNavButton(button4, "Doctors", 3, false);
            StyleNavButton(button5, "Treatments", 4, false);
            StyleNavButton(button6, "Reports", 5, false);
            StyleLogoutButton(button7);
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
            button.SetBounds(0, panelSidebar.ClientSize.Height - 64, 240, 48);
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

        private void WireNavigation()
        {
            button6.Click += (s, e) => RequestNavigation("Reports");
            button7.Click += (s, e) => RequestNavigation("Logout");
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

        private void button5_Click(object sender, EventArgs e)
        {
            RequestNavigation("Treatments");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RequestNavigation("Patients");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RequestNavigation("Appointments");
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {

        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestNavigation("Dashboard");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RequestNavigation("Doctors");
        }
    }
}
