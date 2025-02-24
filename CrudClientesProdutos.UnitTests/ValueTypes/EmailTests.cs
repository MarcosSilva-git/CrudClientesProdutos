using CrudClientesProdutos.Domain.ValueTypes;

namespace CrudClientesProdutos.UnitTests.ValueTypes;

public class EmailTests
{
    private readonly List<string> ValidEmails = new List<string>
    {
        "a@example.com",
        "teste@e.com.br",
        "valid@yahoo.net"
    };

    private readonly List<string> InValidEmails = new List<string>
    {
        "",
        "teste",
        "@exemplo.com",
        "@exemplo.com.br",
        "asdexemplo.com.br",
        "asd@exemplo"
    };

    [Fact]
    public void Should_Parse_Emails()
    {
        foreach (var phoneNumber in ValidEmails)
        {
            var parsedPhoneNumber = EmailType.Parse(phoneNumber);
            Assert.Equal(phoneNumber, parsedPhoneNumber.ToString());
        }
    }

    [Fact]
    public void Should_Not_Parse_Emails()
    {
        foreach (var phoneNumber in InValidEmails)
        {
            Assert.Throws<ArgumentException>(() => EmailType.Parse(phoneNumber));
        }
    }
}
