using MegaFilmes.Models;

namespace MegaFilmes.Dtos.FilmeDtos;

public class ReadFilmeDto
{
    public int FilmeId { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Ano { get; set; }

    public virtual Diretor Diretor { get; set; }
    public virtual Genero Genero { get; set; }
    public virtual ICollection<FilmeAtor> Elenco { get; set; }
}
