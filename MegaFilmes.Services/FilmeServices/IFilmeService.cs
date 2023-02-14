using FluentResults;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.FilmeDtos;

namespace MegaFilmes.Services.FilmeServices;

public interface IFilmeService
{
    ReadFilmeDto AdicionarFilme(CreateFilmeDto createFilmeDto);

    IEnumerable<ReadFilmeDto> BuscarTodosFilmes();

    ReadFilmeDto? BuscarFilmePorId(int id);

    IEnumerable<ReadFilmeDto> BuscarFilmesPorParametro(string param);

    Result EditarFilme(Filme filme);

    Result DeletarFilme(Filme filme);
}
