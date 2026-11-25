using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace DentalClinic.Shared
{
    internal sealed class PatientRecord
    {
        public string Id = "";
        public string Name = "";
        public string RegistrationDate = "";
        public int Age;
        public string Gender = "";
        public string Address = "";
        public string Status = "";
    }

    internal sealed class DoctorRecord
    {
        public string Id = "";
        public string Name = "";
        public string Specialization = "";
        public string Phone = "";
    }

    internal sealed class TreatmentRecord
    {
        public string Id = "";
        public string Name = "";
        public string Description = "";
        public decimal Price;
        public int DurationMinutes;
        public string Status = "";
    }

    internal sealed class AppointmentRecord
    {
        public string Id = "";
        public string PatientId = "";
        public string DoctorId = "";
        public string TreatmentId = "";
        public string Date = "";
        public string Time = "";
        public string Status = "";
    }

    internal sealed class ClinicDatabase
    {
        public List<PatientRecord> Patients = new List<PatientRecord>();
        public List<DoctorRecord> Doctors = new List<DoctorRecord>();
        public List<TreatmentRecord> Treatments = new List<TreatmentRecord>();
        public List<AppointmentRecord> Appointments = new List<AppointmentRecord>();
    }

    internal static class ClinicStore
    {
        private const string HeaderLine = "DENTALCLINIC-DATA|v1";
        private static readonly object Sync = new object();
        private static ClinicDatabase _data;

        public static string DataFilePath
        {
            get
            {
                string root = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(Path.Combine(root, "DentalClinicMS"), "clinic-data.txt");
            }
        }

        public static ClinicDatabase Data
        {
            get
            {
                lock (Sync)
                {
                    if (_data == null)
                    {
                        _data = LoadFromDisk();
                    }
                    return _data;
                }
            }
        }

        public static void Reload()
        {
            lock (Sync)
            {
                _data = LoadFromDisk();
            }
        }

        public static void Save()
        {
            lock (Sync)
            {
                if (_data == null)
                {
                    return;
                }

                string path = DataFilePath;
                string dir = Path.GetDirectoryName(path);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(HeaderLine);
                foreach (PatientRecord p in _data.Patients.OrderBy(x => x.Id))
                {
                    sb.AppendLine(string.Join("|", new string[]
                    {
                        "PATIENT", Enc(p.Id), Enc(p.Name), Enc(p.RegistrationDate),
                        p.Age.ToString(CultureInfo.InvariantCulture), Enc(p.Gender), Enc(p.Address), Enc(p.Status)
                    }));
                }
                foreach (DoctorRecord d in _data.Doctors.OrderBy(x => x.Id))
                {
                    sb.AppendLine(string.Join("|", new string[]
                    {
                        "DOCTOR", Enc(d.Id), Enc(d.Name), Enc(d.Specialization), Enc(d.Phone)
                    }));
                }
                foreach (TreatmentRecord t in _data.Treatments.OrderBy(x => x.Id))
                {
                    sb.AppendLine(string.Join("|", new string[]
                    {
                        "TREATMENT", Enc(t.Id), Enc(t.Name), Enc(t.Description),
                        t.Price.ToString("0.##", CultureInfo.InvariantCulture),
                        t.DurationMinutes.ToString(CultureInfo.InvariantCulture), Enc(t.Status)
                    }));
                }
                foreach (AppointmentRecord a in _data.Appointments.OrderBy(x => x.Id))
                {
                    sb.AppendLine(string.Join("|", new string[]
                    {
                        "APPOINTMENT", Enc(a.Id), Enc(a.PatientId), Enc(a.DoctorId), Enc(a.TreatmentId),
                        Enc(a.Date), Enc(a.Time), Enc(a.Status)
                    }));
                }

                string temp = path + ".tmp";
                File.WriteAllText(temp, sb.ToString(), new UTF8Encoding(false));
                File.Copy(temp, path, true);
                try { File.Delete(temp); } catch { }
            }
        }

        private static ClinicDatabase LoadFromDisk()
        {
            string path = DataFilePath;
            if (!File.Exists(path))
            {
                ClinicDatabase seeded = CreateSeed();
                _data = seeded;
                Save();
                return seeded;
            }

            try
            {
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);
                ClinicDatabase db = Parse(lines);
                if (db.Patients.Count == 0 && db.Doctors.Count == 0 &&
                    db.Treatments.Count == 0 && db.Appointments.Count == 0)
                {
                    throw new InvalidDataException("Data file is empty.");
                }
                return db;
            }
            catch
            {
                try
                {
                    string backup = path + ".corrupt-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    File.Copy(path, backup, true);
                }
                catch { }

                ClinicDatabase seeded = CreateSeed();
                _data = seeded;
                Save();
                return seeded;
            }
        }

        private static ClinicDatabase Parse(string[] lines)
        {
            ClinicDatabase db = new ClinicDatabase();
            foreach (string raw in lines)
            {
                if (string.IsNullOrWhiteSpace(raw) || raw.StartsWith("DENTALCLINIC-DATA", StringComparison.Ordinal))
                {
                    continue;
                }

                string[] f = raw.Split('|');
                if (f.Length == 0)
                {
                    continue;
                }

                switch (f[0])
                {
                    case "PATIENT":
                        if (f.Length >= 8)
                        {
                            db.Patients.Add(new PatientRecord
                            {
                                Id = Dec(f[1]),
                                Name = Dec(f[2]),
                                RegistrationDate = Dec(f[3]),
                                Age = ParseInt(f[4]),
                                Gender = Dec(f[5]),
                                Address = Dec(f[6]),
                                Status = Dec(f[7])
                            });
                        }
                        break;
                    case "DOCTOR":
                        if (f.Length >= 5)
                        {
                            db.Doctors.Add(new DoctorRecord
                            {
                                Id = Dec(f[1]),
                                Name = Dec(f[2]),
                                Specialization = Dec(f[3]),
                                Phone = Dec(f[4])
                            });
                        }
                        break;
                    case "TREATMENT":
                        if (f.Length >= 7)
                        {
                            db.Treatments.Add(new TreatmentRecord
                            {
                                Id = Dec(f[1]),
                                Name = Dec(f[2]),
                                Description = Dec(f[3]),
                                Price = ParseDecimal(f[4]),
                                DurationMinutes = ParseInt(f[5]),
                                Status = Dec(f[6])
                            });
                        }
                        break;
                    case "APPOINTMENT":
                        if (f.Length >= 8)
                        {
                            db.Appointments.Add(new AppointmentRecord
                            {
                                Id = Dec(f[1]),
                                PatientId = Dec(f[2]),
                                DoctorId = Dec(f[3]),
                                TreatmentId = Dec(f[4]),
                                Date = Dec(f[5]),
                                Time = Dec(f[6]),
                                Status = Dec(f[7])
                            });
                        }
                        break;
                }
            }
            return db;
        }

        private static int ParseInt(string value)
        {
            int result;
            int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
            return result;
        }

        private static decimal ParseDecimal(string value)
        {
            decimal result;
            decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out result);
            return result;
        }

        private static string Enc(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            StringBuilder sb = new StringBuilder(value.Length + 8);
            foreach (char c in value)
            {
                if (c == '\\') sb.Append("\\\\");
                else if (c == '|') sb.Append("\\p");
                else if (c == '\r') { }
                else if (c == '\n') sb.Append(' ');
                else sb.Append(c);
            }
            return sb.ToString();
        }

        private static string Dec(string value)
        {
            if (string.IsNullOrEmpty(value) || value.IndexOf('\\') < 0)
            {
                return value ?? "";
            }
            StringBuilder sb = new StringBuilder(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '\\' && i + 1 < value.Length)
                {
                    if (value[i + 1] == '\\') { sb.Append('\\'); i++; continue; }
                    if (value[i + 1] == 'p') { sb.Append('|'); i++; continue; }
                }
                sb.Append(value[i]);
            }
            return sb.ToString();
        }

        public static bool ValidateLogin(string username, string password)
        {
            return string.Equals((username ?? "").Trim(), "admin", StringComparison.OrdinalIgnoreCase)
                && string.Equals(password ?? "", "admin123", StringComparison.Ordinal);
        }

        public static string NextId(string prefix, IEnumerable<string> existing)
        {
            int max = 0;
            foreach (string id in existing)
            {
                if (string.IsNullOrEmpty(id) || id.Length <= prefix.Length)
                {
                    continue;
                }
                int number;
                if (int.TryParse(id.Substring(prefix.Length), NumberStyles.Integer, CultureInfo.InvariantCulture, out number))
                {
                    if (number > max) max = number;
                }
            }
            return prefix + (max + 1).ToString("000", CultureInfo.InvariantCulture);
        }

        public static string NextPatientId() { return NextId("P", Data.Patients.Select(x => x.Id)); }
        public static string NextDoctorId() { return NextId("D", Data.Doctors.Select(x => x.Id)); }
        public static string NextTreatmentId() { return NextId("T", Data.Treatments.Select(x => x.Id)); }
        public static string NextAppointmentId() { return NextId("A", Data.Appointments.Select(x => x.Id)); }

        public static PatientRecord FindPatient(string id)
        {
            return Data.Patients.FirstOrDefault(x => x.Id == id);
        }

        public static DoctorRecord FindDoctor(string id)
        {
            return Data.Doctors.FirstOrDefault(x => x.Id == id);
        }

        public static TreatmentRecord FindTreatment(string id)
        {
            return Data.Treatments.FirstOrDefault(x => x.Id == id);
        }

        public static AppointmentRecord FindAppointment(string id)
        {
            return Data.Appointments.FirstOrDefault(x => x.Id == id);
        }

        public static string PatientName(string id)
        {
            PatientRecord p = FindPatient(id);
            return p == null ? id : p.Name;
        }

        public static string DoctorName(string id)
        {
            DoctorRecord d = FindDoctor(id);
            return d == null ? id : d.Name;
        }

        public static string TreatmentName(string id)
        {
            TreatmentRecord t = FindTreatment(id);
            return t == null ? id : t.Name;
        }

        public static decimal TreatmentPrice(string id)
        {
            TreatmentRecord t = FindTreatment(id);
            return t == null ? 0m : t.Price;
        }

        public static DateTime ParseDate(string value)
        {
            DateTime result;
            if (DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out result))
            {
                return result;
            }
            if (DateTime.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
            return DateTime.Today;
        }

        public static string ToIso(DateTime value)
        {
            return value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public static string DisplayDate(string iso)
        {
            return ParseDate(iso).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        }

        public static string DisplayShortDate(string iso)
        {
            return ParseDate(iso).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public static string DisplayTime(string hhmm)
        {
            DateTime value;
            if (DateTime.TryParseExact(hhmm, "HH:mm", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out value))
            {
                return value.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            }
            return hhmm ?? "";
        }

        public static string ToTimeValue(string display)
        {
            DateTime value;
            if (DateTime.TryParse(display, CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
            {
                return value.ToString("HH:mm", CultureInfo.InvariantCulture);
            }
            return display ?? "";
        }

        public static DateTime AppointmentDateTime(AppointmentRecord a)
        {
            DateTime date = ParseDate(a.Date);
            DateTime time;
            if (DateTime.TryParseExact(a.Time, "HH:mm", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out time))
            {
                return date.AddHours(time.Hour).AddMinutes(time.Minute);
            }
            return date;
        }

        private static ClinicDatabase CreateSeed()
        {
            ClinicDatabase db = new ClinicDatabase();

            AddPatient(db, "P001", "Mahmoud Anwar", "2024-09-02", 34, "Male", "12 Nile Street, Cairo", "Active");
            AddPatient(db, "P002", "Mona Hassan", "2024-09-01", 29, "Female", "8 El Nasr Road, Giza", "Active");
            AddPatient(db, "P003", "Omar Khaled", "2024-08-30", 41, "Male", "25 Makram Ebeid St, Cairo", "Follow-up");
            AddPatient(db, "P004", "Salma Adel", "2024-08-29", 36, "Female", "14 Al Ahram St, Giza", "Active");
            AddPatient(db, "P005", "Youssef Ali", "2024-08-29", 52, "Male", "3 Corniche El Nil, Cairo", "Completed");
            AddPatient(db, "P006", "Nour Ahmed", "2024-08-29", 24, "Female", "19 Abbas El Akkad, Cairo", "Active");
            AddPatient(db, "P007", "Karim Samir", "2024-08-29", 45, "Male", "7 Tahrir St, Giza", "Follow-up");
            AddPatient(db, "P008", "Farah Mohamed", "2024-08-29", 31, "Female", "22 El Merghany St, Cairo", "Active");
            AddPatient(db, "P009", "Hana Mostafa", "2024-08-28", 27, "Female", "5 Gameat El Dowal, Giza", "Completed");
            AddPatient(db, "P010", "Amr Nabil", "2024-08-28", 38, "Male", "31 Mohi El Din Abou El Ezz, Cairo", "Active");
            AddPatient(db, "P011", "Dina Ashraf", "2026-09-03", 22, "Female", "9 El Batal Ahmed Abdel Aziz, Giza", "Active");
            AddPatient(db, "P012", "Tarek Sameh", "2026-09-10", 48, "Male", "16 Sudan St, Cairo", "Follow-up");
            AddPatient(db, "P013", "Rana Fathy", "2026-09-18", 33, "Female", "2 El Thawra St, Cairo", "Active");
            AddPatient(db, "P014", "Laila Emad", "2026-09-25", 40, "Female", "27 Shehab St, Giza", "Completed");
            AddPatient(db, "P015", "Hossam Wael", "2026-10-02", 56, "Male", "11 El Haram St, Giza", "Active");
            AddPatient(db, "P016", "Nadia Ibrahim", "2026-10-08", 30, "Female", "6 Mostafa El Nahas, Cairo", "Active");
            AddPatient(db, "P017", "Mariam Sameh", "2026-10-14", 19, "Female", "18 El Tesaeen St, Cairo", "Follow-up");
            AddPatient(db, "P018", "Ali Mahmoud", "2026-10-21", 12, "Male", "4 El Shorouk St, Cairo", "Active");
            AddPatient(db, "P019", "Sara Khalil", "2026-10-29", 26, "Female", "20 El Rehab St, Cairo", "Active");
            AddPatient(db, "P020", "Ahmed Nabil", "2026-11-03", 44, "Male", "13 El Nozha St, Cairo", "Active");
            AddPatient(db, "P021", "Nourhan Ali", "2026-11-07", 35, "Female", "8 El Salam St, Cairo", "Active");
            AddPatient(db, "P022", "Salma Hassan", "2026-11-10", 28, "Female", "15 El Gaish St, Cairo", "Follow-up");
            AddPatient(db, "P023", "Omar Adel", "2026-11-14", 63, "Male", "1 El Azhar St, Cairo", "Active");
            AddPatient(db, "P024", "Laila Mohamed", "2026-11-18", 9, "Female", "30 El Nasr St, Cairo", "Active");
            AddPatient(db, "P025", "Mariam Adel", "2026-11-20", 51, "Female", "17 El Horreya St, Giza", "Completed");

            AddDoctor(db, "D001", "Ahmed Mohamed", "Orthodontist", "01012345678");
            AddDoctor(db, "D002", "Sara Ali", "Pediatric Dentist", "01123456789");
            AddDoctor(db, "D003", "Omar Hassan", "Oral Surgeon", "01234567890");
            AddDoctor(db, "D004", "Mariam Adel", "Endodontist", "01098765432");
            AddDoctor(db, "D005", "Youssef Sherif", "General Dentist", "01198765432");
            AddDoctor(db, "D006", "Nourhan Ali", "Periodontist", "01298765432");
            AddDoctor(db, "D007", "Mohamed Samir", "Prosthodontist", "01055556666");
            AddDoctor(db, "D008", "Salma Hassan", "Cosmetic Dentist", "01155556666");
            AddDoctor(db, "D009", "Khaled Ibrahim", "Orthodontist", "01255556666");
            AddDoctor(db, "D010", "Laila Mostafa", "General Dentist", "01044445555");
            AddDoctor(db, "D011", "Amr Khalil", "Oral Surgeon", "01144445555");
            AddDoctor(db, "D012", "Hana Mahmoud", "Pediatric Dentist", "01244445555");
            AddDoctor(db, "D013", "Tarek Adel", "Endodontist", "01033334444");
            AddDoctor(db, "D014", "Farah Samy", "Cosmetic Dentist", "01133334444");
            AddDoctor(db, "D015", "Mostafa Nabil", "Periodontist", "01233334444");
            AddDoctor(db, "D016", "Rana Ashraf", "General Dentist", "01022223333");
            AddDoctor(db, "D017", "Hossam Fathy", "Prosthodontist", "01122223333");
            AddDoctor(db, "D018", "Dina Wael", "Orthodontist", "01222223333");
            AddDoctor(db, "D019", "Karim Sameh", "Oral Surgeon", "01011112222");
            AddDoctor(db, "D020", "Nadia Emad", "Pediatric Dentist", "01111112222");

            AddTreatment(db, "T001", "Teeth Cleaning", "Professional dental cleaning", 500m, 30, "Available");
            AddTreatment(db, "T002", "Teeth Whitening", "Whitening and stain removal", 1500m, 60, "Available");
            AddTreatment(db, "T003", "Root Canal", "Root canal treatment", 3000m, 90, "Available");
            AddTreatment(db, "T004", "Dental Filling", "Cavity filling treatment", 800m, 45, "Available");
            AddTreatment(db, "T005", "Tooth Extraction", "Tooth removal procedure", 1200m, 30, "Unavailable");
            AddTreatment(db, "T006", "Braces", "Orthodontic teeth alignment", 12000m, 120, "Available");
            AddTreatment(db, "T007", "Dental Checkup", "General dental examination", 300m, 20, "Available");
            AddTreatment(db, "T008", "Dental Crown", "Dental crown installation", 4000m, 60, "Available");
            AddTreatment(db, "T009", "Gum Treatment", "Treatment for gum inflammation", 1000m, 45, "Available");
            AddTreatment(db, "T010", "Dental Implant", "Replacement of missing tooth", 15000m, 120, "Available");
            AddTreatment(db, "T011", "Fluoride Treatment", "Strengthens tooth enamel", 400m, 20, "Available");
            AddTreatment(db, "T012", "Wisdom Tooth Removal", "Surgical wisdom tooth extraction", 2500m, 60, "Available");
            AddTreatment(db, "T013", "Dental Veneers", "Cosmetic tooth covering", 5000m, 60, "Available");
            AddTreatment(db, "T014", "Pediatric Dentistry", "Dental care for children", 600m, 30, "Available");
            AddTreatment(db, "T015", "Deep Cleaning", "Deep periodontal cleaning", 1800m, 60, "Available");
            AddTreatment(db, "T016", "Dental Bridge", "Replacement of missing teeth", 6500m, 90, "Available");
            AddTreatment(db, "T017", "Night Guard", "Custom protective dental guard", 2000m, 30, "Available");
            AddTreatment(db, "T018", "Emergency Dental Care", "Urgent dental examination", 1000m, 30, "Available");
            AddTreatment(db, "T019", "Orthodontic Consultation", "Braces assessment and consultation", 500m, 30, "Available");
            AddTreatment(db, "T020", "Retainer", "Custom teeth alignment retainer", 1800m, 30, "Available");
            AddTreatment(db, "T021", "Laser Gum Treatment", "Laser treatment for gum problems", 3500m, 60, "Available");
            AddTreatment(db, "T022", "Dental X-Ray", "Dental imaging and diagnosis", 350m, 15, "Available");
            AddTreatment(db, "T023", "Pulp Therapy", "Treatment of damaged dental pulp", 2200m, 60, "Unavailable");
            AddTreatment(db, "T024", "Temporary Filling", "Temporary cavity restoration", 400m, 20, "Available");
            AddTreatment(db, "T025", "Smile Makeover", "Complete cosmetic smile improvement", 20000m, 180, "Available");

            AddAppointment(db, "A001", "P001", "D001", "T001", "2026-11-05", "09:00", "Confirmed");
            AddAppointment(db, "A002", "P002", "D002", "T002", "2026-11-05", "09:30", "Pending");
            AddAppointment(db, "A003", "P003", "D003", "T003", "2026-11-05", "10:00", "Completed");
            AddAppointment(db, "A004", "P004", "D004", "T004", "2026-11-05", "10:30", "Confirmed");
            AddAppointment(db, "A005", "P005", "D005", "T005", "2026-11-05", "11:00", "Cancelled");
            AddAppointment(db, "A006", "P006", "D006", "T007", "2026-11-05", "11:30", "Confirmed");
            AddAppointment(db, "A007", "P007", "D007", "T008", "2026-11-05", "12:00", "Pending");
            AddAppointment(db, "A008", "P008", "D008", "T002", "2026-11-05", "12:30", "Confirmed");
            AddAppointment(db, "A009", "P009", "D009", "T003", "2026-11-05", "13:00", "Completed");
            AddAppointment(db, "A010", "P010", "D010", "T007", "2026-11-05", "13:30", "Confirmed");
            AddAppointment(db, "A011", "P011", "D011", "T012", "2026-11-06", "09:00", "Pending");
            AddAppointment(db, "A012", "P012", "D012", "T014", "2026-11-06", "09:30", "Confirmed");
            AddAppointment(db, "A013", "P013", "D013", "T015", "2026-11-06", "10:00", "Confirmed");
            AddAppointment(db, "A014", "P014", "D014", "T013", "2026-11-06", "10:30", "Cancelled");
            AddAppointment(db, "A015", "P015", "D015", "T020", "2026-11-06", "11:00", "Confirmed");
            AddAppointment(db, "A016", "P016", "D016", "T021", "2026-11-06", "11:30", "Completed");
            AddAppointment(db, "A017", "P017", "D017", "T022", "2026-11-06", "12:00", "Pending");
            AddAppointment(db, "A018", "P018", "D018", "T006", "2026-11-06", "12:30", "Confirmed");
            AddAppointment(db, "A019", "P019", "D019", "T023", "2026-11-06", "13:00", "Confirmed");
            AddAppointment(db, "A020", "P020", "D020", "T025", "2026-11-06", "13:30", "Pending");

            AddAppointment(db, "A021", "P011", "D001", "T001", "2026-09-08", "10:00", "Completed");
            AddAppointment(db, "A022", "P012", "D004", "T004", "2026-09-12", "11:00", "Completed");
            AddAppointment(db, "A023", "P013", "D007", "T008", "2026-09-16", "09:30", "Completed");
            AddAppointment(db, "A024", "P014", "D010", "T007", "2026-09-22", "14:00", "Completed");
            AddAppointment(db, "A025", "P009", "D013", "T015", "2026-09-25", "12:00", "Cancelled");
            AddAppointment(db, "A026", "P010", "D016", "T018", "2026-09-28", "16:00", "Completed");

            AddAppointment(db, "A027", "P015", "D002", "T002", "2026-10-03", "10:30", "Completed");
            AddAppointment(db, "A028", "P016", "D005", "T005", "2026-10-07", "09:00", "Completed");
            AddAppointment(db, "A029", "P017", "D008", "T013", "2026-10-10", "13:00", "Completed");
            AddAppointment(db, "A030", "P018", "D011", "T014", "2026-10-15", "11:30", "Completed");
            AddAppointment(db, "A031", "P019", "D014", "T019", "2026-10-20", "15:00", "Completed");
            AddAppointment(db, "A032", "P020", "D017", "T017", "2026-10-23", "10:00", "Cancelled");
            AddAppointment(db, "A033", "P021", "D019", "T009", "2026-10-27", "12:30", "Completed");
            AddAppointment(db, "A034", "P022", "D020", "T011", "2026-10-30", "14:30", "Completed");

            return db;
        }

        private static void AddPatient(ClinicDatabase db, string id, string name, string date,
            int age, string gender, string address, string status)
        {
            db.Patients.Add(new PatientRecord
            {
                Id = id, Name = name, RegistrationDate = date, Age = age,
                Gender = gender, Address = address, Status = status
            });
        }

        private static void AddDoctor(ClinicDatabase db, string id, string name, string spec, string phone)
        {
            db.Doctors.Add(new DoctorRecord { Id = id, Name = name, Specialization = spec, Phone = phone });
        }

        private static void AddTreatment(ClinicDatabase db, string id, string name, string description,
            decimal price, int duration, string status)
        {
            db.Treatments.Add(new TreatmentRecord
            {
                Id = id, Name = name, Description = description, Price = price,
                DurationMinutes = duration, Status = status
            });
        }

        private static void AddAppointment(ClinicDatabase db, string id, string patientId, string doctorId,
            string treatmentId, string date, string time, string status)
        {
            db.Appointments.Add(new AppointmentRecord
            {
                Id = id, PatientId = patientId, DoctorId = doctorId, TreatmentId = treatmentId,
                Date = date, Time = time, Status = status
            });
        }
    }
}
