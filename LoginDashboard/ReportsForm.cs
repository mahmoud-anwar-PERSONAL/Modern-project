using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Shared;

namespace DentalClinicManagementSystem
{
    public partial class ReportsForm : Form
    {
        public Action<string> NavigationRequested { get; set; }

        private PictureBox _sidebarLogo;
        private Button btnPatients;
        private Button btnAppointments;
        private Button btnDoctors;
        private Button btnTreatments;
        private Button btnReports;
        private Button btnLogout;

        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private ComboBox cboDoctor;
        private Button btnApplyFilters;
        private Button btnClearFilters;
        private Label lblFrom;
        private Label lblTo;
        private Label lblDoctorFilter;
        private bool _uiReady;
        private bool _suppressFilter;

        public ReportsForm()
        {
            InitializeComponent();
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
            SetupReportsUi();
            ApplyPageLayout();
            ResetDateRange();
            RefreshReport();
            Resize += (s, args) => ApplyPageLayout();
            Activated += (s, args) =>
            {
                if (!_uiReady) return;
                ClinicStore.Reload();
                BuildDoctorFilter();
                RefreshReport();
            };
        }

        private void SetupReportsUi()
        {
            if (_uiReady)
            {
                return;
            }

            UiTheme.StyleHeader(pnlHeader);
            UiTheme.StyleTitle(lblPageTitle);
            UiTheme.StyleSubtitle(lblPageSubtitle);
            UiTheme.StyleCard(pnlMonthlySummary);
            UiTheme.StyleSection(lblMonthlySummary);
            UiTheme.StyleGrid(dgvMonthlySummary);

            StyleStatCard(pnlPatients, lblPatientsValue, lblPatientsTitle);
            StyleStatCard(pnlAppointments, lblAppointmentsValue, lblAppointmentsTitle);
            StyleStatCard(pnlTreatments, lblTreatmentsValue, lblTreatmentsTitle);
            StyleStatCard(pnlRevenue, lblRevenueValue, lblRevenueTitle);
            lblPatientsTitle.Text = "Patients (filtered)";
            lblAppointmentsTitle.Text = "Appointments (filtered)";
            lblTreatmentsTitle.Text = "Treatments Used";
            lblRevenueTitle.Text = "Revenue (EGP)";

            lblFrom = MakeFilterLabel("From");
            lblTo = MakeFilterLabel("To");
            lblDoctorFilter = MakeFilterLabel("Doctor");
            pnlMonthlySummary.Controls.Add(lblFrom);
            pnlMonthlySummary.Controls.Add(lblTo);
            pnlMonthlySummary.Controls.Add(lblDoctorFilter);

            dtpFrom = new DateTimePicker();
            UiTheme.StyleDate(dtpFrom);
            pnlMonthlySummary.Controls.Add(dtpFrom);

            dtpTo = new DateTimePicker();
            UiTheme.StyleDate(dtpTo);
            pnlMonthlySummary.Controls.Add(dtpTo);

            cboDoctor = new ComboBox();
            UiTheme.StyleCombo(cboDoctor);
            cboDoctor.SelectedIndexChanged += (s, e) =>
            {
                if (!_suppressFilter) RefreshReport();
            };
            pnlMonthlySummary.Controls.Add(cboDoctor);

            btnApplyFilters = new Button();
            UiTheme.StylePrimary(btnApplyFilters, "Apply");
            btnApplyFilters.Click += (s, e) => RefreshReport();
            pnlMonthlySummary.Controls.Add(btnApplyFilters);

            btnClearFilters = new Button();
            UiTheme.StyleSecondary(btnClearFilters, "Clear");
            btnClearFilters.Click += (s, e) => ClearFilters();
            pnlMonthlySummary.Controls.Add(btnClearFilters);

            colMonth.HeaderText = "Month";
            colMonth.FillWeight = 140F;
            colPatients.HeaderText = "Patients";
            colPatients.FillWeight = 100F;
            colAppointments.HeaderText = "Appointments";
            colAppointments.FillWeight = 120F;
            colTreatments.HeaderText = "Treatments Used";
            colTreatments.FillWeight = 115F;
            colRevenue.HeaderText = "Revenue (EGP)";
            colRevenue.FillWeight = 120F;

            BuildDoctorFilter();
            _uiReady = true;
        }

        private static Label MakeFilterLabel(string text)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Text = text;
            label.Font = UiTheme.SmallBoldFont;
            label.ForeColor = UiTheme.TextPrimary;
            label.BackColor = Color.Transparent;
            return label;
        }

