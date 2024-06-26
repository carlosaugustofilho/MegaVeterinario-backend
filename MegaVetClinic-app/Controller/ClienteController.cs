using Microsoft.AspNetCore.Mvc;
using MegaVetClinic.Repository.Repositories;
using MegaVetClinic.Repository.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MegaVetClinic.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteRepository _clienteRepository;

        public ClientesController(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        

        [HttpPost]
        public async Task<ActionResult<ClienteResponse>> CriarClientesAsync([FromBody] ClienteRequest clienteRequest)
        {
            if (clienteRequest == null)
            {
                return BadRequest();
            }

            var clienteResponse = await _clienteRepository.CriarClientesAsync(clienteRequest);

            return CreatedAtAction(nameof(ClienteRequest), new { id = clienteResponse.Id }, clienteResponse);
        }
    }
}
