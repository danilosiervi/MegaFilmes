using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Data.Dtos;

public class ReadAvaliacaoDto
{
    public int Nota { get; set; }

    public int AvaliacaoId { get; set; }

    // Id do filme
    public int Id { get; set; }

    public string? Comentario { get; set; }
}