﻿using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrudClientesProdutos.Infrastructure.Persistence.EntityFrameworkInMemoryDB.Repositories;

public class RepositoryBase<T>(
    InMemoryDbContext context) : IRepository<T> where T : class, IEntity
{
    protected readonly InMemoryDbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public virtual IPagedEntity<T> GetPaged(int take = 10, int page = 1)
    {
        if (take <= 0) take = 1;
        if (take > 50) take = 50;

        if (page <= 0) page = 1;

        var totalItems = _dbSet.Count();

        int totalPages;
        if (totalItems == 0)
            totalPages = 1;

        else if (totalItems == take)
            totalPages = totalItems / take;

        else
            totalPages = totalItems / take + 1;

        if (totalPages < page)
            page = totalPages;

        var items =  _dbSet
            .Skip(take * (page - 1))
            .Take(take)
            .ToList();

        return new PagedEntity<T>()
        {
            Items = items,
            TotalItems = totalItems,
            Page = page,
            PageSize = items.Count,
            TotalPages = totalPages,
        }; 
    }

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
