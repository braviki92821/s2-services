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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetDatos([FromHeader] string Authorization)
        {
            try
            {
                var acceso = await _userService.esTokenActivo(Authorization.Remove(0, 7));
                Object spicList;
                if (!acceso)
                {
                    throw new Exception("token invalido o expirado");
                }

                spicList = _spicCollection.GetSpicList();

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

        [Authorize]
        [HttpPost]
        [Route("nuevoServidor")]
        public async Task<ActionResult<ApiResponse>> Insertar([FromHeader] string Authorization, [FromBody] Spic spic)
        {
            try
            {
                var acceso = await _userService.esTokenActivo(Authorization.Remove(0, 7));
                Object newSpic;
                if (!acceso)
                {
                    throw new Exception("token invalido o expirado");
                }
               
                    newSpic = _spicCollection.agregar(spic);

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

        [Authorize]
        [HttpPost]
        [Route("ObtenerServidor")]
        public async Task<ActionResult<ApiResponse>> obtenerPorFiltro([FromHeader] string Authorization, [FromBody] spicFilter filter)
        {
            try
            {
                var acceso = await _userService.esTokenActivo(Authorization.Remove(0, 7));
                Object servidor;
                if (!acceso)
                {
                    throw new Exception("token invalido o expirado");
                }
                
                    servidor = _spicCollection.GetSpCbynames(filter);

                return Ok(new ApiResponse
                {
                    Message = "Process success",
                    Content = servidor
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

        [Authorize]
        [HttpPost]
        [Route("cargarDatos")]
        public async Task<ActionResult<ApiResponse>> insertarRegistros([FromHeader] string Authorization, [FromBody] List<Spic> spics)
        {
            try
            {
                var acceso = await _userService.esTokenActivo(Authorization.Remove(0, 7));
                if (!acceso)
                {
                    throw new Exception("token invalido o expirado");
                }
              
                    await _spicCollection.agregarVarios(spics);
                    return Ok(new ApiResponse
                    {
                        Message = "Process success",
                        Content = spics
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

        [Authorize]
        [HttpPut]
        [Route("actualizarServidor")]
        public async Task<ActionResult<ApiResponse>> actualizarServidor([FromHeader] string Authorization, [FromBody] Spic spic)
        {
            try
            {
                bool acceso = await _userService.esTokenActivo(Authorization.Remove(0, 7));
                if (!acceso)
                {
                    throw new Exception("token invalido o expirado");
                }
              
                    await _spicCollection.actualizarSp(spic);
                    return Ok(new ApiResponse
                    {
                        Message = "Process success",
                        Content = spic
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
