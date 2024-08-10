using System.Runtime.CompilerServices;
using Domain.Books;

namespace Domain.Tests.Books;

public class IsbnUnitTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("011211242")]
    [InlineData("01121124251")]
    public void WhenIsbnIsNotTenOrThirteenDigits_ThenInstantiationFailsWithIsbnInvalidException(string isbnValue)
    {
        //Act
        Action act = () => Isbn.Create(isbnValue);

        //Assert
        act.Should().Throw<IsbnInvalidException>()
        .WithMessage("Isbn should be a ten or thirteen digit number.");
    }

    [Theory]
    [InlineData("0112112425")]
    [InlineData("0a12112425")]
    [InlineData("976-0-596-52068-1")]
    [InlineData("978-0-596-52068-1")]
    [InlineData("978-X-596-52068-1")]
    public void WhenInvalidIsbnIsProvided_ThenInstantionFailsWithIsbnInvalidException(string isbnValue)
    {
        //Act
        Action act = () => Isbn.Create(isbnValue);

        //Assert
        act.Should().Throw<IsbnInvalidException>()
        .WithMessage("Isbn is invalid.");
    }

    [Theory]
    [InlineData("0-596-52068-9")]
    [InlineData("0596520689")]
    [InlineData("007462542X")]
    [InlineData("978-0-596-52068-7")]
    [InlineData("978-0-439-02348-1")]
    [InlineData("9780596520687")]
    public void WhenValidIsbnIsProvided_ThenInstantiationSucceeds(string isbnValue)
    {
        //Act
        Action act = () => Isbn.Create(isbnValue);

        //Assert
        act.Should().NotThrow();
    }
}