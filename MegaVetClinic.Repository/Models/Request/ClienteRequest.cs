using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ClienteRequest
{
    public int UsuarioId { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public EnderecoRequest Endereco { get; set; }
}
