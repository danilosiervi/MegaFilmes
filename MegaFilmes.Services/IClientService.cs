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

    Result AvaliarFilme(CreateAvaliacaoDto avaliacao);

    IEnumerable<ReadAvaliacaoDto> BuscarAvaliacoesDoFilme(Filme filme);

    Result EditarAvaliacao(Avaliacao avaliacao);

    Result DeletarAvaliacao(Avaliacao avaliacao);
}
