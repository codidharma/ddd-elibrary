namespace Domain.Books;

public record Isbn
{
    private const int Isbn10Length = 10;
    private const int Isbn13Length = 13;
    private const string IsbnInvalidExceptionMessage = "Isbn is invalid.";
    private const string IsbnInvalidLengthExceptionMessage = "Isbn should be a ten or thirteen digit number.";
    public string Value { get; init; }

    private Isbn(string isbnValue)
    {
        Value = isbnValue;
    }

    public static Isbn Create(string value) => new Isbn(Parse(value));

    private static string Parse(string isbnValue)
    {
        isbnValue = isbnValue.Replace("-","");

        if(!IsIsbnValueTenOrThirteenDigitsInLength(isbnValue))
        {
            throw new IsbnInvalidException(IsbnInvalidLengthExceptionMessage);
        }

        var isbnValueLength = isbnValue.Length;

        if(isbnValueLength == Isbn10Length)
        {
            return IsValidIsbn10(isbnValue)
                ? isbnValue
                : throw new IsbnInvalidException(IsbnInvalidExceptionMessage);
        }
        else
        {
            return IsValidIsbn13(isbnValue)
                ? isbnValue
                : throw new IsbnInvalidException(IsbnInvalidExceptionMessage);

        }
    }

    private static bool IsIsbnValueTenOrThirteenDigitsInLength(string isbnValue)
    {
        if(string.IsNullOrWhiteSpace(isbnValue))
        {
            return false;
        }

        if(isbnValue.Length == Isbn10Length || isbnValue.Length == Isbn13Length)
        {
            return true;
        }

        return false;
    }

    private static bool IsValidIsbn10(string isbnValue)
    {
        bool doFirstNineCharsFromLeftFormAInt = int.TryParse(isbnValue.Substring(0,9), out int numericPart);

        if(!doFirstNineCharsFromLeftFormAInt)
        {
            return false;
        }

        var sum = 0;

        for(int i = 0 ; i < 9; i++)
        {
            sum += (isbnValue[i] -'0') * (10-i);
        }

        if(isbnValue[9] == 'X')
        {
            sum += 10;
        }
        else
        {
            sum += isbnValue[9] -'0';
        }

        return sum % 11 == 0;
    }

    private static bool IsValidIsbn13(string isbnValue)
    {
        bool doFirstTwelveCharsFromLeftFormANumber = double.TryParse(isbnValue.Substring(0,12), out double numericPart);

        if(!doFirstTwelveCharsFromLeftFormANumber)
        {
            return false;
        }

        int firstThreeCharNumber = int.Parse(isbnValue.Substring(0,3));

        if(!(firstThreeCharNumber == 978 || firstThreeCharNumber == 979))
        {
            return false;
        }

        int sum = 0;

        for(int i = 0; i < 12; i++)
        {
            if(i  % 2 == 0)
            {
                sum += isbnValue[i] - '0';
            }
            else
            {
                sum +=  (isbnValue[i] -'0') * 3;
            }
        }
        sum += isbnValue[12] - '0';
        return sum % 10 ==0;
    }
}