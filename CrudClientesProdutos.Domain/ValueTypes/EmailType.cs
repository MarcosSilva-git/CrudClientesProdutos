using CrudClientesProdutos.Domain.Abstractions;
using System.Text.RegularExpressions;

namespace CrudClientesProdutos.Domain.ValueTypes;

public record struct EmailType
{
    private readonly string _email;

    private static readonly string Pattern 
        = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    private EmailType(string email)
    {
        _email = email;
    }

    public static implicit operator EmailType(string value)
        => Parse(value);

    public override string ToString()
        => _email;

    public static EmailType Parse(string value)
    {
        if (TryParse(value, out var email))
            return email!.Value;

        throw new ArgumentException(
            CommomErrors.Email.InvalidEmail(value).Description, 
            nameof(value));
    }

    public static bool TryParse(string value, out EmailType? email)
    {
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, Pattern))
        {
            email = null;
            return false;
        }

        email = new EmailType(value);
        return true;
    }
}
