using Domain.Shared.Types;

namespace Domain.Tests.Books;

public class CurrencyUnitTests
{
    [Theory]
    [InlineData("PKR")]
    public void WhenUnsupportedCurrencyValueIsProvided_ThenParsingThrowsCurrencyUnspportedException(string code)
    {
        //Act
        Action act = () => Currency.FromCode(code);

        //Assert
        act.Should().Throw<CurrencyUnsupportedException>()
        .WithMessage("The provided code does not represent a supported currency.");

    }

    [Theory]
    [InlineData("INR")]
    public void WhenSupportedCurrencyCodeIsProvided_ThenParsingProcessReturnsAValidInstance(string currencyCode)
    {
        //Act
        var currency = Currency.FromCode(currencyCode);

        //Assert
        currency.Code.Should().Be(currencyCode);

    }
}