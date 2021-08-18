using System;
public static class QuickSort
{
    public static void Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);

            Sort(arr, left, pivot - 1);
            Sort(arr, pivot + 1, right);
        }
    }

    private static int Partition(int[] arr, int left, int right)
    {
        int pivot = left;
        int temp;
        for (int i = left; i < right; i++)
        {
            if (arr[i] < arr[right]) 
            {
                temp = arr[pivot];
                arr[pivot++] = arr[i];
                arr[i] = temp;
            }
        }

        temp = arr[pivot]; 
        arr[pivot] = arr[right];
        arr[right] = temp;

        return pivot;
    }
}

public class QuickSort<T> where T : IComparable
{
    public static void Sort(T[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);
            
            Sort(arr, left, pivot - 1);
            Sort(arr, pivot + 1, right);
        }
    }

    private static int Partition(T[] arr, int left, int right)
    {
        int pivot = left;
        T temp;
        
        for (int i = left; i < right; i++)
        {
            if (arr[i].CompareTo(arr[right]) < 0)
            {
                temp = arr[pivot];
                arr[pivot++] = arr[i];
                arr[i] = temp;
            }
        }

        temp = arr[pivot];
        arr[pivot] = arr[right];
        arr[right] = temp;

        return pivot;
    }
}