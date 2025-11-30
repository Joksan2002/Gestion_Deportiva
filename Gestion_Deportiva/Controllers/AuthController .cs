using Gestion_Deportiva.Models;
using Gestion_Deportiva.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Deportiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginService _loginService;

        public AuthController(LoginService loginService)
        {
            _loginService = loginService;
        }

        // Método para el login de usuarios
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new
                {
                    TipoMensaje = 1,
                    Mensaje = "Debe enviar un usuario y contraseña."
                });
            }

            var result = await _loginService.Login(dto);

            if (result.TipoMensaje != 0)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
