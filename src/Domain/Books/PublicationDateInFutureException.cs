namespace Domain.Books;

public class PublicationDateInFutureException(string message) : Exception(message);
