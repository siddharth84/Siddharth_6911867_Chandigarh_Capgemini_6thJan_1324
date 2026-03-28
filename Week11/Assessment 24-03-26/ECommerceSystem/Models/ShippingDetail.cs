namespace ECommerceSystem.Models;

using System.ComponentModel.DataAnnotations;

public class ShippingDetail
{
    public int ShippingDetailId { get; set; }

    [Required]
    public string? Address { get; set; }

    public string? Status { get; set; }

    public int OrderId { get; set; }
    public Order? Order { get; set; }
}