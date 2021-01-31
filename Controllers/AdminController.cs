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
        public bool IsAdministrator()
        {
            var username = ParseToken();
            var user = _userRepository.GetByName(username);
            if (user.Ativo == false)
                return false;

            return _adminRepository.ValidarAdminitrador(user.Id);
        }
        private string ParseToken()
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            string jwtInput = Request.Headers["Authorization"];
            jwtInput = jwtInput.Split(" ")[1];

            var readableToken = jwtHandler.CanReadToken(jwtInput);
            string username = string.Empty;
            if (readableToken)
            {
                var token = jwtHandler.ReadJwtToken(jwtInput);
                var claims = token.Claims;
                username = claims.Where(claim => claim.Type == "unique_name").FirstOrDefault().Value;

            }
            return username;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public ActionResult GetAllAdmin()
        {
            if (IsAdministrator() == false)
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
            if (IsAdministrator() == false)
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
            if (IsAdministrator() == false)
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
            if (IsAdministrator() == false)
            {
                return BadRequest("Somente o administrador pode visualizar essa informação");
            }

            return Ok(_userRepository.GetAllAtivos(page, qtdeReg));
        }
    }
}