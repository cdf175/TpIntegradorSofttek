﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Helpers;
using TpIntegradorSofttek.Services;

namespace TpIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateDto dto)
        {
            var userCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(dto);

            if (userCredentials is null)
            {
                return Unauthorized("Las credenciales son incorrectas");
            }

            var token = _tokenJwtHelper.GenerateToken(userCredentials);

            var user = new UsuarioLoginDto()
            {
                Nombre = userCredentials.Nombre,
                Dni = userCredentials.Dni,
                Tipo = userCredentials.Tipo,
                Email = userCredentials.Email,
                Token = token
            };

            return Ok(user);

        }
    }
}