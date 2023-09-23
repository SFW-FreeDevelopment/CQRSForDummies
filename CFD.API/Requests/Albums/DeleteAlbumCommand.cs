namespace CFD.API.Requests.Albums;

public record DeleteAlbumCommand(string Id) : IRequest
{
    public class Handler : IRequestHandler<DeleteAlbumCommand>
    {
        private readonly CFDContext _context;
        
        public Handler(CFDContext context)
        {
            _context = context;
        }
        
        public async Task Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = await _context.Albums
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            if (album == null) return;
            
            _context.Albums.Remove(album);
        }
    }
}