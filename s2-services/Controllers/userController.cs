using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
        IOptions<Jwt> _configuration;

        public userController(userService userService,IOptions<Jwt> configuration) {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> login(string username, string password) {
           var user= await _userService.GetUsuario(username, password);
           
            if (user != null)
            {
                var scope = user.Scope;
                Console.WriteLine(scope.Length);
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
                    new Claim("username",user.Username)
                };

                var key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Value.key));
                var singIn=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                var expire = DateTime.Now.AddMinutes(2);
                var token = new JwtSecurityToken(_configuration.Value.Issuer,
                    _configuration.Value.Audience,
                    claims,
                    expires: expire,
                    signingCredentials: singIn
                     );

              
                return Ok( new
                {
                    acces_token = new JwtSecurityTokenHandler().WriteToken(token),
                    token_type = "Bearer",
                    expires_in = expire,
                    username=user.Username,
                    scope=user.Scope
                });
            }
            else
            {
                return NotFound("Usuario o contraseña incorrectos");
            }
 
        }
 
    }
}
