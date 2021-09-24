using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_19_Missing_Two
{
	// 第一部份: 找出少掉的數字
	// 使用相乘的方式，數字太大會溢位
    public class Q17_19_Missing_TwoA : Question
    {
		public static int MissingOneA(int[] array)
		{
			UInt64 fullProduct = ProductToN(array.Length + 1);

			UInt64 actualProduct = 1;
			for (int i = 0; i < array.Length; i++)
			{
				actualProduct *= (UInt64)array[i];
			}

			UInt64 missingNumber = fullProduct/actualProduct;
			return (int)missingNumber;
		}

		public static UInt64 ProductToN(int n)
		{
			UInt64 fullProduct = 1;
			for (int i = 2; i <= n; i++)
			{
				fullProduct *= (UInt64)i;
			}
			return fullProduct;
		}

		public override void Run()
        {
			int max = 25;
			int x = 8;
			int len = max - 1;
			int count = 0;
			int[] array = new int[len];
			for (int i = 1; i <= max; i++)
			{
				if (i != x)
				{
					array[count] = i;
					count++;
				}
			}
			Console.WriteLine(x);
			int solution = MissingOneA(array);

			Console.WriteLine(solution);
		}
    }
}
