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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyLoginLayout();
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
            lblLoginTitle.SetBounds(columnLeft, 120, columnWidth, 60);

            lblLoginSubtitle.AutoSize = false;
            lblLoginSubtitle.Text = "Please login to your account";
            lblLoginSubtitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblLoginSubtitle.ForeColor = Color.Gray;
            lblLoginSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            lblLoginSubtitle.SetBounds(columnLeft, 188, columnWidth, 28);

            Font fieldLabelFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            Color fieldLabelColor = Color.FromArgb(45, 55, 72);

            lblUsername.AutoSize = true;
            lblUsername.Font = fieldLabelFont;
            lblUsername.ForeColor = fieldLabelColor;
            lblUsername.Location = new Point(columnLeft, 252);

            txtEmail.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            txtEmail.BackColor = Color.FromArgb(245, 247, 250);
            txtEmail.SetBounds(columnLeft, 278, columnWidth, 32);

            lblPassword.AutoSize = true;
            lblPassword.Font = fieldLabelFont;
            lblPassword.ForeColor = fieldLabelColor;
            lblPassword.Location = new Point(columnLeft, 326);

            txtPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            txtPassword.BackColor = Color.FromArgb(245, 247, 250);
            txtPassword.SetBounds(columnLeft, 352, columnWidth, 32);

            chkShowPassword.AutoSize = false;
            chkShowPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            chkShowPassword.ForeColor = Color.FromArgb(90, 100, 115);
            chkShowPassword.SetBounds(columnLeft, 396, 220, 26);

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
            btnLogin.SetBounds(columnLeft, 442, columnWidth, 56);
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
            DashboardForm dashboard = new DashboardForm();

            dashboard.FormClosed += (s, args) => this.Close();

            dashboard.Show();
            this.Hide();
        }
    }
}
