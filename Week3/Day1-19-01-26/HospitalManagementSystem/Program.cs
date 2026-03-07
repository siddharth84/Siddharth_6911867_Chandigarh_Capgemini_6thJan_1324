using System;
using System.Collections.Generic;

namespace HospitalManagementSystem
{
    public abstract class Person
    {
        public string ID { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string id, string name, int age)
        {
            ID = id;
            Name = name;
            Age = age;
        }

        public abstract void DisplayInfo();
    }

    public class Doctor : Person
    {
        public string Specialization { get; set; }

        public Doctor(string id, string name, int age, string spec) : base(id, name, age)
        {
            Specialization = spec;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Doctor] {Name} | ID: {ID} | Specialty: {Specialization}");
        }
    }

    public class Patient : Person
    {
        private List<string> medicalHistory = new List<string>();

        public Patient(string id, string name, int age) : base(id, name, age) { }

        public void AddHistory(string record)
        {
            string timestampedRecord = $"{DateTime.Now:yyyy-MM-dd}: {record}";
            medicalHistory.Add(timestampedRecord);
        }

        public void ViewMedicalHistory()
        {
            Console.WriteLine($"\n--- Medical History for {Name} ---");
            if (medicalHistory.Count == 0) Console.WriteLine("No records found.");
            else medicalHistory.ForEach(Console.WriteLine);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Patient] {Name} | ID: {ID} | Age: {Age}");
        }
    }

    public class Appointment
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }

        public Appointment(Patient patient, Doctor doctor, DateTime date, string reason)
        {
            Patient = patient;
            Doctor = doctor;
            AppointmentDate = date;
            Reason = reason;
        }

        public void ShowAppointmentDetails()
        {
            Console.WriteLine($"Appointment: {Patient.Name} with Dr. {Doctor.Name} on {AppointmentDate:f}");
            Console.WriteLine($"Reason: {Reason}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Doctor drHouse = new Doctor("D001", "Gregory House", 50, "Diagnostic Medicine");
            Patient p1 = new Patient("P505", "John Doe", 35);

            p1.AddHistory("Diagnosed with seasonal allergies.");
            p1.AddHistory("Prescribed Claritin.");

            Appointment appt = new Appointment(p1, drHouse, DateTime.Now.AddDays(2), "Persistent cough and fatigue");

            Console.WriteLine("--- Hospital Record System ---");
            drHouse.DisplayInfo();
            p1.DisplayInfo();

            Console.WriteLine("\n--- Scheduled Appointment ---");
            appt.ShowAppointmentDetails();

            p1.ViewMedicalHistory();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
