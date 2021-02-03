using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class CustomLinkedList
    {
        private int count = 0;
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public int[] ToArray()
        {
            int index = 0;
            int[] array = new int[count];
            ForEachFromHead((node) =>
            {
                array[index++] = node.Value;
            });
            return array;
        }
        public void ForEachFromHead(Action<Node> action)
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Next;
            }
        }
        public void ForEachFromTail(Action<Node> action)
        {
            Node currentNode = Tail;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Previous;
            }
        }

        public void AddHead(Node node)
        {
            count++;
            if (Head is null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Next = Head;
            Head.Previous = node;
            Head = node;

        }
        public void AddLast(Node node)
        {
            count++;
            if (Tail is null)
            {
                Head = node;
                Tail = node;
                return;
            }
            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;

        }
        public Node RemoveHead()
        {
            if (Head == null)
            {
                return null;
            }
            count--;
            Node nodeToReturn = Head;
            if (Head.Next != null)
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }
            return nodeToReturn;

        }
        public Node RemoveTail()
        {
            if (Tail == null)
            {
                return null;
            }
            count--;
            Node nodeToReturn = Tail;
            if (Tail.Previous != null)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            else
            {
                Tail = null;
                Head = null;
            }
            return nodeToReturn;
        }
    }

    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
}
