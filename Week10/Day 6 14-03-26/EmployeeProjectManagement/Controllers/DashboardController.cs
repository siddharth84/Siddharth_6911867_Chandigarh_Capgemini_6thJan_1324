using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Dashboard showing projects, employees, and departments
    public IActionResult Index()
    {
        var dashboard = _context.Projects
            .Include(p => p.EmployeeProjects)
            .ThenInclude(ep => ep.Employee)
            .ThenInclude(e => e.Department)
            .ToList();

        return View(dashboard);
    }

    // Get number of employees per department
    public IActionResult EmployeesPerDepartment()
    {
        var result = _context.Departments
            .Select(d => new
            {
                DepartmentName = d.Name,
                EmployeeCount = d.Employees.Count()
            })
            .ToList();

        return View(result);
    }

    // Get all employees working on a specific project
    public IActionResult EmployeesInProject(int projectId)
    {
        var employees = _context.EmployeeProjects
            .Where(ep => ep.ProjectId == projectId)
            .Include(ep => ep.Employee)
            .ThenInclude(e => e.Department)
            .Select(ep => ep.Employee)
            .ToList();

        return View(employees);
    }

    // Get all projects assigned to a specific employee
    public IActionResult ProjectsOfEmployee(int employeeId)
    {
        var projects = _context.EmployeeProjects
            .Where(ep => ep.EmployeeId == employeeId)
            .Include(ep => ep.Project)
            .Select(ep => ep.Project)
            .ToList();

        return View(projects);
    }
}