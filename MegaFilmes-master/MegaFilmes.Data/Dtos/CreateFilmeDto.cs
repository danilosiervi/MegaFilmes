﻿using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Data.Dtos;

public class CreateFilmeDto
{
    [Required(ErrorMessage = "O título do filme é obrigatório.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "A descricao é obrigatória.")]
    public string Descricao { get; set; }

    [Required]
    // 1895 foi o ano da criacao do cinema. Se deixássemos em aberto, poderia colocar qualquer inteiro
    [Range(1895, 2023, ErrorMessage = "O ano é obrigatório e deve estar entre 1895 e o ano atual.")]
    public int Ano { get; set; }

    [Required(ErrorMessage = "O diretor do filme é obrigatório.")]
    public string Diretor { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatório.")]
    public string Genero { get; set; }

}