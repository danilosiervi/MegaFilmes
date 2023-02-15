using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MegaFilmes.Models;

public class Genero
{
    public Genero()
    {
        Filmes = new HashSet<Filme>();
    }

    [Key]
    public int GeneroId { get; set; }
    public string Nome { get; set; }

    [JsonIgnore]
    public virtual ICollection<Filme> Filmes { get; set; }
}
