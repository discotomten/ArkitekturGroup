namespace Domain;

public class TodoItem
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsFinished { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
}