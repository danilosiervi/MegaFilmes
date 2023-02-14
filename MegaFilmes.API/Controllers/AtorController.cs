using MegaFilmes.Services.AtorServices;
using MegaFilmes.Services.Dtos.AtorDtos;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.API.Controllers;

[Controller]
[Route("[controller]")]
public class AtorController : ControllerBase
{
    private readonly IAtorService _atorService;

    public AtorController(IAtorService atorService)
    {
        _atorService = atorService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarAtor([FromBody] CreateAtorDto createAtorDto)
    {
        var ator = _atorService.AdicionarAtor(createAtorDto);
        return CreatedAtAction(nameof(BuscarAtorPorId), new { id = ator }, ator);
    }

    [HttpGet]
    public IActionResult BuscarTodosAtores()
    {
        var atores = _atorService.BuscarTodosAtores();
        return (atores == null) ? NotFound() : Ok(atores);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarAtorPorId(int id)
    {
        var ator = _atorService.BuscarAtorPorId(id);
        return (ator == null) ? BadRequest() : Ok(ator);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarAtor(int id)
    {
        var ator = _atorService.DeletarAtor(id);
        if (ator == null) return BadRequest();

        return NoContent();
    }
}
