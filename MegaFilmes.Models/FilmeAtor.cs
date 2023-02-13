namespace MegaFilmes.Models;

public class FilmeAtor : Entity
{
    public int AtorId { get; set; }
    public virtual Ator Ator { get; set; }
    public string Papel { get; set; }

    public int FilmeId { get; set; }
    public virtual Filme Filme { get; set; }
}
