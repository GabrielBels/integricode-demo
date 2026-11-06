using Search;

namespace Search.Tests;

public class NumberSearchTests
{
    [Fact]
    public void Parse_SplitsOnCommasSemicolonsAndWhitespace() =>
        Assert.Equal([1L, 2L, 3L, 4L], NumberSearch.Parse("1, 2;3\n4"));

    [Fact]
    public void Parse_KeepsTheFirstOccurrenceOfARepeatedNumber() =>
        Assert.Equal([7L, 3L], NumberSearch.Parse("7 3 7"));

    [Theory]
    [InlineData("12 abc")]
    [InlineData("-5")]
    [InlineData("0")]
    public void Parse_RejectsATokenThatIsNotAPositiveWholeNumber(string input) =>
        Assert.Throws<ArgumentException>(() => NumberSearch.Parse(input));

    [Fact]
    public void Parse_AcceptsASearchUnderTheLimit() =>
        Assert.Equal(50, NumberSearch.Parse(Numbers(50)).Count);

    [Fact]
    public void Parse_RejectsASearchOverTheLimit()
    {
        var error = Assert.Throws<ArgumentException>(() => NumberSearch.Parse(Numbers(150)));
        Assert.StartsWith("At most 100 numbers per search.", error.Message);
    }

    [Fact]
    public void Parse_CountsARepeatedNumberOnceTowardTheLimit() =>
        Assert.Equal(60, NumberSearch.Parse(Numbers(60) + " " + Numbers(60)).Count);

    private static string Numbers(int count) => string.Join(' ', Enumerable.Range(1, count));
}
