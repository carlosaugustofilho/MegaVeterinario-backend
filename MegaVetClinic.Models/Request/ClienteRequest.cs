using MegaVetClinic.Models.Request;
using System;

namespace MegaVetClinic.Models.Requests
{
    public class ClienteRequest
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public EnderecoRequest Endereco { get; set; }
    }
}
