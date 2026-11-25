using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Shared;

namespace DentalClinicManagementSystem
{
    public partial class DashboardForm : Form
    {
        private readonly Dictionary<string, Form> _modules = new Dictionary<string, Form>();
        private Form _currentModule;
        private bool _closing;
        private bool _uiReady;

        private BarChartPanel _chart;
        private Timer _clockTimer;

        public DashboardForm()
        {
            InitializeComponent();
            WireNavigation();
        }

        private void WireNavigation()
        {
            btnDashboard.Click += (s, e) => NavigateTo("Dashboard");
        }

        private void NavigateTo(string page)
        {
            if (_closing)
            {
                return;
            }

            if (page == "Logout")
            {
                Logout();
                return;
            }

            if (page == "Dashboard")
            {
                if (_currentModule != null && !_currentModule.IsDisposed)
                {
                    _currentModule.Hide();
                }

                _currentModule = null;
                if (!this.Visible)
                {
                    this.Show();
                }
                this.Activate();
                return;
            }

            Form module;
            if (!_modules.TryGetValue(page, out module) || module.IsDisposed)
            {
                module = CreateModule(page);
                if (module == null)
                {
                    return;
                }

                module.FormClosed += Module_FormClosed;
                _modules[page] = module;
            }

            if (_currentModule == module)
            {
                if (!module.Visible)
                {
                    module.Show();
                }
                module.BringToFront();
                module.Activate();
                return;
            }

            if (_currentModule != null && !_currentModule.IsDisposed)
            {
                _currentModule.Hide();
            }
            if (this.Visible)
            {
                this.Hide();
            }

            module.Show();
            module.BringToFront();
            module.Activate();
            _currentModule = module;
        }

        private Form CreateModule(string page)
        {
            switch (page)
            {
                case "Patients":
                    {
                        WinFormsApp2.MainForm form = new WinFormsApp2.MainForm();
                        form.NavigationRequested = NavigateTo;
                        return form;
                    }
                case "Appointments":
                    {
                        AppointmentsForm.AppointmentsForm form = new AppointmentsForm.AppointmentsForm();
                        form.NavigationRequested = NavigateTo;
                        return form;
                    }
                case "Doctors":
                    {
                        Dental_Clinic___Doctors_PROJECTMODERN.DoctorsForm form = new Dental_Clinic___Doctors_PROJECTMODERN.DoctorsForm();
                        form.NavigationRequested = NavigateTo;
                        return form;
                    }
                case "Treatments":
                    {
                        dentalclinicprojecttreatments.TreatmentForm form = new dentalclinicprojecttreatments.TreatmentForm();
                        form.NavigationRequested = NavigateTo;
                        return form;
                    }
                case "Reports":
                    {
                        ReportsForm form = new ReportsForm();
                        form.NavigationRequested = NavigateTo;
                        return form;
                    }
                default:
                    return null;
            }
        }

        private void Module_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form module = sender as Form;
            if (module == null)
            {
                return;
            }

            string key = null;
            foreach (KeyValuePair<string, Form> pair in _modules)
            {
                if (pair.Value == module)
                {
                    key = pair.Key;
                    break;
                }
            }
            if (key != null)
            {
                _modules.Remove(key);
            }

            if (!_closing && _currentModule == module)
            {
                _currentModule = null;
                if (!this.Visible)
                {
                    this.Show();
                }
                this.Activate();
            }
        }

        private void Logout()
        {
            if (_closing)
            {
                return;
            }

            _closing = true;
            CloseModules();

            LoginForm login = new LoginForm();
            login.Show();
            login.Activate();
            this.Close();
        }

