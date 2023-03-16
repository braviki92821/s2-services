using Microsoft.AspNetCore.Mvc;
using s2_services.Data;
using s2_services.Models.filtro;
using s2_services.Models;
using s2_services.repository;
using s2_services.Services;
using System.Net;

namespace s2_services.Controllers
{
    [Route("api/psancionados")]
    [ApiController]
    public class psancionadosController : Controller
    {
        private readonly psancionadosService _psancionadosCollection;
        private readonly userService _userService;

        public psancionadosController(psancionadosService psancionadosCollection, userService userService)
        {
            _psancionadosCollection = psancionadosCollection;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetDatos()
        {
            try
            {
                Object pscancionadoList;
                pscancionadoList = _psancionadosCollection.GetPsancionados();
                return Ok(new ApiResponse
                {
                    Message = "Process success.",
                    Content = pscancionadoList
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
        [Route("nuevoServidorPS")]
        public async Task<ActionResult<ApiResponse>> insertar([FromBody] Psancionados psancionados)
        {
            try
            {
                Object newpsancionados;
                newpsancionados = _psancionadosCollection.insertar(psancionados);
                return Ok(new ApiResponse
                {
                    Message = "Process success.",
                    Content = newpsancionados
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
        [Route("buscarSancionadoP")]
        public async Task<ActionResult<ApiResponse>> obtenerPorFiltro([FromBody] psancionadosFilter filter)
        {
            try
            {
                Object psancionados;
                psancionados = _psancionadosCollection.GetPsancionadosbynames(filter);
                return Ok(new ApiResponse
                {
                    Message = "Process success.",
                    Content = psancionados
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
        [Route("cargarDatos")]
        public async Task<ActionResult<ApiResponse>> insertarRegistros([FromBody] List<Psancionados> psancionados)
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
                await _psancionadosCollection.agregarVarios(psancionados);
                // }
                return Ok(new ApiResponse
                {
                    Message = "Process success",
                    Content = psancionados
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
        public async Task<ActionResult<ApiResponse>> actualizarServidor([FromBody] Psancionados psancionados)
        {
            try
            {
                //bool acceso = await _userService.esTokenActivo(Authorization.Remove(0, 7));
                //if (!acceso)
                //{
                //    throw new Exception("token invalido o expirado");
                //}
                await _psancionadosCollection.actualizarPs(psancionados);
                return Ok(new ApiResponse
                {
                    Message = "Process success",
                    Content = psancionados
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
