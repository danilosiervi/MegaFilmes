using AutoMapper;
using FluentResults;
using MegaFilmes.Data.Repos.FilmeRepos;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.AvaliacaoDtos;
using MegaFilmes.Services.Dtos.FilmeDtos;

namespace MegaFilmes.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepos;
    private readonly IMapper _mapper;

    public ClientService(IClientRepository clientRepos, IMapper mapper)
    {
        _clientRepos = clientRepos;
        _mapper = mapper;
    }

    public IEnumerable<ReadFilmeDto> BuscarTodosFilmes()
    {
        var filmes = _clientRepos.BuscarTodosFilmes()
            .Select(f => _mapper.Map<ReadFilmeDto>(f));

        if (filmes == null) return null;
        return filmes;
    }

    public ReadFilmeDto? BuscarFilmePorId(int id)
    {
        var filme = _clientRepos.BuscarFilmePorId(id);

        if (filme == null) return null;
        return _mapper.Map<ReadFilmeDto>(filme);
    }

    public IEnumerable<ReadFilmeDto> BuscarFilmesPorParametro(string param)
    {
        var filmes = _clientRepos.BuscarFilmesPorParametro(param)
            .Select(f => _mapper.Map<ReadFilmeDto>(f));

        if (filmes == null) return null;
        return filmes;
    }
     
    public ReadAvaliacaoDto AvaliarFilme(CreateAvaliacaoDto createAvaliacaoDto)
    {
        var avaliacao = _mapper.Map<Avaliacao>(createAvaliacaoDto);
        _clientRepos.AvaliarFilme(avaliacao);

        var avaliacaoDto = _mapper.Map<ReadAvaliacaoDto>(avaliacao);
        return avaliacaoDto;
    }

    public ReadAvaliacaoDto? BuscarAvaliacaoPorId(int id)
    {
        var avaliacao = _clientRepos.BuscarAvaliacaoPorId(id);

        if (avaliacao == null) return null;
        return _mapper.Map<ReadAvaliacaoDto>(avaliacao);
    }

    public IEnumerable<ReadAvaliacaoDto> BuscarAvaliacoesDoFilme(Filme filme)
    {
        var avaliacoes = _clientRepos.BuscarAvaliacoesDoFilme(filme)
            .Select(a => _mapper.Map<ReadAvaliacaoDto>(a));

        if (avaliacoes == null) return null;
        return avaliacoes;
    }

    public Result EditarAvaliacao(Avaliacao avaliacao)
    {
        _clientRepos.EditarAvaliacao(avaliacao);
        return Result.Ok();
    }

    public Result DeletarAvaliacao(Avaliacao avaliacao)
    {
        _clientRepos.DeletarAvaliacao(avaliacao);
        return Result.Ok();
    }
}
