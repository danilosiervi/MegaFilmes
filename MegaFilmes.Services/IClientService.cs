using FluentResults;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.AvaliacaoDtos;
using MegaFilmes.Services.Dtos.FilmeDtos;

namespace MegaFilmes.Services;

public interface IClientService
{
    IEnumerable<ReadFilmeDto> BuscarTodosFilmes();

    ReadFilmeDto? BuscarFilmePorId(int id);

    IEnumerable<ReadFilmeDto> BuscarFilmesPorParametro(string param);

    ReadAvaliacaoDto AvaliarFilme(CreateAvaliacaoDto avaliacao);

    ReadAvaliacaoDto? BuscarAvaliacaoPorId(int id);

    IEnumerable<ReadAvaliacaoDto> BuscarAvaliacoesDoFilme(Filme filme);

    Result EditarAvaliacao(Avaliacao avaliacao);

    Result DeletarAvaliacao(Avaliacao avaliacao);
}
