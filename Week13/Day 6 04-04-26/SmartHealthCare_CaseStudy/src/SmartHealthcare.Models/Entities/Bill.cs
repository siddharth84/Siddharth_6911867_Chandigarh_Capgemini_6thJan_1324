using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthcare.Models.Entities;

public class Bill
{
    [Key]
    public int BillId { get; set; }

    [Required]
    public int AppointmentId { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal ConsultationFee { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal MedicineCharges { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalAmount { get; private set; } // Will be mapped as computed in DbContext

    [StringLength(20)]
    public string PaymentStatus { get; set; } = "Unpaid"; // 'Paid','Unpaid'

    // Navigation property
    [ForeignKey("AppointmentId")]
    public Appointment? Appointment { get; set; }
}
