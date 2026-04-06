using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.API.Services.Interfaces;
using SmartHealthcare.Models.DTOs;

namespace SmartHealthcare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BillsController : ControllerBase
{
    private readonly IBillService _service;

    public BillsController(IBillService service)
    {
        _service = service;
    }

    [HttpGet("appointment/{appointmentId}")]
    public async Task<ActionResult<BillDTO>> GetByAppointment(int appointmentId)
    {
        var result = await _service.GetBillByAppointmentAsync(appointmentId);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [Authorize(Roles = "Admin,Doctor")]
    [HttpPost]
    public async Task<ActionResult<BillDTO>> Create(CreateBillDTO dto)
    {
        var result = await _service.CreateBillAsync(dto);
        return CreatedAtAction(nameof(GetByAppointment), new { appointmentId = result.AppointmentId }, result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, UpdateBillStatusDTO dto)
    {
        var result = await _service.UpdateBillStatusAsync(id, dto);
        if (!result) return NotFound();
        return NoContent();
    }
}
