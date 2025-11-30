using Gestion_Deportiva.Models;
using Gestion_Deportiva.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Gestion_Deportiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        // Método para listar clientes
        [HttpGet("vista")]
        public async Task<IActionResult> ListarClientesVista()
        {
            var clientes = await _service.ListarClientesVistaAsync();
            return Ok(clientes);
        }

    }
}
