using System;
using Day05;

try
{
    var projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
    //string path = Path.Combine(projectPath, @"inputs/inputTest1.txt");
    string path = Path.Combine(projectPath, @"inputs/inputPuzzle.txt");

    var inputRanges = new List<string>();
    var inputIngredientIds = new List<string>();
    using StreamReader reader = new(path);
    string line;
    bool readingRanges = true;
    while (true)
    {
        line = reader.ReadLine();
        if(line == null)
        {
            break;
        }
        if(line == String.Empty)
        {
            readingRanges = false;
            continue;
        }
        if (readingRanges)
        {
            inputRanges.Add(line);
        }
        else
        {
            inputIngredientIds.Add(line);
        }
    }
    Console.WriteLine($"Total ranges count: {inputRanges.Count}");
    Console.WriteLine($"Total id count: {inputIngredientIds.Count}");
    Console.WriteLine($"Part1 result: {Solution.GetTotalFreshIngredientId(inputRanges, inputIngredientIds)}");
    Console.WriteLine($"Part2 result: {Solution.GetTotalFreshIngredientId(inputRanges)}");
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}
catch (Exception e)
{
    Console.WriteLine(e);
}
