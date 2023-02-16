using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Dtos.AtorDtos;

public class CreateAtorDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }
}
