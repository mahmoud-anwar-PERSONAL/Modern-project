namespace dentalclinicprojecttreatments
{
    public partial class TreatmentForm : Form
    {
        public TreatmentForm()
        {
            InitializeComponent();
            dgvTreatments.Rows.Clear();

            dgvTreatments.Rows.Add("T001", "Teeth Cleaning", "Professional dental cleaning", "500", "30", "Available");
            dgvTreatments.Rows.Add("T002", "Teeth Whitening", "Whitening and stain removal", "1500", "60", "Available");
            dgvTreatments.Rows.Add("T003", "Root Canal", "Root canal treatment", "3000", "90", "Available");
            dgvTreatments.Rows.Add("T004", "Dental Filling", "Cavity filling treatment", "800", "45", "Available");
            dgvTreatments.Rows.Add("T005", "Tooth Extraction", "Tooth removal procedure", "1200", "30", "Unavailable");
            dgvTreatments.Rows.Add("T006", "Braces", "Orthodontic teeth alignment", "12000", "120", "Available");
            dgvTreatments.Rows.Add("T007", "Dental Checkup", "General dental examination", "300", "20", "Available");
            dgvTreatments.Rows.Add("T008", "Dental Crown", "Dental crown installation", "4000", "60", "Available");
            dgvTreatments.Rows.Add("T009", "Gum Treatment", "Treatment for gum inflammation", "1000", "45", "Available");
            dgvTreatments.Rows.Add("T010", "Dental Implant", "Replacement of missing tooth", "15000", "120", "Available");
            dgvTreatments.Rows.Add("T011", "Fluoride Treatment", "Strengthens tooth enamel", "400", "20", "Available");
            dgvTreatments.Rows.Add("T012", "Wisdom Tooth Removal", "Surgical wisdom tooth extraction", "2500", "60", "Available");
            dgvTreatments.Rows.Add("T013", "Dental Veneers", "Cosmetic tooth covering", "5000", "60", "Available");
            dgvTreatments.Rows.Add("T014", "Pediatric Dentistry", "Dental care for children", "600", "30", "Available");
            dgvTreatments.Rows.Add("T015", "Deep Cleaning", "Deep periodontal cleaning", "1800", "60", "Available");
            dgvTreatments.Rows.Add("T016", "Dental Bridge", "Replacement of missing teeth", "6500", "90", "Available");
            dgvTreatments.Rows.Add("T017", "Night Guard", "Custom protective dental guard", "2000", "30", "Available");
            dgvTreatments.Rows.Add("T018", "Emergency Dental Care", "Urgent dental examination", "1000", "30", "Available");
            dgvTreatments.Rows.Add("T019", "Orthodontic Consultation", "Braces assessment and consultation", "500", "30", "Available");
            dgvTreatments.Rows.Add("T020", "Retainer", "Custom teeth alignment retainer", "1800", "30", "Available");
            dgvTreatments.Rows.Add("T021", "Laser Gum Treatment", "Laser treatment for gum problems", "3500", "60", "Available");
            dgvTreatments.Rows.Add("T022", "Dental X-Ray", "Dental imaging and diagnosis", "350", "15", "Available");
            dgvTreatments.Rows.Add("T023", "Pulp Therapy", "Treatment of damaged dental pulp", "2200", "60", "Unavailable");
            dgvTreatments.Rows.Add("T024", "Temporary Filling", "Temporary cavity restoration", "400", "20", "Available");
            dgvTreatments.Rows.Add("T025", "Smile Makeover", "Complete cosmetic smile improvement", "20000", "180", "Available");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchTreatment_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlTreatmentsList_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
