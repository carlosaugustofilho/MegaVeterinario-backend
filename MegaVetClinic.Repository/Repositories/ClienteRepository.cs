using Microsoft.EntityFrameworkCore;
using MegaVetClinic.Core.Context;
using MegaVetClinic.Repository.Models.Response;
using MegaVetClinic.Repository.Interfaces;

namespace MegaVetClinic.Repository.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly MegaVetClinicContext _context;
        private readonly ClienteRepository _clienteRepository;

        public ClienteRepository(MegaVetClinicContext context, ClienteRepository clienteRepository)
        {
            _context = context;
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteResponse> CriarClientesAsync(ClienteRequest clienteRequest)
        {
            var cliente = new ClienteRequest
            {
                UsuarioId = clienteRequest.UsuarioId,
                Telefone = clienteRequest.Telefone,
                DataNascimento = clienteRequest.DataNascimento,
                CPF = clienteRequest.CPF,
                Email = clienteRequest.Email,
                Endereco = new EnderecoRequest
                {
                    Cep = clienteRequest.Endereco.Cep,
                    Rua = clienteRequest.Endereco.Rua,
                    Numero = clienteRequest.Endereco.Numero,
                    Complemento = clienteRequest.Endereco.Complemento,
                    Bairro = clienteRequest.Endereco.Bairro,
                    Cidade = clienteRequest.Endereco.Cidade,
                    Estado = clienteRequest.Endereco.Estado,
                    PaisId = clienteRequest.Endereco.PaisId
                }
            };

            await _clienteRepository.CriarClientesAsync(cliente);

            var clienteResponse = new ClienteResponse
            {
               
                UsuarioId = cliente.UsuarioId,
                Telefone = cliente.Telefone,
                DataNascimento = cliente.DataNascimento,
                CPF = cliente.CPF,
                Email = cliente.Email,
                Endereco = new EnderecoResponse
                {
                   
                    Cep = cliente.Endereco.Cep,
                    Rua = cliente.Endereco.Rua,
                    Numero = cliente.Endereco.Numero,
                    Complemento = cliente.Endereco.Complemento,
                    Bairro = cliente.Endereco.Bairro,
                    Cidade = cliente.Endereco.Cidade,
                    Estado = cliente.Endereco.Estado,
                    PaisId = cliente.Endereco.PaisId
                }
            };

            return clienteResponse;
        }


    }
}
