namespace Domain.Shared.Types;

public record Currency
{
    internal static readonly Currency IndianRupees = new("INR");

    private Currency(string code) => Code = code;
    public string Code { get; init; }
    public static IReadOnlyList<Currency> SupportedCurrencies { get; private set; } = [IndianRupees];

    public static Currency FromCode(string code) => SupportedCurrencies.FirstOrDefault(currency => currency.Code == code)
            ?? throw new CurrencyUnsupportedException("The provided code does not represent a supported currency.");
}