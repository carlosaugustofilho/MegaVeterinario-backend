using Microsoft.AspNetCore.Mvc;
using MegaVetClinic.Business.Interfaces;
using MegaVetClinic.Models.Requests;
using System;
using MegaVetClinic.Business.Service;

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
    }
}
