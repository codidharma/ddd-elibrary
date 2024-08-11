using Domain.Shared.Types;

namespace Domain.Books;

public class BookItem : Entity
{
    private BookItem(Guid id, BookId bookId, bool canBeReserved) : base(id)
    {
        BookId = bookId;
        CanBeReserved = canBeReserved;
    }

    public BookId BookId { get; private set; }

    public bool CanBeReserved { get; private set; }

    public static BookItem Create(BookId bookId, bool canBeReserved)
    {
        return new BookItem(
            id: Guid.NewGuid(),
            bookId: bookId,
            canBeReserved : canBeReserved
        );
    }
}