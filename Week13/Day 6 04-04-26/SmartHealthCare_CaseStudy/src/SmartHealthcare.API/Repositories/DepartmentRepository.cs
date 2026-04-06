using Microsoft.EntityFrameworkCore;
using SmartHealthcare.API.Data;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Repositories;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Department?> GetDepartmentWithDoctorsAsync(int id)
    {
        return await _context.Departments
            .Include(d => d.Doctors)
            .FirstOrDefaultAsync(d => d.DepartmentId == id);
    }
}
