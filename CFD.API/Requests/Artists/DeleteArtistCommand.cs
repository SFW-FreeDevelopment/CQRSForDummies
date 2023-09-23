namespace CFD.API.Requests.Artists;

public record DeleteArtistCommand(string Id) : IRequest
{
    public class Handler : IRequestHandler<DeleteArtistCommand>
    {
        private readonly CFDContext _context;
        
        public Handler(CFDContext context)
        {
            _context = context;
        }
        
        public async Task Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
        {
            var artist = await _context.Artists
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            if (artist == null) return;
            
            _context.Artists.Remove(artist);
        }
    }
}