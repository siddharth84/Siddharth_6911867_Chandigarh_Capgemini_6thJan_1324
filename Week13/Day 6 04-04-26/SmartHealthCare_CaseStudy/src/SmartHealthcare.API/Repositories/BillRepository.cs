using Microsoft.EntityFrameworkCore;
using SmartHealthcare.API.Data;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Repositories;

public class BillRepository : GenericRepository<Bill>, IBillRepository
{
    public BillRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Bill?> GetBillByAppointmentAsync(int appointmentId)
    {
        return await _context.Bills
            .Include(b => b.Appointment)
            .FirstOrDefaultAsync(b => b.AppointmentId == appointmentId);
    }
}
