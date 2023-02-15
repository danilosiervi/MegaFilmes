using AutoMapper;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.DiretorDtos;

namespace MegaFilmes.Services.Profiles;

public class DiretorProfile : Profile
{
	public DiretorProfile()
	{
		CreateMap<Diretor, ReadDiretorDto>();
		CreateMap<ReadDiretorDto, Diretor>();
		CreateMap<CreateDiretorDto, Diretor>();
	}
}
