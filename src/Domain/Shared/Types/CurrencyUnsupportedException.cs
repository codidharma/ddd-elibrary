namespace Domain.Shared.Types;

public class CurrencyUnsupportedException(string message) : Exception(message);