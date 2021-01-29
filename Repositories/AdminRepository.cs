using System;
using System.Collections.Generic;
using System.Linq;
using IMDb.Models;

namespace IMDb.Repositories
{
    public class AdminRepository
    {
        public List<Administrador> GetAll()
        {
            var lst = new List<Administrador>();
            lst.Add(new Administrador {Id = 1,  Ativo = true, Usuario = new Usuario { Id = 1} });
            return lst;
        }
    }
}