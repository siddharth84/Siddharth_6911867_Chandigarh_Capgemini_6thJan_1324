using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class ProjectsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProjectsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Show all projects
    public IActionResult Index()
    {
        var projects = _context.Projects.ToList();
        return View(projects);
    }

    // Show create project page
    public IActionResult Create()
    {
        ViewBag.Employees = _context.Employees.ToList();
        return View();
    }

    // Save project and assign employees
    [HttpPost]
    public IActionResult Create(Project project, int[] employeeIds)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();

        if (employeeIds != null)
        {
            foreach (var eid in employeeIds)
            {
                _context.EmployeeProjects.Add(new EmployeeProject
                {
                    EmployeeId = eid,
                    ProjectId = project.ProjectId,
                    AssignedDate = DateTime.Now
                });
            }

            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    // Show employees working on a project
    public IActionResult EmployeesInProject(int projectId)
    {
        var employees = _context.EmployeeProjects
            .Where(ep => ep.ProjectId == projectId)
            .Include(ep => ep.Employee)
            .Select(ep => ep.Employee)
            .ToList();

        return View(employees);
    }
}