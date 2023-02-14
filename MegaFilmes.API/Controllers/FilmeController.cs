using MegaFilmes.Services.Dtos.FilmeDtos;
using MegaFilmes.Services.FilmeServices;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.API.Controllers;

[Controller]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly IFilmeService _filmeService;

	public FilmeController(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto createFilmeDto)
    {
        var filme = _filmeService.AdicionarFilme(createFilmeDto);
        return CreatedAtAction(nameof(BuscarFilmePorId), new { id = filme }, filme);
    }

    [HttpGet]
    public IActionResult BuscarTodosFilmes()
    {
        var filmes = _filmeService.BuscarTodosFilmes();
        return (filmes == null) ? NotFound() : Ok(filmes);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarFilmePorId([FromQuery] int id)
    {
        var filme = _filmeService.BuscarFilmePorId(id);
        return (filme == null) ? BadRequest() : Ok(filme);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme([FromQuery] int id)
    {
        var filme = _filmeService.DeletarFilme(id);
        if (filme == null) return BadRequest();

        return NoContent();
    }
}
