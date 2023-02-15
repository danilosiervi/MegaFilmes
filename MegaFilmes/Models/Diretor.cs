using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MegaFilmes.Models;

public class Diretor
{
    public Diretor()
    {
        Filmes = new HashSet<Filme>();
    }

    [Key]
    public int DiretorId { get; set; }
    public string Nome { get; set; }

    [JsonIgnore]
    public virtual ICollection<Filme> Filmes { get; set; }
}
