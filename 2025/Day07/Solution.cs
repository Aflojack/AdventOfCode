using System;

namespace Day07;

public static class Solution
{
    private const char StarterMarker = 'S';
    private const char SplitterMarker = '^';

    public static int GetTotalBeamPart1(List<string> inputMap)
    {
        if(inputMap.Count < 2)
        {
            return 0;
        }

        HashSet<int> indexSet = [];
        for (var j = 0; j < inputMap[0].Length; j++)
        {
            if (inputMap[0][j] == StarterMarker)
            {
                indexSet.Add(j);
                break;
            }
        }

        var splitTimes = 0;
        for (var i = 1; i < inputMap.Count; i++)
        {
            var currentIndexSet = indexSet.ToArray();
            for (var j = 0; j < currentIndexSet.Length; j++)
            {
                if (inputMap[i][currentIndexSet[j]] == SplitterMarker)
                {
                    splitTimes++;
                    var temp = currentIndexSet[j];
                    indexSet.Remove(temp);
                    indexSet.Add(temp + 1);
                    indexSet.Add(temp - 1);
                }
            }
        }

        return splitTimes;
    }
}
