namespace CrudClientesProdutos.Domain.ValueTypes;

public struct NameType
{
    public const int DefaultMinLength = 3;
    public const int DefaultMaxLength = 100;

    private readonly string _value;

    public int MinLength { get; }
    public int MaxLength { get; }

    public NameType(string value, int minLength = DefaultMinLength, int maxLength = DefaultMaxLength)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < minLength || value.Length > DefaultMaxLength)
        {
            throw new DomainException(
            $"The name '{value}' is invalid. The length must be between {minLength} and {maxLength} characters.",
            nameof(value));
        }

        MinLength = minLength;
        MaxLength = maxLength;

        _value = value;
    }

    public override string ToString() => _value;

    public static implicit operator string(NameType name) => name._value;
    public static implicit operator NameType(string value) => new NameType(value);
}
