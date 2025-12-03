using System;

namespace Day02;

public static class Solution
{
    public static long GetInvalidIdSum(ICollection<string> IdRanges)
    {
        var idRangeSum = 0L;
        foreach (string id in IdRanges)
        {
            var idSplit = id.Split("-");
            var minRange = long.Parse(idSplit[0]);
            var maxRange = long.Parse(idSplit[1]);
            for (var i = minRange; i <= maxRange; i++)
            {
                if (IsIdInvalid(i.ToString()))
                {
                    idRangeSum += i;
                }
            }
        }
        return idRangeSum;
    }

    private static bool IsIdInvalid(string id)
    {
        if (id.Length < 2 || id.Length % 2 != 0)
        {
            return false;
        }
        var centerIndex = id.Length / 2;
        if (id[..centerIndex] == id[centerIndex..])
        {
            return true;
        }
        return false;
    }
}
