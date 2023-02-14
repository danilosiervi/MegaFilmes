using AutoMapper;
using FluentResults;
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

    public Result DeletarFilme(Filme filme)
    {
        try
        {
            _dao.Delete(filme);
            return Result.Ok();
        }
        catch
        {
            return Result.Fail("Ocorreu um erro ao tentar deletar o filme");
        }
    }

    public Result EditarFilme(Filme filme)
    {
        try
        {
            _dao.Update(filme);
            return Result.Ok();
        }
        catch
        {
            return Result.Fail("Ocorreu um erro ao tentar editar o filme");
        }
    }
}
