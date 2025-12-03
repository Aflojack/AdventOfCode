using System;

namespace Day02;

public static class Solution
{
    public static long GetInvalidIdSum(ICollection<string> IdRanges, InvalidRuleType invalidRule)
    {
        var idRangeSum = 0L;
        foreach (string id in IdRanges)
        {
            var idSplit = id.Split("-");
            var minRange = long.Parse(idSplit[0]);
            var maxRange = long.Parse(idSplit[1]);
            for (var i = minRange; i <= maxRange; i++)
            {
                if (invalidRule == InvalidRuleType.ExactlyTwice && IsIdInvalidExaclyTwice(i.ToString()))
                {
                    idRangeSum += i;
                }

                if (invalidRule == InvalidRuleType.AtLeastTwice && IsIdInvalidAtLeastTwice(i.ToString()))
                {
                    idRangeSum += i;
                }
            }
        }
        return idRangeSum;
    }

    private static bool IsIdInvalidExaclyTwice(string id)
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

    private static bool IsIdInvalidAtLeastTwice(string id)
    {
        if (id.Length < 2)
        {
            return false;
        }
        if (IsIdInvalidExaclyTwice(id))
        {
            return true;
        }

        var centerIndex = id.Length / 2;
        var segmentSize = 0;
        for (var i = 0; i < centerIndex; i++)
        {
            segmentSize++;
            if (id.Length % segmentSize != 0)
            {
                continue;
            }
            var segmentString = id[..segmentSize];
            var repeated = 0;
            for (var j = segmentSize; j < id.Length; j += segmentSize)
            {
                if (segmentString == id.Substring(j, segmentSize))
                {
                    repeated++;
                }
                else
                {
                    repeated = 0;
                    break;
                }
            }
            if (repeated >= 2)
            {
                return true;
            }
        }
        return false;
    }
}
