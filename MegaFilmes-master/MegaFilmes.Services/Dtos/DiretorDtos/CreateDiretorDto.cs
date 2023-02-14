using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Services.Dtos.DiretorDtos;

public class CreateDiretorDto
{
    [Required]
    public string Nome { get; set; }
}
