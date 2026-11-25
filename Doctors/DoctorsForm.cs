using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Shared;

namespace Dental_Clinic___Doctors_PROJECTMODERN
{
    public partial class DoctorsForm : Form
    {
        public Action<string> NavigationRequested { get; set; }

        private ComboBox cboDoctorFilter;
        private Button btnClearSearch;
        private Label lblDoctorCount;
        private bool _uiReady;
        private bool _suppressFilter;

        private static readonly string[] Specializations =
        {
            "General Dentist", "Orthodontist", "Endodontist", "Periodontist",
            "Prosthodontist", "Oral Surgeon", "Pediatric Dentist", "Cosmetic Dentist"
        };

        public DoctorsForm()
        {
            InitializeComponent();
            WireNavigation();
            CreatePageControls();
            WireCrud();
        }

        private void CreatePageControls()
        {
            cboDoctorFilter = new ComboBox();
            cboDoctorFilter.Name = "cboDoctorFilter";
            pnlGDV.Controls.Add(cboDoctorFilter);

            btnClearSearch = new Button();
            btnClearSearch.Name = "btnClearSearch";
            pnlGDV.Controls.Add(btnClearSearch);

            lblDoctorCount = new Label();
            lblDoctorCount.AutoSize = false;
            pnlGDV.Controls.Add(lblDoctorCount);
        }

