namespace CFD.API.Requests.Songs;

public record UpsertSongCommand(string Id, SongModel Song) : IRequest<ISong>
{
    public class Handler : IRequestHandler<UpsertSongCommand, ISong>
    {
        private readonly CFDContext _context;
        private readonly IMapper _mapper;
        
        public Handler(CFDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<ISong> Handle(UpsertSongCommand request, CancellationToken cancellationToken)
        {
            var song = await _context.Songs
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            if (song == null && string.IsNullOrWhiteSpace(request.Id))
                return null;

            song = _mapper.Map<Song>(request.Song);
            
            _context.Songs.Add(song);

            return request.Song;
        }
    }
}