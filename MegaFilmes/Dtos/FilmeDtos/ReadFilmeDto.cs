using MegaFilmes.Models;
using System.Text.Json.Serialization;

namespace MegaFilmes.Dtos.FilmeDtos;

public class ReadFilmeDto
{
    public int FilmeId { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Ano { get; set; }
    public double NotaMedia
    {
        get
        {
            return (Avaliacoes.Any()) ? Math.Round(Avaliacoes.Average(a => a.Nota), 2) : 0;
        }
        set
        {
        }
    }

    public virtual Diretor Diretor { get; set; }
    public virtual Genero Genero { get; set; }
    public virtual ICollection<FilmeAtor> Elenco { get; set; }

    [JsonIgnore]
    public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
}
