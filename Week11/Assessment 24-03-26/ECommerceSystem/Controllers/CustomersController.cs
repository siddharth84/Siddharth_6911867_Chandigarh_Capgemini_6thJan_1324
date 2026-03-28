using Microsoft.AspNetCore.Mvc;
using ECommerceSystem.Data;
using ECommerceSystem.Models;

namespace ECommerceSystem.Controllers;

public class CustomersController : Controller
{
    private readonly ApplicationDbContext _context;

    public CustomersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 🔹 LIST ALL CUSTOMERS
    public IActionResult Index()
    {
        var customers = _context.Customers.ToList();
        return View(customers);
    }

    // 🔹 SHOW CREATE FORM
    public IActionResult Create()
    {
        return View();
    }

    // 🔹 SAVE CUSTOMER
    [HttpPost]
    public IActionResult Create(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(customer);
    }
}