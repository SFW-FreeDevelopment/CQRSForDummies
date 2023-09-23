namespace CFD.Models;

public interface IIdentifiable
{
    public string Id { get; set; }
}

public abstract class BaseEntity : IIdentifiable
{
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public long Version { get; set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = DateTime.UtcNow;
        SetVersion();
    }
    
    public void SetVersion()
    {
        Version = DateTime.UtcNow.Ticks;
    }
}