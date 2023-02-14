using FluentResults;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.AtorDtos;
using MegaFilmes.Services.Dtos.DiretorDtos;
using MegaFilmes.Services.Dtos.FilmeDtos;
using MegaFilmes.Services.Dtos.GeneroDtos;

namespace MegaFilmes.Services;

public interface IAdminService
{
    ReadFilmeDto AdicionarFilme(CreateFilmeDto filme);
    Result EditarFilme(Filme filme);
    Result DeletarFilme(Filme filme);

    ReadDiretorDto AdicionarDiretor(CreateDiretorDto diretor);
    Result EditarDiretor(Diretor diretor);
    Result DeletarDiretor(Diretor diretor);

    ReadGeneroDto AdicionarGenero(CreateGeneroDto genero);
    Result EditarGenero(Genero genero);
    Result DeletarGenero(Genero genero);

    ReadAtorDto AdicionarAtor(CreateAtorDto ator);
    Result EditarAtor(Ator ator);
    Result DeletarAtor(Ator ator);
}
