using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaVetClinic.Repository.Models.Response
{
    public class ClienteResponse
    {
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("sobrenome")]
        public string Sobrenome { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("data_nascimento")]
        public DateTime? DataNascimento { get; set; } // Atualize para nullable se necessário

        [Column("cpf")]
        public string CPF { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("endereco_id")]
        public int EnderecoId { get; set; }

        public virtual EnderecoResponse Endereco { get; set; }
    }
}
