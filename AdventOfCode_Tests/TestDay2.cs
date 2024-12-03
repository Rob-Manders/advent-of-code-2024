using Advent_of_Code;

namespace Advent_of_Code_Tests;

public class TestDay2
{
    [Test]
    public void TestSafeReports()
    {
        string[] input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Data/Day2/test-input.txt"));
        
        int actual = Day2.SafeReports(input);
        int expected = 4;
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void TestRealSafeReports()
    {
        string[] input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Data/Day2/input.txt"));
        
        int actual = Day2.SafeReports(input);
        int expected = 426;
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}