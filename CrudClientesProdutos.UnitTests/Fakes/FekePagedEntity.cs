using CrudClientesProdutos.Domain.Abstractions;
using CrudClientesProdutos.Domain.Abstractions.Repositories;

namespace CrudClientesProdutos.UnitTests.Fakes;

public class FakePagedEntity<T> : IPagedEntity<T> where T : IEntity
{
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    public int TotalItems { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}

