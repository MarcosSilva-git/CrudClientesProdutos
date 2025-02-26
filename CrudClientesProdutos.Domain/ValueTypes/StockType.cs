namespace CrudClientesProdutos.Domain.ValueTypes;

public record struct StockType
{
    public readonly int _value;

    public StockType(int value)
    {
        if (value < 1)
            throw new DomainException("The stock value must be at least 1.", nameof(value));

        _value = value;
    }
    public override string ToString() => _value.ToString();
    public static implicit operator StockType(int value) => new StockType(value);
    public static implicit operator int(StockType stock) => stock._value;
}
