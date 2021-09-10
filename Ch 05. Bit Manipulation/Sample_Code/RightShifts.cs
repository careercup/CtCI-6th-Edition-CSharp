using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter05.Sample_Code
{
    public class RightShifts : Question
    {
		public static int RepeatedArithmeticShift(int x, int count)
		{
			for (int i = 0; i < count; i++)
			{
				x >>= 1; // Arithmetic shift by 1
			}
			return x;
		}

		public static uint RepeatedLogicalShift(int x, int count)
		{
			uint ans = (uint)x;
			for (int i = 0; i < count; i++)
			{
				// C# 沒有 Logical shift，但有 uint資料結構，所以以此方式處理
				ans >>= 1; // Logical shift by 1
			}
			return ans;
		}

		public override void Run()
        {
			for (int i = 8; i >= -8; i--)
			{
				Console.WriteLine(AssortedMethods.ToFullBinarystring(i) + ": " + i);
			}

			int x = -93242;
			int resultArithmetic = RepeatedArithmeticShift(x, 40);
			int resultLogical = (int)RepeatedLogicalShift(x, 40);
			Console.WriteLine(AssortedMethods.ToFullBinarystring(resultArithmetic) + ": " + resultArithmetic);
			Console.WriteLine(AssortedMethods.ToFullBinarystring(resultLogical) + ": " + resultLogical);
		}
    }
}
