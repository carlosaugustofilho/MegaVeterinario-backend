using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Models.Response;

namespace MegaVetClinic.Repository.Interfaces
{
    public interface IFuncionarioRepository
    {
        FuncionarioResponse CadastrarFuncionario(FuncionarioRequest funcionarioRequest);
        FuncionarioResponse BuscarFuncionarioPorId(int funcionarioId);
        FuncionarioResponse AtualizarFuncionario(int funcionarioId, FuncionarioRequest funcionarioRequest);
        FuncionarioResponse AlterarStatusFuncionario(int funcionarioId, bool ativo);
        bool Exist(string email);
    }
}
