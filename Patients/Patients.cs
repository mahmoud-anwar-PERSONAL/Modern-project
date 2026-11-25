using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Shared;

namespace WinFormsApp2
{
    public partial class MainForm : Form
    {
        public Action<string> NavigationRequested { get; set; }

        private TextBox txtSearchPatients;
        private Button btnClearSearch;
        private Label lblPatientsSubtitle;
        private Label lblPatientCount;
        private bool _uiReady;

        public MainForm()
        {
            InitializeComponent();
            WireNavigation();
            CreatePageControls();
            WireCrud();
        }

        private void CreatePageControls()
        {
            lblPatientsSubtitle = new Label();
            lblPatientsSubtitle.AutoSize = true;
            lblPatientsSubtitle.Text = "Manage patient records and contact details";
            pnlHeader.Controls.Add(lblPatientsSubtitle);

            txtSearchPatients = new TextBox();
            txtSearchPatients.Name = "txtSearchPatients";
            panel1.Controls.Add(txtSearchPatients);

            btnClearSearch = new Button();
            btnClearSearch.Name = "btnClearSearch";
            panel1.Controls.Add(btnClearSearch);

            lblPatientCount = new Label();
            lblPatientCount.AutoSize = false;
            panel1.Controls.Add(lblPatientCount);
        }

        private void WireCrud()
        {
            button8.Click += (s, e) => EditPatient();
            button9.Click += (s, e) => DeletePatient();
            button10.Click += (s, e) => RefreshPatients();
            btnClearSearch.Click += (s, e) =>
            {
                txtSearchPatients.Text = "";
                RefreshPatients();
            };
            txtSearchPatients.TextChanged += (s, e) => RefreshPatients();
            dgvPatients.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) EditPatient();
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyUnifiedSidebar();
            SetupPageUi();
            ApplyPageLayout();
            RefreshPatients();
            Resize += (s, args) => ApplyPageLayout();
            VisibleChanged += (s, args) =>
            {
                if (!_uiReady || !Visible) return;
                ClinicStore.Reload();
                RefreshPatients();
            };
        }

        private void SetupPageUi()
        {
            if (_uiReady)
            {
                return;
            }

            UiTheme.StyleHeader(pnlHeader);
            UiTheme.StyleCard(panel1);
            UiTheme.StyleTitle(lblTitle);
            UiTheme.StyleSubtitle(lblPatientsSubtitle);
            UiTheme.StyleSection(label1);
            UiTheme.StylePrimary(btnAddPatient, "+ Add Patient");
            UiTheme.StylePrimary(button10, "Search");
            UiTheme.StyleSecondary(btnClearSearch, "Clear");
            UiTheme.StyleAction(button8, "Edit", Color.Green);
            UiTheme.StyleAction(button9, "Delete", Color.Red);
            UiTheme.StyleSearchBox(txtSearchPatients, "Search by patient ID or name");
            UiTheme.StyleGrid(dgvPatients);
            UiTheme.AddActionCellColors(dgvPatients, "colStatus");

            lblPatientCount.Font = UiTheme.SmallFont;
            lblPatientCount.ForeColor = UiTheme.TextMuted;
            lblPatientCount.TextAlign = ContentAlignment.MiddleLeft;

            pnlContent.BackColor = UiTheme.Background;
            pictureBox1.Visible = false;

            EnsurePatientColumns();

            _uiReady = true;
        }

        private void EnsurePatientColumns()
        {
            RemoveColumn("colTreatment");
            RemoveColumn("colInsurance");
            RemoveColumn("colRoom");

            if (!dgvPatients.Columns.Contains("colPatientId"))
            {
                dgvPatients.Columns.Insert(0, MakeColumn("colPatientId", "Patient ID", 60));
            }
            if (!dgvPatients.Columns.Contains("colAge"))
            {
                dgvPatients.Columns.Insert(3, MakeColumn("colAge", "Age", 55));
            }
            if (!dgvPatients.Columns.Contains("colGender"))
            {
                dgvPatients.Columns.Insert(4, MakeColumn("colGender", "Gender", 75));
            }
            if (!dgvPatients.Columns.Contains("colAddress"))
            {
                dgvPatients.Columns.Insert(5, MakeColumn("colAddress", "Address", 230));
            }

            colName.FillWeight = 150F;
            colDate.FillWeight = 105F;
            colStatus.FillWeight = 95F;
            dgvPatients.Columns["colPatientId"].FillWeight = 62F;
            dgvPatients.Columns["colAge"].FillWeight = 55F;
            dgvPatients.Columns["colGender"].FillWeight = 75F;
            dgvPatients.Columns["colAddress"].FillWeight = 230F;
        }

