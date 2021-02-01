using IMDb.Models;
using Microsoft.EntityFrameworkCore;

namespace IMDb.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Filmes> Filmes { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Sistema> Sistema { get; set; }
    }
}