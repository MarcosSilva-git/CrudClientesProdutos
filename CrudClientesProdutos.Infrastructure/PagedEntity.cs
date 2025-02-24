using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Abstractions.Repositories;

namespace CrudClientesProdutos.Infrastructure;

public class PagedEntity<T> : IPagedEntity<T> where T : IEntity
{
    public required IEnumerable<T> Items { get; set; }
    public required int TotalItems { get; set; }
    public required int Page { get; set; }
    public required int PageSize { get; set; }
    public required int TotalPages { get; set; }
}
