using System;
using System.Collections.Generic;
using System.Linq;

public class StronglyConnectedComponents
{
    private static List<List<int>> stronglyConnectedComponents;

    private static List<int>[] graph;
    private static List<int>[] reverseGraph;
    private static Stack<int> stack = new Stack<int>();

    private static bool[] visited;

    public static List<List<int>> FindStronglyConnectedComponents(List<int>[] targetGraph)
    {
        graph = targetGraph;
        visited = new bool[graph.Length];

        BuildReverseNode();

        for (int node = 0; node < graph.Length; node++)
        {
            if (!visited[node])
            {
                DFS(node);
            }
        }

        stronglyConnectedComponents = new List<List<int>>();
        visited = new bool[graph.Length];
        while (stack.Count > 0)
        {
            int node = stack.Pop();

            if (!visited[node])
            {
                stronglyConnectedComponents.Add(new List<int>());
                ReverseDFS(node);
            }
        }

        return stronglyConnectedComponents;
    }

    private static void BuildReverseNode()
    {
        reverseGraph = new List<int>[graph.Length];

        for (int i = 0; i < reverseGraph.Length; i++)
        {
            reverseGraph[i] = new List<int>();
        }

        for (int i = 0; i < graph.Length; i++)
        {
            foreach (var child in graph[i])
            {
                reverseGraph[child].Add(i);
            }
        }

    }

    private static void ReverseDFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            stronglyConnectedComponents.Last().Add(node);

            foreach (var child in reverseGraph[node])
            {
                ReverseDFS(child);
            }
        }
    }

    private static void DFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            stack.Push(node);
        }
    }
}
