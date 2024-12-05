namespace Advent_of_Code;

class Program
{
    static void Main(string[] args)
    {
        string[] input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Data/Day5/input.txt"));
        
        Day5 day5 = new(input);
        
        Console.WriteLine(day5.GetCorrectlyOrderedPages());
    }
}