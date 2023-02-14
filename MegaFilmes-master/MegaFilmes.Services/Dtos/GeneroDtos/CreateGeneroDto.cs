using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Services.Dtos.GeneroDtos;

public class CreateGeneroDto
{
    [Required]
    public string Nome { get; set; }
}
