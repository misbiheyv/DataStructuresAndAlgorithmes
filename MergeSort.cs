using System;

public static class MergeSort
{

    public static void Sort(int[] arr)
    {
        Sort(arr, 0, arr.Length-1);
    }
 
    public static void Sort(int[] arr, int left, int right)
    {
        if(left < right)
        {
            int middle = left + (right - left) / 2;

            Sort(arr, left, middle);
            Sort(arr, middle+1, right);
            Merge(arr, left, middle, right);
        }
    }

    private static void Merge(int[] arr, int left, int pivot, int right)
    {
        int leftNum = pivot - left + 1;
        int rightNum = right - pivot;

        int[] leftArr = new int[leftNum];
        int[] rightArr = new int[rightNum];

        for (int i = 0; i < leftNum; i++)
            leftArr[i] = arr[left + i];

        for (int i = 0; i < rightNum; i++)
            rightArr[i] = arr[pivot + 1 + i];

        int indexLeft = 0, indexRight = 0, indexA = left;
        
        while (indexLeft < leftNum && indexRight < rightNum)
            arr[indexA++] = leftArr[indexLeft] <= rightArr[indexRight] ? leftArr[indexLeft++] : rightArr[indexRight++];
        
        while (indexLeft < leftNum)
            arr[indexA++] = leftArr[indexLeft++];

        while (indexRight < rightNum)
            arr[indexA++] = rightArr[indexRight++];
    }

}

public static class MergeSort<T> where T: IComparable
{
    public static void Sort(T[] arr)
    {
        Sort(arr, 0, arr.Length-1);
    }
   
    public static void Sort(T[] arr, int left, int right)
    {
        if(left < right)
        {
            int middle = left + (right - left) / 2;

            Sort(arr, left, middle);
            Sort(arr, middle+1, right);
            Merge(arr, left, middle, right);
        }
    }

    private static void Merge(T[] arr, int left, int pivot, int right)
    {
        int leftNum = pivot - left + 1;
        int rightNum = right - pivot;

        T[] leftArr = new T[leftNum];
        T[] rightArr = new T[rightNum];

        for (int i = 0; i < leftNum; i++)
            leftArr[i] = arr[left + i];

        for (int i = 0; i < rightNum; i++)
            rightArr[i] = arr[pivot + 1 + i];

        int indexLeft = 0, indexRight = 0, indexA = left;
        
        while (indexLeft < leftNum && indexRight < rightNum)
            arr[indexA++] = leftArr[indexLeft].CompareTo(rightArr[indexRight]) <= 0 ? leftArr[indexLeft++] : rightArr[indexRight++];
        
        while (indexLeft < leftNum)
            arr[indexA++] = leftArr[indexLeft++];

        while (indexRight < rightNum)
            arr[indexA++] = rightArr[indexRight++];
        
    }

}