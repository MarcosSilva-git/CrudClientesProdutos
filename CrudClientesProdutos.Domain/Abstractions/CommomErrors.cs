namespace CrudClientesProdutos.Domain.Abstractions;

public static class CommomErrors
{
    public static class Email
    {
        public static Error InvalidEmail(string email)
                => new(
                    "CommomError.Email.InvalidEmail",
                    $"Invalid email format: |{email}|.");
    }
    public static class PhoneNumber 
    {
        public static Error InvalidPhoneNumber(string phoneNumber)
               => new(
                   "CommomError.PhoneNumber.InvalidPhoneNumber",
                   $"Invalid phone number format: '{phoneNumber}'.");
    }
}
