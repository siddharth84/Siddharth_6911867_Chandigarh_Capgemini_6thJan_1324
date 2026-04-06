using Microsoft.EntityFrameworkCore;
using SmartHealthcare.API.Data;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Repositories;

public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Doctor?> GetByUserIdAsync(int userId)
        => await _dbSet.Include(d => d.User)
                       .Include(d => d.Department)
                       .FirstOrDefaultAsync(d => d.UserId == userId);

    public async Task<Doctor?> GetWithDetailsAsync(int id)
        => await _dbSet.Include(d => d.User)
                       .Include(d => d.Department)
                       .FirstOrDefaultAsync(d => d.DoctorId == id);

    public async Task<IEnumerable<Doctor>> GetAllWithDetailsAsync(int page, int pageSize)
        => await _dbSet.Include(d => d.User)
                       .Include(d => d.Department)
                       .OrderBy(d => d.DoctorId)
                       .Skip((page - 1) * pageSize)
                       .Take(pageSize)
                       .ToListAsync();

    public async Task<IEnumerable<Doctor>> SearchBySpecializationAsync(string specialization, int page, int pageSize)
        => await _dbSet.Include(d => d.User)
                       .Include(d => d.Department!)
                       .Where(d => d.Specialization.Contains(specialization) || d.Department!.DepartmentName.Contains(specialization))
                       .OrderBy(d => d.DoctorId)
                       .Skip((page - 1) * pageSize)
                       .Take(pageSize)
                       .ToListAsync();

    public async Task<int> CountBySpecializationAsync(string specialization)
        => await _dbSet.CountAsync(d => d.Specialization.Contains(specialization) || d.Department!.DepartmentName.Contains(specialization));
}
