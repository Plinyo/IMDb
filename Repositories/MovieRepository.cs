using System;
using System.Collections.Generic;
using System.Linq;
using IMDb.Models;

namespace IMDb.Repositories
{
    public class MovieRepository
    {
        public List<Filmes> GetAll()
        {
            var lst = new List<Filmes>();
            lst.Add(new Filmes {Id = 1, NomeFilme = "Batman O cavaleiro das trevas", Genero = "Ação/Aventura", Duracao = "2h 32m", Diretores = "Christopher Nolan",  
            Atores = "Christian Bale, Michael Caine, Heath Ledger", Avaliacao = 4.9m});
            lst.Add(new Filmes {Id = 2, NomeFilme = "Esquadrão Suicida", Genero = "Ação/Aventura", Duracao = "2h 17m", Diretores = "David Ayer",  
            Atores = "Margot Robbie, Will Smith, Jared Leto", Avaliacao = 3.9m});
            lst.Add(new Filmes {Id = 3, NomeFilme = "Batman vs Superman: A Origem da Justiça", Genero = "Ação/Aventura", Duracao = "3h 03m", Diretores = "Zack Snyder",  
            Atores = "Ben Affleck, Henry Cavill, Gal Gadot, Jesse Eisenberg", Avaliacao = 3.9m});
            lst.Add(new Filmes {Id = 4, NomeFilme = "Vingadores: Ultimato", Genero = "Ação/Ficção Científica", Duracao = "3h 02m", Diretores = "Joe Russo, Anthony Russo",  
            Atores = "Chris Evans, Robert Downey Jr., Chris Hemsworth, Mark Ruffalo, Scarlett Johansson", Avaliacao = 4.7m});
            return lst.OrderByDescending(x => x.Avaliacao).ToList(); //.OrderBy(y => y.NomeFilme).ToList();
        }
        public static Filmes GetByName(string movieName)
        {
            var moviesBR = new MovieRepository();
            return moviesBR.GetAll().Where(x => x.NomeFilme.ToLower() == movieName.ToLower()).FirstOrDefault();
        }        
    }
}