namespace CrudClientesProdutos.Application.DTO;

public record PagedResponseDTO<T>
{
    public required IEnumerable<T> Items { get; set; }
    public required int TotalItems { get; set; }
    public required int Page { get; set; }
    public required int PageSize { get; set; }
    public required int TotalPages { get; set; }
}