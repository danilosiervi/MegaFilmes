using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Services.Dtos.AtorDtos;

public class CreateAtorDto
{
    [Required]
    public string Nome { get; set; }
}
