using System.Text.RegularExpressions;

namespace AdventOfCode2024.Solutions;

public sealed partial class Day01 : IDay
{
    public (int solutionA, int solutionB) Solve(string[] input)
    {
        var lists = input
            .Select(LineToIntTuple)
            .Aggregate<(int left, int right), (List<int> left, List<int> right)>(([], []), (result, valueTuple) =>
            {
                result.left.Add(valueTuple.left);
                result.right.Add(valueTuple.right);
                return result;
            });

        lists.left.Sort();
        lists.right.Sort();

        var sum = Enumerable.Range(0, input.Length)
            .Select(i => Math.Abs(lists.left[i] - lists.right[i]))
            .Sum();
        
        var similarity = lists.left.Select(i => (i, lists.right.Where(j => j == i)))
            .Select(tuple => tuple.i * tuple.Item2.Count())
            .Sum();

        return (sum, similarity);
    }
    
    private static (int left, int right) LineToIntTuple(string line)
    {
        var matches = LineRegex().Match(line);
        return (int.Parse(matches.Groups[1].Value), int.Parse(matches.Groups[2].Value));
    }

    [GeneratedRegex(@"(\d+)\s{3}(\d+)")]
    private static partial Regex LineRegex();
}