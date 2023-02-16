using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Dtos.DiretorDtos;

public class CreateDiretorDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }
}
