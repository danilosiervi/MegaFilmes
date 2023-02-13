namespace MegaFilmes.Models;

public class Genero : Entity 
{
    public Genero()
    {
        Filmes = new HashSet<Filme>();
    }

    public string Nome { get; set; }

    public virtual ICollection<Filme> Filmes { get; set; }
}
