using System;
using System.ComponentModel.DataAnnotations.Schema;
using MegaVetClinic.Models.Enums;

namespace MegaVetClinic.Repository.Models.Response
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public FuncionarioTipo Tipo { get; set; }
        public string Email { get; set; }
        [Column("data_contratacao")]
        public DateTime DataContratacao { get; set; } 
    }
}
