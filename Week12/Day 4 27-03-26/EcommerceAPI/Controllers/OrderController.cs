using Microsoft.AspNetCore.Mvc;
using log4net;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(OrderController));

        [HttpPost]
        public IActionResult CreateOrder(int userId)
        {
            try
            {
                log.Info($"Order started for user {userId}");

                if (userId <= 0)
                {
                    log.Warn("Invalid user ID");
                    return BadRequest();
                }

                // Simulate order logic
                log.Info("Order created successfully");

                return Ok("Order placed");
            }
            catch (Exception ex)
            {
                log.Error("Order creation failed", ex);
                return StatusCode(500);
            }
        }
    }
}