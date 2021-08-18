using System.Collections.Generic;

public class Node<TKey, TValue>
{
    public TKey Key { get; set; }

    public List<TValue> Values { get; set; }

    public Node()
    {
        Values = new List<TValue>();
    }
}