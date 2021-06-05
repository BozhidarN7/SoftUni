using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EdmondsKarp
{
    private static int[][] graph;
    private static int[] parent;

    public static int FindMaxFlow(int[][] targetGraph)
    {
        graph = targetGraph;
        parent = Enumerable.Repeat(-1, graph.Length).ToArray();

        int start = 0;
        int end = graph.Length - 1;

        int maxFlow = 0;

        while (BFS(start, end))
        {
            int pathFlow = int.MaxValue;
            int currentNode = end;

            while (currentNode != start)
            {
                int previousNode = parent[currentNode];
                var currentFlow = graph[previousNode][currentNode];

                if (currentFlow > 0 && currentFlow < pathFlow)
                {
                    pathFlow = currentFlow;
                }

                currentNode = previousNode;
            }
            maxFlow += pathFlow;

            currentNode = end;

            while (currentNode != start)
            {
                var previousNode = parent[currentNode];

                graph[previousNode][currentNode] -= pathFlow;
                graph[currentNode][previousNode] += pathFlow;

                currentNode = previousNode;
            }
        }

        return maxFlow;

    }

    private static bool BFS(int start, int end)
    {
        bool[] visited = new bool[graph.Length];
         
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();

            for (int child = 0; child < graph[node].Length; child++)
            {
                if (graph[node][child] > 0 && !visited[child])
                {
                    queue.Enqueue(child);
                    parent[child] = node;
                    visited[child] = true;
                }
            }
        }
        return visited[end];
    }
}
