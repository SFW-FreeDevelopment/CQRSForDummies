namespace CFD.API.Database;

public class CFDContext
{
    public IDbSet<Album> Albums { get; set; } = new DbSet<Album>();
    public IDbSet<Artist> Artists { get; set; } = new DbSet<Artist>();
    public IDbSet<Song> Songs { get; set; } = new DbSet<Song>();

    public CFDContext()
    {
        var random = new Random();
        for (var i = 0; i < 100; i++)
        {
            var artist = new Artist
            {
                Name = Faker.Address.StreetName(),
                BandMembers = new List<string>()
            };
            for (var j = 0; j < random.Next(1, 6); j++)
            {
                artist.BandMembers.Add($"{Faker.Name.First()} {Faker.Name.Last()}");
            }
            Artists.Add(artist);
        }
        for (var i = 0; i < 200; i++)
        {
            var artist = Artists[i/2];
            Albums.Add(new Album
            {
                Name = $"{Faker.Address.UsState()} {Faker.Address.StreetName()}",
                ArtistId = artist.Id,
                ReleaseDate = Faker.Identification.DateOfBirth().ToString("MMMM dd, yyyy")
            });
        }
        for ( var i = 0; i < 2000; i++)
        {
            var album = Albums[i/10];
            var artist = Artists[album.ArtistId];
            Songs.Add(new Song
            {
                Name = $"{Faker.Address.UsState()} {Faker.Address.StreetName()}",
                ArtistId = artist.Id,
                AlbumId = album.Id,
                ReleaseDate = Faker.Identification.DateOfBirth().ToString("MMMM dd, yyyy")
            });
        }
    }
}