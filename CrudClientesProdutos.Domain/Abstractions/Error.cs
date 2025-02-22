namespace CrudClientesProdutos.Domain.Abstractions
{
    public record Error(string Title, string? Description = null, int? StatusCode = null)
    {
        public static readonly Error None = new(string.Empty);
    }
}
