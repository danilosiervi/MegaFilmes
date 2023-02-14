using FluentResults;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.GeneroDtos;

namespace MegaFilmes.Services.GeneroServices;

public interface IGeneroService
{
    ReadGeneroDto AdicionarGenero(CreateGeneroDto createGeneroDto);

    IEnumerable<ReadGeneroDto> BuscarTodosGeneros();

    ReadGeneroDto? BuscarGeneroPorId(int id);

    ReadGeneroDto? EditarGenero(int id);

    ReadGeneroDto? DeletarGenero(int id);
}
