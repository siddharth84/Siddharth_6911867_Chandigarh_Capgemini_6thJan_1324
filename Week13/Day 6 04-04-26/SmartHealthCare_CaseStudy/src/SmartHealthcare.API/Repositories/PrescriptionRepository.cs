using Microsoft.EntityFrameworkCore;
using SmartHealthcare.API.Data;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Repositories;

public class PrescriptionRepository : GenericRepository<Prescription>, IPrescriptionRepository
{
    public PrescriptionRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Prescription?> GetByAppointmentIdAsync(int appointmentId)
        => await _dbSet.FirstOrDefaultAsync(p => p.AppointmentId == appointmentId);

    // Unused, but keep interface consistent
    public async Task<Prescription?> GetWithMedicinesAsync(int id)
        => await _dbSet.FirstOrDefaultAsync(p => p.PrescriptionId == id);
}
