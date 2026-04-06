using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthcare.Models.Entities;

public class Appointment
{
    [Key]
    public int AppointmentId { get; set; }

    [Required]
    public int PatientId { get; set; }

    [Required]
    public int DoctorId { get; set; }

    [Required]
    public DateTime AppointmentDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = "Booked"; // 'Booked','Completed','Cancelled'

    public string Notes { get; set; } = string.Empty;

    // Navigation properties
    [ForeignKey("PatientId")]
    public Patient? Patient { get; set; }

    [ForeignKey("DoctorId")]
    public Doctor? Doctor { get; set; }

    public Prescription? Prescription { get; set; }
    public Bill? Bill { get; set; }
}
