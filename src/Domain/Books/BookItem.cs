using Domain.Shared.Types;

namespace Domain.Books;

public class BookItem : Entity
{
    private BookItem(Guid id, BookId bookId) : base(id)
    {
        BookId = bookId;
    }

    public BookId BookId { get; private set; }

    public static BookItem Create(BookId bookId)
    {
        return new BookItem(
            id: Guid.NewGuid(),
            bookId: bookId
        );
    }
}