namespace ECommerceSystem.Models;

using System.ComponentModel.DataAnnotations;

public class Customer
{
    public int CustomerId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Email { get; set; }

    public ICollection<Order>? Orders { get; set; }
}