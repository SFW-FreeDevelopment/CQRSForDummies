namespace CFD.API.Requests.Artists;

public record GetArtistQuery(string Id) : IRequest<IArtist>
{
    public class Handler : IRequestHandler<GetArtistQuery, IArtist>
    {
        private readonly CFDContext _context;
        private readonly IMapper _mapper;
        
        public Handler(CFDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IArtist> Handle(GetArtistQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Artists.AsEnumerable();
            var result =  await query
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();
            
            return result != null
                ? _mapper.Map<ArtistModel>(result)
                : null;
        }
    }
}