using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private BigList<T> elements;
    private OrderedBag<T> sortedElements;
    private OrderedBag<T> reversedElements;

    public FirstLastList()
    {
        this.elements = new BigList<T>();
        this.sortedElements = new OrderedBag<T>();
        this.reversedElements = new OrderedBag<T>((x, y) => -x.CompareTo(y));
    }

    public int Count
    {
        get
        {
            return this.elements.Count;
        }
    }

    public void Add(T element)
    {
        this.elements.Add(element);
        this.sortedElements.Add(element);
        this.reversedElements.Add(element);
    }

    /*public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this.sortedElements[index];
        }
        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.sortedElements[index] = value;
        }
    }*/


    public void Clear()
    {
        this.elements = new BigList<T>();
        this.sortedElements = new OrderedBag<T>();
        this.reversedElements = new OrderedBag<T>((x, y) => -x.CompareTo(y));
    }

    public IEnumerable<T> First(int count)
    {
        if (0 > count || count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        List<T> result = elements.Take(count).ToList();

        return result;
    }

    public IEnumerable<T> Last(int count)
    {
        if (count < 0 || count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

       // List<T> result = this.elements.Range(this.Count - count, count).ToList();
        for (int i = 0; i < count; i++)
        {
            yield return this.elements[this.Count - 1 - i];
        }
        //result.Reverse();
        //return result;
    }

    public IEnumerable<T> Max(int count)
    {
        if (count < 0 || count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        List<T> result = new List<T>();

        for (int i = 0; i < count; i++)
        {
            result.Add(this.reversedElements[i]);
        }

        return result;
    }

    public IEnumerable<T> Min(int count)
    {
        if (count < 0 || count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        List<T> result = new List<T>();

        for (int i = 0; i < count; i++)
        {
            result.Add(sortedElements[i]);
        }

        return result;
    }

    public int RemoveAll(T element)
    {
        int firstOccurance = sortedElements.IndexOf(element);
        int secondoccurance = sortedElements.LastIndexOf(element);

        if (sortedElements.IndexOf(element) < 0)
        {
            return 0;
        }
        else
        {
            //Predicate<T> predicate = x => x.CompareTo(element) == 0;       
            this.elements.RemoveAll(x => x.CompareTo(element) == 0);
            sortedElements.RemoveAllCopies(element);
            reversedElements.RemoveAllCopies(element);

            return secondoccurance - firstOccurance + 1;
        }
    }
}
