namespace MegaFilmes.Models;

public class Filme : Entity
{
    public Filme()
    {
        Elenco = new HashSet<FilmeAtor>();
        Avaliacoes = new HashSet<Avaliacao>();
    }

    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Ano { get; set; }

    public int DiretorId { get; set; }
    public int GeneroId { get; set; }

    public virtual Diretor Diretor { get; set; }
    public virtual Genero Genero { get; set; }
    public virtual ICollection<FilmeAtor> Elenco { get; set; }
    public virtual ICollection<Avaliacao> Avaliacoes { get; set; }

    public double MediaAvaliacoes => Avaliacoes.Sum(item => item.Nota) / Avaliacoes.Count;
}
