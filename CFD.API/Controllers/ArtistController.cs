namespace CFD.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ArtistController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string name = null) =>
        Ok(await _mediator.Send(new GetArtistsQuery(name)));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var result = await _mediator.Send(new GetArtistQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ArtistModel artist)
    {
        var result = await _mediator.Send(new UpsertArtistCommand(null, artist));
        return Created(result.Id, result);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] ArtistModel artist)
    {
        var result = await _mediator.Send(new UpsertArtistCommand(id, artist));
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _mediator.Send(new DeleteArtistCommand(id));
        return NoContent();
    }
}