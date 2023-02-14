using AutoMapper;
using FluentResults;
using MegaFilmes.Data.Repos.AdminRepos;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.AtorDtos;
using MegaFilmes.Services.Dtos.DiretorDtos;
using MegaFilmes.Services.Dtos.FilmeDtos;
using MegaFilmes.Services.Dtos.GeneroDtos;

namespace MegaFilmes.Services;

public class AdminService
{
    private readonly IAdminRepository _adminRepos;
    private readonly IMapper _mapper;

    public AdminService(IAdminRepository adminRepos, IMapper mapper)
    {
        _adminRepos = adminRepos;
        _mapper = mapper;
    }

    public ReadFilmeDto AdicionarFilme(CreateFilmeDto createFilmeDto)
    {
        var filme = _mapper.Map<Filme>(createFilmeDto);
        _adminRepos.AdicionarFilme(filme);

        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return filmeDto;
    }
    public Result EditarFilme(Filme filme)
    {
        _adminRepos.EditarFilme(filme);
        return Result.Ok();
    }
    public Result DeletarFilme(Filme filme)
    {
        _adminRepos.DeletarFilme(filme);
        return Result.Ok();
    }

    public ReadDiretorDto AdicionarDiretor(CreateDiretorDto createDiretorDto)
    {
        var diretor = _mapper.Map<Diretor>(createDiretorDto);
        _adminRepos.AdicionarDiretor(diretor);

        var diretorDto = _mapper.Map<ReadDiretorDto>(diretor);
        return diretorDto;
    }
    public Result EditarDiretor(Diretor diretor)
    {
        _adminRepos.EditarDiretor(diretor);
        return Result.Ok();
    }
    public Result DeletarDiretor(Diretor diretor)
    {
        _adminRepos.DeletarDiretor(diretor);
        return Result.Ok();
    }

    public ReadGeneroDto AdicionarGenero(CreateGeneroDto createGeneroDto)
    {
        var genero = _mapper.Map<Genero>(createGeneroDto);
        _adminRepos.AdicionarGenero(genero);

        var generoDto = _mapper.Map<ReadGeneroDto>(genero);
        return generoDto;
    }
    public Result EditarGenero(Genero genero)
    {
        _adminRepos.EditarGenero(genero);
        return Result.Ok();
    }
    public Result DeletarGenero(Genero genero)
    {
        _adminRepos.DeletarGenero(genero);
        return Result.Ok();
    }

    public ReadAtorDto AdicionarAtor(CreateAtorDto createAtorDto)
    {
        var ator = _mapper.Map<Ator>(createAtorDto);
        _adminRepos.AdicionarAtor(ator);

        var atorDto = _mapper.Map<ReadAtorDto>(ator);
        return atorDto;
    }
    public Result EditarAtor(Ator ator)
    {
        _adminRepos.EditarAtor(ator);
        return Result.Ok();
    }
    public Result DeletarAtor(Ator ator)
    {
        _adminRepos.DeletarAtor(ator);
        return Result.Ok();
    }
}
