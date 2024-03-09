using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;

namespace Barbershop.Services.Abstractions;

/// <summary>
/// Сервис управления администраторами.
/// </summary>
public interface IAdminService
{
    /// <summary>
    /// Создать администратора.
    /// </summary>
    /// <param name="command">Описание администратора.</param>        
    Task Create(UpsertAdminCommand command);

    /// <summary>
    /// Получить всех администраторов.
    /// </summary>
    /// <returns>Список администраторов.</returns>
    Task<IReadOnlyList<AdminDto>> GetAll();

    /// <summary>
    /// Изменить администратора.
    /// </summary>
    /// <returns>Список администраторов.</returns>
    Task Update(UpsertAdminCommand command);

    /// <summary>
    /// Получить администратора по Id.
    /// </summary>
    /// <param name="id">Id администратора.</param>
    /// <returns></returns>
    Task<AdminDto> GetById(int id);

    /// <summary>
    /// Удалить администратора по Id.
    /// </summary>
    /// <param name="id">Id администратора.</param>
    Task RemoveById(int id);
}
