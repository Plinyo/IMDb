using System.Threading.Tasks;
using IMDb.Models;
using Microsoft.AspNetCore.Authorization;
using IMDb.Repositories;
using IMDb.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IMDb.Controllers
{

    [Route("v1/movie")]
    public class MovieController : ControllerBase
    {
        private readonly MovieRepository _movieRepository;
        public MovieController(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public List<Filmes> GetAllMovies()
        {
            return _movieRepository.GetAll();
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
            // if (obj.Ativo == false)
            // {
            //     return BadRequest("Somente o administrador pode incluir filmes.");
            // }

            _movieRepository.Insert(obj);
            return Ok("Filme inserido com sucesso.");
        }

        [HttpPut]
        [Authorize]
        [Route("Update/{id}")]
        public ActionResult UpdateFilmes(int id, [FromBody] Filmes obj)
        {
            // var movie = _movieRepository.GetById(id);

            // JsonConvert.PopulateObject(obj.ToString(), user);
            // if (_movieRepository.GetByName(obj.NomeFilmes) != null)
            // {
            //     return BadRequest("Usuário já cadastrado no sistema");
            // }
            
            // _movieRepository.Update(obj);
             return Ok("Usuário atualizado com sucesso.");
        }
    }
}