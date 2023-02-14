using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.AvaliacaoDtos;
using MegaFilmes.Services;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _service;

    public ClientController(IClientService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult BuscarTodosFilmes()
    {
        var filmes = _service.BuscarTodosFilmes();
        return Ok(filmes);

    }

    [HttpGet("{id}")]
    public IActionResult BuscarFilmePorId(int id)
    {
        var filme = _service.BuscarFilmePorId(id);
        if (filme == null)
            return NotFound("Filme não localizado");

        return Ok(filme);
    }

    [HttpGet("{param}")]
    public IActionResult BuscarFilmesPorParametro(string param)
    {
        var filmes = _service.BuscarFilmesPorParametro(param);
        if (filmes == null)
            return NotFound("Filme não localizado");

        return Ok(filmes);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AvaliarFilme([FromBody] CreateAvaliacaoDto createAvaliacaoDto)
    {
        var avaliacao = _service.AvaliarFilme(createAvaliacaoDto);
        return CreatedAtAction(nameof(BuscarAvaliacaoPorId), avaliacao);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarAvaliacaoPorId(int id)
    {
        var avaliacao = _service.BuscarAvaliacaoPorId(id);
        if (avaliacao == null)
            return NotFound("Avaliação não localizada");

        return Ok(avaliacao);
    }

    [HttpGet("{filme}")]
    public IActionResult BuscarAvaliacoesDoFilme(Filme filme)
    {
        var avaliacoes = _service.BuscarAvaliacoesDoFilme(filme);
        if (avaliacoes == null)
            return NotFound("Avaliação não localizada");

        return Ok(avaliacoes);
    }

    [HttpPatch]
    public IActionResult EditarAvaliacao(Avaliacao avaliacao)
    {
        var result = _service.EditarAvaliacao(avaliacao);
        return (result.IsSuccess) ? Ok() : BadRequest();
    }

    [HttpDelete]
    public IActionResult DeletarAvaliacao(Avaliacao avaliacao)
    {
        var result = _service.DeletarAvaliacao(avaliacao);
        return (result.IsSuccess) ? Ok() : BadRequest();
    }
}
