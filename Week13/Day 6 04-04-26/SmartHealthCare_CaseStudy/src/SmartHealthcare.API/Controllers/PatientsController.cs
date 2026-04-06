using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.API.Services.Interfaces;
using SmartHealthcare.Models.DTOs;

namespace SmartHealthcare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;
    private readonly ILogger<PatientsController> _logger;

    public PatientsController(IPatientService patientService, ILogger<PatientsController> logger)
    {
        _patientService = patientService;
        _logger = logger;
    }

    [HttpGet("my-profile")]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> GetMyProfile()
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
        {
            return Unauthorized(new ErrorResponseDTO { Message = "Invalid user token", StatusCode = 401 });
        }

        var patient = await _patientService.GetByUserIdAsync(userId);
        if (patient == null)
        {
            return NotFound(new ErrorResponseDTO { Message = "Patient profile not found", StatusCode = 404 });
        }

        return Ok(patient);
    }

    [HttpPost]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> CreateProfile([FromBody] CreatePatientDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
        {
            return Unauthorized(new ErrorResponseDTO { Message = "Invalid user token", StatusCode = 401 });
        }

        // Check if patient profile already exists
        var existingPatient = await _patientService.GetByUserIdAsync(userId);
        if (existingPatient != null)
        {
            return BadRequest(new ErrorResponseDTO { Message = "Patient profile already exists", StatusCode = 400 });
        }

        var result = await _patientService.CreateAsync(userId, dto);
        return CreatedAtAction(nameof(GetMyProfile), result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Patient,Admin")]
    public async Task<IActionResult> UpdateProfile(int id, [FromBody] UpdatePatientDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Allow patients to update only their own profile, admins can update any
        if (User.IsInRole("Patient"))
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized(new ErrorResponseDTO { Message = "Invalid user token", StatusCode = 401 });
            }

            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null || patient.UserId != userId)
            {
                return Forbid();
            }
        }

        var result = await _patientService.UpdateAsync(id, dto);
        if (!result)
        {
            return NotFound(new ErrorResponseDTO { Message = "Patient not found", StatusCode = 404 });
        }

        return NoContent();
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Doctor")]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        if (page < 1 || pageSize < 1 || pageSize > 100)
        {
            return BadRequest(new ErrorResponseDTO { Message = "Invalid pagination parameters", StatusCode = 400 });
        }

        var result = await _patientService.GetAllAsync(page, pageSize);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Doctor")]
    public async Task<IActionResult> GetById(int id)
    {
        var patient = await _patientService.GetByIdAsync(id);
        if (patient == null)
        {
            return NotFound(new ErrorResponseDTO { Message = "Patient not found", StatusCode = 404 });
        }

        return Ok(patient);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _patientService.DeleteAsync(id);
        if (!result)
        {
            return NotFound(new ErrorResponseDTO { Message = "Patient not found", StatusCode = 404 });
        }

        return NoContent();
    }
}