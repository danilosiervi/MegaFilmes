namespace MegaFilmes.Models;

public class Ator : Entity
{
    public Ator()
    {
        Filmes = new Dictionary<FilmeAtor, string>();
    }

    public string Nome { get; set; }

    public virtual IDictionary<FilmeAtor, string> Filmes { get; set; }
}
