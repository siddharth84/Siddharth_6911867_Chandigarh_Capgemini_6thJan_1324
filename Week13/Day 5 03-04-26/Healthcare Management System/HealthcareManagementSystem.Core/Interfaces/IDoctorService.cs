using System.Collections.Generic;
using System.Threading.Tasks;
using HealthcareManagementSystem.Core.DTOs;

namespace HealthcareManagementSystem.Core.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync();
        Task<DoctorDTO> GetDoctorByIdAsync(int id);
        Task<DoctorDTO> CreateDoctorAsync(CreateDoctorDTO doctorDto);
        Task<bool> UpdateDoctorAsync(int id, CreateDoctorDTO doctorDto);
        Task<bool> DeleteDoctorAsync(int id);
    }
}
