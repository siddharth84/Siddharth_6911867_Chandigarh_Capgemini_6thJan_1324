using Microsoft.AspNetCore.Mvc;
using log4net;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ProductController));

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                log.Info($"Product fetch request: {id}");

                if (id <= 0)
                {
                    log.Warn("Invalid product ID");
                    return BadRequest();
                }

                if (id != 1)
                {
                    log.Warn("Product not found");
                    return NotFound();
                }

                return Ok(new { Id = 1, Name = "Laptop", Price = 50000 });
            }
            catch (Exception ex)
            {
                log.Error("Error fetching product", ex);
                return StatusCode(500);
            }
        }
    }
}