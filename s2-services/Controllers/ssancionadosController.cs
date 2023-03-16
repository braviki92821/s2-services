using Microsoft.AspNetCore.Mvc;
using s2_services.Data;
using s2_services.models;
using s2_services.Models;
using s2_services.Models.filtro;
using s2_services.repository;
using s2_services.Services;
using System.Net;

namespace s2_services.Controllers
{
    [Route("api/ssancionados")]
    [ApiController]
    public class ssancionadosController : Controller
    { 
        private readonly ssancionadosService _ssancionadosCollection;
        private readonly userService _userService;

        public ssancionadosController(ssancionadosService ssancionadosCollection, userService userService)
        {
            _ssancionadosCollection = ssancionadosCollection;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetDatos()
        {
            try
            {
                Object sscancionadoList;
                sscancionadoList=_ssancionadosCollection.GetSsancionados();
                return Ok(new ApiResponse
                {
                    Message = "Process success.",
                    Content = sscancionadoList
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    IsSuccess = false
                });
            }
        }

        [HttpPost]
        [Route("nuevoServidorS")]
        public async Task<ActionResult<ApiResponse>> insertar([FromBody] Ssancionados ssancionados)
        {
            try
            {
                Object newssancionados;
                newssancionados= _ssancionadosCollection.insertar(ssancionados);
                return Ok(new ApiResponse
                {
                    Message = "Process success.",
                    Content = newssancionados
                }); 
            }
            catch(Exception ex) {
                return BadRequest(new ApiResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    IsSuccess = false
                });
            }
        }

        [HttpPost]
        [Route("buscarSancionado")]
        public async Task<ActionResult<ApiResponse>> obtenerPorFiltro([FromBody] ssancionadosFilter filter)
        {
            try
            {
                Object ssancionados;
                ssancionados=_ssancionadosCollection.GetSsancionadosbynames(filter);
                return Ok(new ApiResponse
                {
                    Message = "Process success.",
                    Content = ssancionados
                });

            }catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    IsSuccess = false
                });
            }
        }

        [HttpPost]
        [Route("cargarDatos")]
        public async Task<ActionResult<ApiResponse>> insertarRegistros([FromBody] List<Ssancionados> ssancionados)
        {
            try
            {
                //var acceso = await _userService.esTokenActivo(Authorization.Remove(0, 7));
                //if (!acceso)
                //{
                //    throw new Exception("token invalido o expirado");
                //}
                //else
                //{
                    await _ssancionadosCollection.agregarVarios(ssancionados);
               // }
                return Ok(new ApiResponse
                {
                    Message = "Process success",
                    Content = ssancionados
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

        [HttpPut]
        [Route("actualizarSancionado")]
        public async Task<ActionResult<ApiResponse>> actualizarServidor([FromBody] Ssancionados ssancionados)
        {
            try
            {
                //bool acceso = await _userService.esTokenActivo(Authorization.Remove(0, 7));
                //if (!acceso)
                //{
                //    throw new Exception("token invalido o expirado");
                //}
                await _ssancionadosCollection.actualizarSpS(ssancionados);
                return Ok(new ApiResponse
                {
                    Message = "Process success",
                    Content = ssancionados
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
