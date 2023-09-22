namespace CFD.Models;

public class Song : BaseEntity
{
    public string Name { get; set; }
    public string ArtistId { get; set; }
    public List<string> AdditionalArtistIds { get; set; }
    public string AlbumId { get; set; }
    public string ReleaseDate { get; set; }
}