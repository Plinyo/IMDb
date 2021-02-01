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
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public HomeController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Autentica o usuario ao sistema.
        /// </summary>      
        /// <remarks>
        /// Sample request:
        ///     Exemplos de usuarios para começar a utilizar
        ///     Usuario Administrador
        ///     POST /login
        ///       "NomeUsuario": "nick fury",
        ///        "Senha": "shield"
        ///     
        ///     Usuario Comum
        ///     POST /login
        ///        "NomeUsuario": "tony stark",
        ///        "Senha": "ironman"     
        ///
        /// </remarks>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario model)
        {
            var userBR = _userRepository;
            var user = userBR.GetByUserPass(model.NomeUsuario, model.Senha);
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Senha = "";
            return new
            {
                user = user,
                token = token
            };
        }
    }
}