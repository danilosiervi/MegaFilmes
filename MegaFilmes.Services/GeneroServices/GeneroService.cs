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

    public ReadGeneroDto? DeletarGenero(int id)
    {
        var genero = BuscarGeneroPorId(id);

        _dao.Update(_mapper.Map<Genero>(genero));
        return genero;
    }

    public ReadGeneroDto? EditarGenero(int id)
    {
        var genero = BuscarGeneroPorId(id);

        _dao.Update(_mapper.Map<Genero>(genero));
        return genero;
    }
}
