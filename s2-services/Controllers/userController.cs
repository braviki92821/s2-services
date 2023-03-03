﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using s2_services.Data;
using s2_services.Models;
using s2_services.Models.DataTransfer;
using s2_services.repository;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace s2_services.Controllers
{
    [ApiController]
    [Route("oauth/user")]

    public class userController : Controller
    {
        private readonly userService _userService;

        public userController(userService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ApiResponse>> Login([FromBody] user userl)
        {
            try
            {
                var user = await _userService.GetUsuario(userl.Username, userl.Password);
                var tokenBody = new token();
                if (user == null)
                {
                    throw new Exception("Email or password incorrect");
                }
                var scope = user!.Scope;
                if (scope[0].Equals(""))
                {
                    throw new Exception("Scope value is not validate.");
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
                tokenBody.Refresh_token = refreshToken;
                tokenBody.Refresh_token_expires_in = expire;
                tokenBody.Username = user.Username;
                tokenBody.Scope = user.Scope;

                _userService.InsertarToken(tokenBody);
                return Ok(new ApiResponse
                {
                    Message = "Process success.",
                    Content = tokenBody
                });
            }
            catch (Exception e)
            {
                return BadRequest(
                  new ApiResponse
                  {
                      StatusCode = HttpStatusCode.BadRequest,
                      Message = e.Message,
                      IsSuccess = false
                  });
            }
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<ActionResult<ApiResponse>> Registrer([FromHeader] string Authorization,[FromBody]userTransfer nuevoUsuario)
        {
            try
            {  

                var acceso = await _userService.esTokenActivo(Authorization);
                Object userN;
                if (!acceso)
                {
                    throw new Exception("token invalido o expirado");
                }
                else
                {
                    userN = _userService.RegistrarUsuario(nuevoUsuario);
                }
                return Ok(new ApiResponse
                {
                    Message = "Process success.",
                    Content = userN
                });

            }
            catch (Exception e)
            {
                return BadRequest(
                     new ApiResponse
                     {
                         StatusCode = HttpStatusCode.BadRequest,
                         Message = e.Message,
                         IsSuccess = false
                     });
            }
        }

        [HttpGet]
        [Route("obtenerUsuarios")]
        public async Task<ActionResult<ApiResponse>> GetDatos([FromHeader] string Authorization)
        {
            try
            {
                var acceso = await _userService.esTokenActivo(Authorization);
                Object usuarios;
                if (!acceso)
                {
                    throw new Exception("token invalido o expirado");
                }
                else
                {
                    usuarios = _userService.obtenerUsuarios();
                }
                return Ok(new ApiResponse
                {
                    Message = "Process success.",
                    Content = usuarios
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = e.Message,
                    IsSuccess = false
                });
            }
        }

    }
}
