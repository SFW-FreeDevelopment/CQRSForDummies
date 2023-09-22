namespace CFD.Models;

public abstract class BaseEntity
{
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public long Version { get; set; }

    public void SetVersion()
    {
        Version = DateTime.UtcNow.Ticks;
    }
}