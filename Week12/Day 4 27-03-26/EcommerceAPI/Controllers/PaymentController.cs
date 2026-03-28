using Microsoft.AspNetCore.Mvc;
using log4net;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(PaymentController));

        [HttpPost]
        public IActionResult ProcessPayment(int orderId)
        {
            try
            {
                log.Info($"Payment request for order {orderId}");

                var start = DateTime.Now;

                // Simulate delay
                Thread.Sleep(6000);

                var timeTaken = (DateTime.Now - start).TotalSeconds;

                if (timeTaken > 5)
                {
                    log.Warn("Payment delay > 5 seconds");
                }

                // Simulate failure
                throw new Exception("Timeout");

            }
            catch (Exception ex)
            {
                log.Error("Payment failed", ex);
                return StatusCode(500, "Payment Failed");
            }
        }
    }
}