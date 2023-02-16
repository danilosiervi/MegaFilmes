﻿// <auto-generated />
using MegaFilmes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MegaFilmes.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MegaFilmes.Models.Ator", b =>
                {
                    b.Property<int>("AtorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AtorId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AtorId");

                    b.ToTable("Atores");
                });

            modelBuilder.Entity("MegaFilmes.Models.Avaliacao", b =>
                {
                    b.Property<int>("AvalicaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvalicaoId"));

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("AvalicaoId");

                    b.HasIndex("FilmeId");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("MegaFilmes.Models.Diretor", b =>
                {
                    b.Property<int>("DiretorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiretorId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiretorId");

                    b.ToTable("Diretores");
                });

            modelBuilder.Entity("MegaFilmes.Models.Filme", b =>
                {
                    b.Property<int>("FilmeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmeId"));

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiretorId")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FilmeId");

                    b.HasIndex("DiretorId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("MegaFilmes.Models.FilmeAtor", b =>
                {
                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<int>("AtorId")
                        .HasColumnType("int");

                    b.HasKey("FilmeId", "AtorId");

                    b.HasIndex("AtorId");

                    b.ToTable("FilmeAtor");
                });

            modelBuilder.Entity("MegaFilmes.Models.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneroId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GeneroId");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("MegaFilmes.Models.Avaliacao", b =>
                {
                    b.HasOne("MegaFilmes.Models.Filme", "Filme")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("MegaFilmes.Models.Filme", b =>
                {
                    b.HasOne("MegaFilmes.Models.Diretor", "Diretor")
                        .WithMany("Filmes")
                        .HasForeignKey("DiretorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaFilmes.Models.Genero", "Genero")
                        .WithMany("Filmes")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diretor");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("MegaFilmes.Models.FilmeAtor", b =>
                {
                    b.HasOne("MegaFilmes.Models.Ator", "Ator")
                        .WithMany("Filmes")
                        .HasForeignKey("AtorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaFilmes.Models.Filme", "Filme")
                        .WithMany("Elenco")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ator");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("MegaFilmes.Models.Ator", b =>
                {
                    b.Navigation("Filmes");
                });

            modelBuilder.Entity("MegaFilmes.Models.Diretor", b =>
                {
                    b.Navigation("Filmes");
                });

            modelBuilder.Entity("MegaFilmes.Models.Filme", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Elenco");
                });

            modelBuilder.Entity("MegaFilmes.Models.Genero", b =>
                {
                    b.Navigation("Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}
