using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node root;

   public BinarySearchTree()
    {
        this.root = null;
    }

    private BinarySearchTree(Node node)
    {
        this.Copy(node);
    }

    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);
    }

    public void Insert(T value)
    {
        if (this.root == null)
        {
            this.root = new Node(value);
            return;
        }
        Node parent = null;
        Node currentNode = this.root;
        while (currentNode != null)
        {
            int compare = currentNode.Value.CompareTo(value);
            if (compare > 0)
            {
                parent = currentNode;
                currentNode = currentNode.Left;
            }
            else if (compare < 0)
            {
                parent = currentNode;
                currentNode = currentNode.Right;
            }
            else if (compare == 0)
            {
                return;
            }
        }
        Node newNode = new Node(value);
        if (parent.Value.CompareTo(value) > 0)
        {
            parent.Left = newNode;
        }
        else
        {
            parent.Right = newNode;
        }
    }

    private Node Insert(Node node, T value)
    {
        if (node == null)
        {
            return new Node(value);
        }
        int compare = node.Value.CompareTo(value);
        if (compare > 0)
        {
            node.Left = this.Insert(node.Left,value);
        }
        else
        {
            node.Right = this.Insert(node.Right, value);
        }
        return node;
    }

    public bool Contains(T value)
    {
        Node currentNode = this.root;

        while (currentNode != null)
        {
            int compare = currentNode.Value.CompareTo(value);
            if (compare > 0)
            {
                currentNode = currentNode.Left;
            }
            else if (compare < 0)
            {
                currentNode = currentNode.Right;
            }
            else
            {
                return  true;
            }
        }

        return false;

    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }
        if (this.root.Left == null && root.Right == null)
        {
            this.root = null;
            return;
        }
        Node parent = null;
        Node currentNode = this.root;
        while (currentNode.Left != null)
        {
            parent = currentNode;
            currentNode = currentNode.Left;
        }

        if (currentNode.Right != null)
        {
            parent.Left = currentNode.Right;
        }
        else
        {
            parent.Left = null;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node currentNode = root;
        while (currentNode != null)
        {
            int compare = currentNode.Value.CompareTo(item);
            if (compare > 0)
            {
                currentNode = currentNode.Left;
            }
            else if (compare < 0)
            {
                currentNode = currentNode.Right;
            }
            else
            {
                return new BinarySearchTree<T>(currentNode);
            }
        }

        return null;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        List<T> result = new List<T>();
        this.Range(this.root, result, startRange, endRange);
        return result;
    }

    private void Range(Node node,List<T> result, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int compareLow = node.Value.CompareTo(startRange);
        int compareHigh = node.Value.CompareTo(endRange);
        if (compareLow > 0)
        {
            this.Range(node.Left, result, startRange, endRange);
        }
        if (compareLow >= 0 && compareHigh <= 0)
        {
            result.Add(node.Value);
        }
        if (compareHigh < 0)
        {
            this.Range(node.Right, result, startRange, endRange);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private class Node
    {
        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(T value)
        {
            this.Value = value;
            this.Right = null;
            this.Left = null;
        }
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        
    }
}
