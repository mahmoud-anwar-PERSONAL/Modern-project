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
        public DashboardForm()
        {
            InitializeComponent();

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

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void lblPageTitle_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {

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
    }
}
