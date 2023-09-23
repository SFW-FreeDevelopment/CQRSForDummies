namespace CFD.API.Requests.Albums;

public record GetAlbumQuery(string Id) : IRequest<IAlbum>
{
    public class Handler : IRequestHandler<GetAlbumQuery, IAlbum>
    {
        private readonly CFDContext _context;
        private readonly IMapper _mapper;
        
        public Handler(CFDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IAlbum> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Albums.AsEnumerable();
            var result =  await query
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();
            
            return result != null
                ? _mapper.Map<AlbumModel>(result)
                : null;
        }
    }
}