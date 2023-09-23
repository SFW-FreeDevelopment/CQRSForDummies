namespace CFD.API.Requests.Albums;

public record GetAlbumsQuery(string Name = null, string ArtistId = null)
    : IRequest<IReadOnlyCollection<IAlbum>>
{
    public class Handler : IRequestHandler<GetAlbumsQuery, IReadOnlyCollection<IAlbum>>
    {
        private readonly CFDContext _context;
        private readonly IMapper _mapper;
        
        public Handler(CFDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyCollection<IAlbum>> Handle(GetAlbumsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Albums.AsEnumerable();
            
            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(x => x.Name?.ToLower().Contains(request.Name.ToLower()) ?? false);

            if (!string.IsNullOrWhiteSpace(request.ArtistId))
                query = query.Where(x => x.ArtistId == request.ArtistId);

            return await query
                .Select(x => _mapper.Map<AlbumModel>(x))
                .ToArrayAsync();
        }
    }
}
