using ctci.Contracts;
using System;

namespace Chapter10
{
    public class Q10_05_Sparse_Search : Question
    {
        public static int Search(String[] strings, String str, int first, int last)
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
                return Search(strings, str, mid + 1, last);
            }
            else { // Search left
                return Search(strings, str, first, mid - 1);
            }
        }

        public static int Search(String[] strings, String str)
        {
            if (strings == null || string.IsNullOrEmpty(str))
            {
                return -1;
            }
            return Search(strings, str, 0, strings.Length - 1);
        }

        public static int SearchI(String[] strings, String str, int first, int last)
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

        public static int SearchR(String[] strings, String str, int first, int last)
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

        public static int Search2(String[] strings, String str)
        {
            if (strings == null || string.IsNullOrEmpty(str))
            {
                return -1;
            }
            return SearchR(strings, str, 0, strings.Length - 1);
        }

        public override void Run()
        {
            String[] stringList = { "apple", "", "", "banana", "", "", "", "carrot", "duck", "", "", "eel", "", "flower" };

            Console.WriteLine(Search(stringList, "duck"));

            Console.WriteLine(Search2(stringList, "duck"));
        }
    }
}