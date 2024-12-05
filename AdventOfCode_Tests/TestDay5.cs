using Advent_of_Code;

namespace Advent_of_Code_Tests;

public class TestDay5
{
    [Test]
    public void TestGetMiddlePageNumbers()
    {
        string[] input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Data/Day5/test-input.txt"));
        
        Day5 day5 = new(input);
        
        int actual = day5.GetCorrectlyOrderedPages();
        int expected = 143;
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestFixIncorrectPages()
    {
        string[] input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Data/Day5/test-input.txt"));
        
        Day5 day5 = new(input);
        
        int actual = day5.FixIncorrectPages();
        int expected = 123;
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}