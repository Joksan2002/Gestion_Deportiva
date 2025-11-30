using Gestion_Deportiva.Models;
using Gestion_Deportiva.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Deportiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigasController : ControllerBase
    {
        private readonly LigasService _service;

        public LigasController(LigasService service)
        {
            _service = service;
        }

        // lista de ligas vista
        [HttpGet("vista")]
        public async Task<IActionResult> ListarLigasVista()
        {
            var liga = await _service.ListarLigasVistaAsync();
            return Ok(liga);
        }

        // registrar liga
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarLiga([FromBody] LigaRegistrarDTO dto)
        {
            var resultado = await _service.RegistrarLiga(dto);

            return Ok(new
            {
                tipoMensaje = resultado.tipoMensaje,
                mensaje = resultado.mensaje
            });
        }

        // actualizar liga
        [HttpPut("actualizar")]
        public async Task<IActionResult> ActualizarLiga([FromBody] LigaActualizarDTO dto)
        {
            var resultado = await _service.ActualizarLiga(dto);

            return Ok(new
            {
                tipoMensaje = resultado.tipoMensaje,
                mensaje = resultado.mensaje
            });
        }

        //ligas por deporte
        [HttpGet("por-deporte")]
        public async Task<IActionResult> ListarLigasPorDeporte([FromBody] LigaPorDeporteDTO dto)
        {
            var resultado = await _service.ListarLigasPorDeporte(dto.DeportesId);

            return Ok(new
            {
                tipoMensaje = resultado.tipoMensaje,
                mensaje = resultado.mensaje,
                data = resultado.data
            });
        }
    }
}
