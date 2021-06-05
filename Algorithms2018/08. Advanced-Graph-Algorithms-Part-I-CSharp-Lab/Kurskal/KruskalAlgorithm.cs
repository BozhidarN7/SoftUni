using System;
using System.Collections.Generic;
using System.Linq;

public class KruskalAlgorithm
{
    static int[] parents;

    public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
    {
        var nodes = edges.Select(s => s.StartNode).Union(edges.Select(e => e.EndNode)).Distinct().ToList();

        parents = new int[nodes.Max() + 1];

        foreach (var node in nodes)
        {
            parents[node] = node;
        }

        var sortedEdges = edges.OrderBy(e => e.Weight).ToList();
        var result = new List<Edge>();

        while(sortedEdges.Count !=0)
        {
            var edge = sortedEdges.First();
            sortedEdges.Remove(edge);

            var firstNode = edge.StartNode;
            var secondNode = edge.EndNode;

            var firstRoot = FindRoot(firstNode);
            var secondRoot = FindRoot(secondNode);

            if (firstRoot != secondRoot)
            {
                result.Add(edge);
                parents[firstRoot] = secondRoot;
            }
        }

        return result;
    }

    public static int FindRoot(int node)
    {
        while (parents[node] != node)
        {
            node = parents[node];
        }

        return node; 
    }
}

