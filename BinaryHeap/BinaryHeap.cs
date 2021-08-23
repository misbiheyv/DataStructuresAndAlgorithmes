using System;
using System.Collections;
using System.Collections.Generic;

public class BinaryHeap<T> : IEnumerable 
    where T : IComparable
{
    private List<T> items = new List<T>();

    public int Count => items.Count;

    public T PeekMax()
    {
        if (Count > 0)
            return items[0];
        return default(T);
    }

    public void Push(T item)
    {
        items.Add(item);

        int currentIndex = Count - 1;
        int parentIndex = (currentIndex - 1) / 2;
        // parent: (i - 1) / 2

        while( items[currentIndex].CompareTo(items[parentIndex]) >= 0 && currentIndex > 0 )
        {
            T temp = items[currentIndex];
            items[currentIndex] = items[parentIndex];
            items[parentIndex] = temp;
            currentIndex = parentIndex;
            parentIndex = (currentIndex - 1) / 2;
        }
    }

    public T PopMax()
    {
        try
        {
            T result = items[0];
            items[0] = items[Count - 1];
            items.RemoveAt(Count - 1);  
        
            Sort();

            return result; 
        }
        catch
        {
        }
        return default;
    }

    private void Sort()
    {
        int currentIndex = 0;
        // left: 2i + 1
        // right: 2i + 2
        int leftIndex = 2 * currentIndex + 1;
        int rightIndex = 2 * currentIndex + 2;
        int tempIndex;

        if (rightIndex < Count)
        {
            tempIndex = items[leftIndex].CompareTo(items[rightIndex])>0 ? leftIndex : rightIndex;   
        }
        else
        {
            tempIndex = leftIndex;
        }

        while (items[tempIndex].CompareTo(items[currentIndex]) > 0)
        {
            T temp = items[tempIndex];
            items[tempIndex] = items[currentIndex];
            items[currentIndex] = temp;
            currentIndex = tempIndex;

            leftIndex = 2 * currentIndex + 1;
            rightIndex = 2 * currentIndex + 2;

            if (rightIndex < Count && leftIndex < Count)
            {
                tempIndex = items[leftIndex].CompareTo(items[rightIndex])>0 ? leftIndex : rightIndex;   
            }
            else
            {
                break;
            }
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        // There is return sorted list
        while(Count > 0)
        {
            yield return PopMax();
        }
    }
}
