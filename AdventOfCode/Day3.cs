using System.Text.RegularExpressions;

namespace Advent_of_Code;

public class Day3
{
    public static int MultiplyInputs(string input)
    {
        int sum = 0;
        bool mul = true;
        
        var regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)|don't\(\)|do\(\)");
        foreach (Match match in regex.Matches(input))
        {
            if (match.Value == "don't()")
            {
                mul = false;
                continue;
            }
            
            if (match.Value == "do()")
            {
                mul = true;
                continue;
            }
            
            if (!mul) continue;
            
            List<int> numbers = new List<int>(2);
            
            var numberRegex = new Regex(@"\d{1,3}");
            foreach (Match number in numberRegex.Matches(match.Value))
            {
                numbers.Add(int.Parse(number.Value));
            }
            
            sum += numbers[0] * numbers[1];
        }
        
        return sum;
    }
}