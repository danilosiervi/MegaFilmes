using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Models;

public class Ator
{
    public Ator()
    {
        Filmes = new HashSet<FilmeAtor>();
    }

    [Key]
    public int AtorId { get; set; }
    public string Nome { get; set; }

    public virtual ICollection<FilmeAtor> Filmes { get; set; }
}
