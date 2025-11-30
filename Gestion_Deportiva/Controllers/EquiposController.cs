using Gestion_Deportiva.Models;
using Gestion_Deportiva.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Deportiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly EquipoService _service;

        public EquiposController(EquipoService service)
        {
            _service = service;
        }

        // Método para listar equipos
        [HttpGet("vista")]
        public async Task<IActionResult> ListarEquiposVista()
        {
            var equipos = await _service.ListarEquiposVistaAsync();
            return Ok(equipos);
        }

        // Metodo para registrar un nuevo equipo
        [HttpPost("insertar")]
        public async Task<IActionResult> InsertarEquipo([FromBody] EquipoInsertarDTO dto)
        {
            var result = await _service.InsertarEquipoAsync(dto);

            if (result.TipoMensaje == 0)
                return Ok(new { ok = true, mensaje = result.Mensaje });

            return BadRequest(new { ok = false, error = result.Mensaje });
        }

        // Metodo para actualizar un equipo
        [HttpPut("actualizar")]
        public async Task<IActionResult> ActualizarEquipo([FromBody] EquipoActualizarDTO dto)
        {
            var result = await _service.ActualizarEquipoAsync(dto);

            if (result.TipoMensaje == 0)
                return Ok(new { mensaje = result.Mensaje });
            
            return BadRequest(new { error = result.Mensaje });
        }

        //Metodo para eliminar un equipo
        [HttpDelete("eliminar/{equipoId}")]
        public async Task<IActionResult> EliminarEquipo(int equipoId)
        {
            var result = await _service.EliminarEquipoAsync(equipoId);

            if (result.TipoMensaje == 0)
                return Ok(new { mensaje = result.Mensaje });

            return BadRequest(new { error = result.Mensaje });
        }

        // Metodo para obtener un equipo por su ID
        [HttpGet("obtener/{equipoId}")]
        public async Task<IActionResult> ObtenerEquipoPorId(int equipoId)
        {
            var result = await _service.ObtenerEquipoPorIdAsync(equipoId);

            if (result.TipoMensaje != 0)
                return BadRequest(new { error = result.Mensaje });

            return Ok(new
            {
                mensaje = result.Mensaje,
                equipo = result.Data
            });
        }
    }
}
