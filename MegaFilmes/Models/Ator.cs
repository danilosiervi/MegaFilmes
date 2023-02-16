using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MegaFilmes.Models;

public class Ator
{
    public Ator()
    {
        Filmes = new HashSet<FilmeAtor>();
    }

    [Key]
    [JsonIgnore]
    public int AtorId { get; set; }
    public string Nome { get; set; }

    [JsonIgnore]
    public virtual ICollection<FilmeAtor> Filmes { get; set; }
}
