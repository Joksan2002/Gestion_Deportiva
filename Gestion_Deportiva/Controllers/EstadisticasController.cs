using Gestion_Deportiva.Models;
using Gestion_Deportiva.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Deportiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadisticasController : ControllerBase
    {
        private readonly EstadisticaService _service;

        public EstadisticasController(EstadisticaService service)
        {
            _service = service;
        }


        // Método para obtener datos estadísticos
        [HttpGet("vista")]
        public async Task<IActionResult> ObtenerVista()
        {
            var data = await _service.ListarVistaAsync();
            return Ok(data);
        }

        // Metodo para insertar una nueva estadística
        [HttpPost("insertar")]
        public async Task<IActionResult> InsertarEstadistica([FromBody] EstadisticaInsertarDTO dto)
        {
            if (dto == null)
                return BadRequest("El DTO es obligatorio.");

            var (tipo, mensaje) = await _service.InsertarEstadisticaAsync(dto);

            if (tipo == 0)
                return Ok(new { mensaje });

            return BadRequest(new { mensaje });
        }

        //Metodo para actualizar una estadística
        public async Task<IActionResult> Actualizar([FromBody] EstadisticaActualizarDTO dto)
        {
            if (dto == null)
                return BadRequest("El DTO es obligatorio.");

            var (tipo, mensaje) = await _service.ActualizarEstadisticaAsync(dto);

            if (tipo == 0)
                return Ok(new { mensaje });

            return BadRequest(new { mensaje });
        }

        //Metodo para obtener una estadística por su ID
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var (tipo, mensaje, data) = await _service.ObtenerEstadisticaPorIdAsync(id);

            if (tipo == 0)
                return Ok(data);

            return BadRequest(new { mensaje });
        }

        //Metodo para estadisticas por partido
        [HttpGet("partido/{partidoId}")]
        public async Task<IActionResult> ListarPorPartido(int partidoId)
        {
            var (tipo, mensaje, data) = await _service.ListarPorPartidoAsync(partidoId);

            if (tipo == 0)
                return Ok(data);

            return BadRequest(new { mensaje });
        }

        //Metodo para obtener estadisticas por jugador
        [HttpGet("jugador/{jugadorId}")]
        public async Task<IActionResult> ListarPorJugador(int jugadorId)
        {
            var (tipo, mensaje, data) = await _service.ListarPorJugadorAsync(jugadorId);

            if (tipo == 0)
                return Ok(data);

            return BadRequest(new { mensaje });
        }
    }
}
