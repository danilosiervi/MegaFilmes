using AutoMapper;
using MegaFilmes.Models;
using MegaFilmes.Services.Dtos.FilmeDtos;

namespace MegaFilmes.Services.Profiles;

public class FilmeProfile : Profile
{
	public FilmeProfile()
	{
		CreateMap<Filme, ReadFilmeDto>()
			.ForMember(fDto => fDto.Diretor, opts => opts.MapFrom(f => f.Diretor))
			.ForMember(fDto => fDto.Genero, opts => opts.MapFrom(f => f.Genero));

		CreateMap<ReadFilmeDto, Filme>();
		CreateMap<CreateFilmeDto, Filme>();
	}
}
