using Microsoft.EntityFrameworkCore;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // Database First (Conceptual mapping)
    public DbSet<User> Users => Set<User>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    // Code First New Modules
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<Prescription> Prescriptions => Set<Prescription>();
    public DbSet<Medicine> Medicines => Set<Medicine>();
    public DbSet<Bill> Bills => Set<Bill>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Map relationships and constraints
        
        // 1. Roles Constraint
        modelBuilder.Entity<User>()
            .ToTable(t => t.HasCheckConstraint("CHK_Role", "Role IN ('Admin', 'Doctor', 'Patient')"));
            
        // 2. Doctor <-> User One-to-One
        modelBuilder.Entity<Doctor>()
            .HasOne(d => d.User)
            .WithOne(u => u.Doctor)
            .HasForeignKey<Doctor>(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // 3. Department <-> Doctor One-to-Many
        modelBuilder.Entity<Doctor>()
            .HasOne(d => d.Department)
            .WithMany(dept => dept.Doctors)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // 4. Patient <-> User One-to-One
        modelBuilder.Entity<Patient>()
            .HasOne(p => p.User)
            .WithOne()
            .HasForeignKey<Patient>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // 5. Appointment <-> Doctor/Patient One-to-Many
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);
            
        modelBuilder.Entity<Appointment>()
            .ToTable(t => t.HasCheckConstraint("CHK_Appointment_Status", "Status IN ('Booked', 'Completed', 'Cancelled')"));

        // 5. Prescription <-> Appointment One-to-One
        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Appointment)
            .WithOne(a => a.Prescription)
            .HasForeignKey<Prescription>(p => p.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);

        // 5b. Medicine <-> Prescription One-to-Many
        modelBuilder.Entity<Medicine>()
            .HasOne(m => m.Prescription)
            .WithMany(p => p.Medicines)
            .HasForeignKey(m => m.PrescriptionId)
            .OnDelete(DeleteBehavior.Cascade);

        // 6. Bill <-> Appointment One-to-One
        modelBuilder.Entity<Bill>()
            .HasOne(b => b.Appointment)
            .WithOne(a => a.Bill)
            .HasForeignKey<Bill>(b => b.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);
            
        modelBuilder.Entity<Bill>()
            .Property(b => b.TotalAmount)
            .HasComputedColumnSql("[ConsultationFee] + [MedicineCharges]");
            
        modelBuilder.Entity<Bill>()
            .ToTable(t => t.HasCheckConstraint("CHK_PaymentStatus", "PaymentStatus IN ('Paid', 'Unpaid')"));

        // Seed Default Admin User
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                FullName = "System Admin",
                Email = "admin@healthcare.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                Role = "Admin",
                CreatedAt = DateTime.UtcNow
            }
        );

        // Seed Departments (Required for the Database First scenario)
        modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentId = 1, DepartmentName = "Cardiology", Description = "Heart Specialist" },
            new Department { DepartmentId = 2, DepartmentName = "Neurology", Description = "Brain and Nerves" },
            new Department { DepartmentId = 3, DepartmentName = "Orthopedics", Description = "Bones and Muscles" },
            new Department { DepartmentId = 4, DepartmentName = "Pediatrics", Description = "Children Specialist" }
        );
    }
}
