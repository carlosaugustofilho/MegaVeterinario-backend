using System;

namespace MegaVetClinic.Repository.Models.Response
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public EnderecoResponse Endereco { get; set; }
    }
}
