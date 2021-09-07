using ctci.Contracts;
using System;

namespace Chapter10
{
    public class Q10_05_Sparse_Search : Question
    {
        // Worst case 
        // Time complexity: O(n)
        public static int SearchA(string[] strings, string str)
        {
            if (strings == null || string.IsNullOrEmpty(str))
            {
                return -1;
            }
            return SearchA(strings, str, 0, strings.Length - 1);
        }

        public static int SearchA(string[] strings, string str, int first, int last)
        {
            if (first > last)
            {
                return -1;
            }

            /* Move mid to the middle */
            int mid = (last + first) / 2;

            /* If mid is empty, find closest non-empty string. */
            if (string.IsNullOrEmpty(strings[mid]))
            {
                int left = mid - 1;
                int right = mid + 1;
                while (true)
                {
                    if (left < first && right > last)
                    {
                        return -1;
                    }
                    else if (right <= last && !string.IsNullOrEmpty(strings[right]))
                    {
                        mid = right;
                        break;
                    }
                    else if (left >= first && !string.IsNullOrEmpty(strings[left]))
                    {
                        mid = left;
                        break;
                    }
                    right++;
                    left--;
                }
            }

            /* Check for string, and recurse if necessary */
            if (str.Equals(strings[mid]))
            { // Found it!
                return mid;
            }
            else if (strings[mid].CompareTo(str) < 0)
            { // Search right
                return SearchA(strings, str, mid + 1, last);
            }
            else { // Search left
                return SearchA(strings, str, first, mid - 1);
            }
        }

        public static int SearchB(string[] strings, string str)
        {
            if (strings == null || string.IsNullOrEmpty(str))
            {
                return -1;
            }
            return SearchR(strings, str, 0, strings.Length - 1);
        }

        public static int SearchI(string[] strings, string str, int first, int last)
        {
            while (first <= last)
            {
                /* Move mid to the middle */
                int mid = (last + first) / 2;

                /* If mid is empty, find closest non-empty string */
                if (string.IsNullOrEmpty(strings[mid]))
                {
                    int left = mid - 1;
                    int right = mid + 1;
                    while (true)
                    {
                        if (left < first && right > last)
                        {
                            return -1;
                        }
                        else if (right <= last && !string.IsNullOrEmpty(strings[right]))
                        {
                            mid = right;
                            break;
                        }
                        else if (left >= first && !string.IsNullOrEmpty(strings[left]))
                        {
                            mid = left;
                            break;
                        }
                        right++;
                        left--;
                    }
                }

                int res = strings[mid].CompareTo(str);
                if (res == 0)
                { // Found it!
                    return mid;
                }
                else if (res < 0)
                { // Search right
                    first = mid + 1;
                }
                else { // Search left
                    last = mid - 1;
                }
            }
            return -1;
        }

        public static int SearchR(string[] strings, string str, int first, int last)
        {
            if (first > last)
            {
                return -1;
            }

            /* Move mid to the middle */
            int mid = (last + first) / 2;

            /* If mid is empty, find closest non-empty string. */
            if (string.IsNullOrEmpty(strings[mid]))
            {
                int left = mid - 1;
                int right = mid + 1;
                while (true)
                {
                    if (left < first && right > last)
                    {
                        return -1;
                    }
                    else if (right <= last && !string.IsNullOrEmpty(strings[right]))
                    {
                        mid = right;
                        break;
                    }
                    else if (left >= first && !string.IsNullOrEmpty(strings[left]))
                    {
                        mid = left;
                        break;
                    }
                    right++;
                    left--;
                }
            }

            /* Check for string, and recurse if necessary */
            if (str.Equals(strings[mid]))
            { // Found it!
                return mid;
            }
            else if (strings[mid].CompareTo(str) < 0)
            { // Search right
                return SearchR(strings, str, mid + 1, last);
            }
            else { // Search left
                return SearchR(strings, str, first, mid - 1);
            }
        }

        

        public override void Run()
        {
            string[] stringList = { "apple", "", "", "banana", "", "", "", "carrot", "duck", "", "", "eel", "", "flower" };

            Console.WriteLine(SearchA(stringList, "duck"));

            Console.WriteLine(SearchB(stringList, "duck"));
        }
    }
}