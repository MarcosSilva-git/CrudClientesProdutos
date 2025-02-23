using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain.Client;

public static class ClientErrors
{
    public static Error InvalidId(long id) 
        => new("Client.InvalidId", $"Invalid Id \"{id}\"");

    public static readonly Error NotFound 
        = new Error("Client.NotFound", "Client not found", ErrorType.NotFounError);

    public static readonly Error InvalidNameSize 
        = new ("Client.InvalidNameSize", "Client name does not meet the required length");
}
