using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_10._Sorting_and_Searching.Q10_04_Sorted_Search_No_Size
{
	public class Listy
	{
		int[] array;

		public Listy(int[] arr)
		{
			array = arr.ToArray();
		}

		public int ElementAt(int index)
		{
			if (index >= array.Length)
			{
				return -1;
			}
			return array[index];
		}
	}
}
