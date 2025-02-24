namespace CrudClientesProdutos.Domain.Abstractions.Repositories;

public interface IRepository<T> where T : IEntity 
{
    IPagedEntity<T> GetPaged(int take = 10, int page = 1);

    T? Find(long id);

    T Create(T entity); 
    
    T Update(T entity); 
    
    long? Delete(long id); 
}
