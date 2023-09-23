namespace CFD.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SongController : ControllerBase
{
    private readonly IMediator _mediator;

    public SongController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string name = null, [FromQuery] string artistId = null,
        [FromQuery] string albumId = null) =>
        Ok(await _mediator.Send(new GetSongsQuery(name, artistId, albumId)));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var result = await _mediator.Send(new GetSongQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SongModel song)
    {
        var result = await _mediator.Send(new UpsertSongCommand(null, song));
        return Created(result.Id, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] SongModel song)
    {
        var result = await _mediator.Send(new UpsertSongCommand(id, song));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _mediator.Send(new DeleteSongCommand(id));
        return NoContent();
    }
}