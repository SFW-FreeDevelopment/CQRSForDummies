namespace CFD.Models.DTO;

public class AlbumModel : IAlbum
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ArtistId { get; set; }
    public string ReleaseDate { get; set; }
}