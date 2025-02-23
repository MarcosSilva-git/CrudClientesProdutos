using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain.Client;

public static class ClientErrors
{
    public static Error InvalidId(long id) 
        => new("CommomErros.InvalidId", $"Client with id {id} was not found");

    public static readonly Error NotFound 
        = new("Client.NotFound", "Client not found", 404);

    public static readonly Error InvalidNameSize 
        = new("Client.InvalidNameSize", "Client name does not meet the required length");

    public static Error InvalidEmail(string email)
            => new("CommomErros.InvalidEmail", $"The email \"{email}\" is not valid.");
}
