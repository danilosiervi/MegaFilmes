using AutoMapper;
using MegaFilmes.Data.Daos;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.GeneroDtos;

namespace MegaFilmes.Services.AvaliacaoServices;

public class AvaliacaoService : IAvaliacaoService
{
    private readonly IDao<Avaliacao> _dao;
    private readonly IMapper _mapper;

    public AvaliacaoService(IDao<Avaliacao> dao, IMapper mapper)
    {
        _dao = dao;
        _mapper = mapper;
    }

    public ReadAvaliacaoDto AdicionarAvaliacao(CreateAvaliacaoDto createAvaliacaoDto)
    {
        var avaliacao = _mapper.Map<Avaliacao>(createAvaliacaoDto);
        _dao.Add(avaliacao);

        return _mapper.Map<ReadAvaliacaoDto>(avaliacao);
    }

    public IEnumerable<ReadAvaliacaoDto> BuscarTodasAvaliacoes()
    {
        return _dao.GetAll()
            .Select(g => _mapper.Map<ReadAvaliacaoDto>(g));
    }

    //public ReadAvaliacaoDto? BuscarAvaliacoesPorFilme(int id)
    //{
    //    return _mapper.Map<ReadDto>(_dao.GetAvaliacaoByFilm(id));
    //}

}