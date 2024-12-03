namespace Advent_of_Code;

class Program
{
    static void Main(string[] args)
    {
        string[] input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Data/Day2/input.txt"));
        
        Console.WriteLine(Day2.SafeReports(input));
    }
}