namespace Backend.Models;

public class Note
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateOnly? DateUpdate { get; set; }
    public string? Category { get; set; }
    public string? Status { get; set; }
    public int? IdUser { get; set; }
}