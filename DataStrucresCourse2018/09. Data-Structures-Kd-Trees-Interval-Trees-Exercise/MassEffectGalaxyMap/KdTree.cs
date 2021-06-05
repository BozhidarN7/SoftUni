using System;
using System.Collections.Generic;

public class KdTree : IBoundable
{
    private int K = 2;
    private Node root;

    public class Node : IBoundable
    {
        public Node(Point2D point, Rectangle bounds)
        {
            this.Point = point;
            this.Bounds = bounds;
        }

        public Node(Point2D point, int x1, int y1, int width, int height)
        {
            this.Point = point;
            this.Bounds = new Rectangle(x1, y1, width, height);
        }

        public Point2D Point { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Rectangle Bounds { get; set; }
    }

    public KdTree(int width, int height)
    {
        this.Bounds = new Rectangle(0, 0, width, height);
    }

    public KdTree()
    {

    }

    public Node Root
    {
        get
        {
            return this.root;
        }
    }

    public Rectangle Bounds { get; set; }

    public bool Contains(Point2D point)
    {
        var node = this.Search(this.root, point, 0);
        return node != null;
    }

    private object Search(Node node, Point2D point, int depth)
    {
        if (node == null)
        {
            return null;
        }
        int cmp = Compare(point, node.Point, depth);
        if (cmp < 0)
        {
            return Search(node.Left, point, depth + 1);
        }
        else if (cmp > 0)
        {
            return Search(node.Right, point, depth + 1);
        }
        return node;
    }

    private int Compare(Point2D a, Point2D b, int depth)

    {
        int cmp = 0;
        if (depth % 2 == 0)
        {
            cmp = a.X.CompareTo(b.X);
            if (cmp == 0)
            {
                cmp = a.Y.CompareTo(b.Y);
            }
            return cmp;
        }
        else
        {
            cmp = a.Y.CompareTo(b.Y);
            if (cmp == 0)
            {
                cmp = a.X.CompareTo(b.X);
            }
        }
        return cmp;
    }

    public void Insert(Point2D point)
    {
        this.root = this.Insert(root, point, 0);
    }

    private Node Insert(Node node, Point2D point, int depth)
    {
        if (node == null)
        {
            return new Node(point, this.Bounds);
        }
        int compare = depth % K;

        if (compare == 0)
        {
            int compareX = node.Point.X.CompareTo(point.X);
            if (compareX > 0)
            {
                node.Left = this.Insert(node.Left, point, depth + 1);
            }
            else if (compareX <= 0)
            {
                node.Right = this.Insert(node.Right, point, depth + 1);
            }
        }
        else
        {
            int compareY = node.Point.Y.CompareTo(point.Y);

            if (compareY > 0)
            {
                node.Left = this.Insert(node.Left, point, depth + 1);
            }
            else if (compareY <= 0)
            {
                node.Right = this.Insert(node.Right, point, depth + 1);
            }
        }
        return node;
    }

    public IEnumerable<Point2D> RangeSearch(Rectangle bounds)
    {
        var results = new List<Point2D>();
        this.RangeSearch(this.root, bounds, results);
        return results;
    }

    private void RangeSearch(Node node, Rectangle bounds, List<Point2D> results)
    {
        if (node == null)
        {
            return;
        }

        if (node.Point.IsInside(bounds))
        {
            results.Add(node.Point);
        }

        var goLeft = node.Left != null && node.Left.Bounds.Intersects(bounds);
        var goRight = node.Right != null && node.Right.Bounds.Intersects(bounds);

        if (goLeft)
        {
            RangeSearch(node.Left, bounds, results);
        }

        if (goRight)
        {
            RangeSearch(node.Right, bounds, results);
        }
    }

    public void BuildFromList(List<Point2D> points)
    {
        this.root = this.Build(points);
    }

    private Node Build(List<Point2D> results, int depth = 0)
    {
        if (results.Count == 0)
        {
            return null;
        }

        int axis = depth % 2;

        results.Sort((x, y) =>
         {
             if (axis == 0)
             {
                 return x.X.CompareTo(y.X);
             }
             return x.Y.CompareTo(y.Y);
         });

        int median = results.Count / 2;
        List<Point2D> left = new List<Point2D>();
        List<Point2D> right = new List<Point2D>();

        for (int i = 0; i < median; i++)
        {
            left.Add(results[i]);
        }

        for (int i = median + 1; i < results.Count; i++)
        {
            right.Add(results[i]);
        }

        Node newNode = new Node(results[median],this.Bounds);
        newNode.Left = this.Build(left, depth + 1);
        newNode.Right = this.Build(right, depth + 1);

        return newNode;
    }

    public void EachInOrder(Action<Point2D> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<Point2D> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Point);
        this.EachInOrder(node.Right, action);
    }
}
