using AutoMapper;
using MegaFilmes.Dtos.GeneroDtos;
using MegaFilmes.Models;
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
    public IEnumerable<ReadGeneroDto> BuscarTodosGeneros()
    {
        return _mapper.Map<List<ReadGeneroDto>>(_context.Generos);
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
