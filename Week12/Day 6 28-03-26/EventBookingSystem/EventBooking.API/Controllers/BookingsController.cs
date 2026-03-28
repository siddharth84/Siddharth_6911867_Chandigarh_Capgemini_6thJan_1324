using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookingsController(AppDbContext context)
    {
        _context = context;
    }

    // --- NEW: GET USER BOOKINGS ---
    [Authorize]
    [HttpGet("my-bookings")]
    public IActionResult GetMyBookings()
    {
        var userName = User.Identity.Name;

        // Joins with Events to show the Title and Date of the booked event
        var myBookings = _context.Bookings
            .Where(b => b.UserId == userName)
            .Join(_context.Events, 
                b => b.EventId, 
                e => e.Id, 
                (b, e) => new {
                    BookingId = b.Id,
                    EventTitle = e.Title,
                    EventDate = e.Date,
                    SeatsReserved = b.SeatsBooked
                })
            .ToList();

        return Ok(myBookings);
    }

    [Authorize]
    [HttpPost]
    public IActionResult Book(BookingDto dto)
    {
        var ev = _context.Events.Find(dto.EventId);

        if (ev == null || ev.AvailableSeats < dto.SeatsBooked)
            return BadRequest("Not enough seats available.");

        ev.AvailableSeats -= dto.SeatsBooked;

        var booking = new Booking
        {
            EventId = dto.EventId,
            SeatsBooked = dto.SeatsBooked,
            UserId = User.Identity.Name
        };

        _context.Bookings.Add(booking);
        _context.SaveChanges();

        return Ok("Booking Successful");
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult Cancel(int id)
    {
        var booking = _context.Bookings.Find(id);
        if (booking == null) return NotFound();

        // --- ADDED: RESTORE SEATS TO EVENT ---
        var ev = _context.Events.Find(booking.EventId);
        if (ev != null)
        {
            ev.AvailableSeats += booking.SeatsBooked;
        }

        _context.Bookings.Remove(booking);
        _context.SaveChanges();

        return Ok("Booking cancelled and seats restored.");
    }
}