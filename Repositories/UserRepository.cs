using System;
using System.Collections.Generic;
using System.Linq;
using IMDb.Data;
using IMDb.Models;

namespace IMDb.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(DataContext context) : base(context)
        {

        }
        // public List<Usuario> GetAll(int pagina = 1, int qtdeReg = 10)
        // {
        //     var users = new List<Usuario>();
        //     users.Add(new Usuario { Id = 1, NomeUsuario = "tony stark", Senha = "ironman", Sexo = 'M', Ativo = true, DataNascimento = DateTime.Today.AddYears(-30) });
        //     users.Add(new Usuario { Id = 2, NomeUsuario = "steve rogers", Senha = "cap", Sexo = 'M', Ativo = true, DataNascimento = DateTime.Today.AddYears(-100) });
        //     users.Add(new Usuario { Id = 3, NomeUsuario = "natasha romanoff", Senha = "viuvanegra", Sexo = 'F', Ativo = true, DataNascimento = DateTime.Today.AddYears(-25) });
        //     users.Add(new Usuario { Id = 4, NomeUsuario = "bruce banner", Senha = "hulk", Sexo = 'F', Ativo = true, DataNascimento = DateTime.Today.AddYears(-35) });
        //     users.Add(new Usuario { Id = 5, NomeUsuario = "peter parker", Senha = "spiderman", Sexo = 'F', Ativo = true, DataNascimento = DateTime.Today.AddYears(-18) });

        //     if (qtdeReg > 10)
        //         qtdeReg = 10;

        //     var totalPaginas = (int)Math.Ceiling(users.Count() / Convert.ToDecimal(qtdeReg));
        //     return users.OrderBy(x => x.NomeUsuario).Skip(qtdeReg * (pagina - 1)).Take(qtdeReg).ToList();
        // }
        public IEnumerable<Usuario> GetAll(int pagina = 1, int qtdeReg = 10)
        {
            var users = _context.Usuario.ToList<Usuario>();
            if (qtdeReg > 10)
                qtdeReg = 10;

            var totalPaginas = (int)Math.Ceiling(users.Count() / Convert.ToDecimal(qtdeReg));
            return users.OrderBy(x => x.NomeUsuario).Skip(qtdeReg * (pagina - 1)).Take(qtdeReg);
        }
        public IEnumerable<Usuario> GetAllAtivos(int pagina = 1, int qtdeReg = 10)
        {
            var users = _context.Usuario.Where(x => x.Ativo == true).ToList();
            if (qtdeReg > 10)
                qtdeReg = 10;

            var totalPaginas = (int)Math.Ceiling(users.Count() / Convert.ToDecimal(qtdeReg));
            return users.OrderBy(x => x.NomeUsuario).Skip(qtdeReg * (pagina - 1)).Take(qtdeReg);
        }
        public Usuario GetByUserPass(string username, string password)
        {
            return _context.Usuario.Where(x => x.NomeUsuario.ToLower() == username.ToLower() && x.Senha.ToLower() == password.ToLower()).FirstOrDefault();
        }
        public Usuario GetByUser(string username)
        {
            return _context.Usuario.Where(x => x.NomeUsuario.ToLower() == username.ToLower()).FirstOrDefault();
        }
        public Usuario GetByName(string username)
        {
            return _context.Usuario.Where(x => x.NomeUsuario.ToLower() == username.ToLower()).FirstOrDefault();
        }
        public Usuario GetById(int id)
        {
            return _context.Usuario.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Insert(Usuario obj)
        {
            _context.Usuario.Add(obj);
            _context.SaveChanges();
        }
        public void Delete(Usuario obj)
        {
            _context.Usuario.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Usuario obj)
        {
            _context.Usuario.Update(obj);
            _context.SaveChanges();
        }
    }
}