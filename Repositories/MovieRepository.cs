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
        // public List<Filmes> GetAll()
        // {
        //     var lst = new List<Filmes>();
        //     lst.Add(new Filmes
        //     {
        //         Id = 1,
        //         NomeFilme = "Batman O cavaleiro das trevas",
        //         Genero = "Ação/Aventura",
        //         Duracao = "2h 32m",
        //         Diretores = "Christopher Nolan",
        //         Atores = "Christian Bale, Michael Caine, Heath Ledger",
        //         Avaliacao = 4.9m
        //     });
        //     lst.Add(new Filmes
        //     {
        //         Id = 2,
        //         NomeFilme = "Esquadrão Suicida",
        //         Genero = "Ação/Aventura",
        //         Duracao = "2h 17m",
        //         Diretores = "David Ayer",
        //         Atores = "Margot Robbie, Will Smith, Jared Leto",
        //         Avaliacao = 3.9m
        //     });
        //     lst.Add(new Filmes
        //     {
        //         Id = 3,
        //         NomeFilme = "Batman vs Superman: A Origem da Justiça",
        //         Genero = "Ação/Aventura",
        //         Duracao = "3h 03m",
        //         Diretores = "Zack Snyder",
        //         Atores = "Ben Affleck, Henry Cavill, Gal Gadot, Jesse Eisenberg",
        //         Avaliacao = 3.9m
        //     });
        //     lst.Add(new Filmes
        //     {
        //         Id = 4,
        //         NomeFilme = "Vingadores: Ultimato",
        //         Genero = "Ação/Ficção Científica",
        //         Duracao = "3h 02m",
        //         Diretores = "Joe Russo, Anthony Russo",
        //         Atores = "Chris Evans, Robert Downey Jr., Chris Hemsworth, Mark Ruffalo, Scarlett Johansson",
        //         Avaliacao = 4.7m
        //     });
        //     return lst.OrderByDescending(x => x.Avaliacao).ToList(); //.OrderBy(y => y.NomeFilme).ToList();
        // }
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