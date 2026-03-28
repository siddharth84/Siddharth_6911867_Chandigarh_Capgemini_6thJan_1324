using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Models;
using ProductManagementApp.Filters;
using System.Collections.Generic;
using System;

namespace ProductManagementApp.Controllers
{
    [ServiceFilter(typeof(LogActionFilter))]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            // Simulate an exception
            throw new Exception("Test exception for filter");

            var products = new List<Product>
            {
                new Product{ Id=1, Name="Laptop", Price=80000 },
                new Product{ Id=2, Name="Phone", Price=30000 }
            };

            return View(products);
        }
    }
}