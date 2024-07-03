using MegaVetClinic.Core.Context;
using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Interfaces;
using MegaVetClinic.Repository.Models.Response;
using MegaVetClinic.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly MegaVetClinicContext _context;

    public FuncionarioRepository(MegaVetClinicContext context)
    {
        _context = context;
    }

    public FuncionarioResponse CadastrarFuncionario(FuncionarioRequest funcionarioRequest)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            // Criação do usuário
            var usuario = new UsuarioResponse
            {
                Nome = funcionarioRequest.Nome,
                Senha = funcionarioRequest.Senha,
                Tipo = FuncionarioTipo.Funcionario,
                Email = funcionarioRequest.Email,
                DataCriacao = DateTime.Now
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            // Criação do endereço
            var endereco = new EnderecoResponse
            {
                Cep = funcionarioRequest.Endereco.Cep,
                Rua = funcionarioRequest.Endereco.Rua,
                Numero = funcionarioRequest.Endereco.Numero,
                Complemento = funcionarioRequest.Endereco.Complemento,
                Bairro = funcionarioRequest.Endereco.Bairro,
                Cidade = funcionarioRequest.Endereco.Cidade,
                Estado = funcionarioRequest.Endereco.Estado
            };

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            // Criação do funcionário
            var funcionario = new FuncionarioResponse
            {
                UsuarioId = usuario.Id,
                Cargo = funcionarioRequest.Cargo,
                DataContratacao = funcionarioRequest.DataContratacao,
                Salario = funcionarioRequest.Salario,
                Beneficios = funcionarioRequest.Beneficios,
                Email = funcionarioRequest.Email,
                EnderecoId = endereco.Id
            };

            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            transaction.Commit();

            return funcionario;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception("Erro ao cadastrar funcionário", ex);
        }
    }
}
