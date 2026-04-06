using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Models;
using OrderApi.Services;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper  = mapper;
        }

        /// <summary>
        /// Get all orders. Requires login (any role).
        /// </summary>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAllOrdersAsync();
            var result = _mapper.Map<List<OrderResponseDto>>(orders);
            return Ok(result);
        }

        /// <summary>
        /// Get one order by ID. Requires login (any role).
        /// </summary>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.GetOrderByIdAsync(id);
            if (order is null)
                return NotFound(new { message = $"Order with id {id} not found." });

            return Ok(_mapper.Map<OrderResponseDto>(order));
        }

        /// <summary>
        /// Place a new order. Only role = "User" can do this.
        /// Body: { "userId": 1 }
        /// </summary>
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            await _service.PlaceOrderAsync(order);

            return Ok(new { message = "Order placed successfully!", orderId = order.Id });
        }
    }
}
