using AutoMapper;
using MegaVetClinic.Core.Context;
using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Interfaces;
using MegaVetClinic.Repository.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly MegaVetClinicContext _context;
    private readonly IMapper _mapper;

    public FuncionarioRepository(MegaVetClinicContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public FuncionarioResponse CadastrarFuncionario(FuncionarioRequest funcionarioRequest)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
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
}
