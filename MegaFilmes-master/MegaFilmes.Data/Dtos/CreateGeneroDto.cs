using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Data.Dtos;

public class CreateGeneroDto
{

    [Required(ErrorMessage = "O gênero do filme é obrigatório.")]
    public string Genero { get; set; }

    // N precisaria do Filme para criar o gênero
    public virtual Filme Filme { get; set; }
}