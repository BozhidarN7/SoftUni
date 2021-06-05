using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LinkedQueue<T>
{
    private class QueueNode<T>
    {
        public T Value { get; set; }
        public QueueNode<T> NextNode { get; set; }
        public QueueNode<T> PrevNode { get; set; }

        public QueueNode(T value)
        {
            this.Value = value;
        }
    }

    private QueueNode<T> head;
    private QueueNode<T> tail;

    public int Count { get; set; }

    public void Enqueue(T element)
    {
        if (this.Count == 0)
        {
            this.tail = this.head = new QueueNode<T>(element);
        }
        else
        {
            var newTail = new QueueNode<T>(element);
            newTail.PrevNode = this.tail;
            this.tail.NextNode = newTail;
            this.tail = newTail;
        }
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Queue empty");
        }
        var firstElement = this.head.Value;
        this.head = this.head.NextNode;
        if (this.head == null)
        {
            this.head.PrevNode = null;
        }
        else
        {
            this.tail = null;
        }
        this.Count--;
        return firstElement;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        int index = 0;
        var currentNode = this.head;
        while (currentNode != null)
        {
            array[index++] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }
        return array;
    }
}
