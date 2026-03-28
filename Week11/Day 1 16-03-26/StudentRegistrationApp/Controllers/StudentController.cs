using Microsoft.AspNetCore.Mvc;
using StudentRegistrationApp.Models;

namespace StudentRegistrationApp.Controllers
{
    public class StudentController : Controller
    {
        // Show registration form
        public IActionResult Register()
        {
            return View();
        }

        // Handle form submission
        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                // Simulate saving student and generating ID
                student.Id = new Random().Next(1, 1000);

                TempData["SuccessMessage"] = "Student registered successfully!";

                return RedirectToAction("Details", new { id = student.Id, name = student.Name, age = student.Age });
            }

            return View(student);
        }

        // Details page
        public IActionResult Details(int id, string name, int age)
        {
            Student student = new Student
            {
                Id = id,
                Name = name,
                Age = age
            };

            return View(student);
        }
    }
}