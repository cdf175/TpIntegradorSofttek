using Microsoft.AspNetCore.Mvc;

namespace TpIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        // GET: api/<ProyectosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

       
    }
}
