using Gestion_Deportiva.Models;
using Gestion_Deportiva.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Deportiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletosController : ControllerBase
    {
        private readonly BoletoService _service;

        public BoletosController(BoletoService service)
        {
            _service = service;
        }
        //Metodo para registrar un nuevo boleto
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarBoleto([FromBody] BoletoRegistrarDTO dto)
        {
            var (tipo, mensaje) = await _service.RegistrarVentaAsync(dto);

            if (tipo == 0)
                return Ok(new { mensaje });

            return BadRequest(new { mensaje });
        }

        //Metodo para obtener detalles de un boleto por su ID
        [HttpGet("{boletoId}")]
        public async Task<IActionResult> ObtenerPorId(int boletoId)
        {
            var (tipo, mensaje, data) = await _service.ObtenerPorIdAsync(boletoId);

            if (tipo == 0)
                return Ok(data);

            return BadRequest(new { mensaje });
        }

        //Metodo para obtener boletos por ID de partido
        [HttpGet("por-partido/{partidoId}")]
        public async Task<IActionResult> ListarPorPartido(int partidoId)
        {
            var result = await _service.ListarPorPartidoAsync(partidoId);

            if (result.TipoMensaje != 0)
                return BadRequest(new { result.TipoMensaje, result.Mensaje });

            return Ok(result.Data);
        }

    }
}
