using AutoMapper;
using MegaFilmes.Dtos.AtorDtos;
using MegaFilmes.Dtos.AvaliacaoDtos;
using MegaFilmes.Dtos.FilmeAtorDtos;
using MegaFilmes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MegaFilmes.Controllers;

[Controller]
[Route("[controller]")]
public class AtorController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AtorController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarAtor([FromBody] CreateAtorDto createAtorDto)
    {
        if (createAtorDto == null) return BadRequest("Insira os dados do ator a ser criado");

        Ator ator = _mapper.Map<Ator>(createAtorDto);

        _context.Atores.Add(ator);
        _context.SaveChanges();

        return Ok(ator);
    }

    [HttpGet]
    public IEnumerable<ReadAtorDto> BuscarTodosAtores()
    {
        return _mapper.Map<List<ReadAtorDto>>(_context.Atores);
    }

    [HttpPost("filme/{id}")]
    public IActionResult AdicionarAtorAoFilme(int id, [FromBody] CreateFilmeAtorDto createFilmeAtorDto)
    {
        if (createFilmeAtorDto == null) return BadRequest("Insira os dados do elenco");

        FilmeAtor elenco = _mapper.Map<FilmeAtor>(createFilmeAtorDto);
        elenco.FilmeId = id;

        _context.FilmeAtor.Add(elenco);
        _context.SaveChanges();

        return Ok(elenco);
    }
}
