namespace CFD.API.Requests.Artists;

public record GetArtistsQuery(string Name = null) : IRequest<IReadOnlyCollection<IArtist>>
{
    public class Handler : IRequestHandler<GetArtistsQuery, IReadOnlyCollection<IArtist>>
    {
        private readonly CFDContext _context;
        private readonly IMapper _mapper;
        
        public Handler(CFDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyCollection<IArtist>> Handle(GetArtistsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Artists.AsEnumerable();
            
            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(x => x.Name?.ToLower().Contains(request.Name.ToLower()) ?? false);

            return await query
                .Select(x => _mapper.Map<ArtistModel>(x))
                .ToArrayAsync();
        }
    }
}
