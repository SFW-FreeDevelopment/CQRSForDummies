namespace CFD.API.Requests.Songs;

public record DeleteSongCommand(string Id) : IRequest
{
    public class Handler : IRequestHandler<DeleteSongCommand>
    {
        private readonly CFDContext _context;
        
        public Handler(CFDContext context)
        {
            _context = context;
        }
        
        public async Task Handle(DeleteSongCommand request, CancellationToken cancellationToken)
        {
            var song = await _context.Songs
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            if (song == null) return;
            
            _context.Songs.Remove(song);
        }
    }
}