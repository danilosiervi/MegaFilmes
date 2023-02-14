using AutoMapper;
using MegaFilmes.Data.Daos;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.AvaliacaoDtos;

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
            .Select(a => _mapper.Map<ReadAvaliacaoDto>(a));
    }

    public ReadAvaliacaoDto? BuscarAvaliacaoPorId(int id)
    {
        return _mapper.Map<ReadAvaliacaoDto>(_dao.GetById(id));
    }

    public ReadAvaliacaoDto? DeletarAvaliacao(int id)
    {
        var avaliacao = BuscarAvaliacaoPorId(id);

        _dao.Delete(_mapper.Map<Avaliacao>(avaliacao));
        return avaliacao;
    }
}
