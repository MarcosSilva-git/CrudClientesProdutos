using CrudClientesProdutos.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB.Repositories;

public class RepositoryBase<T>(
    InMemoryDbContext context) : IRepository<T> where T : class, IEntity
{
    protected readonly InMemoryDbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public virtual IEnumerable<T> GetAll()
        => _context.Set<T>().ToList();

    public virtual T? Find(long id)
        => _dbSet.Find(id);

    public virtual T Create(T entity)
    {
        var newEntity = _dbSet.Add(entity);
        _context.SaveChanges();

        return newEntity.Entity;
    }

    public virtual T Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();

        return entity;
    }

    public virtual long? Delete(long id)
    {
        var entity = _dbSet.Find(id);

        if (entity is null)
            return null;

        _dbSet.Remove(entity);

        _context.SaveChanges();
        return entity.Id;
    }
}
