using AutoMapper;
using MegaFilmes.Dtos.GeneroDtos;
using MegaFilmes.Models;

namespace MegaFilmes.Profiles;

public class GeneroProfile : Profile
{
    public GeneroProfile()
    {
        CreateMap<Genero, ReadGeneroDto>();
        CreateMap<ReadGeneroDto, Genero>();
        CreateMap<CreateGeneroDto, Genero>();
    }
}
