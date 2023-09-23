namespace CFD.API.Requests.Songs;

public record GetSongQuery(string Id) : IRequest<ISong>
{
    public class Handler : IRequestHandler<GetSongQuery, ISong>
    {
        private readonly CFDContext _context;
        private readonly IMapper _mapper;
        
        public Handler(CFDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<ISong> Handle(GetSongQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Songs.AsEnumerable();
            var result =  await query
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();
            
            return result != null
                ? _mapper.Map<SongModel>(result)
                : null;
        }
    }
}