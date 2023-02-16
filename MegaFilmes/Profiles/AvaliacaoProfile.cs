using AutoMapper;
using MegaFilmes.Dtos.AvaliacaoDtos;
using MegaFilmes.Models;

namespace MegaFilmes.Profiles;

public class AvaliacaoProfile : Profile
{
    public AvaliacaoProfile()
    {
        CreateMap<Avaliacao, ReadAvaliacaoDto>();
        CreateMap<ReadAvaliacaoDto, Avaliacao>();
        CreateMap<CreateAvaliacaoDto, Avaliacao>();
    }
}
