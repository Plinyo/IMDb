using IMDb.Models;
using Microsoft.AspNetCore.Authorization;
using IMDb.Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace IMDb.Controllers
{
    [Route("v1/movie")]
    public class MovieController : ControllerBase
    {
        private readonly MovieRepository _movieRepository;
        private readonly AdminRepository _adminRepository;
        public MovieController(MovieRepository movieRepository, AdminRepository adminRepository)
        {
            _movieRepository = movieRepository;
            _adminRepository = adminRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public IEnumerable<Filmes> GetAllMovies([FromQuery(Name = "page")] int page = 1,
                                            [FromQuery(Name = "qtdeReg")] int qtdeReg = 10)
        {
            return _movieRepository.GetAll(page, qtdeReg);
        }

        [HttpPost]
        [Authorize]
        [Route("Insert")]
        public ActionResult InsertFilmes([FromBody] Filmes obj)
        {
            if (_movieRepository.GetByName(obj.NomeFilme) != null)
            {
                return BadRequest("Filme já cadastrado no sistema");
            }
            if (obj.Avaliacao != 0m)
            {
                return BadRequest("O administrador não pode avaliar os filmes");
            }

            _movieRepository.Insert(obj);
            return Ok("Filme inserido com sucesso.");
        }

        [HttpPut]
        [Authorize]
        [Route("Update")]
        public ActionResult UpdateFilmes([FromBody] Filmes obj, [FromQuery(Name = "id")] int id)
        {
            if (obj.Avaliacao != 0m)
            {
                return BadRequest("O administrador não pode avaliar os filmes");
            }

            var movie = _movieRepository.GetById(id);

            if (!movie.Equals(obj))
            {
                movie.NomeFilme = obj.NomeFilme;
                movie.Atores = obj.Atores;
                movie.Diretores = obj.Diretores;
                movie.Duracao = obj.Duracao;
                movie.Genero = obj.Genero;
                //Avaliação nao pode ser atualizada.
            }

            _movieRepository.Update(movie);
            return Ok("Filme atualizado com sucesso.");
        }

        [HttpPut]
        [Authorize]
        [Route("AvaliarFilmes")]
        public ActionResult AvaliarFilmes([FromQuery(Name = "id")] int id, [FromQuery(Name = "nota")] decimal nota)
        {
            if (_adminRepository.IsAdministrator(Request.Headers["Authorization"]) == true)
            {
                return BadRequest("O administrador não pode avaliar os filmes");
            }

            var movie = _movieRepository.GetById(id);

            if (nota < 0 || nota > 4)
            {
                return BadRequest("Somente é permitido uma avaliação entre 0 e 4");
            }

            if (movie.Avaliacao == 0m)
            {
                movie.Avaliacao = nota;
            }
            else
            {
                movie.Avaliacao = (movie.Avaliacao + nota) / 2;
            }

            _movieRepository.Update(movie);
            return Ok("Filme atualizado com sucesso.");
        }
    }
}