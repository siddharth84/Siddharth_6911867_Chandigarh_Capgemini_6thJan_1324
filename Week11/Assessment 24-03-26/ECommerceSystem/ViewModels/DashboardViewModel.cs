namespace ECommerceSystem.ViewModels;

using ECommerceSystem.Models;

public class DashboardViewModel
{
    public List<TopProductVM> TopProducts { get; set; }
    public List<ShippingDetail> PendingOrders { get; set; }
}

public class TopProductVM
{
    public string ProductName { get; set; }
    public int QuantitySold { get; set; }
}