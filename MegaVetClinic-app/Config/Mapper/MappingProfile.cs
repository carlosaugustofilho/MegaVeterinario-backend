using AutoMapper;
using MegaVetClinic.Models.Enums;
using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Models.Response;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<FuncionarioRequest, UsuarioResponse>()
            .ForMember(destino => destino.Tipo, opcoes => opcoes.MapFrom(src => FuncionarioTipo.Funcionario))
            .ForMember(destino => destino.DataCriacao, opcoes => opcoes.MapFrom(src => DateTime.Now));
        CreateMap<EnderecoRequest, EnderecoResponse>();
        CreateMap<FuncionarioRequest, FuncionarioResponse>()
            .ForMember(destino => destino.UsuarioId, opcoes => opcoes.Ignore())
            .ForMember(destino => destino.EnderecoId, opcoes => opcoes.Ignore());
    }
}
