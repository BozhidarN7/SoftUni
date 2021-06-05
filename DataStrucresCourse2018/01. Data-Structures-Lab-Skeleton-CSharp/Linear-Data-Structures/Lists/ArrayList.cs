using System;
using System.Collections;
using System.Collections.Generic;

public class ArrayList<T> : IEnumerable<T>
{
    public int Count { get; set; }
    public int Capacity { get; set; }

    private T[] array;
    public ArrayList(int capacity = 2)
    {
        this.array = new T[capacity];
        this.Capacity = capacity;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this.array[index];
        }

        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.array[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.Count >= this.Capacity)
        {
            this.Grow();

        }
        this.array[this.Count] = item;
        this.Count++;
    }

    public T RemoveAt(int index)
    {
        T item = this[index];
        this[index] = default(T);
        ShifLeft(index);
        if (this.Count - 1 < this.Capacity / 3)
        {
            Shrink();
        }
        this.Count--;
        return item;
    }

    private void Grow()
    {
        T[] newArray = new T[this.Capacity * 2];
        this.Capacity *= 2;
        Array.Copy(this.array, newArray, this.Count);
        this.array = newArray;
    }

    private void Shrink()
    {
        T[] newArray = new T[this.Capacity / 2];
        this.Capacity /= 2;
        Array.Copy(this.array, newArray, this.Count);
        this.array = newArray;
    }

    private void ShifLeft(int index)
    {
        for (int i = index; i < this.Count - 1; i++)
        {
            this.array[i] = this.array[i + 1];
        }
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
