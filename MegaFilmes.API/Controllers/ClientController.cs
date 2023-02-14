using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.AvaliacaoDtos;
using MegaFilmes.Services.Dtos.FilmeDtos;
using MegaFilmes.Services;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult BuscarTodosFilmes()
        {
            var filmes = _service.BuscarTodosFilmes();
            return Ok(filmes);

        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilmePorId(int id)
        {
            var filme = _service.BuscarFilmePorId(id);
            if (filme == null)
                return NotFound("Filme não localizado");

            return Ok(filme);

        }

        [HttpGet("{param}")]
        public IActionResult BuscarFilmesPorParametro(string param)
        {
            var filmes = _service.BuscarFilmesPorParametro(param);
            if (filmes == null)
                return NotFound("Filme não localizado");

            return Ok(filmes);
        }

        [HttpPost]
        public IActionResult AvaliarFilme([FromBody] CreateAvaliacaoDto createAvaliacaoDto)
        {
            _service.AvaliarFilme(createAvaliacaoDto);
        }

        public IActionResult BuscarAvaliacoesDoFilme(Filme filme)
        {
            var avaliacoes = _service.BuscarAvaliacoesDoFilme(filme);
            if (avaliacoes == null)
                return NotFound("Avaliação não localizada");

            return Ok(avaliacoes);
        }

        public void EditarAvaliacao(Avaliacao avaliacao)
        {
            _service.EditarAvaliacao(avaliacao);
        }

        public void DeletarAvaliacao(Avaliacao avaliacao)
        {
            _service.DeletarAvaliacao(avaliacao);
        }
    }
}
