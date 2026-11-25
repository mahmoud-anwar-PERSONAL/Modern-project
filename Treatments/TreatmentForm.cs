using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DentalClinic.Shared;

namespace dentalclinicprojecttreatments
{
    public partial class TreatmentForm : Form
    {
        public Action<string> NavigationRequested { get; set; }

        private Button btnClearSearch;
        private Label lblTreatmentCount;
        private bool _uiReady;

        public TreatmentForm()
        {
            InitializeComponent();
            WireNavigation();
            CreatePageControls();
            WireCrud();
        }

        private void CreatePageControls()
        {
            btnClearSearch = new Button();
            btnClearSearch.Name = "btnClearSearch";
            pnlTreatmentsList.Controls.Add(btnClearSearch);

            lblTreatmentCount = new Label();
            lblTreatmentCount.AutoSize = false;
            pnlTreatmentsList.Controls.Add(lblTreatmentCount);
        }

        private void WireCrud()
        {
            btnAddTreatment.Click += (s, e) => AddTreatment();
            btnEditTreatment.Click += (s, e) => EditTreatment();
            btnDeletTreatment.Click += (s, e) => DeleteTreatment();
            btnClearSearch.Click += (s, e) => ClearFilters();
            dgvTreatments.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) EditTreatment();
            };
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
            SetupPageUi();
            ApplyPageLayout();
            RefreshTreatments();
            Resize += (s, args) => ApplyPageLayout();
            VisibleChanged += (s, args) =>
            {
                if (!_uiReady || !Visible) return;
                ClinicStore.Reload();
                RefreshTreatments();
            };
        }

        private void SetupPageUi()
        {
            if (_uiReady)
            {
                return;
            }

            UiTheme.StyleHeader(pnlHeader);
            UiTheme.StyleCard(pnlTreatmentsList);
            UiTheme.StyleTitle(lblPageTitle);
            UiTheme.StyleSubtitle(lblPageSubTitle);
            UiTheme.StyleSection(lblTreatmentsList);
            UiTheme.StylePrimary(btnAddTreatment, "+ Add Treatment");
            UiTheme.StyleSecondary(btnClearSearch, "Clear");
            UiTheme.StyleAction(btnEditTreatment, "Edit Treatment", Color.Green);
            UiTheme.StyleAction(btnDeletTreatment, "Delete Treatment", Color.Brown);
            UiTheme.StyleSearchBox(txtSearchTreatment, "Search by treatment name");
            txtSearchTreatment.Text = "";
            UiTheme.StyleGrid(dgvTreatments);
            UiTheme.AddActionCellColors(dgvTreatments, "colTreatmentStatus");

            lblTreatmentCount.Font = UiTheme.SmallFont;
            lblTreatmentCount.ForeColor = UiTheme.TextMuted;
            lblTreatmentCount.TextAlign = ContentAlignment.MiddleLeft;

            pnlcontent.BackColor = UiTheme.Background;
            picTreatmentsContentBackgrounf.Visible = false;

            EnsureTreatmentColumns();
            _uiReady = true;
        }

        private void EnsureTreatmentColumns()
        {
            if (!dgvTreatments.Columns.Contains("colTreatmentStatus"))
            {
                DataGridViewTextBoxColumn status = new DataGridViewTextBoxColumn();
                status.Name = "colTreatmentStatus";
                status.HeaderText = "Status";
                status.FillWeight = 95F;
                status.MinimumWidth = 8;
                status.ReadOnly = true;
                status.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvTreatments.Columns.Add(status);
            }

            coTreatmentlID.HeaderText = "ID";
            coTreatmentlID.FillWeight = 60F;
            colTreatmentName.HeaderText = "Treatment Name";
            colTreatmentName.FillWeight = 170F;
            colDescription.HeaderText = "Description";
            colDescription.FillWeight = 250F;
            colPrice.HeaderText = "Price (EGP)";
            colPrice.FillWeight = 95F;
            colDuration.HeaderText = "Duration (Min)";
            colDuration.FillWeight = 100F;
            dgvTreatments.Columns["colTreatmentStatus"].FillWeight = 95F;
        }

        private void ClearFilters()
        {
            txtSearchTreatment.Text = "";
            RefreshTreatments();
        }

        private void ApplyPageLayout()
        {
            if (pnlcontent == null || pnlcontent.ClientSize.Width < 480)
            {
                return;
            }

            pnlHeader.Height = 112;
            lblPageTitle.Location = new Point(40, 24);
            lblPageSubTitle.Location = new Point(40, 82);
            btnAddTreatment.SetBounds(pnlHeader.ClientSize.Width - 200, 34, 160, 44);

            pnlTreatmentsList.SetBounds(40, 32, pnlcontent.ClientSize.Width - 80, pnlcontent.ClientSize.Height - 64);

            int cardWidth = pnlTreatmentsList.ClientSize.Width;
            int cardHeight = pnlTreatmentsList.ClientSize.Height;

            lblTreatmentsList.Text = "All Treatments";
            lblTreatmentsList.Location = new Point(24, 20);

            int right = cardWidth - 24;
            btnClearSearch.SetBounds(right - 70, 16, 70, 34);
            txtSearchTreatment.SetBounds(right - 70 - 8 - 220, 18, 220, 32);

            int actionTop = cardHeight - 56;
            btnDeletTreatment.SetBounds(cardWidth - 174, actionTop, 150, 36);
            btnEditTreatment.SetBounds(btnDeletTreatment.Left - 142, actionTop, 130, 36);
            lblTreatmentCount.SetBounds(24, actionTop + 7, 320, 22);

            dgvTreatments.SetBounds(24, 62, cardWidth - 48, actionTop - 76);

            if (txtSearchTreatment.Text.Length == 0)
            {
                UiTheme.SetPlaceholder(txtSearchTreatment, "Search by treatment name");
            }
        }

        private void RefreshTreatments()
        {
            if (!_uiReady)
            {
                return;
            }

            string filter = txtSearchTreatment.Text.Trim();
            string selectedId = SelectedTreatmentId();

            var query = ClinicStore.Data.Treatments.AsEnumerable();
            if (filter.Length > 0)
            {
                query = query.Where(t =>
                    (t.Name ?? "").IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var rows = query.OrderBy(t => t.Id).ToList();
            dgvTreatments.SuspendLayout();
            dgvTreatments.Rows.Clear();
            foreach (TreatmentRecord treatment in rows)
            {
                dgvTreatments.Rows.Add(
                    treatment.Id,
                    treatment.Name,
                    treatment.Description,
                    treatment.Price.ToString("N0"),
                    treatment.DurationMinutes,
                    treatment.Status);
            }
            dgvTreatments.ResumeLayout();

            lblTreatmentCount.Text = string.Format("Showing {0} of {1} treatments",
                rows.Count, ClinicStore.Data.Treatments.Count);
            RestoreSelection(selectedId);
        }

        private string SelectedTreatmentId()
        {
            if (dgvTreatments.CurrentRow == null || dgvTreatments.CurrentRow.Cells.Count == 0)
            {
                return null;
            }
            object value = dgvTreatments.CurrentRow.Cells[0].Value;
            return value == null ? null : value.ToString();
        }

        private void RestoreSelection(string id)
        {
            if (string.IsNullOrEmpty(id)) return;
            foreach (DataGridViewRow row in dgvTreatments.Rows)
            {
                if (Convert.ToString(row.Cells[0].Value) == id)
                {
                    row.Selected = true;
                    dgvTreatments.CurrentCell = row.Cells[0];
                    return;
                }
            }
        }

        private void AddTreatment()
        {
            EditorField[] fields =
            {
                EditorField.Text("Name", "Treatment name", ""),
                EditorField.Text("Description", "Description", ""),
                EditorField.Money("Price", "Price (EGP)", 0m),
                EditorField.Integer("Duration", "Duration (minutes)", 30, 5, 480),
                EditorField.Choice("Status", "Status", new[] { "Available", "Unavailable" }, "Available")
            };

            using (RecordEditorForm editor = new RecordEditorForm("Add Treatment", fields,
                values => ValidateTreatment(values, null)))
            {
                if (editor.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                TreatmentRecord treatment = new TreatmentRecord();
                treatment.Id = ClinicStore.NextTreatmentId();
                treatment.Name = editor.GetText("Name");
                treatment.Description = editor.GetText("Description");
                treatment.Price = editor.GetMoney("Price");
                treatment.DurationMinutes = editor.GetInteger("Duration");
                treatment.Status = editor.GetChoice("Status");

                ClinicStore.Data.Treatments.Add(treatment);
                ClinicStore.Save();
                txtSearchTreatment.Text = "";
                RefreshTreatments();
            }
        }

        private void EditTreatment()
        {
            if (dgvTreatments.CurrentRow == null)
            {
                MessageBox.Show(this, "Please select a treatment to edit.", "Edit Treatment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string id = Convert.ToString(dgvTreatments.CurrentRow.Cells["coTreatmentlID"].Value);
            TreatmentRecord treatment = ClinicStore.FindTreatment(id);
            if (treatment == null)
            {
                MessageBox.Show(this, "The selected treatment no longer exists.", "Edit Treatment",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RefreshTreatments();
                return;
            }

            EditorField[] fields =
            {
                EditorField.Text("Name", "Treatment name", treatment.Name),
                EditorField.Text("Description", "Description", treatment.Description),
                EditorField.Money("Price", "Price (EGP)", treatment.Price),
                EditorField.Integer("Duration", "Duration (minutes)", treatment.DurationMinutes, 5, 480),
                EditorField.Choice("Status", "Status", new[] { "Available", "Unavailable" }, treatment.Status)
            };

            using (RecordEditorForm editor = new RecordEditorForm("Edit Treatment - " + treatment.Id, fields,
                values => ValidateTreatment(values, treatment.Id)))
            {
                if (editor.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                treatment.Name = editor.GetText("Name");
                treatment.Description = editor.GetText("Description");
                treatment.Price = editor.GetMoney("Price");
                treatment.DurationMinutes = editor.GetInteger("Duration");
                treatment.Status = editor.GetChoice("Status");

                ClinicStore.Save();
                RefreshTreatments();
            }
        }

        private string ValidateTreatment(Dictionary<string, object> values, string id)
        {
            string name = Convert.ToString(values["Name"]).Trim();
            if (ClinicStore.Data.Treatments.Any(t => t.Id != id &&
                string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase)))
            {
                return "A treatment with this name already exists.";
            }

            decimal price = 0m;
            object priceValue = values["Price"];
            if (priceValue is decimal)
            {
                price = (decimal)priceValue;
            }
            else
            {
                decimal.TryParse(Convert.ToString(priceValue), out price);
            }
            if (price <= 0m)
            {
                return "Price must be greater than zero.";
            }

            return null;
        }

        private void DeleteTreatment()
        {
            if (dgvTreatments.CurrentRow == null)
            {
                MessageBox.Show(this, "Please select a treatment to delete.", "Delete Treatment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string id = Convert.ToString(dgvTreatments.CurrentRow.Cells["coTreatmentlID"].Value);
            TreatmentRecord treatment = ClinicStore.FindTreatment(id);
            if (treatment == null)
            {
                RefreshTreatments();
                return;
            }

            int related = ClinicStore.Data.Appointments.Count(a => a.TreatmentId == id);
            if (related > 0)
            {
                MessageBox.Show(this,
                    string.Format("{0} is used by {1} appointment(s). Cancel or reassign those appointments before deleting the treatment.",
                        treatment.Name, related),
                    "Treatment is in use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult answer = MessageBox.Show(this,
                string.Format("Delete treatment {0} - {1}?", treatment.Id, treatment.Name),
                "Delete Treatment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            ClinicStore.Data.Treatments.Remove(treatment);
            ClinicStore.Save();
            RefreshTreatments();
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
            RefreshTreatments();
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
