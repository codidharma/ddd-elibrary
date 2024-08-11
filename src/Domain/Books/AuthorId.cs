using Domain.Shared.Types;

namespace Domain.Books;

public record AuthorId(Guid value) : TypedId(value);