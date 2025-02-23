using System.Text.RegularExpressions;

namespace CrudClientesProdutos.Domain.ValueTypes;

public struct Email
{
    private readonly string _email;
    public static readonly Email Empty = new Email("");

    private static readonly string Pattern 
        = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    private Email(string email)
    {
        _email = email;
    }

    public static implicit operator Email(string value)
        => Parse(value);

    public override string ToString()
        => _email;

    public static Email Parse(string value)
    {
        if (TryParse(value, out var email))
            return email;

        throw new ArgumentException($"Invalid email format: \"{value}\".", nameof(value));
    }

    public static bool TryParse(string value, out Email email)
    {
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, Pattern))
        {
            email = Empty;
            return false;
        }

        email = new Email(value);
        return true;
    }
}
