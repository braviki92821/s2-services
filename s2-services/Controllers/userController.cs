using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using s2_services.models;
using s2_services.Models;
using s2_services.repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace s2_services.Controllers
{
    [ApiController]
    [Route("oauth/user")]

    public class userController : Controller
    {
        private readonly userService _userService;

        public userController(userService userService) {
            _userService = userService; 
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login(string username, string password) {
           var user= await _userService.GetUsuario(username, password);
            token tokenBody = new token();
            if (user != null)
            {
                var scope = user.Scope;
                if (scope[0].Equals(""))
                {
                    return UnprocessableEntity("Valor de scope no valido");
                }
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                };

                var expire = DateTime.Now.AddSeconds(180);
                var token = _userService.token(claims);
                var refreshToken = _userService.GenerateRefreshToken();

                tokenBody.Access_token = new JwtSecurityTokenHandler().WriteToken(token);
                tokenBody.Token_type = "Bearer"; 
                tokenBody.Expires_in = expire;
                tokenBody.Refresh_token=refreshToken;
                tokenBody.Refresh_token_expires_in=expire;
                tokenBody.Username = user.Username;
                tokenBody.Scope = user.Scope;

                _userService.InsertartToken(tokenBody);
                return Ok(tokenBody);
            }
            else
            {
                return NotFound("Usuario o contraseña incorrectos");
            }
 
        }

        [HttpPost]
        [Route("registrar")]
        public ActionResult<user> Registrer(user user)
        {
            var body = new {mensaje=""};
            if (user.Username == "" || user.Username == null)
            {
                body = new { mensaje = "Ingrese un nombre de usuario valido" };
            } else if (user.Password.Length < 7)
            {
                body = new { mensaje = "contraseña debe tener al menos 8 caracteres" };
            }
            else if (user.Scope[0].Equals("") || !user.Scope[0].Equals("readWrite"))
            {
               body = new{mensaje= "ingrese un scope de permisos valido"};
            }
            else
            {
                 _userService.RegistrarUsuario(user);
                  body = new {mensaje= "Usuario creado correctamente"};
            }

            return Ok(body);
        }

        [Authorize]
        [HttpGet]
        [Route("obtenerUsuarios")]
        public ActionResult<List<userBson>> GetDatos()
        {
            var users = _userService.obtenerUsuarios();
            return Ok(users);
        }



    }
}
