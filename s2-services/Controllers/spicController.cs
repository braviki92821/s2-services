using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using s2_services.Data;
using s2_services.models;
using s2_services.Models;
using s2_services.repository;
using System.Net;

namespace s2_services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class spicController : Controller
    {
        private readonly spicService _spicCollection;
        private readonly userService _userService;

        public spicController(spicService spicCollection, userService userService)
        {
            _spicCollection = spicCollection;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetDatos([FromHeader] string Authorization)
        {
            try
            {
                var acceso = await _userService.esTokenActivo(Authorization);
                Object spicList;
                if (!acceso)
                {
                    throw new Exception("token invalido o expirado");
                }
                else
                {
                    spicList= _spicCollection.GetSpicList();
                }
                return Ok(new ApiResponse
                {
                    Message = "Process success.",
                    Content = spicList
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

        [HttpPost]
        [Route("nuevoServidor")]
        public async Task<ActionResult<ApiResponse>> Insertar([FromHeader] string Authorization, [FromBody] Spic spic)
        {
            try
            {
                var acceso = await _userService.esTokenActivo(Authorization);
                Object newSpic;
                if (!acceso)
                {
                    throw new Exception("token invalido o expirado");
                }
                else
                {
                    newSpic = _spicCollection.agregar(spic);
                }

                return Ok(new ApiResponse
                {
                    Message = "Process success.",
                    Content = newSpic
                });
            }
            catch (Exception ex)
            {
                return BadRequest(
                     new ApiResponse
                     {
                         StatusCode = HttpStatusCode.BadRequest,
                         Message = ex.Message,
                         IsSuccess = false
                     });
            }
        }

    }
}
