using MegaFilmes.Models;
using MegaFilmes.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.IO;

[Controller]
[Route("[controller]")]
public class DiretorController : ControllerBase
{
    private DiretorContext _context;
    private IMapper _mapper;

    public DiretorController(DiretorContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaDiretor(
         [FromBody] CreateDiretorDto diretorDto)
    {
        if (createDiretorDto == null)
            return BadRequest("Dados Inválidos");

        Diretor diretor = _mapper.Map<Diretor>(DiretorDto);
        _context.Diretor.Add(diretor);
        _context.SaveChanges();


        if (diretor == null)
            return BadRequest("O Diretor já existe");

        return CreatedAtAction(nameof(RecuperaDiretorPorId),
            new { id = diretor.Id },
            diretor);
    }

    [HttpGet]
    public IEnumerable<Diretor> RecuperarDiretores([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Diretores.Skip(skip).Take(take);
    }


    [HttpGet("{id}")]
    public IActionResult RecuperaDiretorPorId(int id)
    {
        var diretor = _context.Diretor
            .FirstOrDefault(diretor => diretor.Id == id);
        if (diretor == null) return NotFound("O diretor não foi localizado.");
        var diretorDto = _mapper.Map<ReadDiretorDto>(diretor);
        return Ok(diretorDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaDiretor(int id,
        [FromBody] UpdateDiretorDto diretorDto)
    {
        var diretor = _context.Diretor.FirstOrDefault(
            diretor => diretor.Id == id);
        if (diretor == null) return NotFound("O diretor não foi localizado.");
        _mapper.Map(diretorDto, diretor);
        _context.SaveChanges();
        return NoContent();
    }
}
