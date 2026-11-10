using System;
using System.Windows.Forms;
namespace Dental_Clinic___Doctors_PROJECTMODERN {
    internal static class Program {
        [STAThread] private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DoctorsForm());
        }
    }
}
