using MegaFilmes.Models;

namespace MegaFilmes.Data.Repos.FilmeRepos;

public interface IFilmeRepository
{
    void AdicionarFilme(Filme filme);

    IEnumerable<Filme> BuscarTodosFilmes();

    Filme? BuscarFilmePorId(int id);

    void AvaliarFilme(Filme filme, Avaliacao avaliacao);

    void AtualizarFilme(Filme filme);

    void DeletarFilme(Filme filme);
}
