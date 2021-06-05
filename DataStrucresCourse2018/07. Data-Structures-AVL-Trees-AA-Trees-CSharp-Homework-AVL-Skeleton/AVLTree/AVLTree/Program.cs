using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        AVL<int> avl = new AVL<int>();
        for (int i = 1; i < 10; i++)
        {
            avl.Insert(i);
        }

        avl.Delete(4);
        avl.Delete(2);
        avl.Delete(1);
        avl.EachInOrder(x => Console.Write(x + " "));
        var root = avl.Root;
        //Console.WriteLine(root.Value);
    }
}
