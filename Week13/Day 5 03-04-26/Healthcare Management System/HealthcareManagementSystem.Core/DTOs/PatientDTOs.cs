using System;
using System.ComponentModel.DataAnnotations;

namespace HealthcareManagementSystem.Core.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }

    public class CreatePatientDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, Phone]
        public string ContactNumber { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
