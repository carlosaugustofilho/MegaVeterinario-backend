using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaVetClinic.Repository.Models.Response
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }
    }
}
