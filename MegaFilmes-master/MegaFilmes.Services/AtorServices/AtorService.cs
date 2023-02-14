using AutoMapper;
using MegaFilmes.Data.Daos;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.AtorDtos;

namespace MegaFilmes.Services.AtorServices;

public class AtorService : IAtorService
{
    private readonly IDao<Ator> _dao;
    private readonly IMapper _mapper;

    public AtorService(IDao<Ator> dao, IMapper mapper)
    {
        _dao = dao;
        _mapper = mapper;
    }

    public ReadAtorDto AdicionarAtor(CreateAtorDto createAtorDto)
    {
        var ator = _mapper.Map<Ator>(createAtorDto);
        _dao.Add(ator);

        return _mapper.Map<ReadAtorDto>(ator);
    }
    
    // FilmeAtor ou Ator? 
    public ReadAtorDto? BuscarAtorPorId(int id)
    {
        return _mapper.Map<ReadAtorDto>(_dao.GetById(id));
    }

    public IEnumerable<ReadAtorDto> BuscarTodosAtores()
    {
        return _dao.GetAll()
            .Select(d => _mapper.Map<ReadAtorDto>(d));
    }

    public ReadAtorDto DeletarAtor(int id)
    {
        var ator = BuscarAtorPorId(id);

        _dao.Delete(_mapper.Map<Ator>(ator));
        return ator;
    }

    public ReadAtorDto EditarAtor(int id)
    {
        var ator = BuscarAtorPorId(id);

        _dao.Update(_mapper.Map<Ator>(ator));
        return ator;
    }
}