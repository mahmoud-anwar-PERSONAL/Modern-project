using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Shared;

namespace AppointmentsForm
{
    public partial class AppointmentsForm : Form
    {
        public Action<string> NavigationRequested { get; set; }

        private Panel pnlTopBand;
        private Panel pnlTableCard;
        private Label lblSubtitle;
        private Label lblAllAppointments;
        private Label lblAppointmentCount;
        private TextBox txtSearchAppointments;
        private Button btnClearSearch;
        private Button btnEditAppointment;
        private Button btnDeleteAppointment;
        private bool _uiReady;

        private static readonly string[] TimeSlots = BuildTimeSlots();
        private static readonly string[] TimeDisplays = TimeSlots.Select(ClinicStore.DisplayTime).ToArray();
        private static readonly string[] Statuses = { "Confirmed", "Pending", "Completed", "Cancelled" };

        public AppointmentsForm()
        {
            InitializeComponent();
            WireNavigation();
        }

        private static string[] BuildTimeSlots()
        {
            List<string> slots = new List<string>();
            for (int hour = 9; hour < 17; hour++)
            {
                slots.Add(hour.ToString("00") + ":00");
                slots.Add(hour.ToString("00") + ":30");
            }
            return slots.ToArray();
        }

        private void WireCrud()
        {
            btnNewAppointment.Click += (s, e) => AddAppointment();
            btnEditAppointment.Click += (s, e) => EditAppointment();
            btnDeleteAppointment.Click += (s, e) => DeleteAppointment();
            btnClearSearch.Click += (s, e) => ClearFilters();
            txtSearchAppointments.TextChanged += (s, e) => RefreshAppointments();
            dgvAppointments.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) EditAppointment();
            };
        }

        private void WireNavigation()
        {
            btnPatients.Click += (s, e) => RequestNavigation("Patients");
            btnAppointments.Click += (s, e) => RequestNavigation("Appointments");
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
            WindowState = FormWindowState.Maximized;
            ApplyUnifiedSidebar();
            SetupPageUi();
            ApplyPageLayout();
            RefreshAppointments();
            Resize += (s, args) => ApplyPageLayout();
            VisibleChanged += (s, args) =>
            {
                if (!_uiReady || !Visible) return;
                ClinicStore.Reload();
                RefreshAppointments();
            };
        }

        private void EnsureLayoutPanels()
        {
            if (pnlTopBand != null)
            {
                return;
            }

            pnlTopBand = new Panel();
            pnlTopBand.Name = "pnlTopBand";
            pnlTopBand.Dock = DockStyle.Top;
            pnlTopBand.BackColor = Color.White;
            pnlMain.Controls.Add(pnlTopBand);
            pnlTopBand.BringToFront();
            pnlTopBand.Controls.Add(lblTitle);
            pnlTopBand.Controls.Add(btnNewAppointment);

            lblSubtitle = new Label();
            lblSubtitle.AutoSize = true;
            lblSubtitle.Text = "Manage patient appointments and schedules";
            pnlTopBand.Controls.Add(lblSubtitle);

            pnlTableCard = new Panel();
            pnlTableCard.Name = "pnlTableCard";
            pnlTableCard.BackColor = Color.White;
            pnlMain.Controls.Add(pnlTableCard);
            pnlTableCard.BringToFront();
            pnlTableCard.Controls.Add(dgvAppointments);

            lblAllAppointments = new Label();
            lblAllAppointments.AutoSize = true;
            lblAllAppointments.Text = "All Appointments";
            pnlTableCard.Controls.Add(lblAllAppointments);

            txtSearchAppointments = new TextBox();
            txtSearchAppointments.Name = "txtSearchAppointments";
            pnlTableCard.Controls.Add(txtSearchAppointments);

            btnClearSearch = new Button();
            btnClearSearch.Name = "btnClearSearch";
            pnlTableCard.Controls.Add(btnClearSearch);

            btnEditAppointment = new Button();
            btnEditAppointment.Name = "btnEditAppointment";
            pnlTableCard.Controls.Add(btnEditAppointment);

            btnDeleteAppointment = new Button();
            btnDeleteAppointment.Name = "btnDeleteAppointment";
            pnlTableCard.Controls.Add(btnDeleteAppointment);

            lblAppointmentCount = new Label();
            lblAppointmentCount.AutoSize = false;
            pnlTableCard.Controls.Add(lblAppointmentCount);
        }

        private void SetupPageUi()
        {
            if (_uiReady)
            {
                return;
            }

            EnsureLayoutPanels();
            WireCrud();
            label1.Visible = false;
            pictureBox1.Visible = false;
            pnlMain.BackColor = UiTheme.Background;

            UiTheme.StyleHeader(pnlTopBand);
            UiTheme.StyleCard(pnlTableCard);
            UiTheme.StyleTitle(lblTitle);
            UiTheme.StyleSubtitle(lblSubtitle);
            UiTheme.StyleSection(lblAllAppointments);
            UiTheme.StylePrimary(btnNewAppointment, "+ New Appointment");
            UiTheme.StyleSecondary(btnClearSearch, "Clear");
            UiTheme.StyleAction(btnEditAppointment, "Edit", Color.Green);
            UiTheme.StyleAction(btnDeleteAppointment, "Delete", Color.Red);
            UiTheme.StyleSearchBox(txtSearchAppointments, "Search by patient ID, doctor or date");
            UiTheme.StyleGrid(dgvAppointments);
            UiTheme.AddActionCellColors(dgvAppointments, "Status");

            lblAppointmentCount.Font = UiTheme.SmallFont;
            lblAppointmentCount.ForeColor = UiTheme.TextMuted;
            lblAppointmentCount.TextAlign = ContentAlignment.MiddleLeft;

            EnsureTreatmentColumn();
            _uiReady = true;
        }

        private void EnsureTreatmentColumn()
        {
            if (!dgvAppointments.Columns.Contains("Treatment"))
            {
                DataGridViewTextBoxColumn treatment = new DataGridViewTextBoxColumn();
                treatment.Name = "Treatment";
                treatment.HeaderText = "Treatment";
                treatment.ReadOnly = true;
                treatment.MinimumWidth = 8;
                treatment.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvAppointments.Columns.Insert(3, treatment);
            }

            ID.HeaderText = "ID";
            ID.FillWeight = 50F;
            Patient.HeaderText = "Patient";
            Patient.FillWeight = 145F;
            Doctor.HeaderText = "Doctor";
            Doctor.FillWeight = 135F;
            dgvAppointments.Columns["Treatment"].FillWeight = 135F;
            Date.HeaderText = "Date";
            Date.FillWeight = 95F;
            Time.HeaderText = "Time";
            Time.FillWeight = 80F;
            Status.HeaderText = "Status";
            Status.FillWeight = 90F;
        }

        private void ClearFilters()
        {
            txtSearchAppointments.Text = "";
            RefreshAppointments();
        }

        private void ApplyPageLayout()
        {
            if (pnlMain == null || pnlMain.ClientSize.Width < 480 || pnlTopBand == null)
            {
                return;
            }

            pnlTopBand.Height = 112;
            lblTitle.Location = new Point(40, 24);
            lblSubtitle.Location = new Point(40, 82);
            btnNewAppointment.SetBounds(pnlTopBand.ClientSize.Width - 214, 34, 190, 44);

            pnlTableCard.SetBounds(40, 144, pnlMain.ClientSize.Width - 80, pnlMain.ClientSize.Height - 184);

            int cardWidth = pnlTableCard.ClientSize.Width;
            int cardHeight = pnlTableCard.ClientSize.Height;

            lblAllAppointments.Location = new Point(24, 20);

            int right = cardWidth - 24;
            btnClearSearch.SetBounds(right - 70, 16, 70, 34);
            txtSearchAppointments.SetBounds(right - 70 - 8 - 240, 18, 240, 32);

            int actionTop = cardHeight - 56;
            btnDeleteAppointment.SetBounds(cardWidth - 134, actionTop, 110, 36);
            btnEditAppointment.SetBounds(btnDeleteAppointment.Left - 122, actionTop, 110, 36);
            lblAppointmentCount.SetBounds(24, actionTop + 7, 360, 22);

            dgvAppointments.SetBounds(24, 62, cardWidth - 48, actionTop - 76);

            if (txtSearchAppointments.Text.Length == 0)
            {
                UiTheme.SetPlaceholder(txtSearchAppointments, "Search by patient ID, doctor or date");
            }
        }

        private void RefreshAppointments()
        {
            if (!_uiReady)
            {
                return;
            }

            string filter = txtSearchAppointments.Text.Trim();
            string selectedId = SelectedAppointmentId();

            var query = ClinicStore.Data.Appointments.AsEnumerable();
            if (filter.Length > 0)
            {
                query = query.Where(a =>
                    (a.PatientId ?? "").IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (ClinicStore.PatientName(a.PatientId) ?? "").IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (ClinicStore.DoctorName(a.DoctorId) ?? "").IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (a.Date ?? "").IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ClinicStore.DisplayShortDate(a.Date).IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ClinicStore.DisplayDate(a.Date).IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var rows = query
                .OrderBy(a => ClinicStore.AppointmentDateTime(a))
                .ThenBy(a => a.Id)
                .ToList();

            dgvAppointments.SuspendLayout();
            dgvAppointments.Rows.Clear();
            foreach (AppointmentRecord appointment in rows)
            {
                dgvAppointments.Rows.Add(
                    appointment.Id,
                    ClinicStore.PatientName(appointment.PatientId),
                    ClinicStore.DoctorName(appointment.DoctorId),
                    ClinicStore.TreatmentName(appointment.TreatmentId),
                    ClinicStore.DisplayShortDate(appointment.Date),
                    ClinicStore.DisplayTime(appointment.Time),
                    appointment.Status);
            }
            dgvAppointments.ResumeLayout();

            lblAppointmentCount.Text = string.Format("Showing {0} of {1} appointments",
                rows.Count, ClinicStore.Data.Appointments.Count);
            RestoreSelection(selectedId);
        }

        private string SelectedAppointmentId()
        {
            if (dgvAppointments.CurrentRow == null || dgvAppointments.CurrentRow.Cells.Count == 0)
            {
                return null;
            }
            object value = dgvAppointments.CurrentRow.Cells[0].Value;
            return value == null ? null : value.ToString();
        }

        private void RestoreSelection(string id)
        {
            if (string.IsNullOrEmpty(id)) return;
            foreach (DataGridViewRow row in dgvAppointments.Rows)
            {
                if (Convert.ToString(row.Cells[0].Value) == id)
                {
                    row.Selected = true;
                    dgvAppointments.CurrentCell = row.Cells[0];
                    return;
                }
            }
        }

        private static string[] BuildChoiceOptions(IEnumerable<string> ids, IEnumerable<string> names)
        {
            return ids.Zip(names, (id, name) => id + " - " + name).ToArray();
        }

        private static string ExtractId(string choice)
        {
            if (string.IsNullOrEmpty(choice)) return "";
            int index = choice.IndexOf(" - ", StringComparison.Ordinal);
            return index > 0 ? choice.Substring(0, index) : choice;
        }

        private void AddAppointment()
        {
            if (!ClinicStore.Data.Patients.Any() || !ClinicStore.Data.Doctors.Any() || !ClinicStore.Data.Treatments.Any())
            {
                MessageBox.Show(this,
                    "Add at least one patient, doctor and treatment before creating an appointment.",
                    "Cannot Add Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string[] patientOptions = BuildChoiceOptions(
                ClinicStore.Data.Patients.OrderBy(p => p.Id).Select(p => p.Id),
                ClinicStore.Data.Patients.OrderBy(p => p.Id).Select(p => p.Name));
            string[] doctorOptions = BuildChoiceOptions(
                ClinicStore.Data.Doctors.OrderBy(d => d.Id).Select(d => d.Id),
                ClinicStore.Data.Doctors.OrderBy(d => d.Id).Select(d => d.Name));
            string[] treatmentOptions = BuildChoiceOptions(
                ClinicStore.Data.Treatments.OrderBy(t => t.Id).Select(t => t.Id),
                ClinicStore.Data.Treatments.OrderBy(t => t.Id).Select(t => t.Name));

            EditorField[] fields =
            {
                EditorField.Choice("Patient", "Patient", patientOptions, null),
                EditorField.Choice("Doctor", "Doctor", doctorOptions, null),
                EditorField.Choice("Treatment", "Treatment", treatmentOptions, null),
                EditorField.Date("Date", "Appointment date", DateTime.Today),
                EditorField.Choice("Time", "Time", TimeDisplays, TimeDisplays[0]),
                EditorField.Choice("Status", "Status", Statuses, "Confirmed")
            };

            using (RecordEditorForm editor = new RecordEditorForm("New Appointment", fields,
                values => ValidateAppointment(values, null, true)))
            {
                if (editor.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                AppointmentRecord appointment = new AppointmentRecord();
                appointment.Id = ClinicStore.NextAppointmentId();
                appointment.PatientId = ExtractId(editor.GetChoice("Patient"));
                appointment.DoctorId = ExtractId(editor.GetChoice("Doctor"));
                appointment.TreatmentId = ExtractId(editor.GetChoice("Treatment"));
                appointment.Date = ClinicStore.ToIso(editor.GetDate("Date"));
                appointment.Time = ResolveTime(editor.GetChoice("Time"));
                appointment.Status = editor.GetChoice("Status");

                ClinicStore.Data.Appointments.Add(appointment);
                ClinicStore.Save();
                txtSearchAppointments.Text = "";
                RefreshAppointments();
            }
        }

        private void EditAppointment()
        {
            if (dgvAppointments.CurrentRow == null)
            {
                MessageBox.Show(this, "Please select an appointment to edit.", "Edit Appointment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string id = Convert.ToString(dgvAppointments.CurrentRow.Cells["ID"].Value);
            AppointmentRecord appointment = ClinicStore.FindAppointment(id);
            if (appointment == null)
            {
                MessageBox.Show(this, "The selected appointment no longer exists.", "Edit Appointment",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RefreshAppointments();
                return;
            }

            string[] patientOptions = BuildChoiceOptions(
                ClinicStore.Data.Patients.OrderBy(p => p.Id).Select(p => p.Id),
                ClinicStore.Data.Patients.OrderBy(p => p.Id).Select(p => p.Name));
            string[] doctorOptions = BuildChoiceOptions(
                ClinicStore.Data.Doctors.OrderBy(d => d.Id).Select(d => d.Id),
                ClinicStore.Data.Doctors.OrderBy(d => d.Id).Select(d => d.Name));
            string[] treatmentOptions = BuildChoiceOptions(
                ClinicStore.Data.Treatments.OrderBy(t => t.Id).Select(t => t.Id),
                ClinicStore.Data.Treatments.OrderBy(t => t.Id).Select(t => t.Name));

            List<string> timeOptions = TimeDisplays.ToList();
            string currentTime = ClinicStore.DisplayTime(appointment.Time);
            if (!timeOptions.Contains(currentTime))
            {
                timeOptions.Add(currentTime);
            }

            EditorField[] fields =
            {
                EditorField.Choice("Patient", "Patient", patientOptions,
                    appointment.PatientId + " - " + ClinicStore.PatientName(appointment.PatientId)),
                EditorField.Choice("Doctor", "Doctor", doctorOptions,
                    appointment.DoctorId + " - " + ClinicStore.DoctorName(appointment.DoctorId)),
                EditorField.Choice("Treatment", "Treatment", treatmentOptions,
                    appointment.TreatmentId + " - " + ClinicStore.TreatmentName(appointment.TreatmentId)),
                EditorField.Date("Date", "Appointment date", ClinicStore.ParseDate(appointment.Date)),
                EditorField.Choice("Time", "Time", timeOptions.ToArray(), currentTime),
                EditorField.Choice("Status", "Status", Statuses, appointment.Status)
            };

            using (RecordEditorForm editor = new RecordEditorForm("Edit Appointment - " + appointment.Id, fields,
                values => ValidateAppointment(values, appointment.Id, false)))
            {
                if (editor.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                appointment.PatientId = ExtractId(editor.GetChoice("Patient"));
                appointment.DoctorId = ExtractId(editor.GetChoice("Doctor"));
                appointment.TreatmentId = ExtractId(editor.GetChoice("Treatment"));
                appointment.Date = ClinicStore.ToIso(editor.GetDate("Date"));
                appointment.Time = ResolveTime(editor.GetChoice("Time"));
                appointment.Status = editor.GetChoice("Status");

                ClinicStore.Save();
                RefreshAppointments();
            }
        }

        private static string ResolveTime(string display)
        {
            int index = Array.IndexOf(TimeDisplays, display);
            if (index >= 0)
            {
                return TimeSlots[index];
            }
            return ClinicStore.ToTimeValue(display);
        }

        private string ValidateAppointment(Dictionary<string, object> values, string id, bool isNew)
        {
            DateTime date;
            try
            {
                date = Convert.ToDateTime(values["Date"]).Date;
            }
            catch
            {
                return "Please select a valid appointment date.";
            }

            if (isNew && date < DateTime.Today)
            {
                return "Appointment date cannot be in the past.";
            }

            string doctorId = ExtractId(Convert.ToString(values["Doctor"]));
            string time = ResolveTime(Convert.ToString(values["Time"]));
            string iso = ClinicStore.ToIso(date);

            bool conflict = ClinicStore.Data.Appointments.Any(a =>
                a.Id != id &&
                a.DoctorId == doctorId &&
                a.Date == iso &&
                a.Time == time &&
                !string.Equals(a.Status, "Cancelled", StringComparison.OrdinalIgnoreCase));

            if (conflict)
            {
                return "This doctor already has an appointment on " +
                    ClinicStore.DisplayDate(iso) + " at " + ClinicStore.DisplayTime(time) + ".";
            }

            return null;
        }

        private void DeleteAppointment()
        {
            if (dgvAppointments.CurrentRow == null)
            {
                MessageBox.Show(this, "Please select an appointment to delete.", "Delete Appointment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string id = Convert.ToString(dgvAppointments.CurrentRow.Cells["ID"].Value);
            AppointmentRecord appointment = ClinicStore.FindAppointment(id);
            if (appointment == null)
            {
                RefreshAppointments();
                return;
            }

            string summary = string.Format("{0} - {1} with {2} on {3} at {4}",
                appointment.Id,
                ClinicStore.PatientName(appointment.PatientId),
                ClinicStore.DoctorName(appointment.DoctorId),
                ClinicStore.DisplayDate(appointment.Date),
                ClinicStore.DisplayTime(appointment.Time));

            DialogResult answer = MessageBox.Show(this,
                "Delete this appointment?\n\n" + summary,
                "Delete Appointment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            ClinicStore.Data.Appointments.Remove(appointment);
            ClinicStore.Save();
            RefreshAppointments();
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
