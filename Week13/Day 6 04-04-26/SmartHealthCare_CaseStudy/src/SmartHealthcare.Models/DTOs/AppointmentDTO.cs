using System;

namespace SmartHealthcare.Models.DTOs;

public class AppointmentDTO
{
    public int Id { get; set; } // Alias for AppointmentId
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; } = string.Empty;
    public int DoctorId { get; set; }
    public string DoctorName { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public bool HasPrescription { get; set; }
    public bool HasBill { get; set; }
    public PrescriptionDTO? Prescription { get; set; }
    public BillDTO? Bill { get; set; }
}

public class CreateAppointmentDTO
{
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Notes { get; set; } = string.Empty;
}

public class UpdateAppointmentStatusDTO
{
    public string Status { get; set; } = string.Empty;
}
