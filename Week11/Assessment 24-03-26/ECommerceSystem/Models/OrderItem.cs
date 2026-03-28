namespace ECommerceSystem.Models;

using System.ComponentModel.DataAnnotations;

public class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    [Range(1, 100)]
    public int Quantity { get; set; }
}