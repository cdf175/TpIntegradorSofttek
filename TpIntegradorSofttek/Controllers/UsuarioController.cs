using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttek.DTOs;
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
        [Authorize]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var users = await _unityOfWork.UsuarioRepository.GetAll();
            return Ok(users);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new Usuario(dto);
            await _unityOfWork.UsuarioRepository.Insert(user);
            await _unityOfWork.Complete();

            return Ok("Usuario registrado correctamente");
        }

    }
}
