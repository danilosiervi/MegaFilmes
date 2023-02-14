using MegaFilmes.Models;
using MegaFilmes.Services.DiretorServices;
using MegaFilmes.Services.Dtos.DiretorDtos;
using Microsoft.AspNetCore.Mvc;
using System.IO;

[Controller]
[Route("[controller]")]
public class DiretorController : ControllerBase
{
    private readonly IDiretorService _diretorService;

    public DiretorController(IDiretorService generoService)
    {
        _diretorService = generoService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarDiretor([FromBody] CreateDiretorDto createDiretorDto)
    {
        var diretor = _diretorService.AdicionarDiretor(createDiretorDto);
        return CreatedAtAction(nameof(BuscarDiretorPorId), new { id = diretor }, diretor);
    }

    [HttpGet]
    public IActionResult BuscarTodosDiretores()
    {
        var diretores = _diretorService.BuscarTodosDiretores();
        return (diretores == null) ? NotFound() : Ok(diretores);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarDiretorPorId(int id)
    {
        var diretor = _diretorService.BuscarDiretorPorId(id);
        return (diretor == null) ? BadRequest() : Ok(diretor);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarDiretor(int id)
    {
        var diretor = _diretorService.DeletarDiretor(id);
        if (diretor == null) return BadRequest();

        return NoContent();
    }
}

