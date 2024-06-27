using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaVetClinic.Repository.Models.Response
{
    public class EnderecoResponse
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Cep { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Rua { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Numero { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Complemento { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Bairro { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Cidade { get; set; }

        [Column(TypeName = "varchar(2)")]
        public string Estado { get; set; }

        public ClienteResponse Cliente { get; set; }
    }
}
