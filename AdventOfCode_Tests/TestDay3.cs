using Advent_of_Code;

namespace Advent_of_Code_Tests;

public class TestDay3
{
    [Test]
    public void TestMultiplyInputs()
    {
        string testInput = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        
        int actual = Day3.MultiplyInputs(testInput);
        int expected = 48;
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}