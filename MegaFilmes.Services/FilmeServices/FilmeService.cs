using AutoMapper;
using MegaFilmes.Data.Daos;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.FilmeDtos;

namespace MegaFilmes.Services.FilmeServices;

public class FilmeService : IFilmeService
{
    private readonly IDao<Filme> _dao;
    private readonly IMapper _mapper;

    public FilmeService(IDao<Filme> dao, IMapper mapper)
    {
        _dao = dao;
        _mapper = mapper;
    }

    public ReadFilmeDto AdicionarFilme(CreateFilmeDto createFilmeDto)
    {
        var filme = _mapper.Map<Filme>(createFilmeDto);
        _dao.Add(filme);

        return _mapper.Map<ReadFilmeDto>(filme);
    }

    public ReadFilmeDto? BuscarFilmePorId(int id)
    {
        return _mapper.Map<ReadFilmeDto>(_dao.GetById(id));
    }

    public IEnumerable<ReadFilmeDto> BuscarFilmesPorParametro(string param)
    {
        var lower = param.ToLower();
        var filmes = _dao.GetAll()
            .Where(f =>
                f.Genero.Nome.ToLower().Contains(lower) ||
                f.Titulo.ToLower().Contains(lower) ||
                f.Diretor.Nome.ToLower().Contains(lower))
            .Select(f => _mapper.Map<ReadFilmeDto>(f));

        return filmes;
    }

    public IEnumerable<ReadFilmeDto> BuscarTodosFilmes()
    {
        return _dao.GetAll()
            .Select(f => _mapper.Map<ReadFilmeDto>(f));
    }

    public ReadFilmeDto? DeletarFilme(int id)
    {
        var filme = BuscarFilmePorId(id);

        _dao.Delete(_mapper.Map<Filme>(filme));
        return filme;
    }

    public ReadFilmeDto? EditarFilme(int id)
    {
        var filme = BuscarFilmePorId(id);

        _dao.Update(_mapper.Map<Filme>(filme));
        return filme;
    }
}
