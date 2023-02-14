namespace MegaFilmes.Services.AvaliacaoServices;

public interface IAvaliacaoService
{
    ReadAvaliacaoDto AdicionarAvaliacao(CreateAvaliacaoDto createAvaliacaoDto);

    IEnumerable<ReadAvaliacaoDto> BuscarTodasAvaliacoes();

    //ReadAvaliacaoDto? BuscarAvaliacoesPorFilme(int id);

}
