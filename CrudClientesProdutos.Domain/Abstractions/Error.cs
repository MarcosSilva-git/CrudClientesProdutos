namespace CrudClientesProdutos.Domain.Abstractions;

public readonly record struct Error(
    string Title, 
    string Description, 
    ErrorType Type = ErrorType.DomainRuleError);

