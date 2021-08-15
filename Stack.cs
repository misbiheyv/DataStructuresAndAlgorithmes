using System;
public class Stack<T>
{
    public int Count { get; private set; }

    public bool IsEmpty { get; private set; }

    private T[] arr;

    public Stack() => arr = new T[10];

    public Stack(int size) => arr = new T[size];

    public void Push(T item)
    {
        if(Count >= arr.Length)
        {
            Resize(arr.Length + 10);
        }
        arr[Count++] = item;
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Empty");

        
        T temp = arr[--Count];
        arr[Count] = default(T);
        
        if (Count > 0 && Count < arr.Length - 10)
        {
            Resize(arr.Length - 10);
        }
        return temp;
    }

    public void Peek()
    {
        System.Console.WriteLine(arr[Count-1]);
    }

    public T Show(int count)
    {
        Console.WriteLine(arr[count]);
        if (count == 0)
        {
            return arr[0];
        }
        else
            return Show(count - 1);
    }
    private void Resize(int size)
    {
        T[] temp = new T[size];

        for (int i = 0; i < Count ; i++)
            temp[i] = arr[i];

        arr = temp;
    }

}