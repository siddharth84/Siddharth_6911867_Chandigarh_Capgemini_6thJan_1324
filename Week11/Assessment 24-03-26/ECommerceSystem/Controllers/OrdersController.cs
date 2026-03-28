using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerceSystem.Data;
using ECommerceSystem.Models;
using ECommerceSystem.ViewModels;

namespace ECommerceSystem.Controllers;

public class OrdersController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrdersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // SHOW ORDER LIST (HOME PAGE)
    public IActionResult Index()
    {
        var orders = _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.ShippingDetail)
            .ToList();

        return View(orders);
    }

    // SHOW FORM
    public IActionResult Create()
    {
        ViewBag.Products = _context.Products.ToList();
        ViewBag.Customers = _context.Customers.ToList();
        return View();
    }

    // SAVE ORDER (IMPORTANT PART)
    [HttpPost]
    public IActionResult Create(OrderViewModel model)
    {
        var order = new Order
        {
            CustomerId = model.CustomerId,
            OrderDate = DateTime.Now,
            OrderItems = model.Items?.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList() ?? new List<OrderItem>(),

            ShippingDetail = new ShippingDetail
            {
                Address = model.Address,
                Status = "Pending"
            }
        };

        _context.Orders.Add(order);
        _context.SaveChanges();

        // ADD THIS LINE HERE
        return RedirectToAction("Index");
    }
}