using FluentResults;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.GeneroDtos;

namespace MegaFilmes.Services.GeneroServices;

public interface IGeneroService
{
    ReadGeneroDto AdicionarGenero(CreateGeneroDto filme);

    IEnumerable<ReadGeneroDto> BuscarTodosGeneros();

    ReadGeneroDto? BuscarGeneroPorId(int id);

    Result EditarGenero(Genero filme);

    Result DeletarGenero(Genero filme);
}
