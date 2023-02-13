using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.AvaliacaoDtos;
using MegaFilmes.Services.Dtos.FilmeDtos;

namespace MegaFilmes.Services;

public interface IClientService
{
    IEnumerable<ReadFilmeDto> BuscarTodosFilmes();

    ReadFilmeDto? BuscarFilmePorId(int id);

    IEnumerable<ReadFilmeDto> BuscarFilmesPorParametro(string param);

    void AvaliarFilme(CreateAvaliacaoDto avaliacao);

    IEnumerable<ReadAvaliacaoDto> BuscarAvaliacoesDoFilme(Filme filme);

    void EditarAvaliacao(Avaliacao avaliacao);

    void DeletarAvaliacao(Avaliacao avaliacao);
}
