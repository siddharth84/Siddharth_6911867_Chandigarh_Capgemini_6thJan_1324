using System.Collections.Generic;

namespace HealthcareManagementSystem.Core.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string FullName { get; set; }
        public int ExperienceYears { get; set; }
        public string Qualifications { get; set; }
        public decimal ConsultationFee { get; set; }

        public User User { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<DoctorSpecialization> DoctorSpecializations { get; set; }
    }
}
