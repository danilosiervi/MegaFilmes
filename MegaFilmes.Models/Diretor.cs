namespace MegaFilmes.Models;

public class Diretor
{
    public Diretor()
    {
        Filmes = new HashSet<Filme>();
    }

    public int DiretorId { get; set; }
    public string Nome { get; set; }

    public virtual ICollection<Filme> Filmes { get; set; }
}
