using Microsoft.AspNetCore.Mvc;
using MegaVetClinic.Repository.Interfaces;
using MegaVetClinic.Repository.Models.Response;
using MegaVetClinic.Models.Requests;

namespace MegaVetClinic.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        [Route("CriarCliente")]
        public IActionResult CriarClientes([FromBody] ClienteRequest clienteRequest)
        {
            try
            {
                var result = _clienteRepository.CriarClientes(clienteRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
