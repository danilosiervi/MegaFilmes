using AutoMapper;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.AtorDtos;

namespace MegaFilmes.Services.Profiles;

public class AtorProfile : Profile
{
	public AtorProfile()
	{
		CreateMap<Ator, ReadAtorDto>();
		CreateMap<CreateAtorDto, Ator>();
	}
}
