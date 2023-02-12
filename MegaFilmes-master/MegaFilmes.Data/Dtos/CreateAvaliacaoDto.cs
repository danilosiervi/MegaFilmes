using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Data.Dtos;

public class CreateAvaliacaoDto
{
    [Required]
    [Range(1,5, ErrorMessage = "A nota da avaliacao deve estar entre 1 e 5.")]
    public int Nota { get; set; }

    [Required]
    public int AvaliacaoId { get; set; }

    [Required]
    // Id do filme. Mudar para IdFilme a propriedade?
    public int Id { get; set; }

    [StringLength(200,ErrorMessage = "O comentário deve possuir no máximo 200 caracteres.")]
    public string Comentario { get; set; }
}