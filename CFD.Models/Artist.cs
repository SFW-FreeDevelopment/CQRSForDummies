namespace CFD.Models;

public interface IArtist : IIdentifiable
{
    string Name { get; set; }
    List<string> BandMembers { get; set; }
}

public class Artist : BaseEntity, IArtist
{
    public string Name { get; set; }
    public List<string> BandMembers { get; set; }
}