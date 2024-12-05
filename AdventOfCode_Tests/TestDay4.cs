using Advent_of_Code;

namespace Advent_of_Code_Tests;

public class TestDay4
{
    [Test]
    public void TestGetXMasCount()
    {
        string[] input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Data/Day4/test-input.txt"));
        
        int actual = Day4.GetXMasCount(input);
        int expected = 18;
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestGetXMasCrossCount()
    {
        string[] input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Data/Day4/test-input.txt"));
        
        int actual = Day4.GetXMasCrossCount(input);
        int expected = 9;
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}