using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MegaFilmes.Models;

public class Avaliacao
{
    [Key]
    public int AvalicaoId { get; set; }
    public int Nota { get; set; }
    public string? Comentario { get; set; }

    public int FilmeId { get; set; }

    [JsonIgnore]
    public virtual Filme Filme { get; set; }
}
