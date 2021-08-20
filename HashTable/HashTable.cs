using System;
using System.Collections.Generic;

public class HashTable<TKey, TValue> where TKey : IComparable
{
    private Node<TKey, TValue>[] items;
    
    private int Count = 0;
    
    private int Size;
    
    private double FillingIndex;

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
        // There is not good hash function. It's here just for exmaple.
        var k = key.GetHashCode() % items.Length;
        
        return k;
    }

    public void Add(TKey key, TValue value)
    {
        int k = GetHash(key);

        items[k].Key = key;
        items[k].Values.Add(value);
        Count++;
        FillingIndex = FillingCheck(Size, Count);
        
        if(FillingIndex >= .7) 
            // .7 is recomended value to expansion that i found
            items = Expansion(items);
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
    
    private double FillingCheck(double size, double count)
        => count/size;

    private Node<TKey, TValue>[] Expansion(Node<TKey, TValue>[] arr)
    {
        Node<TKey,TValue>[] newArr = new Node<TKey, TValue>[arr.Length*2];
        Size = newArr.Length;
        FillingIndex = FillingCheck(Size, Count);

        int index = 0;
        for ( ; index < arr.Length; index++)
            newArr[index] = arr[index];

        for ( ; index < newArr.Length; index++)
            newArr[index] = new Node<TKey, TValue>();

        return newArr;
    }
    
}
