namespace CFD.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile() {
        CreateMap<Album, AlbumModel>();
        CreateMap<AlbumModel, Album>();
        
        CreateMap<Artist, ArtistModel>();
        CreateMap<ArtistModel, Artist>();
        
        CreateMap<Song, SongModel>();
        CreateMap<SongModel, Song>();
    }
}