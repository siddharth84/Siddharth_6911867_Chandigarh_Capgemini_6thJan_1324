using System;

namespace HealthcareManagementSystem.Core.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } // Pending, Approved, Completed, Cancelled
        public string Remarks { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        public Prescription Prescription { get; set; }
    }
}
