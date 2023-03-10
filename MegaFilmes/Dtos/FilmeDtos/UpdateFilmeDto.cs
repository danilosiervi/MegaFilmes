using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Dtos.FilmeDtos;

public class UpdateFilmeDto
{
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "A descricao é obrigatória.")]
    public string Descricao { get; set; }

    [Required]
    [Range(1895, 2023, ErrorMessage = "O ano é obrigatório e deve estar entre 1895 e o ano atual.")]
    public int Ano { get; set; }

    [Required(ErrorMessage = "O diretor do filme é obrigatório")]
    public int DiretorId { get; set; }
}
