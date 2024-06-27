using MegaVetClinic.Models.Requests;
using MegaVetClinic.Repository.Models.Response;

namespace MegaVetClinic.Repository.Interfaces
{
    public interface IClienteRepository
    {
        ClienteResponse CriarClientes(ClienteRequest clienteRequest);
    }
}
