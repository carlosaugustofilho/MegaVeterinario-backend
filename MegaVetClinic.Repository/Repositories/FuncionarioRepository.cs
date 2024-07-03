using AutoMapper;
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
            // Mapear FuncionarioRequest para UsuarioResponse
            var usuario = _mapper.Map<UsuarioResponse>(funcionarioRequest);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            // Mapear EnderecoRequest para EnderecoResponse
            var endereco = _mapper.Map<EnderecoResponse>(funcionarioRequest.Endereco);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            // Mapear FuncionarioRequest para FuncionarioResponse
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
