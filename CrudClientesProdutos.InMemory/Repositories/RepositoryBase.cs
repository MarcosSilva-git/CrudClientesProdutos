using CrudClientesProdutos.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CrudClientesProdutos.InMemory.Repositories;

public class RepositoryBase<T>(
    InMemoryDbContext context) : IRepository<T> where T : class, IEntity
{
    protected readonly InMemoryDbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public async virtual Task<IEnumerable<T>> GetAllAsync()
        => await _context.Set<T>().ToListAsync();

    public async virtual Task<T?> FindAsync(long id)
        => await _dbSet.FindAsync(id);

    public async virtual Task<T> CreateAsync(T entity)
    {
        var newEntity = await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return newEntity.Entity;
    }

    public async virtual Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async virtual Task<long?> DeleteAsync(long id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity is null)
            return null;

        _dbSet.Remove(entity);

        await _context.SaveChangesAsync();
        return entity.Id;
    }
}
