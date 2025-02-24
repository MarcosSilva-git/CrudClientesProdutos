namespace CrudClientesProdutos.Domain.Abstractions;

public readonly record struct Error(
    string Title, 
    string Description, 
    ErrorEnum Type = ErrorEnum.DomainRuleError);

