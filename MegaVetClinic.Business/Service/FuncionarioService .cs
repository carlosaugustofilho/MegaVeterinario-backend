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
    }
}