        private void WireCrud()
        {
            btnEditDoctor.Click += (s, e) => EditDoctor();
            btnDeleteDoctor.Click += (s, e) => DeleteDoctor();
            btnClearSearch.Click += (s, e) => ClearFilters();
            txtSearchDoctor.TextChanged += (s, e) => RefreshDoctors();
            cboDoctorFilter.SelectedIndexChanged += (s, e) =>
            {
                if (!_suppressFilter) RefreshDoctors();
            };
            dgvDoctors.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) EditDoctor();
            };
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
            SetupPageUi();
            ApplyPageLayout();
            RefreshDoctors();
            Resize += (s, args) => ApplyPageLayout();
            VisibleChanged += (s, args) =>
            {
                if (!_uiReady || !Visible) return;
                ClinicStore.Reload();
                BuildDoctorFilter();
                RefreshDoctors();
            };
        }

        private void SetupPageUi()
        {
            if (_uiReady)
            {
                return;
            }

            UiTheme.StyleHeader(pnlHeader);
            UiTheme.StyleCard(pnlGDV);
            UiTheme.StyleTitle(lblTitle);
            UiTheme.StyleSubtitle(label1);
            UiTheme.StyleSection(lblDoctorslist);
            UiTheme.StylePrimary(btnAddDoctor, "+ Add Doctor");
            UiTheme.StyleSecondary(btnClearSearch, "Clear");
            UiTheme.StyleAction(btnEditDoctor, "Edit Doctor", Color.Green);
            UiTheme.StyleAction(btnDeleteDoctor, "Delete Doctor", Color.Brown);
            UiTheme.StyleCombo(cboDoctorFilter);
            UiTheme.StyleSearchBox(txtSearchDoctor, "Search name or phone");
            txtSearchDoctor.Text = "";
            UiTheme.StyleGrid(dgvDoctors);
            UiTheme.AddActionCellColors(dgvDoctors, "colSpec");

            lblDoctorCount.Font = UiTheme.SmallFont;
            lblDoctorCount.ForeColor = UiTheme.TextMuted;
            lblDoctorCount.TextAlign = ContentAlignment.MiddleLeft;

            pnlContent.BackColor = UiTheme.Background;
            pictureBox2.Visible = false;

            BuildDoctorFilter();
            _uiReady = true;
        }

        private void BuildDoctorFilter()
        {
            string selected = cboDoctorFilter.SelectedIndex > 0
                ? Convert.ToString(cboDoctorFilter.SelectedItem)
                : null;

            _suppressFilter = true;
            cboDoctorFilter.Items.Clear();
            cboDoctorFilter.Items.Add("All Doctors");
            foreach (DoctorRecord doctor in ClinicStore.Data.Doctors.OrderBy(d => d.Name))
            {
                cboDoctorFilter.Items.Add(doctor.Name);
            }

            int index = 0;
            if (!string.IsNullOrEmpty(selected))
            {
                int found = cboDoctorFilter.Items.IndexOf(selected);
                if (found > 0) index = found;
            }
            cboDoctorFilter.SelectedIndex = index;
            _suppressFilter = false;
        }

        private void ClearFilters()
        {
            _suppressFilter = true;
            txtSearchDoctor.Text = "";
            cboDoctorFilter.SelectedIndex = 0;
            _suppressFilter = false;
            RefreshDoctors();
        }

        private void ApplyPageLayout()
        {
            if (pnlContent == null || pnlContent.ClientSize.Width < 480)
            {
                return;
            }

            pnlHeader.Height = 112;
            lblTitle.Location = new Point(40, 24);
            label1.Location = new Point(40, 82);
            btnAddDoctor.SetBounds(pnlHeader.ClientSize.Width - 200, 34, 160, 44);

            pnlGDV.SetBounds(40, 32, pnlContent.ClientSize.Width - 80, pnlContent.ClientSize.Height - 64);

            int cardWidth = pnlGDV.ClientSize.Width;
            int cardHeight = pnlGDV.ClientSize.Height;

            lblDoctorslist.Text = "All Doctors";
            lblDoctorslist.Location = new Point(24, 20);

            int right = cardWidth - 24;
            btnClearSearch.SetBounds(right - 70, 16, 70, 34);
            txtSearchDoctor.SetBounds(right - 70 - 8 - 190, 18, 190, 32);
            cboDoctorFilter.SetBounds(right - 70 - 8 - 190 - 8 - 170, 18, 170, 32);

            StyleSearchCue();

            int actionTop = cardHeight - 56;
            btnDeleteDoctor.SetBounds(cardWidth - 164, actionTop, 140, 36);
            btnEditDoctor.SetBounds(btnDeleteDoctor.Left - 142, actionTop, 130, 36);
            lblDoctorCount.SetBounds(24, actionTop + 7, 320, 22);

            dgvDoctors.SetBounds(24, 62, cardWidth - 48, actionTop - 76);
        }

        private void StyleSearchCue()
        {
            if (txtSearchDoctor.Text.Length == 0)
            {
                UiTheme.SetPlaceholder(txtSearchDoctor, "Search name or phone");
            }
        }

        private void RefreshDoctors()
        {
            if (!_uiReady)
            {
                return;
            }

            string filter = txtSearchDoctor.Text.Trim();
            string doctorName = cboDoctorFilter.SelectedIndex > 0
                ? Convert.ToString(cboDoctorFilter.SelectedItem)
                : null;
            string selectedId = SelectedDoctorId();

            var query = ClinicStore.Data.Doctors.AsEnumerable();
            if (!string.IsNullOrEmpty(doctorName))
            {
                query = query.Where(d => d.Name == doctorName);
            }
            if (filter.Length > 0)
            {
                query = query.Where(d =>
                    (d.Id ?? "").IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (d.Name ?? "").IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (d.Specialization ?? "").IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (d.Phone ?? "").IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var rows = query.OrderBy(d => d.Id).ToList();
            dgvDoctors.SuspendLayout();
            dgvDoctors.Rows.Clear();
            foreach (DoctorRecord doctor in rows)
            {
                dgvDoctors.Rows.Add(doctor.Id, doctor.Name, doctor.Specialization, doctor.Phone);
            }
            dgvDoctors.ResumeLayout();

            lblDoctorCount.Text = string.Format("Showing {0} of {1} doctors",
                rows.Count, ClinicStore.Data.Doctors.Count);
            RestoreSelection(selectedId);
        }

        private string SelectedDoctorId()
        {
            if (dgvDoctors.CurrentRow == null || dgvDoctors.CurrentRow.Cells.Count == 0)
            {
                return null;
            }
            object value = dgvDoctors.CurrentRow.Cells[0].Value;
            return value == null ? null : value.ToString();
        }

        private void RestoreSelection(string id)
        {
            if (string.IsNullOrEmpty(id)) return;
            foreach (DataGridViewRow row in dgvDoctors.Rows)
            {
                if (Convert.ToString(row.Cells[0].Value) == id)
                {
                    row.Selected = true;
                    dgvDoctors.CurrentCell = row.Cells[0];
                    return;
                }
            }
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            AddDoctor();
        }

        private void AddDoctor()
        {
            EditorField[] fields =
            {
                EditorField.Text("Name", "Full name", ""),
                EditorField.Choice("Specialization", "Specialization", Specializations, "General Dentist"),
                EditorField.Text("Phone", "Phone (7-15 digits)", "")
            };

            using (RecordEditorForm editor = new RecordEditorForm("Add Doctor", fields,
                values => ValidateDoctor(values, null)))
            {
                if (editor.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                DoctorRecord doctor = new DoctorRecord();
                doctor.Id = ClinicStore.NextDoctorId();
                doctor.Name = editor.GetText("Name");
                doctor.Specialization = editor.GetChoice("Specialization");
                doctor.Phone = NormalizePhone(editor.GetText("Phone"));

                ClinicStore.Data.Doctors.Add(doctor);
                ClinicStore.Save();
                BuildDoctorFilter();
                ClearFilters();
            }
        }

        private void EditDoctor()
        {
            if (dgvDoctors.CurrentRow == null)
            {
                MessageBox.Show(this, "Please select a doctor to edit.", "Edit Doctor",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string id = Convert.ToString(dgvDoctors.CurrentRow.Cells["colID"].Value);
            DoctorRecord doctor = ClinicStore.FindDoctor(id);
            if (doctor == null)
            {
                RefreshDoctors();
                return;
            }

            EditorField[] fields =
            {
                EditorField.Text("Name", "Full name", doctor.Name),
                EditorField.Choice("Specialization", "Specialization", Specializations, doctor.Specialization),
                EditorField.Text("Phone", "Phone (7-15 digits)", doctor.Phone)
            };

            using (RecordEditorForm editor = new RecordEditorForm("Edit Doctor - " + doctor.Id, fields,
                values => ValidateDoctor(values, doctor.Id)))
            {
                if (editor.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                doctor.Name = editor.GetText("Name");
                doctor.Specialization = editor.GetChoice("Specialization");
                doctor.Phone = NormalizePhone(editor.GetText("Phone"));

                ClinicStore.Save();
                BuildDoctorFilter();
                RefreshDoctors();
            }
        }

        private string ValidateDoctor(Dictionary<string, object> values, string id)
        {
            string name = Convert.ToString(values["Name"]).Trim();
            if (ClinicStore.Data.Doctors.Any(d => d.Id != id &&
                string.Equals(d.Name, name, StringComparison.OrdinalIgnoreCase)))
            {
                return "A doctor with this name already exists.";
            }

            string phone = NormalizePhone(Convert.ToString(values["Phone"]));
            int digits = 0;
            foreach (char c in phone)
            {
                if (char.IsDigit(c)) digits++;
                else if (c != ' ' && c != '+' && c != '-' && c != '(' && c != ')')
                {
                    return "Phone may contain digits, spaces, +, - and parentheses only.";
                }
            }
            if (digits < 7 || digits > 15)
            {
                return "Phone must contain between 7 and 15 digits.";
            }

            return null;
        }

        private static string NormalizePhone(string phone)
        {
            return (phone ?? "").Trim();
        }

        private void DeleteDoctor()
        {
            if (dgvDoctors.CurrentRow == null)
            {
                MessageBox.Show(this, "Please select a doctor to delete.", "Delete Doctor",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string id = Convert.ToString(dgvDoctors.CurrentRow.Cells["colID"].Value);
            DoctorRecord doctor = ClinicStore.FindDoctor(id);
            if (doctor == null)
            {
                RefreshDoctors();
                return;
            }

            int related = ClinicStore.Data.Appointments.Count(a => a.DoctorId == id);
            if (related > 0)
            {
                MessageBox.Show(this,
                    string.Format("{0} has {1} appointment(s). Cancel or reassign those appointments before deleting the doctor.",
                        doctor.Name, related),
                    "Doctor is in use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult answer = MessageBox.Show(this,
                string.Format("Delete doctor {0} - {1}?", doctor.Id, doctor.Name),
                "Delete Doctor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            ClinicStore.Data.Doctors.Remove(doctor);
            ClinicStore.Save();
            BuildDoctorFilter();
            RefreshDoctors();
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            RequestNavigation("Dashboard");
        }
    }
}
