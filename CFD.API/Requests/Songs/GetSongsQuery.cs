namespace CFD.API.Requests.Songs;

public record GetSongsQuery(string Name = null, string ArtistId = null, string AlbumId = null)
    : IRequest<IReadOnlyCollection<ISong>>
{
    public class Handler : IRequestHandler<GetSongsQuery, IReadOnlyCollection<ISong>>
    {
        private readonly CFDContext _context;
        private readonly IMapper _mapper;
        
        public Handler(CFDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyCollection<ISong>> Handle(GetSongsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Songs.AsEnumerable();
            
            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(x => x.Name?.ToLower().Contains(request.Name.ToLower()) ?? false);

            if (!string.IsNullOrWhiteSpace(request.ArtistId))
                query = query.Where(x => x.ArtistId == request.ArtistId);

            if (!string.IsNullOrWhiteSpace(request.AlbumId))
                query = query.Where(x => x.AlbumId == request.AlbumId);

            return await query
                .Select(x => _mapper.Map<SongModel>(x))
                .ToArrayAsync();
        }
    }
}
