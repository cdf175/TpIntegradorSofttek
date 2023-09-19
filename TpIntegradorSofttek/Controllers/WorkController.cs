using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Helpers;
using TpIntegradorSofttek.Infrastructure;
using TpIntegradorSofttek.Models;
using TpIntegradorSofttek.Services;

namespace TpIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IUnitOfWork _unityOfWork;
        /// <summary>
        /// Contructor del controlador de trabajo.
        /// </summary>
        /// <param name="unitOfWork"></param>
        public WorkController(IUnitOfWork unitOfWork)
        {
            _unityOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene listado de todos los trabajos activos.
        /// </summary>
        /// <returns>Retorna coleccion de trabajos.</returns>
        /// <response code = "200" > Retorna una coleccion de trabajos.</response>
        /// <response code = "201" > Retorna un paginado en caso de enviar número de pagina.</response>
        [HttpGet]
        [Authorize(Policy = "Consult")]
        [ProducesResponseType(typeof(ApiSuccessResponse<WorkResponseDto>), 200)]
        [ProducesResponseType(typeof(PaginateDataDto<WorkResponseDto>), 201)]
        public async Task<IActionResult> GetAll()
        {
            var works = await _unityOfWork.WorkRepository.GetAll();

            List<WorkResponseDto> WoksDto = new List<WorkResponseDto>();

            foreach (var work in works) {
                WoksDto.Add(_unityOfWork.WorkRepository.ConvertToResponseDto(work));
            }
            //Paginado
            if (Request.Query.ContainsKey("page"))
            {
                int pageToShow = 1;
                int pageSize = 10;
                int.TryParse(Request.Query["page"], out pageToShow);
                if (pageToShow < 1) return ResponseFactory.CreateErrorResponse(409, "'page' debe ser un número mayor o igual a 1.");
                if (Request.Query.ContainsKey("pageSize")) int.TryParse(Request.Query["pageSize"], out pageSize);
                if (pageSize < 1) return ResponseFactory.CreateErrorResponse(409, "'pageSize' debe ser un número mayor o igual a 1.");
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                var paginateWorks = PaginateHelper.Paginate(WoksDto, pageToShow, url, pageSize);
                return ResponseFactory.CreateSuccessResponse(201, paginateWorks);
            }

            return ResponseFactory.CreateSuccessResponse(200, WoksDto);
        }

        /// <summary>
        /// Obtiene la información de un trabajo.
        /// </summary>
        /// <param name="id"> Código de trabajo.</param>
        /// <returns>Retorna un objeto con la infomación del trabajo.</returns>
        /// <response code = "200" > Retorna un objeto con la infomación del trabajo.</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "Consult")]
        [ProducesResponseType(typeof(ApiSuccessResponse<Work>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            var work = await _unityOfWork.WorkRepository.GetById(id);

            var dto = new WorkResponseDto()
            {
                Date = work.Date,
                Proyect = work.Proyect,
                Service = work.Service,
                HourQuantity = work.HourQuantity,
                HourValue = work.HourValue,
                Cost = work.HourValue * work.HourQuantity,
            };

            return ResponseFactory.CreateSuccessResponse(200, dto);
        }

        /// <summary>
        /// Crea un nuevo trabajo.
        /// </summary>
        /// <param name="dto"> Fecha, Código Proyecto, Código Servicio, Cantidad de horas, Valor de hora y Costo total.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = "Admin")]
        [Route("Create")]
        [ProducesResponseType(typeof(ApiSuccessResponse<string>), 201)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Create(WorkDto dto)
        {
            var work = new Work(dto);

            var validateError = await _unityOfWork.WorkRepository.workInsertValidator(work);
            if (validateError != null) return ResponseFactory.CreateErrorResponse(409, validateError);

            if (!await _unityOfWork.WorkRepository.Insert(work))
                return ResponseFactory.CreateErrorResponse(400, "No se pudo completar la operación.");


            await _unityOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(201, "¡trabajo creado con éxito!");

        }

        /// <summary>
        /// Modifica un trabajo.
        /// </summary>
        /// <param name="id"> Código de trabajo.</param>
        /// <param name="dto"> Fecha, Código Proyecto, Código Servicio, Cantidad de horas, Valor de hora y Costo total.</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Policy = "Admin")]
        [Route("Update/{id}")]
        [ProducesResponseType(typeof(ApiSuccessResponse<string>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Update(int id, WorkDto dto)
        {
            var work = new Work(dto, id);

            var validateError = await _unityOfWork.WorkRepository.workInsertValidator(work);
            if (validateError != null) return ResponseFactory.CreateErrorResponse(409, validateError);

            if (!await _unityOfWork.WorkRepository.Update(work))
                return ResponseFactory.CreateErrorResponse(400, "No se pudo completar la operación");


            await _unityOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(200, "¡trabajo actualizado con éxito!");

        }

        /// <summary>
        /// Elimina un trabajo.
        /// </summary>
        /// <param name="id">Código de trabajo.</param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Policy = "Admin")]
        [Route("Delete/{id}")]
        [ProducesResponseType(typeof(ApiSuccessResponse<string>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _unityOfWork.WorkRepository.Delete(id))
                return ResponseFactory.CreateErrorResponse(400, "No se pudo completar la operación.");

            await _unityOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(200, "El trabajo se ha dado de baja con éxito.");

        }

    }
}
