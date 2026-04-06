using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthcare.Models.Entities;

public class Prescription
{
    [Key]
    public int PrescriptionId { get; set; }

    [Required]
    public int AppointmentId { get; set; }

    [StringLength(255)]
    public string Diagnosis { get; set; } = string.Empty;

    [StringLength(255)]
    public string Notes { get; set; } = string.Empty;

    // Navigation property
    [ForeignKey("AppointmentId")]
    public Appointment? Appointment { get; set; }

    public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}
