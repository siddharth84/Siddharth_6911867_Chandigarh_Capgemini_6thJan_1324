using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class DepartmentController : Controller
{
    private readonly ApplicationDbContext _context;

    public DepartmentController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Show departments
    public IActionResult Index()
    {
        var departments = _context.Departments.ToList();
        return View(departments);
    }

    // Create page
    public IActionResult Create()
    {
        return View();
    }

    // Save department
    [HttpPost]
    public IActionResult Create(Department department)
    {
        _context.Departments.Add(department);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}