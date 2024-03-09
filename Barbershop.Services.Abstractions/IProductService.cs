using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;

namespace Barbershop.Services.Abstractions;

public interface IProductService
{
    Task Create(UpsertProductCommand command);

    Task<IReadOnlyList<ProductDto>> GetAll();

    Task Update(UpsertProductCommand command);

    Task RemoveById(int id);
}