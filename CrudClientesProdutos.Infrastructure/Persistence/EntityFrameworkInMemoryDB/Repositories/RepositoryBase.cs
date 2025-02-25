using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB.Repositories;

public class RepositoryBase<T>(
    InMemoryDbContext context) : IRepository<T> where T : class, IEntity
{
    protected readonly InMemoryDbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public virtual async Task<IPagedEntity<T>> GetPagedAsync(int take = 10, int page = 1)
    {
        if (take <= 0) take = 1;
        if (take > 50) take = 50;

        if (page <= 0) page = 1;

        var totalItems = await _dbSet.CountAsync();

        int totalPages;
        if (totalItems == 0)
            totalPages = 1;

        else if (totalItems == take)
            totalPages = totalItems / take;

        else
            totalPages = totalItems / take + 1;

        if (totalPages < page)
            page = totalPages;

        var items = await _dbSet
            .Skip(take * (page - 1))
            .Take(take)
            .ToListAsync();

        return new PagedEntity<T>()
        {
            Items = items,
            TotalItems = totalItems,
            Page = page,
            PageSize = items.Count,
            TotalPages = totalPages,
        }; 
    }

    public virtual async Task<T?> FindAsync(long id)
        => await _dbSet.FindAsync(id);

    public virtual async Task<T> CreateAsync(T entity)
    {
        var newEntity = await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return newEntity.Entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<long?> DeleteAsync(long id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity is null)
            return null;

        _dbSet.Remove(entity);

        await _context.SaveChangesAsync();
        return entity.Id;
    }
}
