using OrderApi.Models;

namespace OrderApi.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task PlaceOrderAsync(Order order);
    }
}
