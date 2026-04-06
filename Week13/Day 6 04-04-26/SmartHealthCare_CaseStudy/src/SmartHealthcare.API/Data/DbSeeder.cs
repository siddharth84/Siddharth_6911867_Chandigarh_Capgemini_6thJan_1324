using Microsoft.EntityFrameworkCore;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext db)
    {
        await db.Database.MigrateAsync();

        if (!await db.Users.AnyAsync(u => u.Role == "Doctor"))
        {
            await SeedDoctorsAsync(db);
        }

        if (!await db.Users.AnyAsync(u => u.Role == "Patient"))
        {
            await SeedPatientsAsync(db);
        }
    }

    private static async Task SeedDoctorsAsync(ApplicationDbContext db)
    {
        var doctorUsers = new List<User>
        {
            new User { FullName = "Dr. Aarav Mehta", Email = "doctor1@healthcare.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Doctor@123"), Role = "Doctor", CreatedAt = DateTime.UtcNow },
            new User { FullName = "Dr. Neha Iyer", Email = "doctor2@healthcare.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Doctor@123"), Role = "Doctor", CreatedAt = DateTime.UtcNow }
        };

        await db.Users.AddRangeAsync(doctorUsers);
        await db.SaveChangesAsync();

        var doctors = new List<Doctor>
        {
            new Doctor { UserId = doctorUsers[0].UserId, DepartmentId = 1, Specialization = "Cardiac Surgeon", ExperienceYears = 9, Availability = "9AM-5PM" },
            new Doctor { UserId = doctorUsers[1].UserId, DepartmentId = 2, Specialization = "Neuro Physician", ExperienceYears = 6, Availability = "10AM-6PM" }
        };

        await db.Doctors.AddRangeAsync(doctors);
        await db.SaveChangesAsync();
    }

    private static async Task SeedPatientsAsync(ApplicationDbContext db)
    {
        var patientUsers = new List<User>
        {
            new User { FullName = "Raj Patel", Email = "patient1@healthcare.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Patient@123"), Role = "Patient", CreatedAt = DateTime.UtcNow },
            new User { FullName = "Anjali Verma", Email = "patient2@healthcare.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Patient@123"), Role = "Patient", CreatedAt = DateTime.UtcNow }
        };

        await db.Users.AddRangeAsync(patientUsers);
        await db.SaveChangesAsync();
    }
}