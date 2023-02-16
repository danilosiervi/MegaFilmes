using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Dtos.GeneroDtos;

public class CreateGeneroDto
{
    [Required]
    public string Nome { get; set; }
}
