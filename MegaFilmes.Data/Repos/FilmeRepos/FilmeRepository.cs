using MegaFilmes.Data.Daos;
using MegaFilmes.Models;

namespace MegaFilmes.Data.Repos.FilmeRepos;

public class FilmeRepository : IFilmeRepository
{
    private readonly IDao<Filme> _filmeDao;
    private readonly IDao<Avaliacao> _avaliacaoDao;

    public FilmeRepository(IDao<Filme> dao, IDao<Avaliacao> avaliacaoDao)
    {
        _filmeDao = dao;
        _avaliacaoDao = avaliacaoDao;
    }

    public void AdicionarFilme(Filme filme)
    {
        _filmeDao.Add(filme);
    }

    public IEnumerable<Filme> BuscarTodosFilmes()
    {
        return _filmeDao.GetAll();
    }

    public Filme? BuscarFilmePorId(int id)
    {
        return _filmeDao.GetById(id);
    }

    public void AvaliarFilme(Filme filme, Avaliacao avaliacao)
    {
        _avaliacaoDao.Add(avaliacao);
        _filmeDao.Add(filme);
    }

    public void AtualizarFilme(Filme filme)
    {
        _filmeDao.Update(filme);
    }

    public void DeletarFilme(Filme filme)
    {
        _filmeDao.Delete(filme);
    }
}
