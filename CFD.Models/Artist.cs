namespace CFD.Models;

public class Artist : BaseEntity
{
    public string Name { get; set; }
    public List<string> BandMembers { get; set; }
}