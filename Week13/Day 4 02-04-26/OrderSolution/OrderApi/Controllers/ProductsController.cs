using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OrderApi.Models;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        public ProductsController(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// Get all products. Public - no login needed.
        /// Results are cached for 5 minutes.
        /// </summary>
        [HttpGet]
        public IActionResult GetProducts()
        {
            const string cacheKey = "all_products";

            if (_cache.TryGetValue(cacheKey, out List<object>? cachedProducts))
            {
                return Ok(new { source = "cache (fast!)", data = cachedProducts });
            }

            // Simulate database fetch
            var products = new List<object>
            {
                new { Id = 1, Name = "Laptop",   Price = 999.99, Stock = 10 },
                new { Id = 2, Name = "Mouse",    Price = 29.99,  Stock = 50 },
                new { Id = 3, Name = "Keyboard", Price = 79.99,  Stock = 30 }
            };

            _cache.Set(cacheKey, products, TimeSpan.FromMinutes(5));

            return Ok(new { source = "database", data = products });
        }

        /// <summary>
        /// Add a product. Only Admins can do this.
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public IActionResult AddProduct([FromBody] ProductDto dto)
        {
            // In a real app you'd save to DB here
            return Ok(new { message = $"Product '{dto.Name}' added successfully by Admin." });
        }
    }
}
