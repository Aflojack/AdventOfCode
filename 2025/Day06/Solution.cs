using System;

namespace Day06;

public static class Solution
{
    public const string Addition = "+";
    public const string Multiplication = "*";

    public static long GetGrandTotalPart1(List<string> problems)
    {
        if (problems == null || problems.Count < 2)
        {
            return 0L;
        }
        var total = 0L;
        var prevIndex = 0;
        for (var i = 0; i <= problems[0].Length; i++)
        {
            if (i == problems[0].Length || problems.All(o=>o[i] == ' '))
            {
                var result = 0L;
                var operation = problems.Last()[prevIndex..i].Trim();
                for (var j = 0; j < problems.Count - 1; j++)
                {
                    var currentNumber = long.Parse(problems[j][prevIndex..i]);
                    switch (operation)
                    {
                        case Addition:
                            result += currentNumber;
                            break;
                        case Multiplication:
                            result = result == 0L ? currentNumber : result * currentNumber; 
                            break;
                        default: 
                            break;
                    }
                }
                prevIndex = i + 1;
                total += result;
            }
        }
        return total;
    }

    public static long GetGrandTotalPart2(List<string> problems)
    {
        if (problems == null || problems.Count < 2)
        {
            return 0L;
        }
        var total = 0L;
        var prevIndex = 0;
        for (var i = 0; i <= problems[0].Length; i++)
        {
            if (i == problems[0].Length || problems.All(o=>o[i] == ' '))
            {
                string[] columnProblems = new string[i - prevIndex];
                for (var j = 0; j < problems.Count - 1; j++)
                {
                    var currentString = problems[j][prevIndex..i];
                    for (var k = 0; k < currentString.Length; k++)
                    {
                        columnProblems[k] += currentString[k];
                    }
                    
                }

                var result = 0L;
                var operation = problems.Last()[prevIndex..i].Trim();
                foreach (var currentColumn in columnProblems)
                {
                    var currentNumber = long.Parse(currentColumn);
                    switch (operation)
                    {
                        case Addition:
                            result += currentNumber;
                            break;
                        case Multiplication:
                            result = result == 0L ? currentNumber : result * currentNumber; 
                            break;
                        default: 
                            break;
                    }
                }
                prevIndex = i + 1;
                total += result;
            }
        }
        return total;
    }
}
