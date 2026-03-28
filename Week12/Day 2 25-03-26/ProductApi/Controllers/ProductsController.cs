using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200 },
            new Product { Id = 2, Name = "Phone", Price = 800 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get() => Products;

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return product;
        }

        // PUT: api/products/1
[HttpPut("{id}")]
public IActionResult Put(int id, Product updatedProduct)
{
    var product = Products.FirstOrDefault(p => p.Id == id);

    if (product == null)
        return NotFound();

    product.Name = updatedProduct.Name;
    product.Price = updatedProduct.Price;

    return NoContent();
}

// DELETE: api/products/1
[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var product = Products.FirstOrDefault(p => p.Id == id);

    if (product == null)
        return NotFound();

    Products.Remove(product);
    return NoContent();
}

        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            product.Id = Products.Max(p => p.Id) + 1;
            Products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    }
}
