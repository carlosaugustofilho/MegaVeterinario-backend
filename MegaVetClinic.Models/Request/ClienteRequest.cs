using MegaVetClinic.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MegaVetClinic.Models.Requests
{
    public class ClienteRequest
    {
       
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public EnderecoRequest Endereco { get; set; }
        public UsuarioRequest Usuario { get; set; }
    }


}

