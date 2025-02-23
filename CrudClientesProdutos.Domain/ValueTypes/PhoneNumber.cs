using System.Text.RegularExpressions;

namespace CrudClientesProdutos.Domain.ValueTypes;

public struct PhoneNumber
{
    private readonly string _phoneNumber;

    public static readonly PhoneNumber Empty = new PhoneNumber("");

    private static readonly Dictionary<string, string> PhonePatterns = new()
    {
        { "pt-BR", @"^\+55\s?\d{2}\s?\d{5}-?\d{4}$" }
    };

    public PhoneNumber(string value)
    {
        _phoneNumber = value;
    }

    public static implicit operator PhoneNumber(string value)
        => Parse(value);

    public override string ToString()
    {
        return _phoneNumber;
    }

    public static PhoneNumber Parse(string value)
    {
        if (TryParse(value, out PhoneNumber phoneNumber))
        {
            return phoneNumber;
        }

        throw new ArgumentException($"Invalid phone number format: '{value}'.", nameof(value));
    }

    public static bool TryParse(string value, out PhoneNumber phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            phoneNumber = Empty;
            return false;
        }

        if (PhonePatterns.TryGetValue("pt-BR", out string? pattern))
        {
            var isMatch = Regex.IsMatch(value, pattern);

            if (!isMatch)
            {
                phoneNumber = Empty;
                return false;
            }
        }

        phoneNumber = new PhoneNumber(value);
        return true;
    }
}
