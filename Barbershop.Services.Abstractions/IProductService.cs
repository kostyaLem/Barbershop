using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;

namespace Barbershop.Services.Abstractions;

public interface IProductService
{
    /// <summary>
    /// Создать товар.
    /// </summary>
    /// <param name="command">Описание товара.</param>
    Task Create(UpsertProductCommand command);

    /// <summary>
    /// Получить все товары.
    /// </summary>
    /// <returns>Список товаров.</returns>
    Task<IReadOnlyList<ProductDto>> GetAll();

    /// <summary>
    /// Изменить товар.
    /// </summary>
    /// <param name="command">Описание товара.</param>
    Task Update(UpsertProductCommand command);

    /// <summary>
    /// Получить товар по Id.
    /// </summary>
    /// <param name="id">Id товара.</param>
    /// <returns>Товар.</returns>
    Task<ProductDto> GetById(int id);

    /// <summary>
    /// Удалить товар по Id.
    /// </summary>
    /// <param name="id">Id товара.</param>
    Task RemoveById(int id);
}