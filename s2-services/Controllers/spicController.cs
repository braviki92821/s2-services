using Microsoft.AspNetCore.Mvc;
using s2_services.models;
using s2_services.repository;

namespace s2_services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class spicController : Controller
    {
        private readonly spicService _spicCollection;

        public spicController(spicService spicCollection)
        {
            _spicCollection= spicCollection;
        }

        [HttpGet]
        public  ActionResult<List<Spic>> GetDatos()
        {
            return  _spicCollection.GetSpicList();
        }

        [HttpPost]
        public ActionResult<Spic> Insertar(Spic spic)
        {
            _spicCollection.agregar(spic);
            return Ok(spic);
        }
 
    }
}
