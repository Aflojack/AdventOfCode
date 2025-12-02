using System;

namespace Day01;

public static class Solution
{
    public const int MaxRange = 99;
    public const int MinRange = 0;

    public static int GetNumberOfTimesDialOnZero(List<String> dialsList, int dialStartNumber)
    {
        var currentDialPoint = dialStartNumber;
        var zeroDialNumbers = 0;
        
        foreach (string dial in dialsList)
        {
            var direction = dial[..1];
            var distance = int.Parse(dial[1..]);
            
            if (direction == "R")
            {
                var temp = currentDialPoint + distance;
                if (temp > MaxRange)
                {
                    temp %= MaxRange + 1;
                }
                currentDialPoint = temp;
            }
            else
            {
                var temp = currentDialPoint - distance;
                if (temp < MinRange)
                {
                    temp = MaxRange + 1 - Math.Abs(temp % (MaxRange + 1));
                }
                if (temp > MaxRange)
                {
                    temp %= MaxRange + 1;
                }
                currentDialPoint = temp;
            }

            if (currentDialPoint == 0)
            {
                zeroDialNumbers++;
            }
        }
        return zeroDialNumbers;
    }
}
