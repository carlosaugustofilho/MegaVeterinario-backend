using AutoMapper;
using MegaVetClinic.Models.Enums;
using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Models.Response;

public class PerfilDeMapeamento : Profile
{
    public PerfilDeMapeamento()
    {
        CreateMap<FuncionarioRequest, UsuarioResponse>()
            .ForMember(destino => destino.Tipo, opcoes => opcoes.MapFrom(src => FuncionarioTipo.Funcionario))
            .ForMember(destino => destino.DataContratacao, opcoes => opcoes.Ignore()); 
        CreateMap<EnderecoRequest, EnderecoResponse>();
        CreateMap<FuncionarioRequest, FuncionarioResponse>()
            .ForMember(destino => destino.UsuarioId, opcoes => opcoes.Ignore())
            .ForMember(destino => destino.EnderecoId, opcoes => opcoes.Ignore());
    }
}
