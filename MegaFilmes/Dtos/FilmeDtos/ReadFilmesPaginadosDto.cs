namespace MegaFilmes.Dtos.FilmeDtos;

public class ReadFilmesPaginadosDto
{
    public IEnumerable<ReadFilmeDto> Filmes { get; set; }
    public int Pagina { get; set; }
    public int TotalDePaginas { get; set; }
    public int TotalDeFilmes { get; set; }
}
