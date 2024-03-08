using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;

namespace Barbershop.Services.Abstractions;

public interface IProductService
{
    Task<ProductDto> GetById(int id);

    Task<IReadOnlyList<ProductDto>> GetAll();

    Task Create(CreateProductCommand command);

    Task RemoveById(int id);
}