namespace MegaFilmes.Models;

public class Ator
{
    public Ator()
    {
        Filmes = new HashSet<Filme>();
    }

    public int AtorId { get; set; }
    public string Nome { get; set; }

    public virtual ICollection<Filme> Filmes { get; set; }
}
