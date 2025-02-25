using CrudClientesProdutos.Domain.Abstractions;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace CrudClientesProdutos.Domain.ValueTypes;

public record struct PhoneNumberType
{
    private readonly string _phoneNumber;

    private static readonly Dictionary<string, string> PhonePatterns = new()
    {
        { "pt-BR", @"^\d{2}\s?\d{5}-?\d{4}$" }
    };

    public PhoneNumberType(string value)
    {
        _phoneNumber = value;
    }

    public static implicit operator PhoneNumberType(string value) => Parse(value);
    public static implicit operator string(PhoneNumberType phoneNumber) => phoneNumber._phoneNumber;

    public override string ToString()
    {
        return _phoneNumber;
    }

    public static PhoneNumberType Parse(string value)
    {
        if (TryParse(value, out PhoneNumberType? phoneNumber))
        {
            return phoneNumber!.Value;
        }

        throw new ArgumentException(
            CommomErrors.PhoneNumber.InvalidPhoneNumber(value).Description, 
            nameof(value));
    }

    public static bool TryParse(string value, out PhoneNumberType? phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            phoneNumber = null;
            return false;
        }

        if (PhonePatterns.TryGetValue("pt-BR", out string? pattern))
        {
            var isMatch = Regex.IsMatch(value, pattern);

            if (!isMatch)
            {
                phoneNumber = null;
                return false;
            }
        }

        phoneNumber = new PhoneNumberType(value);
        return true;
    }
}
