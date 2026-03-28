using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ECommerceSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSystem.Controllers;

[Authorize(Roles = "Admin")]   // APPLY HERE (BEST PRACTICE)
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        var topProducts = _context.OrderItems
            .GroupBy(o => o.ProductId)
            .Select(g => new
            {
                ProductId = g.Key,
                Quantity = g.Sum(x => x.Quantity)
            })
            .OrderByDescending(x => x.Quantity)
            .Take(5)
            .ToList();

        var pendingOrders = _context.ShippingDetails
            .Where(s => s.Status == "Pending")
            .ToList();

        ViewBag.TopProducts = topProducts;
        ViewBag.PendingOrders = pendingOrders;

        return View();
    }
}