using AutoMapper;
using MegaFilmes.Dtos.AvaliacaoDtos;
using MegaFilmes.Models;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.Controllers;

[Controller]
[Route("[controller]")]
public class AvaliacaoController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AvaliacaoController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("filme/{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AvaliarFilmePorId(int id, [FromBody] CreateAvaliacaoDto createAvaliacaoDto)
    {
        if (createAvaliacaoDto == null) return BadRequest("Insira os dados da avaliação");

        Avaliacao avaliacao = _mapper.Map<Avaliacao>(createAvaliacaoDto);
        avaliacao.FilmeId = id;

        return Ok(avaliacao);
    }

    [HttpGet("filme/{id}")]
    public IActionResult BuscarAvaliacaoPorFilmeId(int id)
    {
        var avaliacoes = _context.Avaliacoes
            .Where(a => a.FilmeId == id)
            .Select(a => _mapper.Map<ReadAvaliacaoDto>(a))
            .ToList();

        if (avaliacoes == null) return NotFound($"Não foi encontrado nenhuma avaliação para o filme de id {id}");

        return Ok(avaliacoes);
    }
}
