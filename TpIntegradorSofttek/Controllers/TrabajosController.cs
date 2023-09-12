using Microsoft.AspNetCore.Mvc;

namespace TpIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajosController : ControllerBase
    {
        // GET: TrabajosController
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

    }
}
