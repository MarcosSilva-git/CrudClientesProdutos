namespace CrudClientesProdutos.Domain.Abstractions
{
    public interface IRepository<T> where T : IEntity 
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> FindAsync(long id);

        Task<T> CreateAsync(T entity); 
        
        Task<T> UpdateAsync(T entity); 
        
        Task<long?> DeleteAsync(long id); 
    }
}
