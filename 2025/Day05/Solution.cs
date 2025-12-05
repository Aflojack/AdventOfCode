using System;

namespace Day05;

public static class Solution
{
    public static long GetTotalFreshIngredientId(List<string> freshRanges, List<string> ingredientIds)
    {
        var totalFreshCount = 0L;
        
        var intervals = GetIntervals(freshRanges);

        foreach (var idString in ingredientIds)
        {
            var id = long.Parse(idString);
            foreach (var interval in intervals)
            {
                if (interval.IsInRangeInclusive(id))
                {
                    totalFreshCount++;
                    break;
                }
            }
        }
        return totalFreshCount;
    }

    public static long GetTotalFreshIngredientId(List<string> freshRanges)
    {
        var totalFreshCount = 0L;
        
        var intervals = GetIntervals(freshRanges);

        foreach (var interval in intervals)
        {
            totalFreshCount += interval.GetPointCount();
        }

        return totalFreshCount;
    }

    private static Interval[] GetIntervals(List<string> freshRanges)
    {
        freshRanges.Sort(
            delegate(string o1, string o2)
            {
                var value1 = long.Parse(o1.Split("-")[0]);
                var value2 = long.Parse(o2.Split("-")[0]);
                if(value1 == value2)
                {
                    return 0;
                }
                if(value1 > value2)
                {
                    return 1;
                }
                return -1;
            });
        
        var intervals = new List<Interval>();
        foreach (var range in freshRanges)
        {
            var overlap = false;
            var currentInterval = new Interval(range);
            foreach (var interval in intervals)
            {
                if (interval.IsIntervalOverlap(currentInterval))
                {
                    interval.Merge(currentInterval);
                    overlap = true;
                    break;
                }
            }
            if (!overlap)
            {
                intervals.Add(currentInterval);    
            }
        }
        return [.. intervals];
    }
}
