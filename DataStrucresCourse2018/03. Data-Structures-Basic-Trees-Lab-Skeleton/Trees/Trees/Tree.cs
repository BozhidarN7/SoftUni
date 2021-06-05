using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; set; }
    public List<Tree<T>> Children {get;set;}

    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>(children);
    }

    public void Print(int indent = 0)
    {
        this.Print(this, indent);
    }

    private void Print(Tree<T> node, int indent)
    {
        Console.WriteLine($"{new string(' ', 2 * indent)}{node.Value}");
        foreach (var child in node.Children)
        {
            child.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);
        foreach (var child in this.Children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        List<T> result = new List<T>();
        this.DFS(this, result);
        return result;
    }

    private void DFS(Tree<T> node, List<T> result)
    {
        foreach (var child in node.Children)
        {
            this.DFS(child, result);
        }

        result.Add(node.Value);
    }
    
    public IEnumerable<T> OrderBFS()
    {
        Queue<Tree<T>> queue = new Queue<Tree<T>>();
        List<T> result = new List<T>();
        queue.Enqueue(this);
        while (queue.Count > 0)
        {
            Tree<T> currentNode = queue.Dequeue();
            result.Add(currentNode.Value);

            foreach (var child in currentNode.Children)
            {
                queue.Enqueue(child);
            }
        }
        return result;
    }
}
