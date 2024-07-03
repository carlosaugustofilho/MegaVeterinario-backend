using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Models.Response;

namespace MegaVetClinic.Repository.Interfaces
{
    public interface IFuncionarioRepository
    {
        FuncionarioResponse CadastrarFuncionario(FuncionarioRequest funcionarioRequest);
    }
}
