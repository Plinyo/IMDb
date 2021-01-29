using System.ComponentModel.DataAnnotations;

namespace IMDb.Models
{
    public class Administrador
    {
        [Key]
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public Usuario Usuario { get; set;}
    }
}