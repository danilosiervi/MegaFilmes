using FluentResults;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.AtorDtos;

namespace MegaFilmes.Services.AtorServices;

public interface IAtorService
{
    ReadAtorDto AdicionarDiretor(CreateAtorDto createAtorDto);

    IEnumerable<ReadAtorDto> BuscarTodosAtores();

    ReadAtorDto? BuscarAtorPorId(int id);

    ReadAtorDto? EditarAtor(int id);

    ReadAtorDto? DeletarAtor(int id);
}