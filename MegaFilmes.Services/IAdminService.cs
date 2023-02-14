using MegaFilmes.Models;

namespace MegaFilmes.Services;

public interface IAdminService
{
    public void AdicionarFilme(Filme filme);
    public void EditarFilme(Filme filme);
    public void DeletarFilme(Filme filme);

    public void AdicionarDiretor(Diretor diretor);
    public void EditarDiretor(Diretor diretor);
    public void DeletarDiretor(Diretor diretor);

    public void AdicionarGenero(Genero genero);
    public void EditarGenero(Genero genero);
    public void DeletarGenero(Genero genero);

    public void AdicionarAtor(Ator ator);
    public void EditarAtor(Ator ator);
    public void DeletarAtor(Ator ator);
}
