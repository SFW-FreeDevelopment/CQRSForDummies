namespace CFD.API.Requests.Albums;

public record UpsertAlbumCommand(string Id, AlbumModel Album) : IRequest<IAlbum>
{
    public class Handler : IRequestHandler<UpsertAlbumCommand, IAlbum>
    {
        private readonly CFDContext _context;
        private readonly IMapper _mapper;
        
        public Handler(CFDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IAlbum> Handle(UpsertAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = await _context.Albums
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            if (album == null && string.IsNullOrWhiteSpace(request.Id))
                return null;

            album = _mapper.Map<Album>(request.Album);
            
            _context.Albums.Add(album);

            return request.Album;
        }
    }
}