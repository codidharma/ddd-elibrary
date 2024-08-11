namespace Domain.Books.Tests;

public class PublicationDateUnitTests
{
    [Fact]
    public void WhenAFutureDateIsProvided_ThenParsingProcessThrowsPublicationDateInFutureException()
    {
        //Arrange
        var futurePublicationDate = DateOnly.FromDateTime(DateTime.Today.AddYears(1000));

        //Act
        Action act = () => PublicationDate.Create(futurePublicationDate);

        //Assert
        act.Should().Throw<PublicationDateInFutureException>()
        .WithMessage("Publication date can not be a future date.");
    }
}