using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private int count = 0;

        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public int Count { get; set; }
        public T[] ToArray()
        {
            int index = 0;
            T[] array = new T[Count];
            ForEachFromHead((node) =>
            {
                array[index++] = node.Value;
            });
            return array;
        }

        public void ForEach(Action<T> action)
        {
            Node<T> currentNode = this.Head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
        public void ForEachFromHead(Action<Node<T>> action)
        {
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Next;
            }
        }
        public void ForEachFromTail(Action<Node<T>> action)
        {
            Node<T> currentNode = Tail;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Previous;
            }
        }
        public void AddFirst(T value)
        {
            if (Count == 0)
            {
                Head = Tail = new Node<T>(value);
            }
            else
            {
                Node<T> node = new Node<T>(value);
                node.Next = Head;
                Head.Previous = node;
                Head = node;
            }
            Count++;
        }
        public void AddLast(T value)
        {
            if (Count == 0)
            {
                Head = Tail = new Node<T>(value);
            }
            else
            {
                Node<T> node = new Node<T>(value);
                node.Previous = Tail;
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }
        public T RemoveFirst()
        {
            if (Head is null)
            {
                throw new InvalidOperationException("The list is empty");
            }
            T value = Head.Value;
            Head = Head.Next;
            if (Head != null)
            {
                Head.Previous = null;
            }
            else
            {
                Tail = null;
            }
            Count--;
            return value;
        }
        public T RemoveLast()
        {
            if (Tail == null)
            {
                throw new InvalidOperationException("The list is empty");
            }
            T value = Tail.Value;
            Tail = Tail.Previous;
            if (Tail != null)
            {
                Tail.Next = null;
            }
            else
            {
                Head = null;
            }
            Count--;
            return value;
        }
    }

    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
    }
}
