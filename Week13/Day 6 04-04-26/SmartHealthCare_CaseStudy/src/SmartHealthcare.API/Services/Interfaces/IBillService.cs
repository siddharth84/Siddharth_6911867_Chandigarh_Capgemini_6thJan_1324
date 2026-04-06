using SmartHealthcare.Models.DTOs;

namespace SmartHealthcare.API.Services.Interfaces;

public interface IBillService
{
    Task<BillDTO?> GetBillByAppointmentAsync(int appointmentId);
    Task<BillDTO> CreateBillAsync(CreateBillDTO dto);
    Task<bool> UpdateBillStatusAsync(int id, UpdateBillStatusDTO dto);
}
