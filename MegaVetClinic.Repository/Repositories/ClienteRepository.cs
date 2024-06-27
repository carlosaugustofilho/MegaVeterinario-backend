using MegaVetClinic.Core.Context;
using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Interfaces;
using MegaVetClinic.Repository.Models.Response;
using System;

public class ClienteRepository : IClienteRepository
{
    private readonly MegaVetClinicContext _context;

    public ClienteRepository(MegaVetClinicContext context)
    {
        _context = context;
    }

    public ClienteResponse CriarClientes(ClienteRequest clienteRequest)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var usuario = new UsuarioResponse
            {
                Nome = clienteRequest.Usuario.Nome,
                Senha = clienteRequest.Usuario.Senha,
                Tipo = clienteRequest.Usuario.Tipo,
                Email = clienteRequest.Usuario.Email
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            var endereco = new EnderecoResponse
            {
                Cep = clienteRequest.Endereco.Cep,
                Rua = clienteRequest.Endereco.Rua,
                Numero = clienteRequest.Endereco.Numero,
                Complemento = clienteRequest.Endereco.Complemento,
                Bairro = clienteRequest.Endereco.Bairro,
                Cidade = clienteRequest.Endereco.Cidade,
                Estado = clienteRequest.Endereco.Estado,
                Cliente = new ClienteResponse // Associar cliente ao endereço
                {
                    Telefone = clienteRequest.Telefone,
                    DataNascimento = clienteRequest.DataNascimento,
                    CPF = clienteRequest.CPF,
                    Email = clienteRequest.Email,
                    UsuarioId = usuario.Id
                }
            };

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            transaction.Commit();

            return endereco.Cliente; // Retornar o cliente criado
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception("Erro ao criar cliente", ex);
        }
    }

}
