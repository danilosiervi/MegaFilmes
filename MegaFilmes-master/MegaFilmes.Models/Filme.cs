namespace MegaFilmes.Models;

public class Filme
{
    public Filme()
    {
        Elenco = new HashSet<Ator>();
        Avaliacoes = new HashSet<Avaliacao>();
    }

    public int Id { get; set; }
    public string Titulo { get; set; }
    public int Ano { get; set; }
    public string Descricao{ get; set; }

    public int DiretorId { get; set; }
    public int GeneroId { get; set; }

    public virtual Diretor Diretor { get; set; }
    public virtual Genero Genero { get; set; }
    public virtual ICollection<Ator> Elenco { get; set; }
    public virtual ICollection<Avaliacao> Avaliacoes { get; set; }

    public double MediaAvaliacoes => Avaliacoes.Sum(item => item.Nota) / Avaliacoes.Count;
}
