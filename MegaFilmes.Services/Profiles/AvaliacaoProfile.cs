using AutoMapper;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.AvaliacaoDtos;

namespace MegaFilmes.Services.Profiles;

public class AvaliacaoProfile : Profile
{
	public AvaliacaoProfile()
	{
		CreateMap<Avaliacao, ReadAvaliacaoDto>();
		CreateMap<CreateAvaliacaoDto, Avaliacao>();
	}
}
