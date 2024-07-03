using MegaVetClinic.Business.Interfaces;
using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Interfaces;
using MegaVetClinic.Repository.Models.Response;


namespace MegaVetClinic.Business.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ClienteResponse CriarClientes(ClienteRequest clienteRequest)
        {
            return _clienteRepository.CriarClientes(clienteRequest);
        }

        public ClienteResponse BuscarClientePorId(int clienteId)
        {
            return _clienteRepository.BuscarClientePorId(clienteId);
        }

        public ClienteResponse AtualizarCliente(int clienteId, ClienteRequest clienteRequest)
        {
            return _clienteRepository.AtualizarCliente(clienteId, clienteRequest);
        }

        public ClienteResponse BuscarClientePorCpf(string cpf)
        {
            return _clienteRepository.BuscarClientePorCpf(cpf);
        }
    }
}

