using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Models.Response;

namespace MegaVetClinic.Repository.Interfaces
{
    public interface IClienteRepository
    {
        ClienteResponse CriarClientes(ClienteRequest clienteRequest);
        ClienteResponse BuscarClientePorId(int clienteId);
        ClienteResponse AtualizarCliente(int clienteId, ClienteRequest clienteRequest);
        ClienteResponse BuscarClientePorCpf(string cpf);
        bool Exist(string email);
    }
}
