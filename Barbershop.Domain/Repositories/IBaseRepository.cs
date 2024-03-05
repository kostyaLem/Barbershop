using Barbershop.Domain.Models;
using System.Linq.Expressions;

namespace Barbershop.Domain.Repositories
{
    /// <summary>
    /// Базовый класс репозитория для управления сущностью <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Сущность базы данных.</typeparam>
    public interface IBaseRepository<T> where T : Entity, new()
    {
        /// <summary>
        /// Создать сущность.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        Task Add(T entity);

        /// <summary>
        /// Получить все сущности.
        /// </summary>
        /// <returns>Список сущностей.</returns>
        Task<List<T>> GetAll();

        /// <summary>
        /// Получить сущность по Id
        /// </summary>
        /// <param name="id">Id сущности.</param>
        /// <returns>Сущность.</returns>
        /// <exception cref="EntityNotFoundException{T}">Не удалось найти сущность.</exception>
        Task<T> GetById(int id);

        /// <summary>
        /// Удалить сущность по Id.
        /// </summary>
        /// <param name="id">Id сущности.</param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException{T}">Не удалось найти сущность.</exception>
        Task Remove(int id);

        /// <summary>
        /// Обновить сущность.
        /// </summary>
        /// <param name="entity">Обновленная сущность.</param>
        Task Update(T entity);

        /// <summary>
        /// Найти сущности по условию.
        /// </summary>
        /// <param name="predicate">Условие выборки.</param>
        /// <returns>Отфильтрованные сущности.</returns>
        public Task<IReadOnlyList<T>> FindAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Найти сущность по условию.
        /// </summary>
        /// <param name="predicate">Условие выборки.</param>
        /// <returns>Сущность, если найдена.</returns>
        public Task<T?> FindSingle(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Посчитать количество сущностей типа <typeparamref name="T"/>.
        /// </summary>
        /// <returns>Количество сущностей.</returns>
        public Task<int> Count();
    }
}
