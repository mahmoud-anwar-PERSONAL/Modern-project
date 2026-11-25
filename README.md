Dental Clinic Management System — Combined Solution
====================================================

A Windows Forms application for managing patients, doctors, appointments and
treatments, with a shared local data store and a GDI+ dashboard chart.

Projects (all .NET Framework 4.7.2)
-----------------------------------
1) LoginDashboard  — LoginForm, DashboardForm, ReportsForm (startup project)
2) Patients       — MainForm (Patients page)
3) Appointments   — AppointmentsForm
4) Doctors        — DoctorsForm
5) Treatments     — TreatmentForm

Shared code
-----------
The Shared folder holds source files linked into every project (same code,
compiled into each assembly):

- ClinicData.cs       Data models + ClinicStore persistence, validation and helpers
- UiTheme.cs          Colors, fonts, grid/textbox/button styling, placeholders
- BarChartPanel.cs    GDI+ bar chart control (anti-aliased, rounded gradient bars)
- RecordEditorForm.cs Reusable validated Add/Edit dialog

How to open and run
-------------------
1. Open DentalClinic_Combined.sln in Visual Studio 2022.
2. Set LoginDashboard as the startup project.
3. Build (Debug or Release) and run.

Credentials
-----------
Username: admin
Password: admin123

Data storage
------------
Data is stored in one central file shared by every module:

  %LOCALAPPDATA%\DentalClinicMS\clinic-data.txt

- It is created automatically with realistic sample data on first run.
- Every Add/Edit/Delete saves immediately; modules reload the file whenever
  they become visible, so all pages stay consistent.
- If the file is unreadable, it is copied aside as
  clinic-data.corrupt-yyyyMMddHHmmss.txt and fresh sample data is created.
- Back up that file before replacing the application or moving machines.

Features
--------
- Login validation with inline error messages and show/hide password.
- Dashboard: live clock updating every second, correct date, real counts,
  GDI+ appointments-by-status chart, upcoming appointments, quick actions.
- Patients: ID, Name, Registration Date, Age, Gender, Address, Status;
  add/edit/delete, search by patient ID or name, clear filter, count label.
- Doctors: add/edit/delete, search by name/specialization/phone, name filter
  dropdown, clear filter.
- Appointments: add/edit/delete, search by patient ID, doctor name or date;
  patient/doctor/treatment dropdowns, date/time slots, double-booking
  prevention and past-date validation for new appointments.
- Treatments: add/edit/delete, search by treatment name, clear filter,
  price/duration/status validation.
- Reports: date-range and doctor filters, filtered patients/appointments/
  treatments-used/revenue totals, monthly summary computed from real data.
- Relationship safety: patients, doctors and treatments that are referenced by
  appointments cannot be deleted until those appointments are handled.

Notes and limitations
---------------------
- Single-user local storage (a text file), not a database server.
- Appointment times use 30-minute slots from 09:00 to 16:30.
- Revenue counts appointments marked Completed only.
- Each module project still has its own Program.cs and can run standalone;
  the dashboard hosts them as child windows for unified navigation.

Build
-----
Debug and Release configurations both compile the whole solution:

  MSBuild DentalClinic_Combined.sln /t:Build /p:Configuration=Debug
  MSBuild DentalClinic_Combined.sln /t:Build /p:Configuration=Release
