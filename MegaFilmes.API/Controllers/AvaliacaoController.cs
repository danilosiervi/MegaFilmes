using MegaFilmes.Services.AtorServices;
using MegaFilmes.Services.AvaliacaoServices;
using MegaFilmes.Services.Dtos.AtorDtos;
using MegaFilmes.Services.Dtos.AvaliacaoDtos;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.API.Controllers;

[Controller]
[Route("[controller]")]
public class AvaliacaoController : ControllerBase
{
    private readonly IAvaliacaoService _avaliacaoService;

    public AvaliacaoController(IAvaliacaoService avaliacaoService)
    {
        _avaliacaoService = avaliacaoService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarAvaliacao([FromBody] CreateAvaliacaoDto createAvaliacaoDto)
    {
        var avaliacao = _avaliacaoService.AdicionarAvaliacao(createAvaliacaoDto);
        return CreatedAtAction(nameof(BuscarAvaliacaoPorId), new { id = avaliacao }, avaliacao);
    }

    [HttpGet]
    public IActionResult BuscarTodasAvaliacoes()
    {
        var avaliacoes = _avaliacaoService.BuscarTodasAvaliacoes();
        return (avaliacoes == null) ? NotFound() : Ok(avaliacoes);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarAvaliacaoPorId(int id)
    {
        var avaliacoes = _avaliacaoService.BuscarAvaliacaoPorId(id);
        return (avaliacoes == null) ? BadRequest() : Ok(avaliacoes);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarAvaliacao(int id)
    {
        var avaliacao = _avaliacaoService.DeletarAvaliacao(id);
        if (avaliacao == null) return BadRequest();

        return NoContent();
    }
}
