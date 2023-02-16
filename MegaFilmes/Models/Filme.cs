using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Models;

public class Filme
{
    public Filme()
    {
        Elenco = new HashSet<FilmeAtor>();
        Avaliacoes = new HashSet<Avaliacao>();
    }

    [Key]
    public int FilmeId { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Ano { get; set; }

    public int DiretorId { get; set; }
    public int GeneroId { get; set; }

    public virtual Diretor Diretor { get; set; }
    public virtual Genero Genero { get; set; }
    public virtual ICollection<FilmeAtor> Elenco { get; set; }
    public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
}
