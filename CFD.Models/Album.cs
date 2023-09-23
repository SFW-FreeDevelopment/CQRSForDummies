namespace CFD.Models;

public interface IAlbum : IIdentifiable
{
    string Name { get; set; }
    string ArtistId { get; set; }
    string ReleaseDate { get; set; }
}

public class Album : BaseEntity, IAlbum
{
    public string Name { get; set; }
    public string ArtistId { get; set; }
    public string ReleaseDate { get; set; }
}