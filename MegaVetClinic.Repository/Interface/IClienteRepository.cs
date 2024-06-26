using MegaVetClinic.Repository.Models.Response;

namespace MegaVetClinic.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<ClienteResponse> CriarClientesAsync(ClienteRequest clienteRequest);
    }
}
