using ctci.Contracts;
using System;

namespace Chapter10
{
    public class Q10_03_Search_in_Rotated_Array : Question
    {
        /// <summary>
        /// As in the book, returns the correct index (tested)
        /// It's a real kludge though... good initial answer
        /// The code runs in O(logn) time - assuming that all elements are unique. However, with many duplicates, the algorithm is O(n)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Search(int[] a, int left, int right, int x)
        {
            int mid = (left + right) / 2;
            if (x == a[mid])
            { // Found element
                return mid;
            }
            if (right < left)
            {
                return -1;
            }

            /* While there may be an inflection point due to the rotation, either the left or
             * right half must be normally ordered.  We can look at the normally ordered half
             * to make a determination as to which half we should search.
             */
            if (a[left] < a[mid])
            { // Left is normally ordered.
                if (x >= a[left] && x < a[mid])
                {
                    return Search(a, left, mid - 1, x);
                }
                else {
                    return Search(a, mid + 1, right, x);
                }
            }
            else if (a[mid] < a[left])
            { // Right is normally ordered.
                if (x > a[mid] && x <= a[right])
                {
                    return Search(a, mid + 1, right, x);
                }
                else {
                    return Search(a, left, mid - 1, x);
                }
            }
            else if (a[left] == a[mid])
            { // Left is either all repeats OR loops around (with the right half being all dups)
                if (a[mid] != a[right])
                { // If right half is different, search there
                    return Search(a, mid + 1, right, x);
                }
                else { // Else, we have to search both halves
                    int result = Search(a, left, mid - 1, x);
                    if (result == -1)
                    {
                        return Search(a, mid + 1, right, x);
                    }
                    else {
                        return result;
                    }
                }
            }
            return -1;
        }

        /* Another way is to do a pivoted binary search, where you first identify the problematic area, basically start of the originally
         * sorted array. */

        public override void Run()
        {
            int[] a = new int[] { 5, 6, 7, 8, 9, 1, 2, 3, 4 };

            Console.WriteLine(Search(a, 0, a.Length, 8));
        }
    }
}