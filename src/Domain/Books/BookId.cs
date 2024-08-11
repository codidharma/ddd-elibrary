using Domain.Shared.Types;

namespace Domain.Books;

public record BookId(Guid Value) : TypedId(Value);