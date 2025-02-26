namespace CrudClientesProdutos.Domain.ValueTypes;

public struct PriceType
{
    private readonly decimal _value;

    public PriceType(decimal value)
    {
        if (value <= 0)
            throw new DomainException("The value must be greater than zero.", nameof(value));

        _value = value;
    }

    public override string ToString() => _value.ToString("F2");

    public static implicit operator PriceType(decimal value)
        => new PriceType(value);

    public static implicit operator decimal(PriceType price)
        => price._value;
}
