using Advent_of_Code;

namespace Advent_of_Code_Tests;

public class TestDay1
{
    [Test]
    public void TestGetTotalDistance()
    {
        string[] lists = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Data/Day1/test-input.txt"));
        
        int actual = Day1.GetTotalDistance(lists);
        int expected = 11;
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestGetTotalDistance2()
    {
        string[] lists =
        [
            "5    10",
            "20 15",
        ];
        
        int actual = Day1.GetTotalDistance(lists);
        int expected = 10;
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestGetSimilarityScore()
    {
        string[] lists = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Data/Day1/test-input.txt"));
        
        int actual = Day1.GetSimiliarityScore(lists);
        int expected = 31;
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}