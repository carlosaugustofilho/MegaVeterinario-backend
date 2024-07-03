using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Models.Response;

namespace MegaVetClinic.Business.Interfaces
{
    public interface IClienteService
    {
        ClienteResponse CriarClientes(ClienteRequest clienteRequest);
        ClienteResponse BuscarClientePorId(int clienteId);
        ClienteResponse AtualizarCliente(int clienteId, ClienteRequest clienteRequest);
        ClienteResponse BuscarClientePorCpf(string cpf);

    }
}
