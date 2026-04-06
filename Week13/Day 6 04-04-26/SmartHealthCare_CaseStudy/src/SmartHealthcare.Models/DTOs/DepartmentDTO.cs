namespace SmartHealthcare.Models.DTOs;

public class DepartmentDTO
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class CreateDepartmentDTO
{
    public string DepartmentName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
