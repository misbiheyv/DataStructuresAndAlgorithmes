using System;
using System.Collections.Generic;

public class Tree<T> where T : IComparable
{
    public Node<T> Root { get; private set; }

    public int Count { get; private set; } = 0;

    public void Add(T data)
    {
        Node<T> node = new Node<T>(data);

        if (Root == null)
        {
            Root = node;
            Count = 1;
            return;
        }

        if (Count == 1) Count++;

        if (node.Data.CompareTo(Root.Data) < 0)
        {
            if (Root.Left == null)
            {
                Root.Left = node;
                return;
            }

            Add(data, Root.Left);
            return;
        }

        if (Root.Right == null)
        {
            Root.Right = node;
            return;
        }

        Add(data, Root.Right);
    }

    public List<T> Preorder()
    {
        // Prefix oreder. Returns: 
        // 1) Element
        // 2) Left elements
        // 3) Right elements
        // There's the best way for coping BT!

        //     For example. Our tree:

        //          _ 5 _
        //         /     \
        //        3       8
        //      /   \    /  \
        //     1     4  7    9
        //      \      /
        //       2    6

        // Output list -> 5 3 1 2 4 8 7 6 9

        if (Root == null)
            return new List<T>();
        return Preorder(Root);
    }

    public List<T> Postorder()
    {
        // Postfix oreder. Returns: 
        // 1) Left elements
        // 2) Right elements
        // 3) Element
        // There's the most safety way for deleting! 
        // It always returns sheets.

        //     For example. Our tree:

        //          _ 5 _
        //         /     \
        //        3       8
        //      /   \    /  \
        //     1     4  7    9
        //      \      /
        //       2    6

        // Output list -> 2 1 4 3 6 7 9 8 5

        if (Root == null)
            return new List<T>();
        return Postorder(Root);
    }

    public List<T> Inorder()
    {
        // Postfix oreder. Returns: 
        // 1) Left elements
        // 2) Right elements
        // 3) Element
        // There's the best way for sorting! 
        // It returns sorted list.

        //     For example. Our tree:

        //          _ 5 _
        //         /     \
        //        3       8
        //      /   \    /  \
        //     1     4  7    9
        //      \      /
        //       2    6

        // Output list -> 1 2 3 4 5 6 7 8 9

        if (Root == null)
            return new List<T>();
        return Inorder(Root);
    }

    private void Add(T data, Node<T> current)
    {
        Node<T> node = new Node<T>(data);
        Count++;

        if (node.Data.CompareTo(current.Data) < 0)
        {
            if (current.Left == null)
            {
                current.Left = node;
                return;
            }

            Add(data, current.Left);
            return;
        }

        if (current.Right == null)
        {
            current.Right = node;
            return;
        }

        Add(data, current.Right);
    }

    private List<T> Preorder(Node<T> node)
    {
        List<T> list = new List<T>();
        if (node != null)
        {
            list.Add(node.Data);
            if (node.Left != null)
            {
                list.AddRange(Preorder(node.Left));
            }

            if (node.Right != null)
            {
                list.AddRange(Preorder(node.Right));
            }
        }

        return list;
    }

    private List<T> Postorder(Node<T> node)
    {
        List<T> list = new List<T>();
        if (node != null)
        {
            if (node.Left != null)
            {
                list.AddRange(Postorder(node.Left));
            }

            if (node.Right != null)
            {
                list.AddRange(Postorder(node.Right));
            }

            list.Add(node.Data);
        }

        return list;
    }

    private List<T> Inorder(Node<T> node)
    {
        List<T> list = new List<T>();
        if (node != null)
        {
            if (node.Left != null)
            {
                list.AddRange(Inorder(node.Left));
            }

            list.Add(node.Data);

            if (node.Right != null)
            {
                list.AddRange(Inorder(node.Right));
            }
        }

        return list;
    }
}
