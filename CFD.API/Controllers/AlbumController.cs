namespace CFD.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AlbumController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string name = null, [FromQuery] string artistId = null) =>
        Ok(await _mediator.Send(new GetAlbumsQuery(name, artistId)));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var result = await _mediator.Send(new GetAlbumQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AlbumModel album)
    {
        var result = await _mediator.Send(new UpsertAlbumCommand(null, album));
        return Created(result.Id, result);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] AlbumModel album)
    {
        var result = await _mediator.Send(new UpsertAlbumCommand(id, album));
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _mediator.Send(new DeleteAlbumCommand(id));
        return NoContent();
    }
}