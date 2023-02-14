﻿using FluentResults;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.DiretorDtos;

namespace MegaFilmes.Services.DiretorServices;

public interface IDiretorService
{
    ReadDiretorDto AdicionarDiretor(CreateDiretorDto createDiretorDto);

    IEnumerable<ReadDiretorDto> BuscarTodosDiretores();

    ReadDiretorDto? BuscarDiretorPorId(int id);

    ReadDiretorDto? EditarDiretor(int id);

    ReadDiretorDto? DeletarDiretor(int id);
}