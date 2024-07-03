using MegaVetClinic.Core.Context;
using MegaVetClinic.Models.Enums;
using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Interfaces;
using MegaVetClinic.Repository.Models.Response;
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

            var funcionario = new FuncionarioResponse
            {
                UsuarioId = usuario.Id,
                Cargo = funcionarioRequest.Cargo,
                DataContratacao = funcionarioRequest.DataContratacao,
                Salario = funcionarioRequest.Salario,
                Beneficios = funcionarioRequest.Beneficios,
                Email = funcionarioRequest.Email,
                EnderecoId = funcionarioRequest.EnderecoId
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
