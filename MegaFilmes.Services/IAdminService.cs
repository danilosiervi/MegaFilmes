using FluentResults;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.AtorDtos;
using MegaFilmes.Services.Dtos.DiretorDtos;
using MegaFilmes.Services.Dtos.FilmeDtos;
using MegaFilmes.Services.Dtos.GeneroDtos;

namespace MegaFilmes.Services;

public interface IAdminService
{
    ReadFilmeDto AdicionarFilme(Filme filme);
    Result EditarFilme(Filme filme);
    Result DeletarFilme(Filme filme);

    ReadDiretorDto AdicionarDiretor(Diretor diretor);
    Result EditarDiretor(Diretor diretor);
    Result DeletarDiretor(Diretor diretor);

    ReadGeneroDto AdicionarGenero(Genero genero);
    Result EditarGenero(Genero genero);
    Result DeletarGenero(Genero genero);

    ReadAtorDto AdicionarAtor(Ator ator);
    Result EditarAtor(Ator ator);
    Result DeletarAtor(Ator ator);
}
