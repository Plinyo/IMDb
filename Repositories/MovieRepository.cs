using System;
using System.Collections.Generic;
using System.Linq;
using IMDb.Data;
using IMDb.Models;

namespace IMDb.Repositories
{
    public class MovieRepository : BaseRepository
    {
        public MovieRepository(DataContext context) : base(context)
        {

        }
        public IEnumerable<Filmes> GetAll(int pagina = 1, int qtdeReg = 10)
        {
            var list = _context.Filmes.ToList<Filmes>();            

            if (qtdeReg > 10)
                qtdeReg = 10;

            var totalPaginas = (int)Math.Ceiling(list.Count() / Convert.ToDecimal(qtdeReg));
            return list.OrderBy(x => x.Avaliacao).ThenBy(x => x.NomeFilme).Skip(qtdeReg * (pagina - 1)).Take(qtdeReg);
        }
        public Filmes GetByName(string movieName)
        {
            return _context.Filmes.Where(x => x.NomeFilme.ToLower() == movieName.ToLower()).FirstOrDefault();
        }
        public Filmes GetById(int id)
        {
            return _context.Filmes.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Insert(Filmes obj)
        {
            _context.Filmes.Add(obj);
            _context.SaveChanges();
        }
        public void Delete(Filmes obj)
        {
            _context.Filmes.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Filmes obj)
        {
            _context.Filmes.Update(obj);
            _context.SaveChanges();
        }
    }
}