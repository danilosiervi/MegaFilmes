using AutoMapper;
using MegaFilmes.Models;
using Microsoft.AspNetCore.Mvc;
using MegaFilmes.Data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.API.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class FilmeController : ControllerBase
    {
        private MegaFilmesDbContext _context;
        private IMapper _mapper;

        public FilmeController(IMapper mapper, MegaFilmesDbContext context)
        {
            _context = context;
            _mapper = mapper;

        }


        [HttpPost]
        public IActionResult AdicionaFilme(
        [FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId),
                new { id = filme.Id },
                filme);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            var filme = _context.Filmes
                .FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);
        }

        [HttpGet]
        public IEnumerable<ReadFilmeDto> RecuperaFilmePorGenero([FromQuery] int skip = 0,
        [FromQuery] int take = 50,
        [FromQuery] string? Genero = null)
        {
            if (Genero == null)
            {
                return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take).ToList());
            }
            return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take).Where(filme => filme.Genero
                    .Any(genero => sessao.Cinema.Nome == nomeCinema)).ToList());

        }
        //[HttpGet("{id}")]
        //public IActionResult RecuperaFilmePorGenero(int id, [FromBody] CreateGeneroDto generoDto)
        //{
        //    var filme = _context.Filmes
        //      .FirstOrDefault(filme => filme.Genero == Genero);
        //    if (filme == null) return NotFound();
        //    var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        //    return Ok(filmeDto);

        //}

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorDiretor(int id, [FromBody] CreateDiretorDto diretorDto)
        {


        }
    }


}