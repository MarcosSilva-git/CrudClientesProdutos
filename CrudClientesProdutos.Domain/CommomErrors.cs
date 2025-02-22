using CrudClientesProdutos.Domain.Abstractions;

namespace CrudClientesProdutos.Domain
{
    public static class CommomErrors
    {
        public static readonly Error InvalidId = new
            ("CommomErros.InvalidId", "Invalid Id.");

        public static readonly Error InvalidEmail
            = new("CommomErros.InvalidEmail", "Invalid Email");
    }
}
