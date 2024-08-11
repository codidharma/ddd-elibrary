using Domain.Books;

namespace Domain.Tests.Books;

public class BookItemUnitTests
{
    [Theory]
    [InlineData("a7889bff-a5c3-4cf2-bb47-3f7f5cda4598", "1998-07-21")]
    public void WhenCorrectParametersArePassed_ThenInstantiationSucceeds(string bookIdentifier, string publishedDateString)
    {
        //Arrange
        var bookId = new BookId(Guid.Parse(bookIdentifier));

        //Act
        var bookItem = BookItem.Create(bookId);

        //Assert
        bookItem.BookId.Should().Be(bookId);
    }
}