using System;
using System.Collections.Generic;

public static class DijkstraWithPriorityQueue
{
    public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
    {
        int n = 0;
        Node[] distances = new Node[graph.Count];
        foreach (var item in graph)
        {
            distances[n++] = item.Key;
        }

        int[] previous = new int[graph.Count];
        for (int i = 0; i < distances.Length; i++)
        {
            previous[i] = i;
        }

        SortedSet<Node> queue = new SortedSet<Node>();
        distances[sourceNode.Id].DistanceFromStart = 0;
        queue.Add(distances[sourceNode.Id]);

        while (queue.Count > 0)
        {
            var currentNode = queue.Min;
            queue.Remove(currentNode);


            foreach (var item in graph[currentNode])
            {
                if (distances[item.Key.Id].DistanceFromStart > distances[currentNode.Id].DistanceFromStart + item.Value)
                {
                    queue.Remove(distances[item.Key.Id]);
                    distances[item.Key.Id].DistanceFromStart = distances[currentNode.Id].DistanceFromStart + item.Value;
                    queue.Add(distances[item.Key.Id]);
                    previous[item.Key.Id] = currentNode.Id;
                }
            }
        }

        if (previous[destinationNode.Id] == destinationNode.Id)
        {
            return null;
        }

        List<int> path = new List<int>();

        int current = destinationNode.Id;
        while (current != sourceNode.Id)
        {
            path.Add(current);
            current = previous[current];
        }
        path.Add(sourceNode.Id);

        path.Reverse();
        return path;
    }
}

