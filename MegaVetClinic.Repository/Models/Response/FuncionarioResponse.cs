using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaVetClinic.Repository.Models.Response
{
    public class FuncionarioResponse
    {
        public int Id { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("cargo")]
        public string Cargo { get; set; }

        [Column("data_contratacao")]
        public DateTime DataContratacao { get; set; }

        [Column("salario")]
        public decimal? Salario { get; set; }

        [Column("beneficios")]
        public string Beneficios { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("endereco_id")]
        public int EnderecoId { get; set; }

        public virtual UsuarioResponse Usuario { get; set; }
        public virtual EnderecoResponse Endereco { get; set; }
    }
}
