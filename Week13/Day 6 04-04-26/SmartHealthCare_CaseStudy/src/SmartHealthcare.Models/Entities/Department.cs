using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Models.Entities;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }

    [Required]
    [StringLength(100)]
    public string DepartmentName { get; set; } = string.Empty;

    [StringLength(255)]
    public string Description { get; set; } = string.Empty;

    // Navigation property
    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
