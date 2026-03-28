using Microsoft.AspNetCore.Mvc;
using AutoMapper;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public EventsController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetEvents()
    {
        var events = _context.Events.ToList();
        return Ok(_mapper.Map<List<EventDto>>(events));
    }

    [HttpPost]
    public IActionResult CreateEvent([FromBody] EventDto dto)
    {
        if (dto == null) return BadRequest("Invalid data");

        try 
        {
            // Convert DTO to Entity
            var newEvent = _mapper.Map<Event>(dto);
            
            _context.Events.Add(newEvent);
            _context.SaveChanges();
            
            return Ok(newEvent);
        }
        catch (Exception ex)
        {
            // This will show in your VS Code Terminal
            Console.WriteLine($"DB Error: {ex.Message}");
            return StatusCode(500, "Database insertion failed");
        }
    }
}