        private void CloseModules()
        {
            _currentModule = null;
            List<Form> forms = new List<Form>(_modules.Values);
            _modules.Clear();

            foreach (Form form in forms)
            {
                if (form == null || form.IsDisposed)
                {
                    continue;
                }

                form.FormClosed -= Module_FormClosed;
                form.Close();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _closing = true;
            if (_clockTimer != null)
            {
                _clockTimer.Stop();
                _clockTimer.Dispose();
                _clockTimer = null;
            }
            CloseModules();
            base.OnFormClosed(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyUnifiedSidebar();
            SetupDashboardUi();
            ApplyDashboardLayout();
            RefreshDashboard();
            StartClock();
            Resize += (s, args) => ApplyDashboardLayout();
            Activated += (s, args) =>
            {
                if (!_uiReady) return;
                ClinicStore.Reload();
                RefreshDashboard();
            };
        }

        private void SetupDashboardUi()
        {
            if (_uiReady)
            {
                return;
            }

            UiTheme.StyleHeader(pnlHeader);
            UiTheme.StyleTitle(lblPageTitle);
            lblPageTitle.Text = "Welcome Admin !";

            lblTime.Dock = DockStyle.None;
            lblTime.AutoSize = false;
            lblTime.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTime.ForeColor = UiTheme.Navy;
            lblTime.BackColor = Color.Transparent;
            lblTime.TextAlign = ContentAlignment.MiddleRight;

            lblDate.AutoSize = false;
            lblDate.Font = UiTheme.SubtitleFont;
            lblDate.ForeColor = UiTheme.TextMuted;
            lblDate.BackColor = Color.Transparent;

            pnlContent.BackColor = UiTheme.Background;
            picContentBackground.Visible = false;

            StyleStatCard(pnlTotalPatients, picPatients, lblPatientsCount, lblPatientsTitle);
            StyleStatCard(pnlAppointments, picAppointments, lblAppointmentsCount, lblAppointmentsTitle);
            StyleStatCard(pnlTreatments, picTreatments, lblTreatmentsCount, lblTreatmentsTitle);

            _chart = new BarChartPanel();
            _chart.ChartTitle = "Appointments by Status";
            _chart.BackColor = Color.White;
            pnlContent.Controls.Add(_chart);

            UiTheme.StyleCard(pnlQuickActions);
            lblQuickActions.AutoSize = true;
            lblQuickActions.Font = UiTheme.SectionFont;
            lblQuickActions.ForeColor = UiTheme.Navy;
            lblQuickActions.Text = "Quick Actions";
            UiTheme.StylePrimary(btnAddPatient, "+ Add Patient");
            UiTheme.StylePrimary(btnBookAppointment, "+ Book Appointment");
            UiTheme.StylePrimary(btnAddDoctor, "+ Add Doctor");
            UiTheme.StylePrimary(btnViewReports, "View Reports");
            btnAddPatient.Font = UiTheme.ActionFont;
            btnBookAppointment.Font = UiTheme.ActionFont;
            btnAddDoctor.Font = UiTheme.ActionFont;
            btnViewReports.Font = UiTheme.ActionFont;

            UiTheme.StyleCard(pnlRecentAppointments);
            UiTheme.StyleSection(lblRecentAppointments);
            UiTheme.StyleGrid(dgvAppointments);
            EnsureDashboardColumns();
            UiTheme.AddActionCellColors(dgvAppointments, "colStatus");

            _uiReady = true;
        }

        private static void StyleStatCard(Panel card, PictureBox icon, Label count, Label title)
        {
            icon.Anchor = AnchorStyles.Left;
            icon.SizeMode = PictureBoxSizeMode.Zoom;

            count.AutoSize = false;
            count.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            count.ForeColor = Color.White;
            count.TextAlign = ContentAlignment.BottomRight;

            title.AutoSize = false;
            title.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            title.ForeColor = Color.White;
            title.TextAlign = ContentAlignment.TopRight;

            card.Cursor = Cursors.Hand;
        }

        private void EnsureDashboardColumns()
        {
            if (!dgvAppointments.Columns.Contains("colDate"))
            {
                DataGridViewTextBoxColumn date = new DataGridViewTextBoxColumn();
                date.Name = "colDate";
                date.HeaderText = "Date";
                date.ReadOnly = true;
                date.MinimumWidth = 8;
                date.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvAppointments.Columns.Insert(1, date);
            }

            colTime.HeaderText = "Time";
            colTime.FillWeight = 85F;
            dgvAppointments.Columns["colDate"].FillWeight = 95F;
            colPatientName.HeaderText = "Patient";
            colPatientName.FillWeight = 175F;
            colTreatment.HeaderText = "Treatment";
            colTreatment.FillWeight = 175F;
            colStatus.HeaderText = "Status";
            colStatus.FillWeight = 90F;
        }

        private void ApplyDashboardLayout()
        {
            if (pnlContent == null || pnlContent.ClientSize.Width < 480 || _chart == null)
            {
                return;
            }

            pnlHeader.Height = 112;
            int headerWidth = pnlHeader.ClientSize.Width;
            int clockWidth = 240;
            int clockLeft = headerWidth - 24 - clockWidth;
            lblPageTitle.Location = new Point(40, 24);
            lblTime.SetBounds(clockLeft, 44, clockWidth, 36);
            lblDate.SetBounds(40, 82, Math.Max(220, clockLeft - 64), 26);

            int width = pnlContent.ClientSize.Width;
            int height = pnlContent.ClientSize.Height;
            int margin = 40;
            int gap = 20;

            int statWidth = (width - margin * 2 - gap * 2) / 3;
            int statHeight = 104;
            int statTop = 24;

            pnlTotalPatients.SetBounds(margin, statTop, statWidth, statHeight);
            pnlAppointments.SetBounds(margin + statWidth + gap, statTop, statWidth, statHeight);
            pnlTreatments.SetBounds(margin + (statWidth + gap) * 2, statTop, statWidth, statHeight);

            LayoutStatCard(pnlTotalPatients, picPatients, lblPatientsCount, lblPatientsTitle);
            LayoutStatCard(pnlAppointments, picAppointments, lblAppointmentsCount, lblAppointmentsTitle);
            LayoutStatCard(pnlTreatments, picTreatments, lblTreatmentsCount, lblTreatmentsTitle);

            int lowerTop = statTop + statHeight + gap;
            int quickWidth = 300;
            int leftWidth = width - margin * 2 - gap - quickWidth;
            int chartHeight = 236;
            int bottom = height - 24;

            _chart.SetBounds(margin, lowerTop, leftWidth, chartHeight);

            int recentTop = lowerTop + chartHeight + gap;
            int recentHeight = bottom - recentTop;
            pnlRecentAppointments.SetBounds(margin, recentTop, leftWidth, recentHeight);

            int recentWidth = pnlRecentAppointments.ClientSize.Width;
            lblRecentAppointments.Location = new Point(24, 16);
            dgvAppointments.SetBounds(24, 52, recentWidth - 48, pnlRecentAppointments.ClientSize.Height - 68);

            pnlQuickActions.SetBounds(margin + leftWidth + gap, lowerTop, quickWidth, bottom - lowerTop);
            int quickCardWidth = pnlQuickActions.ClientSize.Width;
            lblQuickActions.Location = new Point(20, 18);

            int buttonWidth = quickCardWidth - 40;
            int buttonHeight = 56;
            int buttonGap = 14;
            btnAddPatient.SetBounds(20, 64, buttonWidth, buttonHeight);
            btnBookAppointment.SetBounds(20, 64 + (buttonHeight + buttonGap), buttonWidth, buttonHeight);
            btnAddDoctor.SetBounds(20, 64 + (buttonHeight + buttonGap) * 2, buttonWidth, buttonHeight);
            btnViewReports.SetBounds(20, 64 + (buttonHeight + buttonGap) * 3, buttonWidth, buttonHeight);
        }

        private static void LayoutStatCard(Panel card, PictureBox icon, Label count, Label title)
        {
            int cardWidth = card.ClientSize.Width;
            int cardHeight = card.ClientSize.Height;

            icon.SetBounds(24, (cardHeight - 64) / 2, 64, 64);

            int blockWidth = 190;
            int right = cardWidth - 24;
            count.SetBounds(right - blockWidth, 16, blockWidth, 44);
            title.SetBounds(right - blockWidth, 62, blockWidth, 26);
        }

        private void StartClock()
        {
            UpdateClock();
            if (_clockTimer == null)
            {
                _clockTimer = new Timer();
                _clockTimer.Interval = 1000;
                _clockTimer.Tick += (s, e) => UpdateClock();
            }
            _clockTimer.Start();
        }

        private void UpdateClock()
        {
            DateTime now = DateTime.Now;
            CultureInfo culture = CultureInfo.GetCultureInfo("en-US");
            lblTime.Text = now.ToString("hh:mm:ss tt", culture);
            lblDate.Text = now.ToString("dddd, dd MMMM yyyy", culture);
        }

        private void RefreshDashboard()
        {
            if (!_uiReady)
            {
                return;
            }

            lblPatientsCount.Text = ClinicStore.Data.Patients.Count.ToString("N0");
            lblAppointmentsCount.Text = ClinicStore.Data.Appointments.Count.ToString("N0");
            lblTreatmentsCount.Text = ClinicStore.Data.Treatments.Count.ToString("N0");

            _chart.SetData(new[]
            {
                new ChartBar { Label = "Confirmed", Value = CountByStatus("Confirmed"), Color = Color.FromArgb(22, 128, 78) },
                new ChartBar { Label = "Pending", Value = CountByStatus("Pending"), Color = Color.FromArgb(176, 106, 7) },
                new ChartBar { Label = "Completed", Value = CountByStatus("Completed"), Color = UiTheme.Primary },
                new ChartBar { Label = "Cancelled", Value = CountByStatus("Cancelled"), Color = Color.FromArgb(190, 48, 48) }
            });

            DateTime today = DateTime.Today;
            var upcoming = ClinicStore.Data.Appointments
                .Where(a => ClinicStore.AppointmentDateTime(a) >= today)
                .OrderBy(ClinicStore.AppointmentDateTime)
                .ThenBy(a => a.Id)
                .Take(6)
                .ToList();

            if (upcoming.Count == 0)
            {
                upcoming = ClinicStore.Data.Appointments
                    .OrderByDescending(ClinicStore.AppointmentDateTime)
                    .ThenByDescending(a => a.Id)
                    .Take(6)
                    .ToList();
            }

            dgvAppointments.SuspendLayout();
            dgvAppointments.Rows.Clear();
            foreach (AppointmentRecord appointment in upcoming)
            {
                dgvAppointments.Rows.Add(
                    ClinicStore.DisplayTime(appointment.Time),
                    ClinicStore.DisplayShortDate(appointment.Date),
                    ClinicStore.PatientName(appointment.PatientId),
                    ClinicStore.TreatmentName(appointment.TreatmentId),
                    appointment.Status);
            }
            dgvAppointments.ResumeLayout();
        }

        private static int CountByStatus(string status)
        {
            return ClinicStore.Data.Appointments.Count(a =>
                string.Equals(a.Status, status, StringComparison.OrdinalIgnoreCase));
        }

        private void ApplyUnifiedSidebar()
        {
            pnlSidebar.Width = 240;
            pnlSidebar.BackColor = Color.FromArgb(35, 75, 130);

            pictlogo.BorderStyle = BorderStyle.None;
            pictlogo.BackColor = Color.Transparent;
            pictlogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictlogo.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pictlogo.SetBounds(20, 12, 120, 120);

            StyleNavButton(btnDashboard, "Dashboard", 0, true);
            StyleNavButton(btnPatients, "Patients", 1, false);
            StyleNavButton(btnAppointments, "Appointments", 2, false);
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

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            NavigateTo("Logout");
        }

        private void lblPageTitle_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            NavigateTo("Doctors");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlTotalPatients_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            NavigateTo("Patients");
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            NavigateTo("Appointments");
        }

        private void btnTreatments_Click(object sender, EventArgs e)
        {
            NavigateTo("Treatments");
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            NavigateTo("Reports");
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            NavigateTo("Reports");
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            NavigateTo("Patients");
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            NavigateTo("Appointments");
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            NavigateTo("Doctors");
        }
    }
}
