using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Helpers;
using TpIntegradorSofttek.Infrastructure;
using TpIntegradorSofttek.Models;
using TpIntegradorSofttek.Services;

namespace TpIntegradorSofttek.Controllers
{
    /// <summary>
    /// Esta clase controla las acciones y la lógica relacionada con la gestión de usuarios.
    /// Proporciona métodos para crear, actualizar, eliminar y consultar usuarios.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unityOfWork;
        /// <summary>
        /// Contructor del controlador de usuario.
        /// </summary>
        /// <param name="unitOfWork"></param>
        public UserController(IUnitOfWork unitOfWork)
        {
            _unityOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene listado de todos los usuarios activos.
        /// </summary>
        /// <returns>Retorna coleccion de usuarios.</returns>
        /// <response code = "200" > Retorna una coleccion de usuarios.</response>
        /// <response code = "201" > Retorna un paginado en caso de enviar número de pagina.</response>
        [HttpGet]
        [Authorize(Policy = "Consult")]
        [ProducesResponseType(typeof(ApiSuccessResponse<User>), 200)]
        [ProducesResponseType(typeof(PaginateDataDto<User>), 201)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unityOfWork.UserRepository.GetAll();

            //Paginado
            if (Request.Query.ContainsKey("page"))
            {
                int pageToShow = 1;
                int pageSize = 10;
                int.TryParse(Request.Query["page"], out pageToShow);
                if (Request.Query.ContainsKey("pageSize")) int.TryParse(Request.Query["pageSize"], out pageSize);
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                var paginateUsers = PaginateHelper.Paginate(users, pageToShow, url, pageSize);
                return ResponseFactory.CreateSuccessResponse(201, paginateUsers);
            }

            return ResponseFactory.CreateSuccessResponse(200, users);
        }

        /// <summary>
        /// Obtiene la información de un usuario.
        /// </summary>
        /// <param name="id"> Código de usuario.</param>
        /// <returns>Retorna un objeto con la infomación del usuario.</returns>
        /// <response code = "200" > Retorna un objeto con la infomación del usuario.</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "Consult")]
        [ProducesResponseType(typeof(ApiSuccessResponse<User>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _unityOfWork.UserRepository.GetById(id);
            var dto = new UserResponseDto()
            {
                Id = id,
                Name = user.Name,
                Dni = user.Dni,
                Type = user.Type,
                Email = user.Email,
            };

            return ResponseFactory.CreateSuccessResponse(200, dto);
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="dto">Nombre, Tipo, DNI, Email y Contraseña.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = "Admin")]
        [Route("Create")]
        [ProducesResponseType(typeof(ApiSuccessResponse<string>), 201)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Create(RegisterDto dto)
        {
            if (await _unityOfWork.UserRepository.EmailExist(dto.Email))
                return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el email: {dto.Email}.");
            
            var user = new User(dto);
            
            if (!await _unityOfWork.UserRepository.Insert(user)) 
                return ResponseFactory.CreateErrorResponse(400,"No se pudo completar la operación.");


            await _unityOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(201, "¡Usuario creado con éxito!");

        }

        /// <summary>
        /// Modifica un usuario.
        /// </summary>
        /// <param name="id"> Código de usuario.</param>
        /// <param name="dto">Nombre, Tipo, DNI, Email y Contraseña.</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Policy = "Admin")]
        [Route("Update/{id}")]
        [ProducesResponseType(typeof(ApiSuccessResponse<string>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Update(int id,RegisterDto dto)
        {
            if (await _unityOfWork.UserRepository.EmailUpdateExist(dto.Email,id ))
                return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el email: {dto.Email}.");
            
            var user = new User(dto, id);

            if (!await _unityOfWork.UserRepository.Update(user))
                return ResponseFactory.CreateErrorResponse(400,"No se pudo completar la operación");


            await _unityOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(200, "¡Usuario actualizado con éxito!");

        }

        /// <summary>
        /// Elimina un usuario.
        /// </summary>
        /// <param name="id">Código de usuario.</param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Policy = "Admin")]
        [Route("Delete/{id}")]
        [ProducesResponseType(typeof(ApiSuccessResponse<string>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _unityOfWork.UserRepository.Delete(id)) 
                return ResponseFactory.CreateErrorResponse(400,"No se pudo completar la operación.");

            await _unityOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(200, "El usuario se ha dado de baja con exito.");

        }




    }
}
