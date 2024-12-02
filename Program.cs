using System.Reflection;
using AdventOfCode2024;
using AdventOfCode2024.Solutions;

if (args.Length < 1)
{
    Console.Error.WriteLine("error: no day specified");
    return 1;
}

var day = int.Parse(args[0]);
var days = new IDay[]
{
    new Day01()
};

if (day < 1 || day > days.Length) 
{
    Console.Error.WriteLine("error: invalid day specified");
    return 1;
}

var input = ReadInputForDay(day);
var (a, b) = days[day - 1].Solve(input);

Console.WriteLine($"Solution A: {a}, Solution B: {b}");
return 0;

string[] ReadInputForDay(int i)
{
    using var inputStream = Assembly.GetExecutingAssembly()
        .GetManifestResourceStream($"AdventOfCode2024.Inputs.{i}.txt");
    using var reader = new StreamReader(inputStream);
    return reader.ReadToEnd().Split("\n");
}