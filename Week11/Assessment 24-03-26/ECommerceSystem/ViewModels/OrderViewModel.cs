namespace ECommerceSystem.ViewModels;

public class OrderViewModel
{
    public int CustomerId { get; set; }
    public List<OrderItemVM>? Items { get; set; }
    public string? Address { get; set; }
}

public class OrderItemVM
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}