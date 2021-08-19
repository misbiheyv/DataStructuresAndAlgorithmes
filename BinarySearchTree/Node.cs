using System;

public class Node<T> : IComparable
    where T : IComparable
{
    public T Data { get; private set; }

    public Node<T> Left { get; set; }

    public Node<T> Right { get; set; }

    public Node(T data)
    {
        Data = data;
    }

    public Node(T data, Node<T> left, Node<T> right)
    {
        Data = data;
        Left = left;
        Right = right;
    }

    public int CompareTo(object obj)
    {
        if (obj is Node<T> item)
        {
            if (this.Data.CompareTo(item.Data) < 0)
                return -1;

            if (this.Data.CompareTo(item.Data) == 0)
                return 0;

            if (this.Data.CompareTo(item.Data) > 0)
                return 1;
        }

        throw new Exception("Unknown types");
    }
}