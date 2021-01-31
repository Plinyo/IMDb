using System;
using System.Collections.Generic;
using System.Linq;
using IMDb.Data;
using IMDb.Models;
using IMDb.Utils;

namespace IMDb.Repositories
{
    public class AdminRepository : BaseRepository
    {
        private readonly UserRepository _userRepository;

        public AdminRepository(DataContext context, UserRepository userRepository) : base(context)
        {
            _userRepository = userRepository;
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

        public bool IsAdministrator(string jwtToken)
        {
            var username = Helpers.ParseToken(jwtToken);
            var user = _userRepository.GetByName(username);
            if (user.Ativo == false)
                return false;

            return ValidarAdminitrador(user.Id);
        }
    }
}