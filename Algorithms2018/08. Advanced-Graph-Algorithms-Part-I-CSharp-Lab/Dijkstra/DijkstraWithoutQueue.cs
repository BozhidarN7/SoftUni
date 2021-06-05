using System;
using System.Collections.Generic;

public static class DijkstraWithoutQueue
{
    public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
    {
        int[] distances = new int[graph.GetLength(0)];
        int[] previous = new int[graph.GetLength(0)];
        bool[] used = new bool[graph.GetLength(0)];

        for (int i = 0; i < distances.Length; i++)
        {
            distances[i] = int.MaxValue;
            previous[i] = i;
        }
        distances[sourceNode] = 0;

        while (true)
        {
            int minIndex = int.MaxValue;

            for (int node = 0; node < graph.GetLength(0); node++)
            {
                if (!used[node])
                {
                    if (minIndex == int.MaxValue || distances[minIndex] > distances[node])
                    {
                        minIndex = node;
                    }
                }
            }

            if (minIndex == int.MaxValue)
            {
                break;
            }

            used[minIndex] = true;

            bool update = false;

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[minIndex, i] == 0)
                {
                    continue;
                }

                if (distances[i] > distances[minIndex] + graph[minIndex, i])
                {
                    distances[i] = distances[minIndex] + graph[minIndex, i];
                    previous[i] = minIndex;
                    update = true;
                }
            }

            if (!update)
            {
                break;
            }

        }

        if (previous[destinationNode] == destinationNode)
        {
            return null;
        }

        List<int> path = new List<int>();

        int currentNode = destinationNode;
        while (currentNode != sourceNode)
        {
            path.Add(currentNode);
            currentNode = previous[currentNode];
        }
        path.Add(sourceNode);

        path.Reverse();
        return path;
    }
}

