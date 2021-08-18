using System;
using System.Collections.Generic;

public class HashTable<TKey, TValue> where TKey : IComparable
{
    private Node<TKey, TValue>[] items;

    public HashTable(int size)
    {
        items = new Node<TKey, TValue>[size];
        for (int i = 0; i < size; i++)
        {
            items[i] = new Node<TKey, TValue>();
        }
    }

    private int GetHash(TKey key)
    {
        var k = key.GetHashCode() % items.Length;
        
        return k;
    }

    public void Add(TKey key, TValue value)
    {
        int k = GetHash(key);

        items[k].Key = key;
        items[k].Values.Add(value);
    }

    public List<TValue> Search(TKey key)
    {
        int k = GetHash(key);
        if(items[k].Key.ToString == null)
            return null;
        return items[k].Values;
    }

    public void Delete(TKey key)
    {
        int k = key.GetHashCode();
        items[k] = new Node<TKey, TValue>();
    }

}
