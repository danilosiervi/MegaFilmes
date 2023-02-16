using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Dtos.GeneroDtos;

public class CreateGeneroDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }
}
