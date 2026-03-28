using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerceSystem.Data;
using ECommerceSystem.Models;

namespace ECommerceSystem.Controllers;

public class ShippingDetailsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ShippingDetailsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 🔹 LIST ALL SHIPPING DETAILS
    public IActionResult Index()
    {
        var shipping = _context.ShippingDetails
            .Include(s => s.Order)
            .ToList();

        return View(shipping);
    }

    // 🔹 CREATE FORM
    public IActionResult Create()
    {
        ViewBag.Orders = _context.Orders.ToList();
        return View();
    }

    // 🔹 SAVE SHIPPING DETAIL
    [HttpPost]
    public IActionResult Create(ShippingDetail shippingDetail)
    {
        if (ModelState.IsValid)
        {
            _context.ShippingDetails.Add(shippingDetail);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        ViewBag.Orders = _context.Orders.ToList();
        return View(shippingDetail);
    }

    // 🔹 EDIT STATUS
    public IActionResult Edit(int id)
    {
        var shipping = _context.ShippingDetails.Find(id);
        return View(shipping);
    }

    [HttpPost]
    public IActionResult Edit(ShippingDetail model)
    {
        var shipping = _context.ShippingDetails
            .FirstOrDefault(s => s.ShippingDetailId == model.ShippingDetailId);

        if (shipping == null)
            return NotFound();

        shipping.Address = model.Address;
        shipping.Status = model.Status;

        _context.SaveChanges();

        return RedirectToAction("Index");
    }

}