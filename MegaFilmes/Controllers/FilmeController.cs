using AutoMapper;
using MegaFilmes.Dtos.FilmeDtos;
using MegaFilmes.Models;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.Controllers;

[Controller]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public FilmeController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto createFilmeDto)
    {
        if (createFilmeDto == null) return BadRequest("Insira os dados do filme a ser criado");

        Filme filme = _mapper.Map<Filme>(createFilmeDto);

        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return CreatedAtAction(nameof(BuscarFilmePorId), new { id = filme.FilmeId }, filme);
    }

    [HttpGet]
    public ReadFilmesPaginadosDto BuscarTodosFilmes([FromQuery] int page = 0, [FromQuery] int take = 10)
    {
        int quantidade = _context.Filmes.Count();
        int paginas = quantidade / take;

        var listaDeFilmes = _context.Filmes.Skip(page).Take(take)
            .ToList();

        var listaDeFilmesDto = listaDeFilmes.ConvertAll(f => _mapper.Map<ReadFilmeDto>(f));

        return new ReadFilmesPaginadosDto
        {
            Filmes = listaDeFilmesDto,
            Pagina = page + 1,
            TotalDePaginas = paginas + 1,
            TotalDeFilmes = quantidade
        };
    }

    [HttpGet("{id}")]
    public IActionResult BuscarFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.FilmeId == id);
        if (filme == null) return NotFound($"Não foi encontrado um filme com id {id}");

        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    [HttpGet("Parameter/{param}")]
    public IActionResult BuscarFilmePorParametro(string param)
    {
        var filmes = _context.Filmes
            .Where(f =>
                f.Titulo.ToLower().Contains(param.ToLower()) ||
                f.Genero.Nome.ToLower().Contains(param.ToLower()) ||
                f.Diretor.Nome.ToLower().Contains(param.ToLower()))
            .ToList();
        if (filmes == null) return NotFound($"Não foi encontrado nenhum filme com {param}");

        var filmesDto = filmes.ConvertAll(f => _mapper.Map<ReadFilmeDto>(f));
        return Ok(filmesDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id, [FromBody] CreateFilmeDto createFilmeDto)
    {
        if (createFilmeDto == null) return BadRequest("Insira os dados do filme a ser atualizado");

        var filme = _context.Filmes.FirstOrDefault(f => f.FilmeId == id);
        if (filme == null) return NotFound($"Não foi encontrado um filme com id {id}");

        _mapper.Map(createFilmeDto, filme);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.FilmeId == id);
        if (filme == null) return NotFound($"Não foi encontrado um filme com id {id}");

        _context.Filmes.Remove(filme);
        _context.SaveChanges();

        return NoContent();
    }
}
