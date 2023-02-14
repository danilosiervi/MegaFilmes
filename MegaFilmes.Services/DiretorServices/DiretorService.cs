using AutoMapper;
using FluentResults;
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

    public Result DeletarDiretor(Diretor diretor)
    {
        try
        {
            _dao.Delete(diretor);
            return Result.Ok();
        }
        catch
        {
            return Result.Fail("Ocorreu um erro ao tentar deletar o diretor");
        }
    }

    public Result EditarDiretor(Diretor diretor)
    {
        try
        {
            _dao.Delete(diretor);
            return Result.Ok();
        }
        catch
        {
            return Result.Fail("Ocorreu um erro ao tentar editar o diretor");
        }
    }
}
