namespace ECommerceSystem.Models;

using System.ComponentModel.DataAnnotations;

public class Product
{
    public int ProductId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Range(0.01, 100000)]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<OrderItem>? OrderItems { get; set; }
}