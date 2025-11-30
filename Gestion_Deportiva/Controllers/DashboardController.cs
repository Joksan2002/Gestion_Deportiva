using Gestion_Deportiva.Models;
using Gestion_Deportiva.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Gestion_Deportiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _service;

        public DashboardController(DashboardService service)
        {
            _service = service;
        }

        // obtener contadores para el dashboard
        [HttpGet("contadores")]
        public async Task<IActionResult> ObtenerContadores()
        {
            var data = await _service.ObtenerDashboardAsync();
            return Ok(data);
        }

        // obtener proximos partidos
        [HttpGet("proximos-partidos")]
        public async Task<IActionResult> ObtenerProximosPartidos()
        {
            var data = await _service.ObtenerProximosPartidosAsync();
            return Ok(data);
        }

        // obtener ultimos resultados
        [HttpGet("ultimos-resultados")]
        public async Task<IActionResult> ObtenerResultadosRecientes()
        {
            var data = await _service.ObtenerResultadosRecientesAsync();
            return Ok(data);
        }
    }
}
