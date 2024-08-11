using System.Net.Http.Headers;
using Domain.Books;
using Domain.Shared.Types;

namespace Domain.Tests.Books;

public class BookUnitTests
{
    [Theory]
    [InlineData("0-596-52068-9", "Art of War", "88a7ff9b-a5c3-4cf2-bb47-3f7f5cda4568", "INR", 100.54)]
    public void WhenValidParametersArePassed_ThenBookInstantiationIsSuccessful(
        string isbnValue,
        string titleValue,
        string authorIdentifier,
        string currencyCode,
        decimal priceValue)
    {
        //Arrange
        var isbn = Isbn.Create(isbnValue);
        var title = new Title(titleValue);
        var authorId = new AuthorId( Guid.Parse(authorIdentifier));
        var publicationDate = PublicationDate.Create(DateOnly.FromDateTime(DateTime.Today));
        var price = new Money(priceValue, Currency.FromCode(currencyCode));

        //Act
        var book = Book.Create(isbn, title, authorId, publicationDate, price);

        //Assert
        book.Isbn.Should().Be(isbn);
        book.Title.Should().Be(title);
        book.AuthorId.Should().Be(authorId);
        book.PublicationDate.Should().Be(publicationDate);
        book.Price.Should().Be(price);
    }
}