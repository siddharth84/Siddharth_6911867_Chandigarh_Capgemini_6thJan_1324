using System.ComponentModel.DataAnnotations;

public class Booking
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public string UserId { get; set; }

    [Range(1, 100)]
    public int SeatsBooked { get; set; }
}