using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter05.Sample_Code
{
    public class Sample_Code : Question
    {
		public static bool GetBit(int num, int i)
		{
			return ((num & (1 << i)) != 0);
		}

		public static int SetBit(int num, int i)
		{
			return num | (1 << i);
		}

		public static int ClearBit(int num, int i)
		{
			int mask = ~(1 << i);
			return num & mask;
		}

		public static int UpdateBit(int num, int i, bool bitIs1)
		{
			int value = bitIs1 ? 1 : 0;
			int mask = ~(1 << i);
			return (num & mask) | (value << i);
		}

		public static int ClearBitsMSBthroughI(int num, int i)
		{
			int mask = (1 << i) - 1;
			return num & mask;
		}

		public static int ClearBitsIthrough0(int num, int i)
		{
			int mask = (-1 << (i + 1));
			return num & mask;
		}

		public override void Run()
        {
			int number = 59;
			Console.WriteLine("Testing with number: " + number);

			// Get Bit
			Console.WriteLine("Get Bit");
			Console.WriteLine(AssortedMethods.ToFullBinarystring(number));
			for (int i = 31; i >= 0; i--)
			{
				int res = GetBit(number, i) ? 1 : 0;
				Console.Write(res);
			}

			// Update Bit
			Console.WriteLine("\n\nUpdate Bit");
			int num1 = 1578; // arbitrary number
			for (int i = 31; i >= 0; i--)
			{
				num1 = UpdateBit(num1, i, GetBit(number, i));
			}
			Console.WriteLine(num1);

			// Set and Clear Bit
			Console.WriteLine("\nSet and Clear Bit");
			int num2 = 1578; // arbitrary number
			for (int i = 31; i >= 0; i--)
			{
				if (GetBit(number, i))
				{
					num2 = SetBit(num2, i);
				}
				else
				{
					num2 = ClearBit(num2, i);
				}
			}
			Console.WriteLine(num2);

			// Clear Bits MSB through i
			number = 13242352;
			int clearMSBThrough = 4;
			Console.WriteLine("\nClear bits MSB through " + clearMSBThrough);
			Console.WriteLine(AssortedMethods.ToFullBinarystring(number));
			int num3 = ClearBitsMSBthroughI(number, clearMSBThrough);
			Console.WriteLine(AssortedMethods.ToFullBinarystring(num3));

			// Clear Bits i through 0
			int clearToLSB = 2;
			Console.WriteLine("\nClear bits " + clearToLSB + " through 0");
			number = -1;
			Console.WriteLine(AssortedMethods.ToFullBinarystring(number));
			int num4 = ClearBitsIthrough0(number, clearToLSB);
			Console.WriteLine(AssortedMethods.ToFullBinarystring(num4));
		}
    }
}
