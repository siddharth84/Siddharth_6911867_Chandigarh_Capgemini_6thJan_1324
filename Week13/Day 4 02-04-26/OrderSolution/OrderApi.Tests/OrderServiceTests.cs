using Moq;
using OrderApi.Models;
using OrderApi.Repositories;
using OrderApi.Services;

namespace OrderApi.Tests
{
    // ─────────────────────────────────────────────────────────
    // These tests verify OrderService WITHOUT touching a real DB
    // Moq creates a fake IOrderRepository so we test logic only
    // ─────────────────────────────────────────────────────────
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _repoMock;
        private readonly OrderService _service;

        public OrderServiceTests()
        {
            _repoMock = new Mock<IOrderRepository>();
            _service  = new OrderService(_repoMock.Object);
        }

        [Fact]
        public async Task PlaceOrder_ShouldSetOrderDateToNow()
        {
            // Arrange
            var order = new Order { UserId = 1 };
            var before = DateTime.UtcNow;

            // Act
            await _service.PlaceOrderAsync(order);

            // Assert
            Assert.True(order.OrderDate >= before);
        }

        [Fact]
        public async Task PlaceOrder_ShouldSetStatusToPending()
        {
            var order = new Order { UserId = 1 };

            await _service.PlaceOrderAsync(order);

            Assert.Equal("Pending", order.Status);
        }

        [Fact]
        public async Task PlaceOrder_ShouldCallRepositoryExactlyOnce()
        {
            var order = new Order { UserId = 1 };

            await _service.PlaceOrderAsync(order);

            // Verify our service actually called the repo
            _repoMock.Verify(r => r.AddAsync(order), Times.Once);
        }

        [Fact]
        public async Task GetAllOrders_ShouldReturnOrdersFromRepository()
        {
            // Arrange: fake repo returns two orders
            var fakeOrders = new List<Order>
            {
                new Order { Id = 1, UserId = 1, Status = "Pending" },
                new Order { Id = 2, UserId = 2, Status = "Pending" }
            };
            _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(fakeOrders);

            // Act
            var result = await _service.GetAllOrdersAsync();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetOrderById_WhenNotFound_ShouldReturnNull()
        {
            _repoMock.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Order?)null);

            var result = await _service.GetOrderByIdAsync(999);

            Assert.Null(result);
        }
    }
}
