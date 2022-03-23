using System;

namespace QuickSort
{
    class Program
    {
        static public void QuickSort(int[] items, int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = items[left];
                while (true)
                {
                    while (items[left] < pivot)
                    {
                        left++;
                    }
                    while (items[right] > pivot)
                    {
                        right--;
                    }
                    if (left < right)
                    {
                        int temp = items[right];
                        items[right] = items[left];
                        items[left] = temp;
                    }
                    else
                    {
                        pivot =  right;
                        break;
                    }
                }

                if (pivot > 1)
                {
                    QuickSort(items, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(items, pivot + 1, right);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter Number Of Items: ");
            int noi = int.Parse(Console.ReadLine());

            int[] items = new int[noi];
            Console.Write("Enter  Items: ");
            for (int index = 0; index < noi; index++)
            {
                items[index] = int.Parse(Console.ReadLine());
            }

            Console.Write("Items Before Sort: ");
            for (int index = 0; index < noi; index++)
            {
                Console.Write(items[index] + " ");
            }

            QuickSort(items, 0, noi-1);

            Console.Write("\nSorted Array is: ");
            for (int index = 0; index < noi; index++)
            {
                Console.Write(items[index] + " ");
            }

            Console.Read();
        }
    }
}
