using Gestion_Deportiva.Models;
using Gestion_Deportiva.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Deportiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturasService _connection;

        public FacturaController(FacturasService connection)
        {
            _connection = connection;
        }

        // obtener una factura por id
        [HttpGet("obtener/{id}")]
        public async Task<IActionResult> ObtenerFactura(int id)
        {
            var (factura, tipoMensaje, mensaje) = await _connection.ObtenerFacturaPorId(id);

            if (tipoMensaje == 1)
                return BadRequest(new { tipoMensaje, mensaje });

            return Ok(new
            {
                tipoMensaje,
                mensaje,
                factura
            });
        }
    }
}
