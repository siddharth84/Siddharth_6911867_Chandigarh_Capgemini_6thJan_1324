using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthcareManagementSystem.Core.DTOs
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Notes { get; set; }
        public List<MedicineDTO> Medicines { get; set; }
    }

    public class CreatePrescriptionDTO
    {
        [Required]
        public int AppointmentId { get; set; }
        public string Notes { get; set; }
        public List<int> MedicineIds { get; set; }
    }
}
