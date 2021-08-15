using System;

public static class InsertionSort 
{
    public static void SortUp(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = i;
            int value = arr[i];

            while (key > 0 && value <= arr[key-1])
            {
                arr[key] = arr[key-1];
                key--;
            }
            arr[key] = value;
        }
    }
    public static void SortDown(int[] arr)
    {
        
        for (int i = 0; i < arr.Length; i++)
        {
            int key = i;
            int value = arr[i];

            while (key > 0 && value <= arr[key-1])
            {
                arr[key] = arr[key-1];
                key--;
            }
            arr[key] = value;
        }
    }
    public static void Print(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            System.Console.WriteLine(arr[i]);
        }
    }

}

public static class InsertionSort<T> where T: IComparable
{
    public static void SortUp(T[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = i;
            T value = arr[i];

            while (key > 0 && value.CompareTo(arr[key-1]) >= 0)
            {
                arr[key] = arr[key-1];
                key--;
            }
            arr[key] = value;
        }
    }
    public static void SortDown(T[] arr)
    {
        
        for (int i = 0; i < arr.Length; i++)
        {
            int key = i;
            T value = arr[i];

            while (key > 0 && value.CompareTo(arr[key-1]) <= 0)
            {
                arr[key] = arr[key-1];
                key--;
            }
            arr[key] = value;
        }
    }
    public static void Print(T[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            System.Console.WriteLine(arr[i]);
        }
    }

}