using Domain.Shared.Types;

namespace Domain.Books;

public class Book : Entity
{
    private Book(
        Guid id,
        Isbn isbn,
        Title title,
        AuthorId authorId,
        PublicationDate publicationDate,
        Money price) : base(id)
    {
        Isbn = isbn;
        Title = title;
        AuthorId = authorId;
        PublicationDate = publicationDate;
        Price = price;
    }

    public Isbn Isbn { get; private set; }

    public Title Title { get; private set; }

    public AuthorId AuthorId { get; private set; }

    public PublicationDate PublicationDate { get; private set;}

    public Money Price { get; private set; }

    public static Book Create(
        Isbn isbn,
        Title title,
        AuthorId authorId,
        PublicationDate publicationDate,
        Money price)
    {
        var book = new Book(
            id: Guid.NewGuid(),
            isbn: isbn,
            title: title,
            authorId: authorId,
            publicationDate: publicationDate,
            price: price);

        return book;
    }
}
