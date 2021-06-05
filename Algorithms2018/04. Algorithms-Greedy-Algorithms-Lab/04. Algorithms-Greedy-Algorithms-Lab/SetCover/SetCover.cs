using System;
using System.Collections.Generic;
using System.Linq;

public class SetCover
{
    public static void Main(string[] args)
    {
        var universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
        var sets = new[]
        {
            new[] { 20 },
            new[] { 1, 5, 20, 30 },
            new[] { 3, 7, 20, 30, 40 },
            new[] { 9, 30 },
            new[] { 11, 20, 30, 40 },
            new[] { 3, 7, 40 }
        };

        /*var input = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        //input.RemoveAt(0);
        var universe = input.Skip(1).Select(int.Parse).ToList();

        var numberOfSets = int.Parse(Console.ReadLine());

        List<int[]> sets = new List<int[]>();*
        for (int i = 0; i < numberOfSets; i++)
        {
            var line = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            sets.Add(line);
        }
        */
        var selectedSets = ChooseSets(sets.ToList(), universe);
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");
        foreach (var set in selectedSets)
        {
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");
        }
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        var result = new List<int[]>();
        var universeSet = new HashSet<int>(universe);
        var setsSet = new HashSet<int[]>(sets);

        while (universe.Count > 0)
        {
            var currentSet = sets.OrderByDescending(s => s.Count(e => universe.Contains(e))).First();
            result.Add(currentSet);
            setsSet.Remove(currentSet);

            foreach (var item in currentSet)
            {
                universe.Remove(item);
            }
        }

        return result;
    }
}
