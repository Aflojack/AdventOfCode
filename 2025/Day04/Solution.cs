using System;
using Microsoft.VisualBasic;

namespace Day04;

public static class Solution
{
    private const char PaperRoll = '@';
    private const char EmptySpace = '.';
    private const char MovablePaperRoll = 'x';

    public static int GetTotalMovablePaper(List<string> inputLines, int range, int paperRollLimit)
    {
        char[][] mapArray = [.. inputLines.Select(o=>o.ToCharArray())];
        char[][] resultArray = [.. inputLines.Select(o=>o.ToCharArray())];
        var totalMovable = 0;
        for (var i = 0; i < mapArray.Length; i++)
        {
            for (var j = 0; j < mapArray[0].Length; j++)
            {
                if (mapArray[i][j] == PaperRoll &&
                    GetRollNumberInRange(mapArray, i, j, range) < paperRollLimit)
                {
                    resultArray[i][j] = MovablePaperRoll;
                    totalMovable++;
                }
            }
        }
        return totalMovable;
    }

    public static int GetTotalMovablePaperIterative(List<string> inputLines, int range, int paperRollLimit)
    {
        char[][] mapArray = [.. inputLines.Select(o=>o.ToCharArray())];
        char[][] resultArray = [.. inputLines.Select(o=>o.ToCharArray())];
        var totalMovable = 0;
        while (true)
        {
            var newMovable = 0;
            for (var i = 0; i < mapArray.Length; i++)
            {
                for (var j = 0; j < mapArray[0].Length; j++)
                {
                    if (mapArray[i][j] == PaperRoll &&
                        GetRollNumberInRange(mapArray, i, j, range) < paperRollLimit)
                    {
                        resultArray[i][j] = MovablePaperRoll;
                        newMovable++;
                    }
                }
            }
            if (newMovable == 0)
            {
                break;
            }
            totalMovable += newMovable;
            mapArray = [.. resultArray];
        }
        return totalMovable;
    }

    private static int GetRollNumberInRange(char[][] array, int local_i, int local_j, int range)
    {
        var total = 0;
        for (var i = local_i - range; i <= local_i + range; i++)
        {
            for (var j = local_j - range; j <= local_j + range; j++)
            {
                if(i == local_i && j == local_j)
                {
                    continue;
                }
                if (GetElementByIndex(array, i, j) == PaperRoll)
                {
                    total++;
                }
            }
        }
        return total;
    }

    private static char GetElementByIndex(char[][] array, int i, int j)
    {
        if (i < 0 || i >= array.Length || j < 0 || j >= array[0].Length)
        {
            return EmptySpace;
        }
        return array[i][j];
    }
}
