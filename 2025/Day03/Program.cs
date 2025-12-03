using System;
using Day03;

try
{
    //string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"inputs/inputTest1.txt");
    string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"inputs/inputPuzzle.txt");
    var inputBatteryPacks = new List<string>();
    using StreamReader reader = new(path);
    string line;
    while (true)
    {
        line = reader.ReadLine();
        if(line != null && line != "" && line != "\n")
        {
            inputBatteryPacks.Add(line);
        }
        else
        {
            break;
        }
    }
    Console.WriteLine($"Total packs count: {inputBatteryPacks.Count}");
    Console.WriteLine($"Total output joltage: {Solution.GetTotalOutputVoltage(inputBatteryPacks, 2)}");
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