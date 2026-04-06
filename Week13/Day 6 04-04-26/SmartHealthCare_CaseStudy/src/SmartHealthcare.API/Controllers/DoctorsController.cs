using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.API.Services.Interfaces;
using SmartHealthcare.Models.DTOs;

namespace SmartHealthcare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _service;

    public DoctorsController(IDoctorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<DoctorDTO>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _service.GetAllAsync(page, pageSize);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorDTO>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<DoctorDTO>> GetByUserId(int userId)
    {
        var result = await _service.GetByUserIdAsync(userId);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("user/{userId}")]
    public async Task<ActionResult<DoctorDTO>> Create(int userId, CreateDoctorDTO dto)
    {
        var result = await _service.CreateAsync(userId, dto);
        return CreatedAtAction(nameof(GetById), new { id = result.DoctorId }, result);
    }

    [Authorize(Roles = "Admin,Doctor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateDoctorDTO dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        if (!result) return NotFound();
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<ActionResult<PagedResult<DoctorDTO>>> Search([FromQuery] string query, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _service.SearchBySpecializationAsync(query, page, pageSize);
        return Ok(result);
    }
}
