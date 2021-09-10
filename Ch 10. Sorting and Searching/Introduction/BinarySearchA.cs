using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_10._Sorting_and_Searching.Introduction
{
    public class BinarySearchA : Question
    {
        public static int BinarySearch(int[] a, int x)
        {
            int low = 0;
            int high = a.Length - 1;
            int mid;

            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (a[mid] < x)
                {
                    low = mid + 1;
                }
                else if (a[mid] > x)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }

        public static int BinarySearchRecursive(int[] a, int x, int low, int high)
        {
            if (low > high) return -1; // Error

            int mid = (low + high) / 2;
            if (a[mid] < x)
            {
                return BinarySearchRecursive(a, x, mid + 1, high);
            }
            else if (a[mid] > x)
            {
                return BinarySearchRecursive(a, x, low, mid - 1);
            }
            else
            {
                return mid;
            }
        }

        // Recursive algorithm to return the closest element
        public static int BinarySearchRecursiveClosest(int[] a, int x, int low, int high)
        {
            if (low > high)
            { // high is on the left side now
                if (high < 0) return low;
                if (low >= a.Length) return high;
                if (x - a[high] < a[low] - x)
                {
                    return high;
                }
                return low;
            }

            int mid = (low + high) / 2;
            if (a[mid] < x)
            {
                return BinarySearchRecursiveClosest(a, x, mid + 1, high);
            }
            else if (a[mid] > x)
            {
                return BinarySearchRecursiveClosest(a, x, low, mid - 1);
            }
            else
            {
                return mid;
            }
        }

        public override void Run()
        {
            int[] array = { 3, 6, 9, 12, 15, 18 };
            for (int i = 0; i < 20; i++)
            {
                int loc = BinarySearch(array, i);
                int loc2 = BinarySearchRecursive(array, i, 0, array.Length - 1);
                int loc3 = BinarySearchRecursiveClosest(array, i, 0, array.Length - 1);
                Console.WriteLine(i + ": " + loc + " " + loc2 + " " + loc3);
            }
        }
    }
}
