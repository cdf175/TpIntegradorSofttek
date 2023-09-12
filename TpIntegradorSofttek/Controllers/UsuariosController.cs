using Microsoft.AspNetCore.Mvc;

namespace TpIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET: UsuarioController
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

    }
}
