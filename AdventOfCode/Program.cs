namespace Advent_of_Code;

class Program
{
    static void Main(string[] args)
    {
        string[] input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Data/Day4/input.txt"));
        
        Console.WriteLine(Day4.GetXMasCrossCount(input));
    }
}