namespace CFD.API.Requests.Artists;

public record UpsertArtistCommand(string Id, ArtistModel Artist) : IRequest<IArtist>
{
    public class Handler : IRequestHandler<UpsertArtistCommand, IArtist>
    {
        private readonly CFDContext _context;
        private readonly IMapper _mapper;
        
        public Handler(CFDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IArtist> Handle(UpsertArtistCommand request, CancellationToken cancellationToken)
        {
            var artist = await _context.Artists
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            if (artist == null && string.IsNullOrWhiteSpace(request.Id))
                return null;

            artist = _mapper.Map<Artist>(request.Artist);
            
            _context.Artists.Add(artist);

            return request.Artist;
        }
    }
}