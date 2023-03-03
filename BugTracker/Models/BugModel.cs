namespace BugTracker.Models;


public class Bug
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Progress { get; set; } //either a 0 for open, 1 for review or 2 for closed; to save space
    public DateTime StartDate { get; set; }
    public DateTime CloseDate { get; set; }
    public string? OpenedBy { get; set; }
    public string? ClosedBy { get; set; }
    
    public string? Solution { get; set; }
}