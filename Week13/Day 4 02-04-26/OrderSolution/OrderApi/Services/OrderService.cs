using OrderApi.Models;
using OrderApi.Repositories;

namespace OrderApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task PlaceOrderAsync(Order order)
        {
            // Business rule: server always sets the date, never trust the client
            order.OrderDate = DateTime.UtcNow;
            order.Status = "Pending";
            await _repo.AddAsync(order);
        }
    }
}
