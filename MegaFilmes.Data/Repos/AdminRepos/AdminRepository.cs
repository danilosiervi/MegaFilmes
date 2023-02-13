using MegaFilmes.Data.Daos;
using MegaFilmes.Models;

namespace MegaFilmes.Data.Repos.AdminRepos;

public class AdminRepository
{
    private readonly IDao<Filme> _filmeDao;
    private readonly IDao<Diretor> _diretorDao;
    private readonly IDao<Genero> _generoDao;
    private readonly IDao<Ator> _atorDao;

    public AdminRepository(IDao<Filme> filmeDao, IDao<Diretor> diretorDao, IDao<Genero> generoDao, IDao<Ator> atorDao)
    {
        _filmeDao = filmeDao;
        _diretorDao = diretorDao;
        _generoDao = generoDao;
        _atorDao = atorDao;
    }

    public void AdicionarFilme(Filme filme) => _filmeDao.Add(filme);
    public void EditarFilme(Filme filme) => _filmeDao.Update(filme);
    public void DeletarFilme(Filme filme) => _filmeDao.Delete(filme);

    public void AdicionarDiretor(Diretor diretor) => _diretorDao.Add(diretor);
    public void EditarDiretor(Diretor diretor) => _diretorDao.Update(diretor);
    public void DeletarDiretor(Diretor diretor) => _diretorDao.Delete(diretor);

    public void AdicionarGenero(Genero genero) => _generoDao.Add(genero);
    public void EditarGenero(Genero genero)
    {

    }
    public void DeletarGenero(Genero genero)
    {

    }

    public void AdicionarAtor(Ator ator)
    {

    }
    public void EditarAtor(Ator ator)
    {

    }
    public void DeletarAtor(Ator ator)
    {

    }
}
