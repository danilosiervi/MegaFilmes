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

    [HttpPost("Filme/{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AvaliarFilme(int id, [FromBody] CreateAvaliacaoDto createAvaliacaoDto)
    {
        if (createAvaliacaoDto == null) return BadRequest("Insira os dados da avaliação");

        Avaliacao avaliacao = _mapper.Map<Avaliacao>(createAvaliacaoDto);
        avaliacao.FilmeId = id;

        _context.Avaliacoes.Add(avaliacao);
        _context.SaveChanges();

        return Ok(avaliacao);
    }

    [HttpGet("Filme/{id}")]
    public IActionResult BuscarAvaliacaoPorFilmeId(int id)
    {
        var avaliacoes = _context.Avaliacoes
            .Where(a => a.FilmeId == id)
            .Select(a => _mapper.Map<ReadAvaliacaoDto>(a))
            .ToList();

        if (avaliacoes == null) return NotFound($"Não foi encontrado nenhuma avaliação para o filme de id {id}");

        return Ok(avaliacoes);
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverAvaliacao(int id)
    {
        var avaliacao = _context.Avaliacoes.FirstOrDefault(a => a.AvaliacaoId == id);
        if (avaliacao == null) return NotFound($"Não é possivel encontrar avaliação com id {id}");

        _context.Avaliacoes.Remove(avaliacao);
        _context.SaveChanges();

        return NoContent();
    }
}
