using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Helpers;
using TpIntegradorSofttek.Infrastructure;
using TpIntegradorSofttek.Models;
using TpIntegradorSofttek.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TpIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unityOfWork;
        /// <summary>
        /// Contructor del controlador de servicio.
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unityOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene listado de todos los servicios.
        /// Si se ingresa un número de página se aplicará un paginado en la respuesta.
        /// </summary>
        /// <returns>Retorna un listado de servicios.</returns>
        /// <param name="page">Número de página</param>
        /// <param name="pageSize">Cantidad de registros por página</param>
        /// <response code = "200" > Retorna una lista de servicios.</response>
        /// <response code = "201" > Retorna un paginado en caso de enviar número de pagina.</response>
        [HttpGet]
        [Authorize(Policy = "Consult")]
        [ProducesResponseType(typeof(ApiSuccessResponseList<Service>), 200)]
        [ProducesResponseType(typeof(PaginateDataDto<Service>), 201)]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize = 10)
        {
            var services = await _unityOfWork.ServiceRepository.GetAll();

            //Paginado
            if (page > 0)
            {
                if (pageSize < 1) return ResponseFactory.CreateErrorResponse(409, "'pageSize' debe ser un número mayor o igual a 1.");
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                var paginateServices = PaginateHelper.Paginate(services, page, url, pageSize);
                return ResponseFactory.CreateSuccessResponse(201, paginateServices);
            }

            return ResponseFactory.CreateSuccessResponse(200, services);
        }

        /// <summary>
        /// Obtiene listado de todos los servicios con estado activo.
        /// Si se ingresa un número de página se aplicará un paginado en la respuesta.
        /// </summary>
        ///  <param name="page">Número de página</param>
        ///  <param name="pageSize">Cantidad de registros por página</param>
        /// <returns></returns>
        /// <response code = "200" > Retorna una lista de servicios activos.</response>
        /// <response code = "201" > Retorna un paginado en caso de enviar número de pagina.</response>
        /// <response code = "409" > Retorna error.</response>
        [HttpGet]
        [Authorize(Policy = "Consult")]
        [Route("Active")]
        [ProducesResponseType(typeof(ApiSuccessResponseList<Service>), 200)]
        [ProducesResponseType(typeof(PaginateDataDto<Service>), 201)]
        [ProducesResponseType(typeof(ApiErrorResponse), 409)]
        public async Task<IActionResult> GetAllActive([FromQuery] int page, [FromQuery] int pageSize = 10)
        {
            var services = await _unityOfWork.ServiceRepository.GetAllActive();

            //Paginado
            if (page > 0)
            {
                if (pageSize < 1) return ResponseFactory.CreateErrorResponse(409, "'pageSize' debe ser un número mayor o igual a 1.");
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                var paginateServices = PaginateHelper.Paginate(services, page, url, pageSize);
                return ResponseFactory.CreateSuccessResponse(201, paginateServices);
            }

            return ResponseFactory.CreateSuccessResponse(200, services);
        }
        /// <summary>
        /// Obtiene la información de un servicio.
        /// </summary>
        /// <param name="id"> Código de servicio.</param>
        /// <returns>Retorna un objeto con la infomación del servicio.</returns>
        /// <response code = "200" > Retorna un objeto con la infomación del servicio.</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "Consult")]
        [ProducesResponseType(typeof(ApiSuccessResponse<ServiceDto>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _unityOfWork.ServiceRepository.GetById(id);

            return ResponseFactory.CreateSuccessResponse(200, service);
        }

        /// <summary>
        /// Crea un nuevo servicio.
        /// </summary>
        /// <param name="dto"> Descripción, Estado y Valor por hora.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = "Admin")]
        [Route("Create")]
        [ProducesResponseType(typeof(ApiSuccessResponse<string>), 201)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Create(ServiceDto dto)
        {

            var service = new Service(dto);

            if (!await _unityOfWork.ServiceRepository.Insert(service))
                return ResponseFactory.CreateErrorResponse(400, "No se pudo completar la operación.");


            await _unityOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(201, "¡servicio creado con éxito!");

        }

        /// <summary>
        /// Modifica un servicio.
        /// </summary>
        /// <param name="id"> Código de servicio.</param>
        /// <param name="dto"> Descripción, Estado y Valor por hora.</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Policy = "Admin")]
        [Route("Update/{id}")]
        [ProducesResponseType(typeof(ApiSuccessResponse<string>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Update(int id, ServiceDto dto)
        {

            var service = new Service(dto, id);

            if (!await _unityOfWork.ServiceRepository.Update(service))
                return ResponseFactory.CreateErrorResponse(400, "No se pudo completar la operación");


            await _unityOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(200, "¡servicio actualizado con éxito!");

        }

        /// <summary>
        /// Elimina un servicio.
        /// </summary>
        /// <param name="id">Código de servicio.</param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Policy = "Admin")]
        [Route("Delete/{id}")]
        [ProducesResponseType(typeof(ApiSuccessResponse<string>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _unityOfWork.ServiceRepository.Delete(id))
                return ResponseFactory.CreateErrorResponse(400, "No se pudo completar la operación.");

            await _unityOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(200, "El servicio se ha dado de baja con éxito.");

        }

    }
}
