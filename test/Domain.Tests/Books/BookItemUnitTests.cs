using Domain.Books;

namespace Domain.Tests.Books;

public class BookItemUnitTests
{
    [Theory]
    [InlineData("a7889bff-a5c3-4cf2-bb47-3f7f5cda4598")]
    public void WhenCorrectParametersArePassed_ThenInstantiationSucceeds(string bookIdentifier)
    {
        //Arrange
        var bookId = new BookId(Guid.Parse(bookIdentifier));
        var canBeReserved = true;

        //Act
        var bookItem = BookItem.Create(bookId, canBeReserved);

        //Assert
        bookItem.BookId.Should().Be(bookId);
        bookItem.CanBeReserved.Should().BeTrue();
    }
}