namespace MegaFilmes.Models;

public class Ator : Entity
{
    public Ator()
    {
        Filmes = new HashSet<FilmeAtor>();
    }

    public string Nome { get; set; }

    public virtual ICollection<FilmeAtor> Filmes { get; set; }
}
