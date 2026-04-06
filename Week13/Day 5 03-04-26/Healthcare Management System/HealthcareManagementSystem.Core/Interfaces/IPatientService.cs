using System.Collections.Generic;
using System.Threading.Tasks;
using HealthcareManagementSystem.Core.DTOs;

namespace HealthcareManagementSystem.Core.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDTO>> GetAllPatientsAsync();
        Task<PatientDTO> GetPatientByIdAsync(int id);
        Task<PatientDTO> CreatePatientAsync(CreatePatientDTO patientDto);
        Task<bool> UpdatePatientAsync(int id, CreatePatientDTO patientDto);
        Task<bool> DeletePatientAsync(int id);
    }
}
