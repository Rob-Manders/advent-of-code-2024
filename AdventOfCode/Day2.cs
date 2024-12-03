namespace Advent_of_Code;

public class Day2
{
    private static string _direction = "";
    
    public static int SafeReports(string[] input)
    {
        int safeReports = 0;
        
        foreach (string line in input)
        {
            List<int> values = ParseLine(line);

            if (IsSafe([..values]))
            {
                safeReports++;
                continue;
            }

            if (SafeWithDampener([..values])) safeReports++;
        }
        
        return safeReports;
    }

    private static bool SafeWithDampener(List<int> values)
    {
        bool safe = false;

        for (int i = 0; i < values.Count; i++)
        {
            List<int> v = RemoveValueFromList([..values], i);

            if (IsSafe(v))
            {
                safe = true;
                break;
            }
        }

        return safe;
    }
    
    private static List<int> RemoveValueFromList(List<int> values, int index)
    {
        if (index < values.Count)
        {
            values.RemoveAt(index);
        }
        else if (index == values.Count)
        {
            values = values[..(index - 1)];
        }
        
        return values;
    }

    private static bool IsSafe(List<int> values)
    {
        bool safe = true;
        _direction = values[1] > values[0] ? "increasing" : "decreasing";
        
        for (int i = 1; i < values.Count; i++)
        {
            if (!IsSafeValue(values[i], values[i - 1]))
            {
                safe = false;
            }
        }

        if (!IsSafeValue(values[1], values[0]))
        {
            safe = false;
        }

        return safe;
    }

    private static bool IsSafeValue(int i, int j)
    {
        if ((_direction == "decreasing" && i > j) || (_direction == "increasing" && i < j))
        {
            return false;
        }
            
        return (Math.Abs(i - j) is >= 1 and <= 3);
    }

    private static List<int> ParseLine(string line)
    {
        List<int> values = [];
        foreach (string value in line.Trim().Split(' '))
        {
            values.Add(int.Parse(value));
        }
        
        return values;
    }
}