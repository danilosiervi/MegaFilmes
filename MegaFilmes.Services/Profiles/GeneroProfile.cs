using AutoMapper;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.GeneroDtos;

namespace MegaFilmes.Services.Profiles;

public class GeneroProfile : Profile
{
	public GeneroProfile()
	{
		CreateMap<Genero, ReadGeneroDto>();
		CreateMap<CreateGeneroDto, Genero>();
	}
}
