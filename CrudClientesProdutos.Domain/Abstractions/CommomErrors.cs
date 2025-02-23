namespace CrudClientesProdutos.Domain.Abstractions;

public static class CommomErrors
{
    public static Error InvalidId(long id)
        => new("Commom.InvalidId", $"Invalid Id \"{id}\"");

    public static class Email
    {
        public static Error InvalidEmail(string email)
                => new(
                    "CommomError.Email.InvalidEmail", 
                    $"The email \"{email}\" is not valid.");
    }
}
