using System;
using Day01;

try
{
    var inputDials = new List<string>();
    //string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"inputs/inputTest1.txt");
    //string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"inputs/inputTest2.txt");
    string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"inputs/inputPuzzle.txt");
    Console.WriteLine(path);
    using StreamReader reader = new(path);
    string line;
    while (true)
    {
        line = reader.ReadLine();
        if(line != null && line != "" && line != "\n")
        {
            inputDials.Add(line);
        }
        else
        {
            break;
        }
    }
    Console.WriteLine($"Total dials: {inputDials.Count}");
    Console.WriteLine($"Result: {Solution.GetNumberOfTimesDialOnZero(inputDials, 50)}");
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}