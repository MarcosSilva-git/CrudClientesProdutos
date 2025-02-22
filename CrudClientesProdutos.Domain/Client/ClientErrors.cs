using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain.Client;

public static class ClientErrors
{
    public static readonly Error NotFound 
        = new("Client.NotFound", "Client not found", 404);

    public static readonly Error InvalidNameSize 
        = new("Client.InvalidNameSize", "Client name does not meet the required length");
}
