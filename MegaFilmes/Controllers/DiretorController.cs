using AutoMapper;
using MegaFilmes.Dtos.DiretorDtos;
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
        if (createDiretorDto == null) return BadRequest();

        Diretor diretor = _mapper.Map<Diretor>(createDiretorDto);

        _context.Diretores.Add(diretor);
        _context.SaveChanges();

        return Ok(diretor);
    }

    [HttpGet]
    public IEnumerable<ReadDiretorDto> BuscarTodosOsDiretores()
    {
        return _context.Diretores.Select(d => _mapper.Map<ReadDiretorDto>(d)).ToList();
    }
}
