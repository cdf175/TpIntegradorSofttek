using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttek.Models;
using TpIntegradorSofttek.Services;

namespace TpIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unityOfWork;
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unityOfWork = unitOfWork;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var users = await _unityOfWork.UsuarioRepository.GetAll();
            return Ok(users);
        }

    }
}
