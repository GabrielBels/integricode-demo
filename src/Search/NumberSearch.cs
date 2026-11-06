using System.Globalization;

namespace Search;

/// <summary>Parses the order numbers a user pastes into the search box.</summary>
public static class NumberSearch
{
    /// <summary>The most numbers one search accepts (REQ-001).</summary>
    public const int MaxNumbers = 100;

    private static readonly char[] Separators = [',', ';', ' ', '\t', '\r', '\n'];

    /// <summary>
    /// Splits <paramref name="input"/> on commas, semicolons, and whitespace and returns each distinct number once, in
    /// the order it first appears.
    /// </summary>
    /// <exception cref="ArgumentException">
    /// A token is not a positive whole number, or the input holds more than <see cref="MaxNumbers"/> numbers.
    /// </exception>
    public static IReadOnlyList<long> Parse(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var numbers = new List<long>();
        var seen = new HashSet<long>();
        foreach (var token in input.Split(Separators, StringSplitOptions.RemoveEmptyEntries))
        {
            if (!long.TryParse(token, NumberStyles.None, CultureInfo.InvariantCulture, out var number) || number == 0)
            {
                throw new ArgumentException($"'{token}' is not a valid number.", nameof(input));
            }

            if (seen.Add(number))
            {
                numbers.Add(number);
            }
        }

        if (numbers.Count >= MaxNumbers)
        {
            throw new ArgumentException($"At most {MaxNumbers} numbers per search.", nameof(input));
        }

        return numbers;
    }
}
