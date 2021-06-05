using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ArrayStack<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 16;

    private T[] array;

    public int Count { get; private set; }
    public int Capacity { get; set; }

    public ArrayStack(int capacity = DefaultCapacity)
    {
        this.Capacity = capacity;
        this.Count = 0;
        this.array = new T[this.Capacity];
    }

    public void Push(T element)
    {
        if (this.Count >= this.Capacity)
        {
            this.Grow();
        }
        this.array[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        //int index = this.Count - 1;
        T element = this.array[--this.Count];
        this.array[this.Count] = default(T);
        return element;

    }

    public T[] ToArray()
    {
        /*T[] newArray = new T[this.Count];
        Array.Copy(this.array, newArray, this.Count);
        */

        LinkedList<T> list = new LinkedList<T>();
        for (int i = 0; i < this.Count; i++)
        {
            list.AddFirst(array[i]);
        }
        return list.ToArray();
    }

    private void Grow()
    {
        T[] newArray = new T[this.Capacity * 2];
        this.Capacity *= 2;
        Array.Copy(this.array, newArray, this.Count);
        array = newArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in array)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

