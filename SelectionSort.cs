using System;

public static class SelectionSort
{
    public static void SortUp(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++) // n
        {
            int key = i; // n-1

            for (int j = i; j < arr.Length; j++) //     
                if (arr[key] > arr[j])
                    key = j;


            int temp = arr[i];
            arr[i] = arr[key];
            arr[key] = temp;
        }
    }

    public static void SortDown(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int key = i;

            for (int j = i; j < arr.Length; j++)
                if (arr[key] < arr[j])
                    key = j;

            int temp = arr[i];
            arr[i] = arr[key];
            arr[key] = temp;
        }
    }
}

public static class SelectionSort<T> where T : IComparable
{
    public static void SortUp(T[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int key = i;

            for (int j = i; j < arr.Length; j++)
                if (arr[key].CompareTo(arr[j]) > 0)
                    key = j;


            T temp = arr[i];
            arr[i] = arr[key];
            arr[key] = temp;
        }
    }

    public static void SortDown(T[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int key = i;

            for (int j = i; j < arr.Length; j++)
                if (arr[key].CompareTo(arr[j]) < 0)
                    key = j;

            T temp = arr[i];
            arr[i] = arr[key];
            arr[key] = temp;
        }
    }
}