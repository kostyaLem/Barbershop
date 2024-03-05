using Barbershop.DAL.Context;
using Barbershop.DAL.Exceptions;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Barbershop.DAL.Repositories
{
    /// <summary>
    /// Базовый класс репозитория для управления сущностью <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Сущность базы данных.</typeparam>
    internal class BaseRepository<T> : IBaseRepository<T> where T : Entity, new()
    {
        private readonly BarbershopContextFactory _contextFactory;

        public BaseRepository(BarbershopContextFactory contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public async Task Add(T entity)
        {
            using var context = _contextFactory.CreateContext();

            context.Add(entity);

            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            using var context = _contextFactory.CreateContext();

            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            using var context = _contextFactory.CreateContext();

            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            using var context = _contextFactory.CreateContext();

            var entity = await context.Set<T>().FindAsync(id)
                ?? throw new EntityNotFoundException<T>(id);

            return entity;
        }

        public async Task Remove(int id)
        {
            using var context = _contextFactory.CreateContext();

            var entity = await context.Set<T>().FindAsync(id) 
                ?? throw new EntityNotFoundException<T>(id);

            context.Set<T>().Remove(entity);

            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            using var context = _contextFactory.CreateContext();

            await GetById(entity.Id);

            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task<int> Count()
        {
            using var context = _contextFactory.CreateContext();

            if (context.Set<T>().TryGetNonEnumeratedCount(out var count))
                return count;

            return await context.Set<T>().CountAsync();
        }

        public async Task<T?> FindSingle(Expression<Func<T, bool>> predicate)
        {
            using var context = _contextFactory.CreateContext();

            var entity = await context.Set<T>().FirstOrDefaultAsync(predicate);

            return entity;
        }
    }
}
