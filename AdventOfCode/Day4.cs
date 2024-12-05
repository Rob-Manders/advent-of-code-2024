using System.Text.RegularExpressions;

namespace Advent_of_Code;

public class Day4
{
    private static readonly string[] SearchStrings = ["XMAS", "SAMX"];

    public static int GetXMasCrossCount(string[] input)
    {
        List<List<char>> grid = CreateGrid(input);

        string[] validPatterns = ["MMASS", "SSAMM", "MSAMS", "SMASM"];
        int count = 0;
        
        for (int i = 0; i < grid.Count - 2; i++)
        {
            for (int j = 0; j < grid[0].Count - 2; j++)
            {
                string pattern = $"{grid[i][j]}{grid[i + 2][j]}{grid[i + 1][j + 1]}{grid[i][j + 2]}{grid[i + 2][j + 2]}";

                if (validPatterns.Contains(pattern)) count++;
            }
        }
        
        return count;
    }
    
    public static int GetXMasCount(string[] input)
    {
        int count = CountInstancesInLines([..input]);
        
        List<List<char>> grid = CreateGrid([..input]);
        
        count += GetVerticalCount([..grid]);
        count += GetDiagonalCount([..grid]);
        
        return count;
    }

    private static int GetDiagonalCount(List<List<char>> grid)
    {
        List<string> lines = new List<string>();
        
        int height = grid.Count - 1;
        int width = grid[0].Count - 1;

        // Top-Left to Bottom-Right
        for (int j = 0; j < height + width + 1; j++)
        {
            string line = "";

            int i = j;
            int k = 0;
            
            if (j > height)
            {
                i = height;
                k = j - height;
            }

            while (i >= 0)
            {
                line += grid[i][k];
                
                if (k == width) break;
                
                i--;
                k++;
            }
            
            lines.Add(line);
        }
        
        // Top-Right to Bottom-Left
        for (int j = 0; j < height + width + 1; j++)
        {
            string line = "";

            int i = j;
            int k = width;
            
            if (j > height)
            {
                i = height;
                k = (height + width) - j;
            }

            while (i >= 0)
            {
                line += grid[i][k];
                
                if (k == 0) break;
                
                i--;
                k--;
            }
            
            lines.Add(line);
        }
        
        return CountInstancesInLines(lines);
    }

    private static int GetVerticalCount(List<List<char>> input)
    {
        List<string> columns = new List<string>();
        
        int height = input.Count;
        int width = input[0].Count;

        for (int i = 0; i < width; i++)
        {
            string column = "";
            for (int j = 0; j < height; j++)
            {
                column += input[j][i];
            }
            
            columns.Add(column);
        }

        return CountInstancesInLines(columns);
    }

    private static int CountInstancesInLines(List<string> lines)
    {
        int count = 0;
        
        foreach (string s in SearchStrings)
        {
            foreach (string line in lines)
            {
                count += new Regex(s).Matches(line).Count;
            }
        }
        
        return count;
    }
    
    private static List<List<char>> CreateGrid(string[] input)
    {
        List<List<char>> grid = new List<List<char>>();

        foreach (string line in input)
        {
            List<char> chars = new List<char>();
            foreach (char letter in line)
            {
                chars.Add(letter);
            }
            
            grid.Add(chars);
        }

        return grid;
    }
}