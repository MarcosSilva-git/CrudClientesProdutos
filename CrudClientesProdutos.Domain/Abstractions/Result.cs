namespace CrudClientesProdutos.Domain.Abstractions;

public readonly struct Result<T> 
{
    public readonly bool IsSuccess;
    public bool IsFailure { get => !IsSuccess; }

    public readonly Error Error;
    public readonly T? Value;
    
    private Result(T? value, bool isSuccess, Error error)
    {
        Value = value;
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result<T> Success(T value) => new Result<T>(value, true, Error.None);
    public static Result<T> Fail(Error error) => new Result<T>(default, false, error);


    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(Error error) => Fail(error);

    public TResult Match<TResult>(
        Func<T, TResult> onSuccess, 
        Func<Error, TResult> onFailure)
        => IsSuccess ? onSuccess(Value!) : onFailure(Error);

}
