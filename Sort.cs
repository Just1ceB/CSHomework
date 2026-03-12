using Prjcts;
using System.ComponentModel;

namespace Prjcts
{
    internal class Sort
    {
        public static int[] BubbleSort(int[] arr)
        {
            int tmp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        tmp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = tmp;
                    }
                }
            }

            return arr;
        }

        public static void UnitTest()
        {
            int[] arr = { 0, 6, 5, 25, 31, 3, 4, 7 };

            Sort.BubbleSort(arr);

            Funcs.PrintArray(arr);
        }
    }
}
