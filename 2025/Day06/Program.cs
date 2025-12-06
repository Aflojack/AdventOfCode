using System;
using Day06;

try
{
    var projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
    //string path = Path.Combine(projectPath, @"inputs/inputTest1.txt");
    string path = Path.Combine(projectPath, @"inputs/inputPuzzle.txt");

    using StreamReader reader = new(path);
    var input = new List<string>();
    string line;
    while (true)
    {
        line = reader.ReadLine();
        if(line == null || line == String.Empty)
        {
            break;
        }
        input.Add(line);
    }
    Console.WriteLine($"Total input line: {input.Count}");
    Console.WriteLine($"Part1 result: {Solution.GetGrandTotalPart1(input)}");
    Console.WriteLine($"Part2 result: {Solution.GetGrandTotalPart2(input)}");
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
