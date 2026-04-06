using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [Authorize(Roles = "User")]
    [HttpPost]
    public async Task<IActionResult> Create(OrderDto dto)
    {
        var order = new Order
        {
            UserId = dto.UserId
        };

        await _service.PlaceOrder(order);

        return Ok("Order Created");
    }
}