using Microsoft.AspNetCore.Mvc;

namespace OrderMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
