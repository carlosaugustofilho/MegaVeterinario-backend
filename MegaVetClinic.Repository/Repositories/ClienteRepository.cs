using MegaVetClinic.Core.Context;
using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Interfaces;
using MegaVetClinic.Repository.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.RegularExpressions;

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
            string cpf = LimparCpf(clienteRequest.CPF);

            if (!ValidarCpf(cpf))
            {
                throw new Exception("CPF inválido");
            }

            var cliente = new ClienteResponse
            {
                Nome = clienteRequest.Nome,
                Sobrenome = clienteRequest.Sobrenome,
                Telefone = clienteRequest.Telefone,
                DataNascimento = clienteRequest.DataNascimento,
                CPF = cpf,
                Email = clienteRequest.Email,
                Endereco = new EnderecoResponse
                {
                    Cep = clienteRequest.Endereco.Cep,
                    Rua = clienteRequest.Endereco.Rua,
                    Numero = clienteRequest.Endereco.Numero,
                    Complemento = clienteRequest.Endereco.Complemento,
                    Bairro = clienteRequest.Endereco.Bairro,
                    Cidade = clienteRequest.Endereco.Cidade,
                    Estado = clienteRequest.Endereco.Estado,
                }
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            transaction.Commit();

            return cliente;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception("Erro ao criar cliente", ex);
        }
    }

    public ClienteResponse BuscarClientePorId(int clienteId)
    {
        var cliente = _context.Clientes
            .Include(c => c.Endereco)
            .FirstOrDefault(c => c.Id == clienteId);

        if (cliente == null)
        {
            throw new Exception("Cliente não encontrado");
        }

        return cliente;
    }

    public ClienteResponse AtualizarCliente(int clienteId, ClienteRequest clienteRequest)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var cliente = _context.Clientes
                .Include(c => c.Endereco)
                .FirstOrDefault(c => c.Id == clienteId);

            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado");
            }

            string cpf = LimparCpf(clienteRequest.CPF);

            if (!ValidarCpf(cpf))
            {
                throw new Exception("CPF inválido");
            }

            cliente.Nome = clienteRequest.Nome;
            cliente.Sobrenome = clienteRequest.Sobrenome;
            cliente.Telefone = clienteRequest.Telefone;
            cliente.DataNascimento = clienteRequest.DataNascimento;
            cliente.CPF = cpf;
            cliente.Email = clienteRequest.Email;

            cliente.Endereco.Cep = clienteRequest.Endereco.Cep;
            cliente.Endereco.Rua = clienteRequest.Endereco.Rua;
            cliente.Endereco.Numero = clienteRequest.Endereco.Numero;
            cliente.Endereco.Complemento = clienteRequest.Endereco.Complemento;
            cliente.Endereco.Bairro = clienteRequest.Endereco.Bairro;
            cliente.Endereco.Cidade = clienteRequest.Endereco.Cidade;
            cliente.Endereco.Estado = clienteRequest.Endereco.Estado;

            _context.SaveChanges();
            transaction.Commit();

            return cliente;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception("Erro ao atualizar cliente", ex);
        }
    }

    public ClienteResponse BuscarClientePorCpf(string cpf)
    {
        cpf = LimparCpf(cpf);

        var cliente = _context.Clientes
            .Include(c => c.Endereco)
            .FirstOrDefault(c => c.CPF == cpf);

        if (cliente == null)
        {
            throw new Exception("Cliente não encontrado");
        }

        return cliente;
    }

     public bool Exist(string email)
    {
        return _context.Funcionarios.Any(f => f.Usuario.Email == email);
    }

    private string LimparCpf(string cpf)
    {
        return Regex.Replace(cpf, @"[^\d]", "");
    }

    private bool ValidarCpf(string cpf)
    {
        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            return false;
        }

        var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var tempCpf = cpf.Substring(0, 9);
        var soma = 0;

        for (var i = 0; i < 9; i++)
        {
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        }

        var resto = soma % 11;
        if (resto < 2)
        {
            resto = 0;
        }
        else
        {
            resto = 11 - resto;
        }

        var digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        for (var i = 0; i < 10; i++)
        {
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        }

        resto = soma % 11;
        if (resto < 2)
        {
            resto = 0;
        }
        else
        {
            resto = 11 - resto;
        }

        digito = digito + resto.ToString();

        return cpf.EndsWith(digito);
    }
}
