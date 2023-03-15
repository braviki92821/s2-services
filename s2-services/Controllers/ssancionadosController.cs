using Microsoft.AspNetCore.Mvc;
using s2_services.Data;
using s2_services.Models;
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
    }
}
