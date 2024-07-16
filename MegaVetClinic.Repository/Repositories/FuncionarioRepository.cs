using AutoMapper;
using MegaVetClinic.Core.Context;
using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Interfaces;
using MegaVetClinic.Repository.Models.Response;
using MegaVetClinic.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class FuncionarioRepository : RepositoryBase<FuncionarioResponse>, IFuncionarioRepository
{
    private readonly IMapper _mapper;

    public FuncionarioRepository(MegaVetClinicContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public FuncionarioResponse CadastrarFuncionario(FuncionarioRequest funcionarioRequest)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            // Verifica se já existe um usuário com o mesmo email
            if (Exist(funcionarioRequest.Email))
            {
                throw new InvalidOperationException("Já existe um usuário com o email fornecido.");
            }

            var usuario = _mapper.Map<UsuarioResponse>(funcionarioRequest);
            usuario.DataContratacao = DateTime.Now;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            var endereco = _mapper.Map<EnderecoResponse>(funcionarioRequest.Endereco);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            var funcionario = _mapper.Map<FuncionarioResponse>(funcionarioRequest);
            funcionario.UsuarioId = usuario.Id;
            funcionario.EnderecoId = endereco.Id;

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

    public FuncionarioResponse BuscarFuncionarioPorId(int funcionarioId)
    {
        var funcionario = _context.Funcionarios
            .Include(f => f.Usuario)
            .Include(f => f.Endereco)
            .FirstOrDefault(f => f.Id == funcionarioId);

        if (funcionario == null)
        {
            throw new Exception("Funcionário não encontrado");
        }

        return funcionario;
    }

    public FuncionarioResponse AtualizarFuncionario(int funcionarioId, FuncionarioRequest funcionarioRequest)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var funcionario = _context.Funcionarios
                .Include(f => f.Usuario)
                .Include(f => f.Endereco)
                .FirstOrDefault(f => f.Id == funcionarioId);

            if (funcionario == null)
            {
                throw new Exception("Funcionário não encontrado");
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == funcionario.UsuarioId);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == funcionario.EnderecoId);
            if (endereco == null)
            {
                throw new Exception("Endereço não encontrado");
            }

            usuario.Nome = funcionarioRequest.Nome;
            usuario.Senha = funcionarioRequest.Senha;
            usuario.Email = funcionarioRequest.Email;

            endereco.Cep = funcionarioRequest.Endereco.Cep;
            endereco.Rua = funcionarioRequest.Endereco.Rua;
            endereco.Numero = funcionarioRequest.Endereco.Numero;
            endereco.Complemento = funcionarioRequest.Endereco.Complemento;
            endereco.Bairro = funcionarioRequest.Endereco.Bairro;
            endereco.Cidade = funcionarioRequest.Endereco.Cidade;
            endereco.Estado = funcionarioRequest.Endereco.Estado;

            funcionario.Cargo = funcionarioRequest.Cargo;
            funcionario.DataContratacao = funcionarioRequest.DataContratacao;
            funcionario.Salario = funcionarioRequest.Salario;
            funcionario.Beneficios = funcionarioRequest.Beneficios;

            _context.SaveChanges();
            transaction.Commit();

            return funcionario;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception("Erro ao atualizar funcionário", ex);
        }
    }

    public FuncionarioResponse AlterarStatusFuncionario(int funcionarioId, bool ativo)
    {
        var funcionario = _context.Funcionarios.Find(funcionarioId);

        if (funcionario == null)
        {
            throw new KeyNotFoundException("Funcionário não encontrado");
        }

        if (funcionario.Ativo == ativo)
        {
            throw new InvalidOperationException($"Funcionário já está {(ativo ? "ativo" : "inativo")}");
        }

        funcionario.Ativo = ativo;
        _context.SaveChanges();

        return funcionario;
    }

    public bool Exist(string email)
    {
        return _context.Funcionarios.Any(f => f.Usuario.Email == email);
    }

    public FuncionarioResponse AtivarFuncionario(int funcionarioId)
    {
        return AlterarStatusFuncionario(funcionarioId, true);
    }

    public FuncionarioResponse InativarFuncionario(int funcionarioId)
    {
        return AlterarStatusFuncionario(funcionarioId, false);
    }
}
