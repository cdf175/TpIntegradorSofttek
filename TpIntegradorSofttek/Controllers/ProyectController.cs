using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Helpers;
using TpIntegradorSofttek.Infrastructure;
using TpIntegradorSofttek.Models;
using TpIntegradorSofttek.Services;

namespace TpIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectController : ControllerBase
    {
        private readonly IUnitOfWork _unityOfWork;
        /// <summary>
        /// Contructor del controlador de proyecto.
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ProyectController(IUnitOfWork unitOfWork)
        {
            _unityOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene listado de todos los proyectos. 
        /// Si se ingresa un número de página se aplicará un paginado en la respuesta.
        /// </summary>
        /// <param name="page">Número de página</param>
        /// <param name="pageSize">Cantidad de registros por página</param>
        /// <returns>Retorna una lista de proyectos.</returns>
        /// <response code = "200" >Retorna una lista de proyectos.</response>
        /// <response code = "201" >Retorna un paginado en caso de enviar número de pagina.</response>
        [HttpGet]
        [Authorize(Policy = "Consult")]
        [ProducesResponseType(typeof(ApiSuccessResponseList<Proyect>), 200)]
        [ProducesResponseType(typeof(PaginateDataDto<Proyect>), 201)]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize = 10)
        {
            var proyects = await _unityOfWork.ProyectRepository.GetAll();

            //Paginado
            if (page > 0)
            {
                if (pageSize < 1) return ResponseFactory.CreateErrorResponse(409, "'pageSize' debe ser un número mayor o igual a 1.");
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                var paginateProyects = PaginateHelper.Paginate(proyects, page, url, pageSize);
                return ResponseFactory.CreateSuccessResponse(201, paginateProyects);
            }

            return ResponseFactory.CreateSuccessResponse(200, proyects);
        }

        /// <summary>
        /// Obtiene listado de todos los proyectos filtrando por estado.
        /// Si se ingresa un número de página se aplicará un paginado en la respuesta.
        /// </summary>
        /// <param name="page">Número de página</param>
        /// <param name="pageSize">Cantidad de registros por página</param>
        /// <param name="state">Estado: 1 – Pendiente, 2 – Confirmado, 3 – Terminado</param>
        /// <returns></returns>
        /// <response code = "200" >Retorna una lista de proyectos.</response>
        /// <response code = "201" >Retorna un paginado en caso de enviar número de pagina.</response>
        /// <response code = "409" >Retorna error.</response>
        [HttpGet("state/{state}")]
        [Authorize(Policy = "Consult")]
        [ProducesResponseType(typeof(ApiSuccessResponse<Proyect>), 200)]
        [ProducesResponseType(typeof(PaginateDataDto<Proyect>), 201)]
        [ProducesResponseType(typeof(ApiErrorResponse), 409)]
        public async Task<IActionResult> GetAllState(ProyectState state, [FromQuery] int page, [FromQuery] int pageSize = 10)
        {

            var proyects = await _unityOfWork.ProyectRepository.GetAll(state);

            //Paginado
            if (page > 0)
            {
                if (pageSize < 1) return ResponseFactory.CreateErrorResponse(409, "'pageSize' debe ser un número mayor o igual a 1.");
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                var paginateProyects = PaginateHelper.Paginate(proyects, page, url, pageSize);
                return ResponseFactory.CreateSuccessResponse(201, paginateProyects);
            }

            return ResponseFactory.CreateSuccessResponse(200, proyects);


        }

        /// <summary>
        /// Obtiene la información de un proyecto.
        /// </summary>
        /// <param name="id"> Código de proyecto.</param>
        /// <returns>Retorna la infomación de un proyecto.</returns>
        /// <response code = "200" > Retorna la infomación de un proyecto.</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "Consult")]
        [ProducesResponseType(typeof(ApiSuccessResponse<Proyect>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            var proyect = await _unityOfWork.ProyectRepository.GetById(id);

            return ResponseFactory.CreateSuccessResponse(200, proyect);
        }

        /// <summary>
        /// Crea un nuevo proyecto.
        /// </summary>
        /// <param name="dto">Nombre, Dirección y Estado.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = "Admin")]
        [Route("Create")]
        [ProducesResponseType(typeof(ApiSuccessResponse<string>), 201)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Create(ProyectDto dto)
        {
            var proyect = new Proyect(dto);

            if (!await _unityOfWork.ProyectRepository.Insert(proyect))
                return ResponseFactory.CreateErrorResponse(400, "No se pudo completar la operación.");

            await _unityOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(201, "¡proyecto creado con éxito!");

        }

        /// <summary>
        /// Modifica un proyecto.
        /// </summary>
        /// <param name="id"> Código de proyecto.</param>
        /// <param name="dto">Nombre, Dirección y Estado.</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Policy = "Admin")]
        [Route("Update/{id}")]
        [ProducesResponseType(typeof(ApiSuccessResponse<string>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Update(int id, ProyectDto dto)
        {
            var proyect = new Proyect(dto, id);

            if (!await _unityOfWork.ProyectRepository.Update(proyect))
                return ResponseFactory.CreateErrorResponse(400, "No se pudo completar la operación");


            await _unityOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(200, "¡proyecto actualizado con éxito!");

        }

        /// <summary>
        /// Elimina un proyecto.
        /// </summary>
        /// <param name="id">Código de proyecto.</param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Policy = "Admin")]
        [Route("Delete/{id}")]
        [ProducesResponseType(typeof(ApiSuccessResponse<string>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _unityOfWork.ProyectRepository.Delete(id))
                return ResponseFactory.CreateErrorResponse(400, "No se pudo completar la operación.");

            await _unityOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(200, "El proyecto se ha dado de baja con éxito.");

        }


    }
}
