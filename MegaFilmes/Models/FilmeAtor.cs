using System.Text.Json.Serialization;

namespace MegaFilmes.Models;

public class FilmeAtor
{
    [JsonIgnore]
    public int AtorId { get; set; }
    public string Personagem { get; set; }
    public virtual Ator Ator { get; set; }

    [JsonIgnore]
    public int FilmeId { get; set; }

    [JsonIgnore]
    public virtual Filme Filme { get; set; }
}
