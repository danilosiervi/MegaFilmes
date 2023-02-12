using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Data.Dtos;
{

    public class CreateDiretorDto
    {
    [Required]
    // Colocar alguma restricao de tamanho?
    public string Nome { get; set; }

    }
}