namespace MegaFilmes.Models;

public class Genero
{
    public Genero()
    {
        Filmes = new HashSet<Filme>();
    }

    public int GeneroId { get; set; }
    public string Nome { get; set; }

    public virtual ICollection<Filme> Filmes { get; set; }
}
