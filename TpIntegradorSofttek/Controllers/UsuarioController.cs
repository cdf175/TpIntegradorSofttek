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

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var user = await _unityOfWork.UsuarioRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new Usuario(dto);
            bool success = await _unityOfWork.UsuarioRepository.Insert(user);
            if (!success) return BadRequest("No se pudo completar la operación");

            await _unityOfWork.Complete();

            return Ok("Usuario registrado correctamente");
        }

        [HttpPut]
        [Authorize(Policy = "Admin")]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id,RegisterDto dto)
        {
            var user = new Usuario(dto, id);

            bool success = await _unityOfWork.UsuarioRepository.Update(user);
            if (!success) return BadRequest("No se pudo completar la operación");


            await _unityOfWork.Complete();

            return Ok("Usuario actualizado correctamente");
        }

        [HttpDelete]
        [Authorize(Policy = "Admin")]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool success = await _unityOfWork.UsuarioRepository.Delete(id);

            if (!success) return BadRequest("No se pudo completar la operación");

            await _unityOfWork.Complete();

            return Ok("El usuario se ha dado de baja.");
        }




    }
}