        private void RemoveColumn(string name)
        {
            if (dgvPatients.Columns.Contains(name))
            {
                dgvPatients.Columns.Remove(name);
            }
        }

        private static DataGridViewTextBoxColumn MakeColumn(string name, string header, float weight)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.Name = name;
            column.HeaderText = header;
            column.FillWeight = weight;
            column.MinimumWidth = 8;
            column.ReadOnly = true;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            return column;
        }

        private void ApplyPageLayout()
        {
            if (pnlContent == null || pnlContent.ClientSize.Width < 480)
            {
                return;
            }

            pnlHeader.Height = 112;
            lblTitle.Location = new Point(40, 24);
            lblPatientsSubtitle.Location = new Point(40, 82);

            btnAddPatient.SetBounds(pnlHeader.ClientSize.Width - 200, 34, 160, 44);

            int contentWidth = pnlContent.ClientSize.Width;
            int contentHeight = pnlContent.ClientSize.Height;
            int contentTop = pnlHeader.Height;
            panel1.SetBounds(40, contentTop + 32, contentWidth - 80, contentHeight - contentTop - 64);

            int cardWidth = panel1.ClientSize.Width;
            int cardHeight = panel1.ClientSize.Height;

            label1.Text = "All Patients";
            label1.Location = new Point(24, 20);

            int right = cardWidth - 24;
            button10.SetBounds(right - 100, 16, 100, 34);
            btnClearSearch.SetBounds(right - 100 - 8 - 76, 16, 76, 34);
            txtSearchPatients.SetBounds(right - 100 - 8 - 76 - 8 - 220, 18, 220, 32);

            int actionTop = cardHeight - 56;
            button9.SetBounds(cardWidth - 144, actionTop, 120, 36);
            button8.SetBounds(button9.Left - 122, actionTop, 110, 36);
            lblPatientCount.SetBounds(24, actionTop + 7, 320, 22);

            dgvPatients.SetBounds(24, 64, cardWidth - 48, actionTop - 78);
        }

        private void RefreshPatients()
        {
            if (dgvPatients == null || !_uiReady)
            {
                return;
            }

            string filter = txtSearchPatients == null ? "" : txtSearchPatients.Text.Trim();
            string selectedId = SelectedPatientId();

            var query = ClinicStore.Data.Patients.AsEnumerable();
            if (filter.Length > 0)
            {
                query = query.Where(p =>
                    (p.Id ?? "").IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (p.Name ?? "").IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var rows = query.OrderBy(p => p.Id).ToList();
            dgvPatients.SuspendLayout();
            dgvPatients.Rows.Clear();
            foreach (PatientRecord patient in rows)
            {
                dgvPatients.Rows.Add(
                    patient.Id,
                    patient.Name,
                    ClinicStore.DisplayDate(patient.RegistrationDate),
                    patient.Age,
                    patient.Gender,
                    patient.Address,
                    patient.Status);
            }
            dgvPatients.ResumeLayout();

            lblPatientCount.Text = string.Format("Showing {0} of {1} patients",
                rows.Count, ClinicStore.Data.Patients.Count);

            RestoreSelection(selectedId);
        }

        private string SelectedPatientId()
        {
            if (dgvPatients.CurrentRow == null || dgvPatients.CurrentRow.Cells.Count == 0)
            {
                return null;
            }
            object value = dgvPatients.CurrentRow.Cells[0].Value;
            return value == null ? null : value.ToString();
        }

        private void RestoreSelection(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return;
            }
            foreach (DataGridViewRow row in dgvPatients.Rows)
            {
                if (Convert.ToString(row.Cells[0].Value) == id)
                {
                    row.Selected = true;
                    dgvPatients.CurrentCell = row.Cells[0];
                    return;
                }
            }
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            AddPatient();
        }

        private void AddPatient()
        {
            EditorField[] fields =
            {
                EditorField.Text("Name", "Full name", ""),
                EditorField.Date("Date", "Registration date", DateTime.Today),
                EditorField.Integer("Age", "Age", 30, 0, 120),
                EditorField.Choice("Gender", "Gender", new[] { "Male", "Female", "Other" }, null),
                EditorField.Text("Address", "Address", ""),
                EditorField.Choice("Status", "Status", new[] { "Active", "Follow-up", "Completed" }, "Active")
            };

            using (RecordEditorForm editor = new RecordEditorForm("Add Patient", fields, ValidateNewPatient))
            {
                if (editor.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                PatientRecord patient = new PatientRecord();
                patient.Id = ClinicStore.NextPatientId();
                patient.Name = editor.GetText("Name");
                patient.RegistrationDate = ClinicStore.ToIso(editor.GetDate("Date"));
                patient.Age = editor.GetInteger("Age");
                patient.Gender = editor.GetChoice("Gender");
                patient.Address = editor.GetText("Address");
                patient.Status = editor.GetChoice("Status");

                ClinicStore.Data.Patients.Add(patient);
                ClinicStore.Save();
                txtSearchPatients.Text = "";
                RefreshPatients();
            }
        }

        private string ValidateNewPatient(System.Collections.Generic.Dictionary<string, object> values)
        {
            string name = Convert.ToString(values["Name"]).Trim();
            if (ClinicStore.Data.Patients.Any(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase)))
            {
                return "A patient with this name already exists. Please check the existing record.";
            }
            return null;
        }

        private void EditPatient()
        {
            if (dgvPatients.CurrentRow == null)
            {
                MessageBox.Show(this, "Please select a patient to edit.", "Edit Patient",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string id = Convert.ToString(dgvPatients.CurrentRow.Cells["colPatientId"].Value);
            PatientRecord patient = ClinicStore.FindPatient(id);
            if (patient == null)
            {
                MessageBox.Show(this, "The selected patient no longer exists.", "Edit Patient",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RefreshPatients();
                return;
            }

            EditorField[] fields =
            {
                EditorField.Text("Name", "Full name", patient.Name),
                EditorField.Date("Date", "Registration date", ClinicStore.ParseDate(patient.RegistrationDate)),
                EditorField.Integer("Age", "Age", patient.Age, 0, 120),
                EditorField.Choice("Gender", "Gender", new[] { "Male", "Female", "Other" }, patient.Gender),
                EditorField.Text("Address", "Address", patient.Address),
                EditorField.Choice("Status", "Status", new[] { "Active", "Follow-up", "Completed" }, patient.Status)
            };

            using (RecordEditorForm editor = new RecordEditorForm("Edit Patient - " + patient.Id, fields,
                values => ValidateEditedPatient(values, patient.Id)))
            {
                if (editor.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                patient.Name = editor.GetText("Name");
                patient.RegistrationDate = ClinicStore.ToIso(editor.GetDate("Date"));
                patient.Age = editor.GetInteger("Age");
                patient.Gender = editor.GetChoice("Gender");
                patient.Address = editor.GetText("Address");
                patient.Status = editor.GetChoice("Status");

                ClinicStore.Save();
                RefreshPatients();
            }
        }

        private string ValidateEditedPatient(System.Collections.Generic.Dictionary<string, object> values, string id)
        {
            string name = Convert.ToString(values["Name"]).Trim();
            if (ClinicStore.Data.Patients.Any(p => p.Id != id &&
                string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase)))
            {
                return "Another patient already uses this name.";
            }
            return null;
        }

        private void DeletePatient()
        {
            if (dgvPatients.CurrentRow == null)
            {
                MessageBox.Show(this, "Please select a patient to delete.", "Delete Patient",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string id = Convert.ToString(dgvPatients.CurrentRow.Cells["colPatientId"].Value);
            PatientRecord patient = ClinicStore.FindPatient(id);
            if (patient == null)
            {
                RefreshPatients();
                return;
            }

            int related = ClinicStore.Data.Appointments.Count(a => a.PatientId == id);
            if (related > 0)
            {
                MessageBox.Show(this,
                    string.Format("{0} has {1} appointment(s). Cancel or reassign those appointments before deleting the patient.",
                        patient.Name, related),
                    "Patient is in use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult answer = MessageBox.Show(this,
                string.Format("Delete patient {0} - {1}? This cannot be undone.", patient.Id, patient.Name),
                "Delete Patient", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            ClinicStore.Data.Patients.Remove(patient);
            ClinicStore.Save();
            RefreshPatients();
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
