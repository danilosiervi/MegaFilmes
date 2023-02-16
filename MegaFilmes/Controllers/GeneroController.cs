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
        if (createGeneroDto == null) return BadRequest("Insira os dados do gênero a ser criado");

        Genero genero = _mapper.Map<Genero>(createGeneroDto);

        _context.Generos.Add(genero);
        _context.SaveChanges();

        return Ok(genero);
    }

    [HttpGet]
    public IEnumerable<ReadGeneroDto> BuscarTodosGeneros()
    {
        return _mapper.Map<List<ReadGeneroDto>>(_context.Generos);
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverGenero(int id)
    {
        var genero = _context.Generos.FirstOrDefault(a => a.GeneroId == id);
        if (genero == null) return NotFound($"Não é possivel encontrar genero com id {id}");

        _context.Generos.Remove(genero);
        _context.SaveChanges();

        return NoContent();
    }
}
