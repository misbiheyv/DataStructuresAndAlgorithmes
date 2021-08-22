using System;
using System.Collections;

public class Map<TKey, TValue> : IEnumerable
{
    private int size = 100;
    private int count = 0;
    private Node<TKey, TValue>[] items;

    public Map( )
    {
        items = new Node<TKey, TValue>[size];
        for (int i = 0; i < size; i++)
        {
            items[i] = new Node<TKey, TValue>();
        }
    }
    
    public Map(int lenth)
    {
        size = lenth;
        items = new Node<TKey, TValue>[size];
        for (int i = 0; i < size; i++)
        {
            items[i] = new Node<TKey, TValue>();
        }
    }

    public void Add(TKey key, TValue value)
    {
        int k = GetHash(key);

        if(count >= size) 
            items = Resize(items);
        
        if(items[k].Value == null)
        {
            items[k] = new Node<TKey, TValue>(key, value);
            count++;
            return;
        }

        int counter = 0;
        bool placed = false;
        for (int i = k; i < items.Length && counter < items.Length; i++, counter++)
        {
            if(key.Equals(items[i].Key)) 
                return;

            if(items[i].Value == null)
            {
                items[i] =  new Node<TKey, TValue>(key, value);
                placed = true;
                break;
            }

            if(i == items.Length - 1) 
                i = 0;
        }
        if(placed) 
            count++;

        if(!placed)
            throw new Exception("Something was wrong");
    }
    
    public TValue Search(TKey key)
    {
        int k = GetHash(key);

        int counter = 0;

        for (int i = k; i < items.Length && counter < items.Length; i++, counter++)
        {
            if(key.Equals(items[i].Key)) 
                return items[i].Value;

            if(i == items.Length - 1) 
                i = 0;
        }
        return default;
    }

    public void Remove(TKey key)
    {
        int k = GetHash(key);
    
        if(key.Equals(items[k].Key))
        {
            items[k] = new Node<TKey, TValue>();
            count--;
        }
        else
        {
            int counter = 0;
            for (int i = k; i < items.Length && counter < items.Length; i++, counter++)
            {
                if(key.Equals(items[i].Key))
                {
                    items[i] = new Node<TKey, TValue>();
                    count--;
                    return;
                }
                if(i == items.Length - 1) 
                    i = 0;
            }
        }
    }

    public IEnumerator GetEnumerator()
    {
        foreach (var item in items)
        {
            if(item.Value != null)
            {
                yield return item;
            }
        }
    }

    private int GetHash(TKey key)
        => key.GetHashCode() % size;
    
    private Node<TKey, TValue>[] Resize(Node<TKey, TValue>[] arr)
    {
        Node<TKey, TValue>[] newArr = new Node<TKey, TValue>[arr.Length*2];
        
        int index = 0;
        for ( ; index < arr.Length; index++)
            newArr[index] = arr[index];

        for( ; index < newArr.Length; index++)
            newArr[index] = new Node<TKey, TValue>();
        
        return newArr;
    }

}
