using AutoMapper;
using MegaFilmes.Dtos.FilmeAtorDtos;
using MegaFilmes.Models;

namespace MegaFilmes.Profiles;

public class FilmeAtorProfile : Profile
{
	public FilmeAtorProfile()
	{
		CreateMap<CreateFilmeAtorDto, FilmeAtor>();
	}
}
