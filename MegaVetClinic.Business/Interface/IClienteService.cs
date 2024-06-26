using MegaVetClinic.Repository.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MegaVetClinic.Business.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteResponse> CriarClientesAsync(ClienteRequest clienteRequest);
    }
}
