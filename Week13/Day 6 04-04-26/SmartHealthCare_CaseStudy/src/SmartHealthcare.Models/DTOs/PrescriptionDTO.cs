namespace SmartHealthcare.Models.DTOs;

public class PrescriptionDTO
{
    public int PrescriptionId { get; set; }
    public int AppointmentId { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public List<MedicineDTO> Medicines { get; set; } = new();
    public string Notes { get; set; } = string.Empty;
}

public class CreatePrescriptionDTO
{
    public int AppointmentId { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public List<CreateMedicineDTO> Medicines { get; set; } = new();
    public string Notes { get; set; } = string.Empty;
}
