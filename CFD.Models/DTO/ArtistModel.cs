namespace CFD.Models.DTO;

public class ArtistModel : IArtist
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<string> BandMembers { get; set; }
}