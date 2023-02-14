using System.Text.Json.Serialization;

namespace MegaFilmes.Models;

public class Diretor : Entity
{
    public Diretor()
    {
        Filmes = new HashSet<Filme>();
    }

    public string Nome { get; set; }

    [JsonIgnore]
    public virtual ICollection<Filme> Filmes { get; set; }
}
