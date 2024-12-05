namespace Advent_of_Code;

public class Day5
{
    private static List<List<int>> _orderingRules;
    private static List<List<int>> _pageList;
    private static List<List<int>> _correctPages = new();
    private static List<List<int>> _incorrectPages = new();

    public Day5(string[] input)
    {
        ParseInput(input);
        SortPages();
    }

    public int FixIncorrectPages()
    {
        List<List<int>> correctedPages = new();

        foreach (var page in _incorrectPages)
        {
            List<int> currentPage = page;
            
            bool correct = false;
            while (!correct)
            {
                if (!IsPageCorrect(currentPage))
                {
                    currentPage = FixPageOrder([..currentPage]);
                }
                else
                {
                    correct = true;
                }
            }
            
            correctedPages.Add(currentPage);
        }

        return PagesTotal(correctedPages);
    }

    public int GetCorrectlyOrderedPages()
    {
        return PagesTotal(_correctPages);
    }

    public static List<int> FixPageOrder(List<int> page)
    {
        foreach (List<int> rule in _orderingRules)
        {
            if (page.Contains(rule[0]) && page.Contains(rule[1]))
            {
                int indexA = GetIndex(page, rule[0]);
                int indexB = GetIndex(page, rule[1]);
                
                int value = page[indexB];
                
                page.Remove(indexB);
                page.Insert(indexA, value);
            }
        }

        return page;
    }

    public static bool IsPageCorrect(List<int> page)
    {
        foreach (List<int> rule in _orderingRules)
        {
            if (!IsCorrectOrder(page, rule[0], rule[1])) return false;
        }
     
        return true;
    }

    private static int PagesTotal(List<List<int>> pages)
    {
        int total = 0;

        foreach (List<int> page in _correctPages)
        {
            int middle = page.Count / 2;
            total += page[middle];
        }
        
        return total;
    }

    private static void SortPages()
    {
        foreach (List<int> page in _pageList)
        {
            bool pass = true;
            
            foreach (List<int> rule in _orderingRules)
            {
                if (page.Contains(rule[0]) && page.Contains(rule[1])) pass = IsCorrectOrder(page, rule[0], rule[1]);
            }
            
            if (pass) _correctPages.Add(page);
            else _incorrectPages.Add(page);
        }
    }

    private static bool IsCorrectOrder(List<int> page, int ruleA, int ruleB)
    {
        int a = GetIndex(page, ruleA);
        int b = GetIndex(page, ruleB);

        if (a >= b) return false;
        
        return true;
    }

    private static int GetIndex(List<int> page, int rule)
    {
        for (int i = 0; i < page.Count; i++)
        {
            if (page[i] == rule) return i;
        }

        return -1;
    }
    
    private static void ParseInput(string[] input)
    {
        bool assigningRules = true;
        
        List<List<int>> rules = new List<List<int>>();
        List<List<int>> pages = new List<List<int>>();

        foreach (string line in input)
        {
            if (line == "")
            {
                assigningRules = false;
                continue;
            }

            if (assigningRules)
            {
                List<string> r = line.Split("|").ToList();
                rules.Add([Int32.Parse(r[0]), Int32.Parse(r[1])]);
            }
            else
            {
                List<string> p = line.Split(",").ToList();
                List<int> page = new List<int>();
                
                foreach (string value in p)
                {
                    page.Add(Int32.Parse(value));
                }
                
                pages.Add(page);
            }
        }
        
        _orderingRules = rules;
        _pageList = pages;
    }
}