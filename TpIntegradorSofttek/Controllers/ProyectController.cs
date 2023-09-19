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
        /// Obtiene listado de todos los proyectos activos.
        /// </summary>
        /// <returns>Retorna coleccion de proyectos.</returns>
        /// <response code = "200" > Retorna una coleccion de proyectos.</response>
        /// <response code = "201" > Retorna un paginado en caso de enviar número de pagina.</response>
        [HttpGet]
        [Authorize(Policy = "Consult")]
        [ProducesResponseType(typeof(ApiSuccessResponse<Proyect>), 200)]
        [ProducesResponseType(typeof(PaginateDataDto<Proyect>), 201)]
        public async Task<IActionResult> GetAll()
        {
            var proyects = await _unityOfWork.ProyectRepository.GetAll();

            //Paginado
            if (Request.Query.ContainsKey("page"))
            {
                int pageToShow;
                int pageSize = 10;
                int.TryParse(Request.Query["page"], out pageToShow);
                if (pageToShow < 1 ) return ResponseFactory.CreateErrorResponse(409, "'page' debe ser un número mayor o igual a 1.");
                if (Request.Query.ContainsKey("pageSize")) int.TryParse(Request.Query["pageSize"], out pageSize);
                if (pageSize < 1) return ResponseFactory.CreateErrorResponse(409, "'pageSize' debe ser un número mayor o igual a 1.");
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                var paginateProyects = PaginateHelper.Paginate(proyects, pageToShow, url, pageSize);
                return ResponseFactory.CreateSuccessResponse(201, paginateProyects);
            }

            return ResponseFactory.CreateSuccessResponse(200, proyects);
        }

        /// <summary>
        /// Obtiene la información de un proyecto.
        /// </summary>
        /// <param name="id"> Código de proyecto.</param>
        /// <returns>Retorna un objeto con la infomación del proyecto.</returns>
        /// <response code = "200" > Retorna un objeto con la infomación del proyecto.</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "Consult")]
        [ProducesResponseType(typeof(ApiSuccessResponse<ProyectDto>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            var proyect = await _unityOfWork.ProyectRepository.GetById(id);
            var dto = new ProyectDto()
            {
                Name = proyect.Name,
                Address = proyect.Address,
                State = proyect.State,
            };

            return ResponseFactory.CreateSuccessResponse(200, dto);
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
