using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static Dictionary<int, Tree<int>> nodeByValues = new Dictionary<int, Tree<int>>();
    //static List<int> longestPath = new List<int>();
    //static int parent = 0;

    // Tasks 5,6
    static Tree<int> deepestNode = null;
    static List<Tree<int>> path;
    static void Main(string[] args)
    {
        // Problme 1 Root Node
        /*ReadTree();
        Console.WriteLine("Root node: {0}",GetRootNode().Value);
        */

        // Problem 2.Print Tree
        /*ReadTree();
        PrintTree(0);
        */

        // Problem 3.	Leaf Nodes
        /*ReadTree();
        List<int> leaves = new List<int>();
        FindAllLeaves(leaves);
        int[] array = leaves.ToArray();
        Array.Sort(array);
        Console.Write("Leaf nodes: ");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        */

        // Problem 4.	Middle Nodes
        /*ReadTree();
        List<int> middleNodes = new List<int>();
        FindAllMiddleNodes(middleNodes);
        int[] array = middleNodes.ToArray();
        Array.Sort(array);
        Console.Write("Middle nodes: ");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        */

        // Problem 6.Longest Path / Problem 5.  * Deepest Node
        /*ReadTree();
        Tree<int> root = GetRootNode();
        //Console.WriteLine("Deepest node: " + FindDeepestNode(root).Value);
        path = new List<Tree<int>>();
        deepestNode = FindDeepestNode(root);
        RecoverPath(root);
        Console.Write("Longest path: ");
        for (int i = path.Count - 1; i >= 0; i--)
        {
            Console.Write(path[i].Value + " ");
        }
        Console.WriteLine();*/


        // Problem 7.	All Paths With a Given Sum
        /*ReadTree();
        Tree<int> root = GetRootNode();
        sum = int.Parse(Console.ReadLine());
        Console.WriteLine("Paths of sum {0}:", sum);
        foreach (var leaf in FindAllPathsWithSum(root))
        {
            PrintPath(leaf);
        }
        */


        // Problem 8.  * All Subtrees With a Given Sum
        ReadTree();
        Tree<int> root = GetRootNode();
        foreach (var node in FindSubTreeWithSum(root))
        {
            PrintPreOrder(node);
            Console.WriteLine();
        }
    }

    static Tree<int> GetTreeNodeByValue(int value)
    {
        if (!nodeByValues.ContainsKey(value))
        {
            nodeByValues[value] = new Tree<int>(value);
        }

        return nodeByValues[value];
    }

    static void AddEdge(int parent, int child)
    {
        Tree<int> parentNode = GetTreeNodeByValue(parent);
        Tree<int> childNode = GetTreeNodeByValue(child);

        parentNode.Children.Add(childNode);
        childNode.Parent = parentNode;
    }

    static void ReadTree()
    {
        int nodeCount = int.Parse(Console.ReadLine());
        for (int i = 1; i < nodeCount; i++)
        {
            string[] edge = Console.ReadLine().Split(' ');
            AddEdge(int.Parse(edge[0]), int.Parse(edge[1]));
        }
    }

    static Tree<int> GetRootNode()
    {
        return nodeByValues.Values.FirstOrDefault(x => x.Parent == null);
    }

    public static void PrintTree(int indent)
    {
        PrintTree(GetRootNode(), indent);
    }

    private static void PrintTree(Tree<int> node, int indent)
    {
        Console.WriteLine($"{new string(' ', indent)}{node.Value}");
        foreach (var child in node.Children)
        {
            PrintTree(child, indent + 2);
        }
    }

    public static void FindAllLeaves(List<int> leaves)
    {
        FindAllLeaves(GetRootNode(), leaves);
    }

    private static void FindAllLeaves(Tree<int> node, List<int> leaves)
    {
        foreach (var child in node.Children)
        {
            FindAllLeaves(child, leaves);
        }

        if (node.Children.Count == 0)
        {
            leaves.Add(node.Value);
        }
    }

    public static void FindAllMiddleNodes(List<int> middleNodes)
    {
        FindAllMiddleNodes(GetRootNode(), middleNodes);
    }

    private static void FindAllMiddleNodes(Tree<int> node, List<int> middleNodes)
    {
        foreach (var child in node.Children)
        {
            FindAllMiddleNodes(child, middleNodes);
        }

        if (node.Parent != null && node.Children.Count != 0)
        {
            middleNodes.Add(node.Value);
        }
    }

    // Tasks 5,6
    private static Tree<int> FindDeepestNode(Tree<int> root)
    {
        Queue<Tree<int>> queue = new Queue<Tree<int>>();
        queue.Enqueue(root);
        Tree<int> currentNode = null;
        while (queue.Count > 0)
        {
            currentNode = queue.Dequeue();
            for (int i = currentNode.Children.Count - 1; i >= 0; i--)
            {
                queue.Enqueue(currentNode.Children[i]);
            }
        }

        return currentNode;
    }

    private static void RecoverPath(Tree<int> node)
    {
        foreach (var child in node.Children)
        {
            RecoverPath(child);
        }

        if (node == deepestNode)
        {
            path.Add(node);
            deepestNode = node.Parent;
        }
    }

    // Problem 7.	All Paths With a Given Sum
    /*
    public static List<Tree<int>> FindAllPathsWithSum(Tree<int> root)
    {
        var leaves = new List<Tree<int>>();

        DFS(root, sum, 0, leaves);

        return leaves;
    }

    private static void DFS(Tree<int> currentNode, int target, int current, List<Tree<int>> leaves)
    {
        if (currentNode == null)
        {
            return;
        }

        current += currentNode.Value;

        if (current == target && currentNode.Children.Count == 0)
        {
            leaves.Add(currentNode);
        }

        foreach (var child in currentNode.Children)
        {
            DFS(child, target, current, leaves);
        }
    }
    private static void PrintPath(Tree<int> leaf)
    {
        var stack = new Stack<int>();
        var current = leaf;
        while (current != null)
        {
            stack.Push(current.Value);
            current = current.Parent;
        }

        Console.WriteLine(string.Join(" ", stack.ToArray()));
    }
    */
    // Problem 8.	* All Subtrees With a Given Sum
    private static List<Tree<int>> FindSubTreeWithSum(Tree<int> root)
    {
        int target = int.Parse(Console.ReadLine());
        Console.WriteLine("Subtrees of sum {0}:", target);

        List<Tree<int>> roots = new List<Tree<int>>();

        int sum = DFS(root, target, 0, roots);

        return roots;
    }

    private static int DFS(Tree<int> node, int target, int current, List<Tree<int>> roots)
    {
        if (node == null)
        {
            return 0;
        }

        current = node.Value;

        foreach (var child in node.Children)
        {
            current += DFS(child, target, current, roots);
        }

        if (current == target)
        {
            roots.Add(node);
        }

        return current;
    }

    private static void PrintPreOrder(Tree<int> node)
    {
        Console.Write(node.Value + " ");
        foreach (var child in node.Children)
        {
            PrintPreOrder(child);
        }
    }
}
