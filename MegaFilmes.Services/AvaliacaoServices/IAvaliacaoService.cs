using MegaFilmes.Services.Dtos.AvaliacaoDtos;

namespace MegaFilmes.Services.AvaliacaoServices;

public interface IAvaliacaoService
{
    ReadAvaliacaoDto AdicionarAvaliacao(CreateAvaliacaoDto createAvaliacaoDto);

    IEnumerable<ReadAvaliacaoDto> BuscarTodasAvaliacoes();

    ReadAvaliacaoDto? BuscarAvaliacaoPorId(int id);

    ReadAvaliacaoDto? DeletarAvaliacao(int id);
}
