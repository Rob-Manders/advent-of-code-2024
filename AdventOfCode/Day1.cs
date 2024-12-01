namespace Advent_of_Code;

public class Day1
{
    public static int GetTotalDistance(string[] lists)
    {
        (List<int> leftList, List<int>rightList) = SplitLists(lists);
        
        int totalDistance = 0;
        for (int i = 0; i < leftList.Count; i++)
        {
            totalDistance += Math.Abs(rightList[i] - leftList[i]);
        }

        return totalDistance;
    }

    public static int GetSimiliarityScore(string[] lists)
    {
        (List<int> leftList, List<int> rightList) = SplitLists(lists);
        
        Dictionary<int, int> scores = new Dictionary<int, int>();

        foreach (int i in leftList)
        { 
            scores.TryAdd(i, 0);
            
            foreach (int j in rightList)
            {
                int occurrences = 0;
                if (i == j) occurrences += 1;

                scores[i] += i * occurrences;
            }
        }
        
        return scores.Values.Sum();
    }

    private static (List<int> leftList, List<int> rightList) SplitLists(string[] lists)
    {
        List<int> leftList = [];
        List<int> rightList = [];

        foreach (string row in lists)
        {
            string[] segments = row.Split(' ');
            
            leftList.Add(int.Parse(segments[0]));
            rightList.Add(int.Parse(segments[^1]));
        }
        
        leftList.Sort();
        rightList.Sort();
        
        return (leftList, rightList);
    }
}