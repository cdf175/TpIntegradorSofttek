using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Models;
using TpIntegradorSofttek.Services;

namespace TpIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unityOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unityOfWork = unitOfWork;
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _unityOfWork.UserRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _unityOfWork.UserRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        [Route("Create")]
        public async Task<IActionResult> Create(RegisterDto dto)
        {
            var user = new User(dto);
            bool success = await _unityOfWork.UserRepository.Insert(user);
            if (!success) return BadRequest("No se pudo completar la operación");

            await _unityOfWork.Complete();

            return Ok("Usuario creado correctamente");
        }

        [HttpPut]
        [Authorize(Policy = "Admin")]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id,RegisterDto dto)
        {
            var user = new User(dto, id);

            bool success = await _unityOfWork.UserRepository.Update(user);
            if (!success) return BadRequest("No se pudo completar la operación");


            await _unityOfWork.Complete();

            return Ok("Usuario actualizado correctamente");
        }

        [HttpDelete]
        [Authorize(Policy = "Admin")]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool success = await _unityOfWork.UserRepository.Delete(id);

            if (!success) return BadRequest("No se pudo completar la operación");

            await _unityOfWork.Complete();

            return Ok("El usuario se ha dado de baja.");
        }




    }
}
