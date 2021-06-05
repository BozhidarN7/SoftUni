using System;
using System.Collections.Generic;

public class TopologicalSorterApp
{
    static void Main()
    {
        //var graph = new Dictionary<string, List<string>>() {
        //    { "IDEs", new List<string>() { "variables", "loops" } },
        //    { "variables", new List<string>() { "conditionals", "loops", "bits" } },
        //    { "loops", new List<string>() { "bits" } },
        //    { "bits", new List<string>() { } },
        //    { "conditionals", new List<string>() { "loops" } }
        //};

        var graph = new Dictionary<string, List<string>>()
        {
            { "A", new List<string>() { "B" } },
            { "B", new List<string>() { "C" } },
            { "C", new List<string>() { "D", "E" } },
            { "D", new List<string>() { "E" } },
            { "E", new List<string>() { "F", "C" } },
            { "F", new List<string>() { } },
            { "Z", new List<string>() { "A" } }
        };

        var topSorter = new TopologicalSorter(graph);
        var sortedNodes = topSorter.TopSort();

        Console.WriteLine("Topological sorting: {0}",
            string.Join(", ", sortedNodes));

        // Topological sorting: A, B, E, D, C, F
    }
}
