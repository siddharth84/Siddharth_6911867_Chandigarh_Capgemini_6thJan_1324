using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.MVC.Services;
using SmartHealthcare.Models.DTOs;

namespace SmartHealthcare.MVC.Controllers;

public class BillsController : Controller
{
    private readonly IApiService _apiService;
    private readonly ILogger<BillsController> _logger;

    public BillsController(IApiService apiService, ILogger<BillsController> logger)
    {
        _apiService = apiService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Account");
        }

        var role = HttpContext.Session.GetString("Role");
        if (role != "Admin")
        {
            return RedirectToAction("Index", "Dashboard");
        }

        // For admin, get all bills - but API doesn't have get all, so perhaps get by appointments or something
        // Since API has get by appointment, but for index, maybe redirect or show message
        TempData["Info"] = "Bill management is available per appointment.";
        return RedirectToAction("Index", "Appointment");
    }

    [HttpGet]
    public async Task<IActionResult> Create(int appointmentId)
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Account");
        }

        var role = HttpContext.Session.GetString("Role");
        if (role != "Admin" && role != "Doctor")
        {
            return RedirectToAction("Index", "Dashboard");
        }

        // Check if bill already exists for this appointment
        var existingBill = await _apiService.GetAsync<BillDTO>($"bills/appointment/{appointmentId}", token);
        if (existingBill != null)
        {
            TempData["Info"] = "A bill already exists for this appointment.";
            return RedirectToAction("Details", "Appointment", new { id = appointmentId });
        }

        ViewBag.AppointmentId = appointmentId;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBillDTO dto)
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Account");
        }

        if (!ModelState.IsValid)
        {
            ViewBag.AppointmentId = dto.AppointmentId;
            return View(dto);
        }

        try
        {
            var result = await _apiService.PostAsync<BillDTO>("bills", dto, token);
            if (result == null)
            {
                TempData["Error"] = "Failed to create bill.";
                ViewBag.AppointmentId = dto.AppointmentId;
                return View(dto);
            }

            _logger.LogInformation($"Bill {result.BillId} created for appointment {result.AppointmentId}");
            TempData["Success"] = "Bill created successfully!";
            return RedirectToAction("Details", "Appointment", new { id = dto.AppointmentId });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating bill");
            TempData["Error"] = "An error occurred while creating the bill.";
            ViewBag.AppointmentId = dto.AppointmentId;
            return View(dto);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Details(int appointmentId)
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Account");
        }

        var bill = await _apiService.GetAsync<BillDTO>($"bills/appointment/{appointmentId}", token);
        if (bill == null)
        {
            TempData["Error"] = "Bill not found.";
            return RedirectToAction("Index", "Appointment");
        }

        ViewBag.Role = HttpContext.Session.GetString("Role");
        return View(bill);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int id, string status)
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Account");
        }

        var role = HttpContext.Session.GetString("Role");
        if (role != "Admin")
        {
            return Forbid();
        }

        try
        {
            var updateDto = new UpdateBillStatusDTO { PaymentStatus = status };
            var result = await _apiService.PatchAsync<object>($"bills/{id}/status", updateDto, token);
            // Since API returns NoContent, result will be null on success
            TempData["Success"] = "Bill status updated successfully!";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating bill status");
            TempData["Error"] = "An error occurred while updating the bill status.";
        }

        return RedirectToAction("Index", "Appointment");
    }
}