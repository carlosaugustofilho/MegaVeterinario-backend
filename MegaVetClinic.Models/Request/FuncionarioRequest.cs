using System;

namespace MegaVetClinic.Models.Requests
{
    public class FuncionarioRequest
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Cargo { get; set; }
        public DateTime DataContratacao { get; set; }
        public decimal? Salario { get; set; }
        public string Beneficios { get; set; }
        public string Email { get; set; }
        public int EnderecoId { get; set; }
    }
}
