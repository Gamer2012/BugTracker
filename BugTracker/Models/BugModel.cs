namespace BugTracker.Models;

public class BugModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Progress { get; set; } //either a 0 for open, 1 for work in progress or 2 for closed; to save space
    public DateOnly StartDate { get; set; }
    public DateOnly CloseDate { get; set; }
}