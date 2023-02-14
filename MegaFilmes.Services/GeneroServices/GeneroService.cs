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

    public ReadGeneroDto AdicionarGenero(CreateGeneroDto filme)
    {
        throw new NotImplementedException();
    }

    public ReadGeneroDto? BuscarGeneroPorId(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ReadGeneroDto> BuscarTodosGeneros()
    {
        throw new NotImplementedException();
    }

    public Result DeletarGenero(Genero filme)
    {
        throw new NotImplementedException();
    }

    public Result EditarGenero(Genero filme)
    {
        throw new NotImplementedException();
    }
}
