namespace Advent_of_Code;

public class Day2
{
    public static int SafeReports(string[] input)
    {
        int safeReports = 0;
        
        foreach (string line in input)
        {
            List<int> values = [];
            foreach (string value in line.Trim().Split(' '))
            {
                values.Add(int.Parse(value));
            }

            (bool isSafe, List<int> unsafeIndices) = IsSafe(values);

            if (isSafe)
            {
                safeReports++;
                continue;
            }

            bool canBeSafe = false;
            int valuesRemoved = 0;
            
            foreach (int index in unsafeIndices)
            {
                if (!CanBeSafe([..values], index)) continue;
                
                canBeSafe = true;
                valuesRemoved++;
            }

            if (canBeSafe && valuesRemoved == 1) safeReports++;
        }
        
        return safeReports;
    }
    
    private static bool CanBeSafe(List<int> values, int index)
    {
        if (index < values.Count)
        {
            values.RemoveAt(index);
        }
        else if (index == values.Count)
        {
            values = values.Slice(0, index - 1).ToList();
        }
        
        (bool safe, _) = IsSafe(values);
        
        return safe;
    }

    private static (bool isSafe, List<int> unsafeIndices) IsSafe(List<int> values)
    {
        bool safe = true;
        string direction = "decreasing";

        List<int> unsafeIndices = [];
        
        if (values[1] > values[0])
        {
            direction = "increasing";
        }
        
        for (int i = 1; i < values.Count; i++)
        {
            if ((direction == "decreasing" && values[i] > values[i - 1]) || (direction == "increasing" && values[i] < values[i - 1]))
            {
                safe = false;
                unsafeIndices.Add(i);
                continue;
            }
            
            if (Math.Abs(values[i] - values[i - 1]) is >= 1 and <= 3) continue;
            
            safe = false;
            unsafeIndices.Add(i);
        }
        
        if ((direction == "decreasing" && values[1] > values[0]) || (direction == "increasing" && values[1] < values[0]))
        {
            safe = false;
            unsafeIndices.Add(0);
        }
        
        int difference = Math.Abs(values[1] - values[0]);
        if (difference < 1 || difference > 3)
        {
            safe = false;
            unsafeIndices.Add(0);
        };

        return (safe, unsafeIndices);
    }
}