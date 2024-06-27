using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaVetClinic.Models.Request
{
    public class UsuarioRequest
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }
        public int? FilialId { get; set; }
    }
}
