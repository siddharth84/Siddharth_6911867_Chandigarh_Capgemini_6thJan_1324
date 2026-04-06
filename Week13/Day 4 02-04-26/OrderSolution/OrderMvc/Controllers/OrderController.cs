using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace OrderMvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _factory;

        public OrderController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        // GET /Order/Login
        public IActionResult Login() => View();

        // POST /Order/Login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var client = _factory.CreateClient("ApiClient");

            var payload = new { username, password };
            var response = await client.PostAsJsonAsync("api/auth/login", payload);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Invalid credentials. Try: user / user123 or admin / admin123";
                return View();
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<JsonElement>(json);
            var token = result.GetProperty("token").GetString();
            var role  = result.GetProperty("role").GetString();

            // Store token in session-like TempData so it survives the redirect
            TempData["Token"] = token;
            TempData["Role"]  = role;
            TempData["Username"] = username;

            return RedirectToAction("Create");
        }

        // GET /Order/Create
        public IActionResult Create()
        {
            ViewBag.Token    = TempData["Token"];
            ViewBag.Role     = TempData["Role"];
            ViewBag.Username = TempData["Username"];

            // Keep TempData alive for the POST
            TempData.Keep();
            return View();
        }

        // POST /Order/Create
        [HttpPost]
        public async Task<IActionResult> Create(int userId, string token)
        {
            var client = _factory.CreateClient("ApiClient");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var payload  = new { userId };
            var response = await client.PostAsJsonAsync("api/orders", payload);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Success");

            ViewBag.Error    = $"Failed ({(int)response.StatusCode}): Make sure you used the 'user' account, not 'admin'.";
            ViewBag.Token    = token;
            ViewBag.Role     = TempData["Role"];
            ViewBag.Username = TempData["Username"];
            TempData.Keep();
            return View();
        }

        // GET /Order/Orders
        public async Task<IActionResult> Orders(string token)
        {
            var client = _factory.CreateClient("ApiClient");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("api/orders");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Could not load orders. Please login first.";
                return View(new List<dynamic>());
            }

            var json   = await response.Content.ReadAsStringAsync();
            var orders = JsonSerializer.Deserialize<List<JsonElement>>(json);

            ViewBag.Token = token;
            return View(orders);
        }

        // GET /Order/Products
        public async Task<IActionResult> Products()
        {
            var client   = _factory.CreateClient("ApiClient");
            var response = await client.GetAsync("api/products");
            var json     = await response.Content.ReadAsStringAsync();
            var result   = JsonSerializer.Deserialize<JsonElement>(json);

            ViewBag.Source   = result.GetProperty("source").GetString();
            ViewBag.Products = result.GetProperty("data");
            return View();
        }

        public IActionResult Success() => View();
    }
}
