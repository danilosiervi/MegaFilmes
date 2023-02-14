using AutoMapper;
using FluentResults;
using MegaFilmes.Data.Daos;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.GeneroDtos;

namespace MegaFilmes.Services.GeneroServices;

public class GeneroService : IGeneroService
{
    private readonly IDao<Genero> _dao;
    private readonly IMapper _mapper;

    public GeneroService(IDao<Genero> dao, IMapper mapper)
    {
        _dao = dao;
        _mapper = mapper;
    }

    public ReadGeneroDto AdicionarGenero(CreateGeneroDto createGeneroDto)
    {
        var genero = _mapper.Map<Genero>(createGeneroDto);
        _dao.Add(genero);

        return _mapper.Map<ReadGeneroDto>(genero);
    }

    public ReadGeneroDto? BuscarGeneroPorId(int id)
    {
        return _mapper.Map<ReadGeneroDto>(_dao.GetById(id));
    }

    public IEnumerable<ReadGeneroDto> BuscarTodosGeneros()
    {
        return _dao.GetAll()
            .Select(g => _mapper.Map<ReadGeneroDto>(g));
    }

    public Result DeletarGenero(Genero genero)
    {
        try
        {
            _dao.Delete(genero);
            return Result.Ok();
        }
        catch
        {
            return Result.Fail("Ocorreu um erro ao tentar deletar o gênero");
        }
    }

    public Result EditarGenero(Genero genero)
    {
        try
        {
            _dao.Update(genero);
            return Result.Ok();
        }
        catch
        {
            return Result.Fail("Ocorreu um erro ao tentar editar o gênero");
        }
    }
}
