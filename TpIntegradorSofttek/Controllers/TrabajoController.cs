using Microsoft.AspNetCore.Mvc;

namespace TpIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajoController : ControllerBase
    {
        // GET: TrabajosController
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

    }
}
