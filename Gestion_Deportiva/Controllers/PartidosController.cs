using Gestion_Deportiva.Models;
using Gestion_Deportiva.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Deportiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidosController : ControllerBase
    {
        private readonly PartidoService _service;

        public PartidosController(PartidoService service)
        {
            _service = service;
        }

        // Método para listar partidos 
        [HttpGet("vista")]
        public async Task<IActionResult> ListarPartidosVista()
        {
            var data = await _service.ListarPartidosVistaAsync();
            return Ok(data);
        }

        // Metodo para registrar un nuevo partido 
        [HttpPost("insertar")]
        public async Task<IActionResult> InsertarPartido([FromBody] PartidoInsertarDTO dto)
        {
            var result = await _service.InsertarPartidoAsync(dto);

            if (result.TipoMensaje == 0)
                return Ok(new { mensaje = result.Mensaje });

            return BadRequest(new { error = result.Mensaje });
        }

        // PUT api/partidos/actualizar
        [HttpPut("actualizar")]
        public async Task<IActionResult> ActualizarPartido([FromBody] PartidoActualizarDTO dto)
        {
            if (dto == null || dto.PartidoId <= 0)
                return BadRequest("El objeto DTO es inválido o falta PartidoId.");

            var (tipo, mensaje) = await _service.ActualizarPartidoAsync(dto);

            if (tipo == 0)
                return Ok(new { mensaje });

            return BadRequest(new { mensaje });
        }

        // PUT api/partidos/actualizar-marcador
        [HttpPut("actualizar-marcador")]
        public async Task<IActionResult> ActualizarMarcador([FromBody] PartidoActualizarMarcadorDTO dto)
        {
            if (dto == null)
                return BadRequest("El DTO es obligatorio.");

            if (dto.PartidoId <= 0)
                return BadRequest("El ID del partido es inválido.");

            var (tipo, mensaje) = await _service.ActualizarMarcadorAsync(dto);

            if (tipo == 0)
                return Ok(new { mensaje });

            return BadRequest(new { mensaje });
        }

        // Metodo para obtener un partido por su ID 
     
        [HttpGet("obtener/{id:int}")]
        public async Task<IActionResult> ObtenerPartidoPorId(int id)
        {
            var (tipo, mensaje, data) = await _service.ObtenerPartidoPorIdAsync(id);

            if (tipo == 1)
                return NotFound(new { mensaje });

            if (tipo == 2)
                return StatusCode(500, new { mensaje });

            return Ok(data);
        }

        // Metodo para listar partidos por liga
        [HttpGet("listar-por-liga/{ligaId:int}")]
        public async Task<IActionResult> ListarPartidosPorLiga(int ligaId)
        {
            var (tipo, mensaje, data) = await _service.ListarPartidosPorLigaAsync(ligaId);

            if (tipo == 1)
                return BadRequest(new { mensaje });

            if (tipo == 2)
                return StatusCode(500, new { mensaje });

            return Ok(data);
        }
    }
}
