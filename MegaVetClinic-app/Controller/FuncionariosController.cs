using Microsoft.AspNetCore.Mvc;
using MegaVetClinic.Business.Interfaces;
using MegaVetClinic.Models.Requests;
using System;

namespace MegaVetClinic.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionariosController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpPost("CadastrarFuncionario")]
        public IActionResult CadastrarFuncionario([FromBody] FuncionarioRequest funcionarioRequest)
        {
            try
            {
                var result = _funcionarioService.CadastrarFuncionario(funcionarioRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{funcionarioId}")]
        public IActionResult BuscarFuncionarioPorId(int funcionarioId)
        {
            try
            {
                var funcionario = _funcionarioService.BuscarFuncionarioPorId(funcionarioId);
                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{funcionarioId}")]
        public IActionResult AtualizarFuncionario(int funcionarioId, [FromBody] FuncionarioRequest funcionarioRequest)
        {
            try
            {
                var funcionario = _funcionarioService.AtualizarFuncionario(funcionarioId, funcionarioRequest);
                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AlterarStatusFuncionario/{funcionarioId}")]
        public IActionResult AlterarStatusFuncionario(int funcionarioId, [FromQuery] bool ativo)
        {
            try
            {
                var funcionario = _funcionarioService.AlterarStatusFuncionario(funcionarioId, ativo);
                return Ok(new
                {
                    Mensagem = $"Funcionário {(ativo ? "ativado" : "inativado")} com sucesso",
                    Funcionario = funcionario
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

    }
}
