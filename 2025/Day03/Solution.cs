using System;

namespace Day03;

public static class Solution
{
    public static int GetTotalOutputVoltage(ICollection<string> batteryPacks, int maxUsableInPack)
    {
        var totalJoltage = 0;
        foreach (var batteryPack in batteryPacks)
        {
            var maximumJoltage = 0;
            for (var i = 0; i < batteryPack.Length; i++)
            {
                var position = i + 1;
                var possibleJoltage = batteryPack.Substring(i, 1);
                while (possibleJoltage.Length != maxUsableInPack)
                {
                    var largestJoltage = 0;
                    var largestPosition = 0;
                    for (var j = position; j < batteryPack.Length; j++)
                    {
                        var currentJoltage = int.Parse(batteryPack.Substring(j, 1));
                        if (largestJoltage < currentJoltage)
                        {
                            largestJoltage = currentJoltage;
                            largestPosition = j;
                        }
                    }
                    if (largestJoltage == 0)
                    {
                        break;
                    }
                    possibleJoltage += largestJoltage;
                    position = largestPosition + 1;
                }
                var possibleJoltageValue = int.Parse(possibleJoltage);
                if (maximumJoltage < possibleJoltageValue)
                {
                    maximumJoltage = possibleJoltageValue;
                }
            }
            totalJoltage += maximumJoltage;
        }
        return totalJoltage;
    }
}
