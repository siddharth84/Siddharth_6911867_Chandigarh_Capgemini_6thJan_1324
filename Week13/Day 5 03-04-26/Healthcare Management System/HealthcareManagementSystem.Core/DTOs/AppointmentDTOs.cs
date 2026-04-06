using System;
using System.ComponentModel.DataAnnotations;

namespace HealthcareManagementSystem.Core.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }

    public class CreateAppointmentDTO
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public string Remarks { get; set; }
    }

    public class UpdateAppointmentStatusDTO
    {
        [Required]
        public string Status { get; set; }
    }
}
