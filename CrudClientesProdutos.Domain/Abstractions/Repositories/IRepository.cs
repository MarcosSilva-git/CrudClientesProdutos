namespace CrudClientesProdutos.Domain.Abstractions.Repositories;

public interface IRepository<T> where T : IEntity 
{
    Task<IPagedEntity<T>> GetPagedAsync(int take = 10, int page = 1);

    Task<T?> FindAsync(long id);
    Task<T> CreateAsync(T entity); 
    Task<T> UpdateAsync(T entity); 
    Task<long?> DeleteAsync(long id); 
}
