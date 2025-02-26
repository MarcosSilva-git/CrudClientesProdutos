namespace CrudClientesProdutos.Domain;

public class DomainException : ArgumentException
{
    public DomainException(string message) 
        : base(message) { }

    public DomainException(string message, string paramName) 
        : base(message, paramName) { }
}
