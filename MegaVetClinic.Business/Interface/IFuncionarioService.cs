using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Models.Response;

namespace MegaVetClinic.Business.Interfaces
{
    public interface IFuncionarioService
    {
        FuncionarioResponse CadastrarFuncionario(FuncionarioRequest funcionarioRequest);
    }
}
