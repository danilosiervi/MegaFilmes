using MegaFilmes.Models;

namespace MegaFilmes.Data.Repos.AdminRepos;

public interface IAdminRepository
{
    void AdicionarFilme(Filme filme);
    void EditarFilme(Filme filme);
    void DeletarFilme(Filme filme);

    void AdicionarDiretor(Diretor diretor);
    void EditarDiretor(Diretor diretor);
    void DeletarDiretor(Diretor diretor);

    void AdicionarGenero(Genero genero);
    void EditarGenero(Genero genero);
    void DeletarGenero(Genero genero);

    void AdicionarAtor(Ator ator);
    void EditarAtor(Ator ator);
    void DeletarAtor(Ator ator);
}
