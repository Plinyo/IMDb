using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IMDb.Models;
using Microsoft.AspNetCore.Authorization;
using IMDb.Repositories;
using IMDb.Services;
using System.Collections.Generic;

namespace IMDb.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]Usuario model)
        {
            var userBR = new UserRepository();
            var user = userBR.Get(model.NomeUsuario, model.Senha);
            //var user = UserRepository.Get(model.NomeUsuario, model.Senha);
            if(user == null)
            return NotFound( new {message = "Usuário ou senha inválidos"});

            var token = TokenService.GenerateToken(user);
            user.Senha = "";
            return new 
            {
                user = user,
                token = token
            };        
        }

        [HttpGet]
        [Route("GetAllUsers")]
        [Authorize]
        public List<Usuario> GetAllUsers() 
        {
            var userBR = new UserRepository();
            return userBR.GetAll();
        }

        [HttpGet]
        [Route("GetAllMovies")]
        [Authorize]
        public List<Filmes> GetAllMovies() 
        {
            var moviesBR = new MovieRepository();
            return moviesBR.GetAll();
        }
        
        [HttpGet]
        [Route("GetAllAdm")]
        [Authorize]
        public List<Administrador> GetAllAdmin() 
        {
            var adminBR = new AdminRepository();
            return adminBR.GetAll();
        }
    }
}