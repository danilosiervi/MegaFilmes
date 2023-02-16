using AutoMapper;
using MegaFilmes.Dtos.DiretorDtos;
using MegaFilmes.Models;

namespace MegaFilmes.Profiles;

public class DiretorProfile : Profile
{
    public DiretorProfile()
    {
        CreateMap<Diretor, ReadDiretorDto>();
        CreateMap<ReadDiretorDto, Diretor>();
        CreateMap<CreateDiretorDto, Diretor>();
    }
}
