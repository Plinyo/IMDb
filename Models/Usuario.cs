using System;
using System.ComponentModel.DataAnnotations;

namespace IMDb.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório, ao inserir um novo, valor deve ser 'true'")]
        public bool Ativo { get; set; }
    }
}