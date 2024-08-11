namespace Domain.Books;

public record PublicationDate
{
    public DateOnly Value { get; init; }

    private PublicationDate(DateOnly date) => Value = date;

    public static PublicationDate Create(DateOnly date)
    {
        var todaysDate = DateOnly.FromDateTime(DateTime.Today);

        if(date.DayNumber > todaysDate.DayNumber)
        {
            throw new PublicationDateInFutureException("Publication date can not be a future date.");
        }
        return new PublicationDate(date);
    }
}