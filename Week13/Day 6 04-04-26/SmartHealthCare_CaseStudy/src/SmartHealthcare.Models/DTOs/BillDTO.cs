namespace SmartHealthcare.Models.DTOs;

public class BillDTO
{
    public int BillId { get; set; }
    public int AppointmentId { get; set; }
    public decimal ConsultationFee { get; set; }
    public decimal MedicineCharges { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentStatus { get; set; } = string.Empty;
}

public class CreateBillDTO
{
    public int AppointmentId { get; set; }
    public decimal ConsultationFee { get; set; }
    public decimal MedicineCharges { get; set; }
    public string PaymentStatus { get; set; } = "Unpaid";
}

public class UpdateBillStatusDTO
{
    public string PaymentStatus { get; set; } = "Paid";
}
