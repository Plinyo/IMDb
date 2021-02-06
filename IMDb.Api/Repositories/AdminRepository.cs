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
            return _context.Administrador.Where(x => x.UserId == id && x.Ativo == true).Any();
        }

        public IEnumerable<Usuario> GetAll(int pagina = 1, int qtdeReg = 10)
        {
            var listAdmin = _context.Administrador.ToList();
            var list = _context.Usuario.ToList<Usuario>().Where(x => listAdmin.Any(y => y.UserId == x.Id));
            if (qtdeReg > 10)
                qtdeReg = 10;

            var totalPaginas = (int)Math.Ceiling(list.Count() / Convert.ToDecimal(qtdeReg));
            return list.OrderBy(x => x.NomeUsuario).Skip(qtdeReg * (pagina - 1)).Take(qtdeReg);
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