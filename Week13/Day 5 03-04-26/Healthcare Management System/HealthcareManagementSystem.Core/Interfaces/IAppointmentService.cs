using System.Collections.Generic;
using System.Threading.Tasks;
using HealthcareManagementSystem.Core.DTOs;

namespace HealthcareManagementSystem.Core.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsAsync();
        Task<AppointmentDTO> GetAppointmentByIdAsync(int id);
        Task<AppointmentDTO> CreateAppointmentAsync(CreateAppointmentDTO appointmentDto);
        Task<bool> UpdateAppointmentStatusAsync(int id, UpdateAppointmentStatusDTO statusDto);
        Task<bool> DeleteAppointmentAsync(int id);
    }
}
