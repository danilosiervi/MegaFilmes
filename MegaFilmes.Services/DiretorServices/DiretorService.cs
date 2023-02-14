using AutoMapper;
using MegaFilmes.Data.Daos;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.DiretorDtos;

namespace MegaFilmes.Services.DiretorServices;

public class DiretorService : IDiretorService
{
    private readonly IDao<Diretor> _dao;
    private readonly IMapper _mapper;

    public DiretorService(IDao<Diretor> dao, IMapper mapper)
    {
        _dao = dao;
        _mapper = mapper;
    }

    public ReadDiretorDto AdicionarDiretor(CreateDiretorDto createDiretorDto)
    {
        var diretor = _mapper.Map<Diretor>(createDiretorDto);
        _dao.Add(diretor);

        return _mapper.Map<ReadDiretorDto>(diretor);
    }

    public ReadDiretorDto? BuscarDiretorPorId(int id)
    {
        return _mapper.Map<ReadDiretorDto>(_dao.GetById(id));
    }

    public IEnumerable<ReadDiretorDto> BuscarTodosDiretores()
    {
        return _dao.GetAll()
            .Select(d => _mapper.Map<ReadDiretorDto>(d));
    }

    public ReadDiretorDto DeletarDiretor(int id)
    {
        var diretor = BuscarDiretorPorId(id);

        _dao.Delete(_mapper.Map<Diretor>(diretor));
        return diretor;
    }

    public ReadDiretorDto EditarDiretor(int id)
    {
        var diretor = BuscarDiretorPorId(id);

        _dao.Update(_mapper.Map<Diretor>(diretor));
        return diretor;
    }
}
