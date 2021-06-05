using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    static List<int>[] graph;
    //{
    //    new List<int>() { 3, 6 },
    //    new List<int>() { 3, 4, 5, 6 },
    //    new List<int>() { 8 },
    //    new List<int>() { 0, 1, 5 },
    //    new List<int>() { 1, 6 },
    //    new List<int>() { 1, 3 },
    //    new List<int>() { 0, 1, 4 },
    //    new List<int>() { },
    //    new List<int>() { 2 }
    //};

    static bool[] visited;

    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    private static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }
        return graph;
    }

    private static void FindGraphConnectedComponents()
    {
        visited = new bool[graph.Length];

        for (int i = 0; i < graph.Length; i++)
        {
            if (!visited[i])
            {
                Console.Write("Connected component:");
                DFS(i);
                Console.WriteLine();
            }
        }
    }

    private static void DFS(int vertex)
    {
        if (!visited[vertex])
        {
            visited[vertex] = true;
            foreach (var item in graph[vertex])
            {
                DFS(item);
            }

            Console.Write(" " + vertex);
        }
    }
}
