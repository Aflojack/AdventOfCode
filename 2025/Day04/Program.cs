using System;
using Day04;

try
{
    //string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"inputs/inputTest1.txt");
    string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"inputs/inputPuzzle.txt");
    var input = new List<string>();
    using StreamReader reader = new(path);
    string line;
    while (true)
    {
        line = reader.ReadLine();
        if(line != null && line != "" && line != "\n")
        {
            input.Add(line);
        }
        else
        {
            break;
        }
    }
    Console.WriteLine($"Total line count: {input.Count}");
    Console.WriteLine($"Total movable paper roll: {Solution.GetTotalMovablePaper(input, 1, 4)}");
    Console.WriteLine($"Total movable paper roll: {Solution.GetTotalMovablePaperIterative(input, 1, 4)}");
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