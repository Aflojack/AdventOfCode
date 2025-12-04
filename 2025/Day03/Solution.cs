using System;

namespace Day03;

public static class Solution
{
    public static long GetTotalOutputJoltage(ICollection<string> batteryPacks, int maxUsableInPack)
    {
        var totalOutput = 0L;
        foreach (var batteryPack in batteryPacks)
        {
            long[] batteryArray = [.. batteryPack.ToArray().Select(o=>(long)Char.GetNumericValue(o))];
            for (var i = 0; i < maxUsableInPack; i++)
            {
                for (var j = 0; j < batteryPack.Length; j++)
                {
                    if(i == 0)
                    {
                        if(j == 0)
                        {
                            continue;
                        }
                        batteryArray[j] = Math.Max(batteryArray[j], batteryArray[j - 1]);
                        continue;
                    }
                    if(j == 0)
                    {
                        batteryArray[0] = batteryArray[0] * 10 + long.Parse(batteryPack.Substring(i, 1));
                        continue;
                    }
                    if(j + i >= batteryPack.Length)
                    {
                        break;
                    }
                    batteryArray[j] = Math.Max(batteryArray[j - 1], batteryArray[j] * 10 + long.Parse(batteryPack.Substring(j + i, 1)));
                }
            }
            totalOutput += batteryArray.Max();
        }
        return totalOutput;
    }
}
