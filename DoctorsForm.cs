using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic___Doctors_PROJECTMODERN
{
    public partial class DoctorsForm : Form
    {
        public DoctorsForm()
        {
            InitializeComponent();
            dgvDoctors.Rows.Clear();

            dgvDoctors.Rows.Add("D001", "Ahmed Mohamed", "Orthodontist", "01012345678");
            dgvDoctors.Rows.Add("D002", "Sara Ali", "Pediatric Dentist", "01123456789");
            dgvDoctors.Rows.Add("D003", "Omar Hassan", "Oral Surgeon", "01234567890");
            dgvDoctors.Rows.Add("D004", "Mariam Adel", "Endodontist", "01098765432");
            dgvDoctors.Rows.Add("D005", "Youssef Sherif", "General Dentist", "01198765432");
            dgvDoctors.Rows.Add("D006", "Nourhan Ali", "Periodontist", "01298765432");
            dgvDoctors.Rows.Add("D007", "Mohamed Samir", "Prosthodontist", "01055556666");
            dgvDoctors.Rows.Add("D008", "Salma Hassan", "Cosmetic Dentist", "01155556666");
            dgvDoctors.Rows.Add("D009", "Khaled Ibrahim", "Orthodontist", "01255556666");
            dgvDoctors.Rows.Add("D010", "Laila Mostafa", "General Dentist", "01044445555");
            dgvDoctors.Rows.Add("D011", "Amr Khalil", "Oral Surgeon", "01144445555");
            dgvDoctors.Rows.Add("D012", "Hana Mahmoud", "Pediatric Dentist", "01244445555");
            dgvDoctors.Rows.Add("D013", "Tarek Adel", "Endodontist", "01033334444");
            dgvDoctors.Rows.Add("D014", "Farah Samy", "Cosmetic Dentist", "01133334444");
            dgvDoctors.Rows.Add("D015", "Mostafa Nabil", "Periodontist", "01233334444");
            dgvDoctors.Rows.Add("D016", "Rana Ashraf", "General Dentist", "01022223333");
            dgvDoctors.Rows.Add("D017", "Hossam Fathy", "Prosthodontist", "01122223333");
            dgvDoctors.Rows.Add("D018", "Dina Wael", "Orthodontist", "01222223333");
            dgvDoctors.Rows.Add("D019", "Karim Sameh", "Oral Surgeon", "01011112222");
            dgvDoctors.Rows.Add("D020", "Nadia Emad", "Pediatric Dentist", "01111112222");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dgvDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {

        }
    }
}
