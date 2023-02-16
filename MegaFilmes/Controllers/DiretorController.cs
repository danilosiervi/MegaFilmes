using AutoMapper;
using MegaFilmes.Dtos.DiretorDtos;
using MegaFilmes.Dtos.GeneroDtos;
using MegaFilmes.Models;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.Controllers;

[Controller]
[Route("[controller]")]
public class DiretorController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public DiretorController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarDiretor([FromBody] CreateDiretorDto createDiretorDto)
    {
        if (createDiretorDto == null) return BadRequest("Insira os dados do diretor a ser criado");

        Diretor diretor = _mapper.Map<Diretor>(createDiretorDto);

        _context.Diretores.Add(diretor);
        _context.SaveChanges();

        return Ok(diretor);
    }

    [HttpGet]
    public IEnumerable<ReadDiretorDto> BuscarTodosDiretores()
    {
        return _mapper.Map<List<ReadDiretorDto>>(_context.Diretores);
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverDiretor(int id)
    {
        var diretor = _context.Diretores.FirstOrDefault(a => a.DiretorId == id);
        if (diretor == null) return NotFound($"Não é possivel encontrar diretor com id {id}");

        _context.Diretores.Remove(diretor);
        _context.SaveChanges();

        return NoContent();
    }
}