        private static void StyleStatCard(Panel card, Label value, Label title)
        {
            value.AutoSize = true;
            value.Location = new Point(24, 40);
            value.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            value.ForeColor = Color.White;
            title.AutoSize = true;
            title.Location = new Point(24, 98);
            title.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            title.ForeColor = Color.White;
        }

        private void BuildDoctorFilter()
        {
            string selected = cboDoctor.SelectedIndex > 0
                ? Convert.ToString(cboDoctor.SelectedItem)
                : null;

            _suppressFilter = true;
            cboDoctor.Items.Clear();
            cboDoctor.Items.Add("All Doctors");
            foreach (DoctorRecord doctor in ClinicStore.Data.Doctors.OrderBy(d => d.Name))
            {
                cboDoctor.Items.Add(doctor.Name);
            }

            int index = 0;
            if (!string.IsNullOrEmpty(selected))
            {
                int found = cboDoctor.Items.IndexOf(selected);
                if (found > 0) index = found;
            }
            cboDoctor.SelectedIndex = index;
            _suppressFilter = false;
        }

        private void ResetDateRange()
        {
            DateTime from = DateTime.Today;
            DateTime to = DateTime.Today;

            if (ClinicStore.Data.Appointments.Any())
            {
                from = ClinicStore.Data.Appointments.Min(a => ClinicStore.ParseDate(a.Date));
                to = ClinicStore.Data.Appointments.Max(a => ClinicStore.ParseDate(a.Date));
            }

            dtpFrom.Value = from;
            dtpTo.Value = to;
        }

        private void ClearFilters()
        {
            _suppressFilter = true;
            cboDoctor.SelectedIndex = 0;
            _suppressFilter = false;
            ResetDateRange();
            RefreshReport();
        }

