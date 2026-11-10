using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinicManagementSystem
{
    public partial class DashboardForm : Form
    {
        private readonly Dictionary<string, Form> _modules = new Dictionary<string, Form>();
        private Form _currentModule;
        private bool _closing;

        public DashboardForm()
        {
            InitializeComponent();
            WireNavigation();

            dgvAppointments.Rows.Clear();

            dgvAppointments.Rows.Add("09:00 AM", "Ahmed Mohamed", "Teeth Cleaning", "Confirmed");
            dgvAppointments.Rows.Add("10:30 AM", "Sara Ali", "Root Canal", "Pending");
            dgvAppointments.Rows.Add("11:00 AM", "Omar Hassan", "Teeth Whitening", "Completed");
            dgvAppointments.Rows.Add("12:30 PM", "Mariam Adel", "Dental Filling", "Confirmed");
            dgvAppointments.Rows.Add("02:00 PM", "Youssef Sherif", "Dental Checkup", "Pending");
            dgvAppointments.Rows.Add("02:30 PM", "Nourhan Ali", "Tooth Extraction", "Confirmed");
            dgvAppointments.Rows.Add("03:00 PM", "Mohamed Samir", "Dental Cleaning", "Pending");
            dgvAppointments.Rows.Add("03:30 PM", "Salma Hassan", "Braces Consultation", "Completed");
            dgvAppointments.Rows.Add("04:00 PM", "Omar Adel", "Root Canal", "Confirmed");
            dgvAppointments.Rows.Add("04:30 PM", "Laila Mohamed", "Dental Filling", "Pending");
            dgvAppointments.Refresh();
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
            CloseModules();
            base.OnFormClosed(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyUnifiedSidebar();
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
