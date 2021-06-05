using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LinkedStack<T>
{
    private class Node<T>
    {
        public T Value { get; set; }
        public Node<T> NextNode { get; set; }
        public Node(T value)
        {
            this.Value = value;
        }
        public Node(T value, Node<T> nextNode) : this(value)
        {
            this.NextNode = nextNode;
        }
    }
    private Node<T> firstNode;
    public int Count { get; set; }

    public void Push(T element)
    {
        if (this.firstNode == null)
        {
            this.firstNode = new Node<T>(element);
        }
        else
        {
            firstNode = new Node<T>(element, this.firstNode);
        }
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Empty stack");
        }
        T element = this.firstNode.Value;
        this.firstNode = this.firstNode.NextNode;
        this.Count--;
        return element;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        int index = 0;
        while (this.firstNode != null)
        {
            array[index++] = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
        }
        return array;
    }
}
