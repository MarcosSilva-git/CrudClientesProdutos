namespace CrudClientesProdutos.Domain.Abstractions.Repositories;

public interface IPagedEntity<T> where T : IEntity
{
    IEnumerable<T> Items { get; set; }
    int TotalItems { get; set; }
    int Page { get; set; }
    int PageSize { get; set; }
    int TotalPages { get; set; }
}
