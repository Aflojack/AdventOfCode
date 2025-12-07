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

    public static long GetTotalBeamPart2(List<string> inputMap)
    {
        if(inputMap.Count < 2)
        {
            return 0;
        }

        HashSet<int> indexSet = [];
        long[] timesArray = new long[inputMap[0].Length];
        for (var j = 0; j < inputMap[0].Length; j++)
        {
            if (inputMap[0][j] == StarterMarker)
            {
                indexSet.Add(j);
                timesArray[j] = 1;
                break;
            }
        }
        
        for (var i = 1; i < inputMap.Count; i++)
        {
            var currentIndexSet = indexSet.ToArray();
            for (var j = 0; j < currentIndexSet.Length; j++)
            {
                if (inputMap[i][currentIndexSet[j]] == SplitterMarker)
                {
                    var tempIndex = currentIndexSet[j];
                    indexSet.Remove(tempIndex);
                    indexSet.Add(tempIndex + 1);
                    indexSet.Add(tempIndex - 1);

                    var tempTimes = timesArray[tempIndex];
                    timesArray[tempIndex + 1] += tempTimes == 1 ? 1 : tempTimes;
                    timesArray[tempIndex - 1] += tempTimes == 1 ? 1 : tempTimes;
                    timesArray[tempIndex] = 0;
                }
            }
        }
        
        var total = 0L;
        foreach (var index in indexSet)
        {
            total += timesArray[index];
        }
        return total;
    }
}
