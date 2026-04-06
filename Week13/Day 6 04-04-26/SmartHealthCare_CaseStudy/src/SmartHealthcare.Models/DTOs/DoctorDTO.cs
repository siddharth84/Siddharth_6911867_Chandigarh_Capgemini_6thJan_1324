namespace SmartHealthcare.Models.DTOs;

public class DoctorDTO
{
    public int Id { get; set; } // Alias for DoctorId
    public int DoctorId { get; set; }
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public List<string> Specializations { get; set; } = new();
    public int ExperienceYears { get; set; }
    public int YearsOfExperience { get; set; } // Alias
    public string Availability { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public string Phone { get; set; } = string.Empty;
    public decimal ConsultationFee { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
}

public class CreateDoctorDTO
{
    public int UserId { get; set; }
    public int DepartmentId { get; set; }
    public string Specialization { get; set; } = string.Empty;
    public int ExperienceYears { get; set; }
    public int YearsOfExperience { get; set; }
    public string Availability { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public string Phone { get; set; } = string.Empty;
    public decimal ConsultationFee { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public List<int> SpecializationIds { get; set; } = new();
}

public class UpdateDoctorDTO
{
    public int DepartmentId { get; set; }
    public string Specialization { get; set; } = string.Empty;
    public int ExperienceYears { get; set; }
    public int YearsOfExperience { get; set; }
    public string Availability { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public string Phone { get; set; } = string.Empty;
    public decimal ConsultationFee { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public List<int> SpecializationIds { get; set; } = new();
}
