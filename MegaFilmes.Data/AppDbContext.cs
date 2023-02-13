using MegaFilmes.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaFilmes.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> opts)
		: base(opts)
	{
	}

	public DbSet<Filme> Filmes { get; set; }
	public DbSet<Diretor> Diretores { get; set; }
	public DbSet<Ator> Atores { get; set; }
	public DbSet<Genero> Generos { get; set; }
	public DbSet<Avaliacao> Avaliacoes { get; set; }
	public DbSet<FilmeAtor> FilmeAtor { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<FilmeAtor>()
			.HasKey(fa => new { fa.FilmeId, fa.AtorId });

		modelBuilder.Entity<FilmeAtor>()
			.HasOne(fa => fa.Ator)
			.WithMany(a => a.Filmes)
			.HasForeignKey(fa => fa.AtorId);

		modelBuilder.Entity<FilmeAtor>()
			.HasOne(fa => fa.Filme)
			.WithMany(f => f.Elenco)
			.HasForeignKey(fa => fa.FilmeId);

        modelBuilder.Entity<Filme>()
			.HasOne(f => f.Diretor)
			.WithMany(d => d.Filmes)
			.HasForeignKey(f => f.DiretorId);

		modelBuilder.Entity<Filme>()
			.HasOne(f => f.Genero)
			.WithMany(g => g.Filmes)
			.HasForeignKey(f => f.Genero);

		modelBuilder.Entity<Avaliacao>()
			.HasOne(a => a.Filme)
			.WithMany(f => f.Avaliacoes)
			.HasForeignKey(a => a.FilmeId);
	}
}
