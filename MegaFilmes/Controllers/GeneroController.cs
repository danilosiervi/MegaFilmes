using AutoMapper;
using MegaFilmes.Data;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.GeneroDtos;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.Controllers;

[Controller]
[Route("[controller]")]
public class GeneroController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GeneroController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarGenero([FromBody] CreateGeneroDto createGeneroDto)
    {
        Genero genero = _mapper.Map<Genero>(createGeneroDto);

        _context.Generos.Add(genero);
        _context.SaveChanges();

        return CreatedAtAction(nameof(BuscarGeneroPorId), new { id = genero.GeneroId }, genero);
    }

    [HttpGet]
    public IEnumerable<ReadGeneroDto> BuscarTodosGeneros([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadGeneroDto>>(_context.Generos.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult BuscarGeneroPorId(int id)
    {
        var genero = _context.Generos.FirstOrDefault(g => g.GeneroId == id);
        if (genero == null) return NotFound();

        var generoDto = _mapper.Map<ReadGeneroDto>(genero);
        return Ok(generoDto);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarGenero(int id)
    {
        var genero = _context.Generos.FirstOrDefault(g => g.GeneroId == id);
        if (genero == null) return NotFound();

        _context.Remove(genero);
        _context.SaveChanges();

        return NoContent();
    }
}
