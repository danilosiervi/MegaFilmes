using MegaFilmes.Models;

namespace MegaFilmes.Data.Repos.FilmeRepos;

public interface IClientRepository
{
    IEnumerable<Filme> BuscarTodosFilmes();

    Filme? BuscarFilmePorId(int id);

    IEnumerable<Filme> BuscarFilmesPorParametro(string param);

    void AvaliarFilme(Avaliacao avaliacao);

    void EditarAvaliacao(Avaliacao avaliacao);

    void DeletarAvaliacao(Avaliacao avaliacao);
}
