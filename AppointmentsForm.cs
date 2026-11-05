using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentsForm
{
    public partial class AppointmentsForm: Form
    {
        public AppointmentsForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AppointmentsForm_Load(object sender, EventArgs e)
        {



            dgvAppointments.Rows.Add("A001", "Mahmoud Anwar", "Ahmed Mohamed", "05/11/2026", "09:00 AM", "Confirmed");
            dgvAppointments.Rows.Add("A002", "Mona Hassan", "Sara Ali", "05/11/2026", "09:30 AM", "Pending");
            dgvAppointments.Rows.Add("A003", "Omar Khaled", "Omar Hassan", "05/11/2026", "10:00 AM", "Completed");
            dgvAppointments.Rows.Add("A004", "Salma Adel", "Mariam Adel", "05/11/2026", "10:30 AM", "Confirmed");
            dgvAppointments.Rows.Add("A005", "Youssef Ali", "Youssef Sherif", "05/11/2026", "11:00 AM", "Cancelled");
            dgvAppointments.Rows.Add("A006", "Nour Ahmed", "Nourhan Ali", "05/11/2026", "11:30 AM", "Confirmed");
            dgvAppointments.Rows.Add("A007", "Karim Samir", "Mohamed Samir", "05/11/2026", "12:00 PM", "Pending");
            dgvAppointments.Rows.Add("A008", "Farah Mohamed", "Salma Hassan", "05/11/2026", "12:30 PM", "Confirmed");
            dgvAppointments.Rows.Add("A009", "Hana Mostafa", "Khaled Ibrahim", "05/11/2026", "01:00 PM", "Completed");
            dgvAppointments.Rows.Add("A010", "Amr Nabil", "Laila Mostafa", "05/11/2026", "01:30 PM", "Confirmed");
            dgvAppointments.Rows.Add("A011", "Dina Ashraf", "Amr Khalil", "06/11/2026", "09:00 AM", "Pending");
            dgvAppointments.Rows.Add("A012", "Tarek Sameh", "Hana Mahmoud", "06/11/2026", "09:30 AM", "Confirmed");
            dgvAppointments.Rows.Add("A013", "Rana Fathy", "Tarek Adel", "06/11/2026", "10:00 AM", "Confirmed");
            dgvAppointments.Rows.Add("A014", "Laila Emad", "Farah Samy", "06/11/2026", "10:30 AM", "Cancelled");
            dgvAppointments.Rows.Add("A015", "Hossam Wael", "Mostafa Nabil", "06/11/2026", "11:00 AM", "Confirmed");
            dgvAppointments.Rows.Add("A016", "Nadia Ibrahim", "Rana Ashraf", "06/11/2026", "11:30 AM", "Completed");
            dgvAppointments.Rows.Add("A017", "Mariam Sameh", "Hossam Fathy", "06/11/2026", "12:00 PM", "Pending");
            dgvAppointments.Rows.Add("A018", "Ali Mahmoud", "Dina Wael", "06/11/2026", "12:30 PM", "Confirmed");
            dgvAppointments.Rows.Add("A019", "Sara Khalil", "Karim Sameh", "06/11/2026", "01:00 PM", "Confirmed");
            dgvAppointments.Rows.Add("A020", "Ahmed Nabil", "Nadia Emad", "06/11/2026", "01:30 PM", "Pending");
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

