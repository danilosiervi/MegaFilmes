using MegaFilmes.Data.Daos;
using MegaFilmes.Models;

namespace MegaFilmes.Data.Repos.FilmeRepos;

public class ClientRepository : IClientRepository
{
    private readonly IDao<Filme> _filmeDao;
    private readonly IDao<Avaliacao> _avaliacaoDao;

    public ClientRepository(IDao<Filme> dao, IDao<Avaliacao> avaliacaoDao)
    {
        _filmeDao = dao;
        _avaliacaoDao = avaliacaoDao;
    }

    public IEnumerable<Filme> BuscarTodosFilmes() => _filmeDao.GetAll();

    public Filme? BuscarFilmePorId(int id) => _filmeDao.GetById(id);

    public IEnumerable<Filme> BuscarFilmesPorParametro(string param)
    {
        var lower = param.ToLower();
        return _filmeDao.GetAll()
            .Where(f =>
                f.Genero.Nome.ToLower().Contains(lower) ||
                f.Titulo.ToLower().Contains(lower) ||
                f.Diretor.Nome.ToLower().Contains(lower));
    }

    public void AvaliarFilme(Avaliacao avaliacao) => _avaliacaoDao.Add(avaliacao);

    public Avaliacao? BuscarAvaliacaoPorId(int id) => _avaliacaoDao.GetById(id);

    public IEnumerable<Avaliacao> BuscarAvaliacoesDoFilme(Filme filme)
    {
        return _avaliacaoDao.GetAll()
            .Where(a => a.FilmeId == filme.Id);
    }

    public void EditarAvaliacao(Avaliacao avaliacao) => _avaliacaoDao.Update(avaliacao);

    public void DeletarAvaliacao(Avaliacao avaliacao) => _avaliacaoDao.Delete(avaliacao);
}
