using System.Threading.Tasks;
using IMDb.Models;
using Microsoft.AspNetCore.Authorization;
using IMDb.Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IMDb.Controllers
{
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public IEnumerable<Usuario> GetAllUsers([FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "qtdeReg")] int qtdeReg = 10)
        {
            return _userRepository.GetAll(page, qtdeReg);
        }

        [HttpPost]
        [Authorize]
        [Route("Insert")]
        public ActionResult InsertUsuario([FromBody] Usuario obj)
        {
            if (_userRepository.GetByName(obj.NomeUsuario) != null)
            {
                return BadRequest("Usuário já cadastrado no sistema");
            }
            if (obj.Ativo == false)
            {
                return BadRequest("Usuário desativado, favor ativá-lo.");
            }

            _userRepository.Insert(obj);
            return Ok("Usuário inserido com sucesso.");
        }

        [HttpPut]
        [Authorize]
        [Route("Update")]
        public ActionResult UpdateUsuario([FromQuery(Name = "id")] int id, [FromBody] Usuario obj)
        {
            var user = _userRepository.GetById(id);
            JsonConvert.PopulateObject(obj.ToString(), user);
            if (_userRepository.GetByName(obj.NomeUsuario) != null)
            {
                return BadRequest("Usuário já cadastrado no sistema");
            }

            _userRepository.Update(obj);
            return Ok("Usuário atualizado com sucesso.");
        }

        [HttpPost]
        [Authorize]
        [Route("Delete")]
        public ActionResult DeleteUsuario([FromQuery(Name = "id")] int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return BadRequest("Usuário não encontrado");
            }
            user.Ativo = false;
            _userRepository.Update(user);
            return Ok("Deleção lógica concluida");
        }
    }
}