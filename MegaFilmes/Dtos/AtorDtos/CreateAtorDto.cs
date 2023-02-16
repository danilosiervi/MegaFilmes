using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Dtos.AtorDtos;

public class CreateAtorDto
{
    [Required]
    public string Nome { get; set; }
}
