public class EventDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; } // Add this!
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public int AvailableSeats { get; set; }
}