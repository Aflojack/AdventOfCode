using Day02;

try
{
    //string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"inputs/inputTest1.txt");
    string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"inputs/inputPuzzle.txt");
    using StreamReader reader = new(path);
    string line;
    line = reader.ReadToEnd();
    string[] inputIdRanges = line.Split(',');
    Console.WriteLine($"Total ID ranges: {inputIdRanges.Length}");
    Console.WriteLine($"Invalid id sum: {Solution.GetInvalidIdSum(inputIdRanges)}");
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
