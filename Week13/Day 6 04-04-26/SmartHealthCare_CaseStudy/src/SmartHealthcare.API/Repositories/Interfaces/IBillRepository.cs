using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Repositories.Interfaces;

public interface IBillRepository : IGenericRepository<Bill>
{
    Task<Bill?> GetBillByAppointmentAsync(int appointmentId);
}
