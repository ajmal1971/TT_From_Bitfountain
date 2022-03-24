using System;

namespace QuickSort
{
    class Program
    {
        static public int Partition(int[] arr, int left, int right)
        {
            int pivot;
            pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        static public void QuickSort(int[] arr, int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number Of Items: ");
            int noi = int.Parse(Console.ReadLine());

            int[] items = new int[noi];
            for (int index = 0; index < noi; index++)
                items[index] = int.Parse(Console.ReadLine());

            Console.Write("\nItems Before Sort: ");
            for (int index = 0; index < noi; index++)
                Console.Write(items[index] + " ");

            QuickSort(items, 0, noi-1);

            Console.Write("\n\nItems Before Sort: ");
            for (int index = 0; index < noi; index++)
                Console.Write(items[index] + " ");

            Console.Read();
        }
    }
}
