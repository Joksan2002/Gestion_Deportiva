using Gestion_Deportiva.Models;
using Gestion_Deportiva.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Deportiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        private readonly JugadorService _service;

        public JugadoresController(JugadorService service)
        {
            _service = service;
        }

        // obtener la lista de jugadores
        [HttpGet("vista")]
        public async Task<IActionResult> ListarJugadoresVista()
        {
            var jugadores = await _service.ListarJugadoresVistaAsync();
            return Ok(jugadores);
        }

        // registrar un nuevo jugador
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarJugador([FromBody] JugadorRegistrarDTO dto)
        {
            var resultado = await _service.RegistrarJugadorAsync(dto);

            if (resultado.TipoMensaje == 0)
                return Ok(new { ok = true, mensaje = resultado.Mensaje });

            return BadRequest(new { ok = false, mensaje = resultado.Mensaje });
        }

        // actualizar un jugador existente
        [HttpPut("actualizar")]
        public async Task<IActionResult> ActualizarJugador([FromBody] JugadorActualizarDTO dto)
        {
            var result = await _service.ActualizarJugadorAsync(dto);

            if (result.TipoMensaje == 0)
                return Ok(new { mensaje = result.Mensaje });

            return BadRequest(new { error = result.Mensaje });
        }


        // eliminar un jugador por id
        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarJugador(int id)
        {
            var result = await _service.EliminarJugadorAsync(id);

            if (result.TipoMensaje == 0)
                return Ok(new { mensaje = result.Mensaje });

            return BadRequest(new { error = result.Mensaje });
        }

        // obtener un jugador por id
        [HttpGet("obtener/{id}")]
        public async Task<IActionResult> ObtenerJugadorPorId(int id)
        {
            var result = await _service.ObtenerJugadorPorIdAsync(id);

            if (result.TipoMensaje != 0)
                return BadRequest(new { error = result.Mensaje });

            return Ok(new
            {
                mensaje = result.Mensaje,
                jugador = result.Data
            });
        }

        // listar jugadores por equipo
        [HttpGet("por-equipo/{equipoId}")]
        public async Task<IActionResult> ListarPorEquipo(int equipoId)
        {
            var result = await _service.ListarPorEquipoAsync(equipoId);

            if (result.TipoMensaje != 0)
                return BadRequest(new { error = result.Mensaje });

            return Ok(new
            {
                mensaje = result.Mensaje,
                jugadores = result.Data
            });
        }


    }
}
