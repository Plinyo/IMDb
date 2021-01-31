using System;
using System.Collections.Generic;
using System.Linq;
using IMDb.Data;
using IMDb.Models;

namespace IMDb.Repositories
{
    public class AdminRepository : BaseRepository
    {
        public AdminRepository(DataContext context): base(context)
        {

        }
        public bool ValidarAdminitrador(int id)
        {
            return _context.Administrador.Where(x => x.Usuario.Id == id && x.Ativo == true).Any();
        }

        public List<Administrador> GetAll()
        {
            var lst = new List<Administrador>();
            lst.Add(new Administrador { Id = 1, Ativo = true, Usuario = new Usuario { Id = 1 } });
            return lst;
        }
        public Administrador GetById(int id)
        {
            return _context.Administrador.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Insert(Administrador obj)
        {
            _context.Administrador.Add(obj);
            _context.SaveChanges();
        }
        public void Update(Administrador obj)
        {
            _context.Administrador.Update(obj);
            _context.SaveChanges();
        }
    }
}