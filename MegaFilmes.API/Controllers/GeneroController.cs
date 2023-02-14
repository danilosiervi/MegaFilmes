using MegaFilmes.Services.Dtos.GeneroDtos;
using MegaFilmes.Services.GeneroServices;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.API.Controllers;

[Controller]
[Route("[controller]")]
public class GeneroController : ControllerBase
{
    private readonly IGeneroService _generoService;

    public GeneroController(IGeneroService generoService)
    {
        _generoService = generoService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarGenero([FromBody] CreateGeneroDto createGeneroDto)
    {
        var genero = _generoService.AdicionarGenero(createGeneroDto);
        return CreatedAtAction(nameof(BuscarGeneroPorId), new { id = genero }, genero);
    }

    [HttpGet]
    public IActionResult BuscarTodosGeneros()
    {
        var generos = _generoService.BuscarTodosGeneros();
        return (generos == null) ? NotFound() : Ok(generos);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarGeneroPorId([FromQuery] int id)
    {
        var genero = _generoService.BuscarGeneroPorId(id);
        return (genero == null) ? BadRequest() : Ok(genero);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarGenero([FromQuery] int id)
    {
        var genero = _generoService.DeletarGenero(id);
        if (genero == null) return BadRequest();

        return NoContent();
    }
}
