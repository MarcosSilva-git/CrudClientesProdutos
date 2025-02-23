﻿using CrudClientesProdutos.Domain.ValueTypes;

namespace CrudClientesProdutos.UnitTests.ValueTypes;

public class PhoneNumberTests
{
    private readonly List<string> ValidPhoneNumbers = new List<string>
    {
        "+55 11 99999-9999",
        "+5511999999999",
        "+55 11 999999999",
    };

    private readonly List<string> InValidPhoneNumbers = new List<string>
    {
        "",
        "teste",
        "55 11 99999-9999",
        "55 11 9999-9999",
        "+55 11 9999999",
    };

    [Fact]
    public void Should_Parse_PhoneNumbers()
    {
        foreach (var phoneNumber in ValidPhoneNumbers)
        {
            var parsedPhoneNumber = PhoneNumber.Parse(phoneNumber);
            Assert.Equal(phoneNumber, parsedPhoneNumber.ToString());
        }
    }

    [Fact]
    public void Should_Not_Parse_PhoneNumbers()
    {
        foreach (var phoneNumber in InValidPhoneNumbers)
        {
            Assert.Throws<ArgumentException>(() => PhoneNumber.Parse(phoneNumber));
        }
    }
}
