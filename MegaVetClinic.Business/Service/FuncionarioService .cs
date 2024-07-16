using MegaVetClinic.Business.Interfaces;
using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Interfaces;
using MegaVetClinic.Repository.Models.Response;

namespace MegaVetClinic.Business.Service
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public FuncionarioResponse CadastrarFuncionario(FuncionarioRequest funcionarioRequest)
        {
            return _funcionarioRepository.CadastrarFuncionario(funcionarioRequest);
        }

        public FuncionarioResponse BuscarFuncionarioPorId(int funcionarioId)
        {
            return _funcionarioRepository.BuscarFuncionarioPorId(funcionarioId);
        }

        public FuncionarioResponse AtualizarFuncionario(int funcionarioId, FuncionarioRequest funcionarioRequest)
        {
            return _funcionarioRepository.AtualizarFuncionario(funcionarioId, funcionarioRequest);
        }

        public FuncionarioResponse AlterarStatusFuncionario(int funcionarioId, bool ativo)
        {
            return _funcionarioRepository.AlterarStatusFuncionario(funcionarioId, ativo);
        }


    }
}
