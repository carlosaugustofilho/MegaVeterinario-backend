using Microsoft.AspNetCore.Mvc;
using MegaVetClinic.Business.Interfaces;
using MegaVetClinic.Models.Requests;
using System;

namespace MegaVetClinic.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("CriarCliente")]
        public IActionResult CriarClientes([FromBody] ClienteRequest clienteRequest)
        {
            try
            {
                var result = _clienteService.CriarClientes(clienteRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{clienteId}")]
        public IActionResult BuscarClientePorId(int clienteId)
        {
            try
            {
                var cliente = _clienteService.BuscarClientePorId(clienteId);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{clienteId}")]
        public IActionResult AtualizarCliente(int clienteId, [FromBody] ClienteRequest clienteRequest)
        {
            try
            {
                var cliente = _clienteService.AtualizarCliente(clienteId, clienteRequest);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("BuscarPorCpf/{cpf}")]
        public IActionResult BuscarClientePorCpf(string cpf)
        {
            try
            {
                var cliente = _clienteService.BuscarClientePorCpf(cpf);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
