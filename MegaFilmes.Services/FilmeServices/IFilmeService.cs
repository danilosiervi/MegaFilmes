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

    ReadFilmeDto? EditarFilme(int id);

    ReadFilmeDto? DeletarFilme(int id);
}
