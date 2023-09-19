using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Helpers;
using TpIntegradorSofttek.Infrastructure;
using TpIntegradorSofttek.Services;

namespace TpIntegradorSofttek.Controllers
{
    /// <summary>
    /// Esta clase controla las operaciones relacionadas con la autenticación y el inicio de sesión de usuarios.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor del controlador de login
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="unitOfWork"></param>
        public LoginController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

        /// <summary>
        /// Inicia sesion para poder acceder a las distintas funcionalidades de la API.
        /// </summary>
        /// <param name="dto"> Email y Contraseña</param>
        /// <returns> Retorna un token. </returns>
        /// <response code = "200" > Retorna un token. </response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiSuccessResponse<UserLoginDto>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 401)]
        public async Task<IActionResult> Login(AuthenticateDto dto)
        {
            var userCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(dto);

            if (userCredentials is null)
            {
                return ResponseFactory.CreateErrorResponse(401, "Las credenciales son incorrectas");
            }

            var token = _tokenJwtHelper.GenerateToken(userCredentials);

            var user = new UserLoginDto()
            {
                Name = userCredentials.Name,
                Dni = userCredentials.Dni,
                Type = userCredentials.Type,
                Email = userCredentials.Email,
                Token = token
            };

            return ResponseFactory.CreateSuccessResponse(200, user);

        }
    }
}
