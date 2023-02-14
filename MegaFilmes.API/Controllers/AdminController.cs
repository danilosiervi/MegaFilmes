using MegaFilmes.Services;
using MegaFilmes.Services.Dtos.FilmeDtos;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.API.Controllers;

[Controller]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;
    private readonly IClientService _clientService;

    public AdminController(IAdminService adminService, IClientService clientService)
    {
        _adminService = adminService;
        _clientService = clientService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto createFilmeDto)
    {
        var filme = _adminService.AdicionarFilme(createFilmeDto);
        return CreatedAtAction(nameof(BuscarFilmePorId), filme);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarFilmePorId(int id)
    {
        var filme = _clientService.BuscarFilmePorId(id);
        if (filme == null)
            return NotFound("Filme não localizado");

        return Ok(filme);
    }
}
