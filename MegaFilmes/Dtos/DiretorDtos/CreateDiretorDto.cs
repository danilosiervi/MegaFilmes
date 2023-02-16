using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Dtos.DiretorDtos;

public class CreateDiretorDto
{
    [Required]
    public string Nome { get; set; }
}
