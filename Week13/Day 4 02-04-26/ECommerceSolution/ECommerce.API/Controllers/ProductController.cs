using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult AddProduct()
    {
        return Ok("Product added by Admin");
    }
}