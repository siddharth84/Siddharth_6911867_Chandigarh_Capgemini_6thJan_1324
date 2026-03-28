namespace ECommerceSystem.Models;

public class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public ICollection<OrderItem>? OrderItems { get; set; }

    public ShippingDetail? ShippingDetail { get; set; }
}