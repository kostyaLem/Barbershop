using Barbershop.Domain.Models;

namespace Barbershop.Services.Abstractions;

public interface IClientService
{
    public Task AddClient(Client client);

    public Task<Client> GetClient(int id);

    public Task<IReadOnlyList<Client>> GetAllClients();

    public Task UpdateClient(Client client);

    public Task UpdateClientsNotes(int clientId, string newNotes);

    public Task DeleteClient(int id);
}