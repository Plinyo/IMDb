using IMDb.Models;
using Microsoft.AspNetCore.Authorization;
using IMDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace IMDb.Controllers
{
    [Route("v1/admin")]
    public class AdminController : ControllerBase
    {
        private readonly AdminRepository _adminRepository;
        private readonly UserRepository _userRepository;
        public AdminController(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public ActionResult GetAllAdmin()
        {
            if (_adminRepository.IsAdministrator(Request.Headers["Authorization"]) == false)
            {
                return BadRequest("Administrador já cadastrado no sistema");
            }
            return Ok(_adminRepository.GetAll());
        }

        [HttpPost]
        [Authorize]
        [Route("Insert")]
        public ActionResult InsertAdministrador([FromBody] Administrador obj)
        {
            if (_adminRepository.IsAdministrator(Request.Headers["Authorization"]) == false)
            {
                return BadRequest("Administrador já cadastrado no sistema");
            }

            _adminRepository.Insert(obj);
            return Ok("Administrador inserido com sucesso.");
        }

        [HttpPost]
        [Authorize]
        [Route("Delete")]
        public ActionResult DeleteAdministrador(int adminId)
        {
            if (_adminRepository.IsAdministrator(Request.Headers["Authorization"]) == false)
            {
                return BadRequest("Apenas administradores podem remover outros administradores no sistema");
            }
            var admin = _adminRepository.GetById(adminId);            
            admin.Ativo = false;
            _adminRepository.Update(admin);
            return Ok("Administrador inativado com sucesso.");
        }

        [HttpGet]
        [Route("GetAllUsersAtivos")]
        [Authorize]
        public ActionResult GetAllUsersAtivos([FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "qtdeReg")] int qtdeReg = 10)
        {
            if (_adminRepository.IsAdministrator(Request.Headers["Authorization"]) == false)
            {
                return BadRequest("Somente o administrador pode visualizar essa informação");
            }

            return Ok(_userRepository.GetAllAtivos(page, qtdeReg));
        }
    }
}