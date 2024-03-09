using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;

namespace Barbershop.Services.Abstractions;

public interface IAdminService
{
    /// <summary>
    /// Получить авторизированного администратора.
    /// </summary>
    /// <param name="username">Логин.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Администратор.</returns>
    Task<AdminDto> Login(string username, string password);

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
    /// Удалить администратора по Id.
    /// </summary>
    /// <param name="id">Id администратора.</param>
    Task RemoveById(int id);
}