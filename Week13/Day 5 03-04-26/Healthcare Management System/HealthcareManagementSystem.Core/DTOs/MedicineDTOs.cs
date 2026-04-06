using System.ComponentModel.DataAnnotations;

namespace HealthcareManagementSystem.Core.DTOs
{
    public class MedicineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
    }

    public class CreateMedicineDTO
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Dosage { get; set; }
    }
}
