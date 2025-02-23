namespace CrudClientesProdutos.Domain.Abstractions;

public interface IRepository<T> where T : IEntity 
{
    IEnumerable<T> GetAll();

    T? Find(long id);

    T Create(T entity); 
    
    T Update(T entity); 
    
    long? Delete(long id); 
}
