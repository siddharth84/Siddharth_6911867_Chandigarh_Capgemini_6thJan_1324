using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthcareManagementSystem.Core.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int ExperienceYears { get; set; }
        public string Qualifications { get; set; }
        public decimal ConsultationFee { get; set; }
        
        // Example: List of specialization names or another nested DTO
        public List<string> Specializations { get; set; } 
    }

    public class CreateDoctorDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        public int ExperienceYears { get; set; }
        
        [Required]
        public string Qualifications { get; set; }
        
        public decimal ConsultationFee { get; set; }

        public List<int> SpecializationIds { get; set; }
    }
}
