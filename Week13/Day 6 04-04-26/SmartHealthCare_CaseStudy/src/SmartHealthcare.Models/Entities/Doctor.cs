using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthcare.Models.Entities;

public class Doctor
{
    [Key]
    public int DoctorId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    [StringLength(100)]
    public string Specialization { get; set; } = string.Empty;

    public int ExperienceYears { get; set; }

    [StringLength(100)]
    public string Availability { get; set; } = string.Empty;

    [StringLength(20)]
    public string Phone { get; set; } = string.Empty;

    [Column(TypeName = "decimal(10,2)")]
    public decimal ConsultationFee { get; set; }

    [StringLength(50)]
    public string LicenseNumber { get; set; } = string.Empty;

    public bool IsAvailable { get; set; } = true;

    // Navigation properties
    [ForeignKey("UserId")]
    public User? User { get; set; }

    [ForeignKey("DepartmentId")]
    public Department? Department { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
