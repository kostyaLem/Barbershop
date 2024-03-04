using Barbershop.Domain.Models;
using Barbershop.Services.Abstractions;

namespace Barbershop.Services;

public class ClientService : IClientService
{
    public Task AddClient(Client client)
    {
        throw new NotImplementedException();
    }

    public Task DeleteClient(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Client>> GetAllClients()
    {
        throw new NotImplementedException();
    }

    public Task<Client> GetClient(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateClient(Client client)
    {
        throw new NotImplementedException();
    }

    public Task UpdateClientsNotes(int clientId, string newNotes)
    {
        throw new NotImplementedException();
    }
}