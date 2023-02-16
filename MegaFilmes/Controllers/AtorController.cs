using AutoMapper;
using FilmesApi.Data;
using MegaFilmes.Data.Dtos;
using MegaFilmes.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.Controllers;

[ApiController]
[Route("[controller]")]
public class AtorController : ControllerBase
{

    private AtorContext _context;
    private IMapper _mapper;

    public AtorController(AtorContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um ator ao banco de dados
    /// </summary>
    /// <param name="atorDto">Objeto com os campos necessários para criação de um ator</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaAtor(
        [FromBody] CreateAtorDto atorDto)
    {
        if (createAtorDto == null)
            return BadRequest("Dados Inválidos");

        Ator ator = _mapper.Map<Ator>(atorDto);
        _context.Ator.Add(ator);
        _context.SaveChanges();


        if (ator == null)
            return BadRequest("O Ator já existe");
        
        return CreatedAtAction(nameof(RecuperaAtorPorId),
            new { id = ator.Id },
            ator);
    }

    [HttpGet]
    public IEnumerable<Ator> RecuperarAtores([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Atores.Skip(skip).Take(take);
    }


    [HttpGet("{id}")]
    public IActionResult RecuperaAtorPorId(int id)
    {
        var ator = _context.Ator
            .FirstOrDefault(ator => ator.Id == id);
        if (ator == null) return NotFound("O ator não foi localizado.");
        var atorDto = _mapper.Map<ReadAtorDto>(ator);
        return Ok(atorDto);
    }
}