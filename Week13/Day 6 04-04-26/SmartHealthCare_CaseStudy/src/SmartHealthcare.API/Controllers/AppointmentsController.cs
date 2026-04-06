using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.API.Services.Interfaces;
using SmartHealthcare.Models.DTOs;
using System.Security.Claims;

namespace SmartHealthcare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _service;
    private readonly IPatientService _patientService;

    public AppointmentsController(IAppointmentService service, IPatientService patientService)
    {
        _service = service;
        _patientService = patientService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<PagedResult<AppointmentDTO>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _service.GetAllAsync(page, pageSize);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppointmentDTO>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        // Additional auth logic for patient/doctor could be placed here
        return Ok(result);
    }

    [Authorize(Roles = "Patient,Admin")]
    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult<PagedResult<AppointmentDTO>>> GetByPatient(int patientId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _service.GetByPatientIdAsync(patientId, page, pageSize);
        return Ok(result);
    }

    [Authorize(Roles = "Patient")]
    [HttpGet("my-appointments")]
    public async Task<ActionResult<PagedResult<AppointmentDTO>>> GetMyAppointments([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
        {
            return Unauthorized();
        }

        var patient = await _patientService.GetByUserIdAsync(userId);
        if (patient == null)
        {
            return BadRequest("Patient profile not set up.");
        }

        var result = await _service.GetByPatientIdAsync(patient.Id, page, pageSize);
        return Ok(result);
    }

    [Authorize(Roles = "Patient,Admin")]
    [HttpPost("patient/{patientId}")]
    public async Task<ActionResult<AppointmentDTO>> Create(int patientId, CreateAppointmentDTO dto)
    {
        var result = await _service.CreateAsync(patientId, dto);
        return CreatedAtAction(nameof(GetById), new { id = result.AppointmentId }, result);
    }

    [Authorize(Roles = "Patient")]
    [HttpPost]
    public async Task<ActionResult<AppointmentDTO>> CreateForCurrentUser(CreateAppointmentDTO dto)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
        {
            return Unauthorized();
        }

        var patient = await _patientService.GetByUserIdAsync(userId);
        if (patient == null)
        {
            return BadRequest("Patient profile not set up. Please create your patient profile first.");
        }

        var result = await _service.CreateAsync(patient.Id, dto);
        return CreatedAtAction(nameof(GetById), new { id = result.AppointmentId }, result);
    }

    [Authorize(Roles = "Admin,Doctor,Patient")]
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateAppointmentStatusDTO dto)
    {
        var result = await _service.UpdateStatusAsync(id, dto.Status);
        if (!result) return NotFound();
        return NoContent();
    }

    [Authorize(Roles = "Admin,Patient")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
