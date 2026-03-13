using Prjcts;
using System.ComponentModel;

namespace Prjcts
{
    internal class Sort
    {
        public static void BubbleSort(int[] arr)
        {
            int tmp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        tmp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = tmp;
                    }
                }
            }
        }


        public static void QuickSort(int[] arr, int start, int end)
        {
            if (end <= start) return;

            int pivot = Partition(arr, start, end); // Figuring out pivot (all numbers to the left are smaller and to the right are bigger)

            QuickSort(arr, start, pivot - 1); // sorting left part
            QuickSort(arr, pivot + 1, end); // sorting right part
        }


        public static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int i = start - 1;
            int tmp;

            for(int j = start; j <= end - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                }
            }
            i++;
            tmp = arr[i];
            arr[i] = arr[end];
            arr[end] = tmp;
            
            return i;
        }


        public static void UnitTest()
        {
            int[] arr = { 0, 6, 5, 25, 31, 3, 4, 7 };
            int[] arr2 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Sort.BubbleSort(arr);
            Funcs.PrintArray(arr);
            Console.WriteLine(" - Bubble Sort");

            Sort.QuickSort(arr2, 0, arr2.Length -1);

            Funcs.PrintArray(arr2);
            Console.WriteLine(" - Quick Sort");
        }
    }
}
