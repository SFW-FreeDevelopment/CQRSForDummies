namespace CFD.Models;

public interface ISong : IIdentifiable
{
    string Name { get; set; }
    string ArtistId { get; set; }
    string AlbumId { get; set; }
    string ReleaseDate { get; set; }
}

public class Song : BaseEntity, ISong
{
    public string Name { get; set; }
    public string ArtistId { get; set; }
    public string AlbumId { get; set; }
    public string ReleaseDate { get; set; }
}