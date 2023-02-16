using AutoMapper;
using MegaFilmes.Dtos.AtorDtos;
using MegaFilmes.Models;

namespace MegaFilmes.Profiles;

public class AtorProfile : Profile
{
    public AtorProfile()
    {
        CreateMap<Ator, ReadAtorDto>();
        CreateMap<ReadAtorDto, Ator>();
        CreateMap<CreateAtorDto, Ator>();
    }
}
