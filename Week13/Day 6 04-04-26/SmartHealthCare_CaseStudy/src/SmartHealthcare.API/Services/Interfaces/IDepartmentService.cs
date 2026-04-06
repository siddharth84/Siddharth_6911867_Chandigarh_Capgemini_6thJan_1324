using SmartHealthcare.Models.DTOs;

namespace SmartHealthcare.API.Services.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();
    Task<DepartmentDTO?> GetDepartmentByIdAsync(int id);
    Task<DepartmentDTO> CreateDepartmentAsync(CreateDepartmentDTO dto);
    Task<bool> UpdateDepartmentAsync(int id, CreateDepartmentDTO dto);
    Task<bool> DeleteDepartmentAsync(int id);
}
