using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace ProductClient.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductsModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public List<Product> Products { get; set; } = new();

        // GET: Load products
        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient("ProductApi");

            var response = await client.GetAsync("products");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                Products = JsonSerializer.Deserialize<List<Product>>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new();
            }
        }

        // CREATE: Add product
        public async Task<IActionResult> OnPostAsync(string Name, decimal Price)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            var product = new Product
            {
                Name = Name,
                Price = Price
            };

            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PostAsync("products", content);

            return RedirectToPage(); // refresh page
        }

        // DELETE: Remove product
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            await client.DeleteAsync($"products/{id}");

            return RedirectToPage();
        }

        // UPDATE: Edit product
public async Task<IActionResult> OnPostEditAsync(int Id, string Name, decimal Price)
{
    var client = _clientFactory.CreateClient("ProductApi");

    var product = new Product
    {
        Id = Id,
        Name = Name,
        Price = Price
    };

    var json = JsonSerializer.Serialize(product);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    await client.PutAsync($"products/{Id}", content);

    return RedirectToPage();
}
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}