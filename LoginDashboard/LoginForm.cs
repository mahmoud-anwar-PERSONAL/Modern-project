using System;
using System.Drawing;
using System.Windows.Forms;
using DentalClinic.Shared;

namespace DentalClinicManagementSystem
{
    public partial class LoginForm : Form
    {
        private Label lblError;
        private Label lblHint;
        private bool _loggingIn;

        public LoginForm()
        {
            InitializeComponent();
            CreateLoginExtras();
        }

        private void CreateLoginExtras()
        {
            lblError = new Label();
            lblError.AutoSize = false;
            lblError.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblError.ForeColor = Color.FromArgb(190, 48, 48);
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblError);

            lblHint = new Label();
            lblHint.AutoSize = false;
            lblHint.Text = "Demo credentials: admin / admin123";
            lblHint.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblHint.ForeColor = Color.FromArgb(130, 140, 155);
            lblHint.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblHint);

            txtEmail.TextChanged += (s, e) => ClearError();
            txtPassword.TextChanged += (s, e) => ClearError();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyLoginLayout();
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            AcceptButton = btnLogin;
            ActiveControl = txtEmail;
        }

        private void ApplyLoginLayout()
        {
            Rectangle work = Screen.PrimaryScreen.WorkingArea;
            int width = Math.Min(1100, work.Width - 120);
            int height = Math.Min(660, work.Height - 120);
            ClientSize = new Size(width, height);

            const int brandingWidth = 430;
            const int columnWidth = 420;
            int columnLeft = brandingWidth + ((width - brandingWidth - columnWidth) / 2);

            pnlBranding.SetBounds(0, 0, brandingWidth, height);

            picDental.SetBounds((brandingWidth - 280) / 2, 100, 280, 300);

            lblWelcome.AutoSize = false;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcome.SetBounds(0, 430, brandingWidth, 40);

            lblLoginTitle.AutoSize = false;
            lblLoginTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblLoginTitle.ForeColor = Color.FromArgb(35, 75, 130);
            lblLoginTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblLoginTitle.SetBounds(columnLeft, 110, columnWidth, 60);

            lblLoginSubtitle.AutoSize = false;
            lblLoginSubtitle.Text = "Please login to your account";
            lblLoginSubtitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblLoginSubtitle.ForeColor = Color.Gray;
            lblLoginSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            lblLoginSubtitle.SetBounds(columnLeft, 178, columnWidth, 28);

            Font fieldLabelFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            Color fieldLabelColor = Color.FromArgb(45, 55, 72);

            lblUsername.AutoSize = true;
            lblUsername.Font = fieldLabelFont;
            lblUsername.ForeColor = fieldLabelColor;
            lblUsername.Location = new Point(columnLeft, 238);

            txtEmail.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            txtEmail.BackColor = Color.FromArgb(245, 247, 250);
            txtEmail.SetBounds(columnLeft, 264, columnWidth, 32);

            lblPassword.AutoSize = true;
            lblPassword.Font = fieldLabelFont;
            lblPassword.ForeColor = fieldLabelColor;
            lblPassword.Location = new Point(columnLeft, 312);

            txtPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            txtPassword.BackColor = Color.FromArgb(245, 247, 250);
            txtPassword.SetBounds(columnLeft, 338, columnWidth, 32);

            chkShowPassword.AutoSize = false;
            chkShowPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            chkShowPassword.ForeColor = Color.FromArgb(90, 100, 115);
            chkShowPassword.SetBounds(columnLeft, 380, 220, 26);

            lblError.SetBounds(columnLeft, 406, columnWidth, 22);

            btnLogin.AutoSize = false;
            btnLogin.Text = "LOGIN";
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.BackColor = Color.FromArgb(23, 100, 192);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 88, 167);
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(17, 74, 142);
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.SetBounds(columnLeft, 436, columnWidth, 52);

            lblHint.SetBounds(columnLeft, 500, columnWidth, 22);
        }

        private void ClearError()
        {
            if (lblError != null)
            {
                lblError.Text = "";
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            txtPassword.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblClinicName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_loggingIn)
            {
                return;
            }

            string username = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (username.Length == 0)
            {
                lblError.Text = "Please enter your username.";
                txtEmail.Focus();
                return;
            }

            if (password.Length == 0)
            {
                lblError.Text = "Please enter your password.";
                txtPassword.Focus();
                return;
            }

            if (!ClinicStore.ValidateLogin(username, password))
            {
                txtPassword.Clear();
                ShowError("Incorrect username or password.");
                return;
            }

            _loggingIn = true;
            lblError.Text = "";

            DashboardForm dashboard = new DashboardForm();
            dashboard.FormClosed += (s, args) => this.Close();

            dashboard.Show();
            this.Hide();
        }
    }
}