        private void ApplyPageLayout()
        {
            if (pnlContent == null || pnlContent.ClientSize.Width < 480 || !_uiReady)
            {
                return;
            }

            pnlHeader.Height = 112;
            lblPageTitle.Location = new Point(40, 24);
            lblPageSubtitle.Location = new Point(40, 82);

            int contentWidth = pnlContent.ClientSize.Width;
            int contentHeight = pnlContent.ClientSize.Height;

            int gap = 20;
            int cardWidth = (contentWidth - 80 - gap * 3) / 4;
            Panel[] cards = { pnlPatients, pnlAppointments, pnlTreatments, pnlRevenue };
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].SetBounds(40 + (i * (cardWidth + gap)), 24, cardWidth, 132);
            }

            pnlMonthlySummary.SetBounds(40, 176, contentWidth - 80, contentHeight - 200);

            lblMonthlySummary.Location = new Point(24, 20);

            int filterTop = 56;
            lblFrom.Location = new Point(24, filterTop + 8);
            dtpFrom.SetBounds(68, filterTop, 130, 30);
            lblTo.Location = new Point(214, filterTop + 8);
            dtpTo.SetBounds(244, filterTop, 130, 30);
            lblDoctorFilter.Location = new Point(390, filterTop + 8);
            cboDoctor.SetBounds(444, filterTop, 180, 30);

            int right = pnlMonthlySummary.ClientSize.Width - 24;
            btnClearFilters.SetBounds(right - 80, filterTop - 2, 80, 34);
            btnApplyFilters.SetBounds(right - 80 - 8 - 90, filterTop - 2, 90, 34);

            dgvMonthlySummary.SetBounds(24, 104,
                pnlMonthlySummary.ClientSize.Width - 48,
                pnlMonthlySummary.ClientSize.Height - 124);
        }

        private void RefreshReport()
        {
            if (!_uiReady)
            {
                return;
            }

            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;
            if (from > to)
            {
                MessageBox.Show(this, "The From date must be on or before the To date.",
                    "Invalid date range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string doctorId = null;
            if (cboDoctor.SelectedIndex > 0)
            {
                string doctorName = Convert.ToString(cboDoctor.SelectedItem);
                DoctorRecord doctor = ClinicStore.Data.Doctors
                    .FirstOrDefault(d => d.Name == doctorName);
                if (doctor != null)
                {
                    doctorId = doctor.Id;
                }
            }

            List<AppointmentRecord> filtered = ClinicStore.Data.Appointments
                .Where(a =>
                {
                    DateTime date = ClinicStore.ParseDate(a.Date).Date;
                    if (date < from || date > to)
                    {
                        return false;
                    }
                    if (doctorId != null && a.DoctorId != doctorId)
                    {
                        return false;
                    }
                    return true;
                })
                .ToList();

            lblPatientsValue.Text = filtered.Select(a => a.PatientId).Distinct().Count().ToString("N0");
            lblAppointmentsValue.Text = filtered.Count.ToString("N0");
            lblTreatmentsValue.Text = filtered.Select(a => a.TreatmentId).Distinct().Count().ToString("N0");

            decimal totalRevenue = filtered
                .Where(a => string.Equals(a.Status, "Completed", StringComparison.OrdinalIgnoreCase))
                .Sum(a => ClinicStore.TreatmentPrice(a.TreatmentId));
            lblRevenueValue.Text = totalRevenue.ToString("N0");

            CultureInfo culture = CultureInfo.GetCultureInfo("en-US");
            var months = filtered
                .GroupBy(a => (a.Date ?? "").Length >= 7 ? a.Date.Substring(0, 7) : "unknown")
                .OrderBy(g => g.Key);

            dgvMonthlySummary.SuspendLayout();
            dgvMonthlySummary.Rows.Clear();
            foreach (var group in months)
            {
                string monthLabel = "Unknown";
                DateTime monthDate;
                if (DateTime.TryParseExact(group.Key + "-01", "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out monthDate))
                {
                    monthLabel = monthDate.ToString("MMMM yyyy", culture);
                }

                int patients = group.Select(a => a.PatientId).Distinct().Count();
                int appointments = group.Count();
                int treatments = group.Select(a => a.TreatmentId).Distinct().Count();
                decimal revenue = group
                    .Where(a => string.Equals(a.Status, "Completed", StringComparison.OrdinalIgnoreCase))
                    .Sum(a => ClinicStore.TreatmentPrice(a.TreatmentId));

                dgvMonthlySummary.Rows.Add(
                    monthLabel,
                    patients,
                    appointments,
                    treatments,
                    revenue.ToString("N0"));
            }
            dgvMonthlySummary.ResumeLayout();
        }

        private void ApplyUnifiedSidebar()
        {
            pnlSidebar.Width = 240;
            pnlSidebar.BackColor = Color.FromArgb(35, 75, 130);
            lblBrand.Visible = false;
            lblBrandSub.Visible = false;

            if (_sidebarLogo == null)
            {
                _sidebarLogo = new PictureBox();
                _sidebarLogo.Name = "picSidebarLogo";
                _sidebarLogo.BackColor = Color.Transparent;
                _sidebarLogo.SizeMode = PictureBoxSizeMode.Zoom;
                _sidebarLogo.Image = (Image)new ComponentResourceManager(typeof(DashboardForm)).GetObject("pictlogo.Image");
                pnlSidebar.Controls.Add(_sidebarLogo);
            }
            _sidebarLogo.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            _sidebarLogo.SetBounds(20, 12, 120, 120);

            if (btnPatients == null)
            {
                btnPatients = CreateNavButton("btnPatients", "Patients", () => RequestNavigation("Patients"));
                btnAppointments = CreateNavButton("btnAppointments", "Appointments", () => RequestNavigation("Appointments"));
                btnDoctors = CreateNavButton("btnDoctors", "Doctors", () => RequestNavigation("Doctors"));
                btnTreatments = CreateNavButton("btnTreatments", "Treatments", () => RequestNavigation("Treatments"));
                btnReports = CreateNavButton("btnReports", "Reports", () => RequestNavigation("Reports"));
                btnLogout = CreateLogoutButton();
            }

            StyleNavButton(btnDashboard, "Dashboard", 0, false);
            StyleNavButton(btnPatients, "Patients", 1, false);
            StyleNavButton(btnAppointments, "Appointments", 2, false);
            StyleNavButton(btnDoctors, "Doctors", 3, false);
            StyleNavButton(btnTreatments, "Treatments", 4, false);
            StyleNavButton(btnReports, "Reports", 5, true);
            StyleLogoutButton(btnLogout);
        }

        private Button CreateNavButton(string name, string text, Action navigate)
        {
            Button button = new Button();
            button.Name = name;
            button.Text = text;
            button.Click += (s, e) => navigate();
            pnlSidebar.Controls.Add(button);
            return button;
        }

        private Button CreateLogoutButton()
        {
            Button button = new Button();
            button.Name = "btnLogout";
            button.Text = "Log Out";
            button.Click += (s, e) => RequestNavigation("Logout");
            pnlSidebar.Controls.Add(button);
            return button;
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            RequestNavigation("Dashboard");
        }
    }
}
