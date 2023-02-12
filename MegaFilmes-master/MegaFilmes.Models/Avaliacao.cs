namespace MegaFilmes.Models;

public class Avaliacao
{
    public int AvaliacaoId { get; set; }

    public int Nota { get; set; }

    public string? Comentario { get; set; }

    public int FilmeId { get; set; }

    public virtual Filme Filme { get; set; }
}
