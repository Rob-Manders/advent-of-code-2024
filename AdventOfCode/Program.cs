namespace Advent_of_Code;

class Program
{
    static void Main(string[] args)
    {
        string input = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Data/Day3/input.txt"));
        
        Console.WriteLine(Day3.MultiplyInputs(input));
    }
}