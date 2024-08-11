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

    [Fact]
    public void WhenAPresentOrPastDateIsProvided_ThenParsingProcessesProducesValidInstance()
    {
        //Arrange
        var todaysDate = DateOnly.FromDateTime(DateTime.Today);
        var pastDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-70));

        //Act
        var todaysPublicationDate = PublicationDate.Create(todaysDate);
        var pastPublicationDate = PublicationDate.Create(pastDate);

        //Assert
        todaysPublicationDate.Value.Should().Be(todaysDate);
        pastPublicationDate.Value.Should().Be(pastDate);

    }
}