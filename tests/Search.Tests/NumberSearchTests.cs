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
}
