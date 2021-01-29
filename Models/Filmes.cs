using System;
using System.ComponentModel.DataAnnotations;

namespace IMDb.Models
{
    public class Filmes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]      
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string NomeFilme { get; set; }
        public string Genero { get; set; }
        public string Duracao { get; set; }
        public string Atores { get; set; }
        public string Diretores { get; set; }
        public decimal Avaliacao { get; set; }    
    }
}