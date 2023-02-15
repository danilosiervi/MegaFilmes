namespace MegaFilmes.Models;

public class FilmeAtor
{
    public int AtorId { get; set; }
    public virtual Ator Ator { get; set; }

    public int FilmeId { get; set; }
    public virtual Filme Filme { get; set; }
}
