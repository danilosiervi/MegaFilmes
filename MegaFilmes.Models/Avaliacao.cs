namespace MegaFilmes.Models;

public class Avaliacao : Entity
{
    public int Nota { get; set; }
    public string? Comentario { get; set; }

    public int FilmeId { get; set; }

    public virtual Filme Filme { get; set; }
}
