namespace CrudClientesProdutos.Domain.Abstractions
{
    public record Error(string Code, string? Description = null, int? StatusCode = null)
    {
        public static readonly Error None = new(string.Empty);
    }
}
