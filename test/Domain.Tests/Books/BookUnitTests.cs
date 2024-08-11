using System.Net.Http.Headers;
using Domain.Books;
using Domain.Shared.Types;

namespace Domain.Tests.Books;

public class BookUnitTests
{
    [Theory]
    [InlineData("0-596-52068-9", "Art of War", "88a7ff9b-a5c3-4cf2-bb47-3f7f5cda4568")]
    public void WhenValidParametersArePassed_ThenBookInstantiationIsSuccessful(
        string isbnValue, string titleValue, string authorIdentifier)
    {
        //Arrange
        var isbn = Isbn.Create(isbnValue);
        var title = new Title(titleValue);
        var authorId = new AuthorId( Guid.Parse(authorIdentifier));

        //Act
        var book = Book.Create(isbn, title, authorId);

        //Assert
        book.Isbn.Should().Be(isbn);
        book.Title.Should().Be(title);
        book.AuthorId.Should().Be(authorId);
    }
}