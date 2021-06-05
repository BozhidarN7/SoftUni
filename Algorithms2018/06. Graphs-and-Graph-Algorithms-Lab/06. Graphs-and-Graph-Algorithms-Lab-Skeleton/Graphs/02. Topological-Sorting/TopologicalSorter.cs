using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    private Dictionary<string, int> predecessorCount;

    //private HashSet<string> visited;
    //private HashSet<string> cycleNodes;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
        //this.visited = new HashSet<string>();
        //this.cycleNodes = new HashSet<string>();
    }

    public ICollection<string> TopSort()
    {
        /*LinkedList<string> sorted = new LinkedList<string>();

        foreach (var node in graph.Keys)
        {
            DFS(node, sorted);
        }

        return sorted;*/

        List<string> sorted = new List<string>();
        GetPredecessorCount(graph);
        while (true)
        {
            string nodeToRemove = predecessorCount.Keys.Where(x => predecessorCount[x] == 0).FirstOrDefault();

            if (nodeToRemove == null)
            {
                break;
            }

            var children = graph[nodeToRemove];
            foreach (var child in children)
            {
                predecessorCount[child]--;
            }
            predecessorCount.Remove(nodeToRemove);

            graph.Remove(nodeToRemove);
            sorted.Add(nodeToRemove);
        }

        if (graph.Count > 0)
        {
            throw new InvalidOperationException();
        }

        return sorted;

    }

    /*private void DFS(string node, LinkedList<string> result)
    {
        if (cycleNodes.Contains(node))
        {
            throw new InvalidOperationException();
        }

        if (!visited.Contains(node))
        {
            visited.Add(node);
            cycleNodes.Add(node);

            foreach (var item in graph[node])
            {
                DFS(item, result);
            }

            cycleNodes.Remove(node);
            result.AddFirst(node);
        }
    }
    */
    private void GetPredecessorCount(Dictionary<string, List<string>> graph)
    {
        predecessorCount = new Dictionary<string, int>();

        foreach (var node in graph)
        {
            if (!predecessorCount.ContainsKey(node.Key))
            {
                predecessorCount[node.Key] = 0;
            }

            foreach (var child in node.Value)
            {
                if (!predecessorCount.ContainsKey(child))
                {
                    predecessorCount[child] = 0;
                }

                predecessorCount[child]++;
            }
        }
    }
}
