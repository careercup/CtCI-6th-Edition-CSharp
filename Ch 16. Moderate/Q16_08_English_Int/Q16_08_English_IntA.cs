using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_08_English_Int
{
    public class Q16_08_English_IntA : Question
    {
		public static string[] smalls = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
		public static string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
		public static string[] bigs = { "", "Thousand", "Million", "Billion" };
		public static string hundred = "Hundred";
		public static string negative = "Negative";

		public static string Convert(int num)
		{
			if (num == 0)
			{
				return smalls[0];
			}
			else if (num < 0)
			{
				return negative + " " + Convert(-1 * num);
			}

			LinkedList<string> parts = new LinkedList<string>();
			int chunkCount = 0;

			while (num > 0)
			{
				if (num % 1000 != 0)
				{
					string chunk = ConvertChunk(num % 1000) + " " + bigs[chunkCount];
					parts.AddFirst(chunk);
				}
				num /= 1000; // shift chunk
				chunkCount++;
			}

			return ListTostring(parts);
		}


		public static string ConvertChunk(int number)
		{
			LinkedList<string> parts = new LinkedList<string>();

			/* Convert hundreds place */
			if (number >= 100)
			{
				parts.AddLast(smalls[number / 100]);
				parts.AddLast(hundred);
				number %= 100;
			}

			/* Convert tens place */
			if (number >= 10 && number <= 19)
			{
				parts.AddLast(smalls[number]);
			}
			else if (number >= 20)
			{
				parts.AddLast(tens[number / 10]);
				number %= 10;
			}

			/* Convert ones place */
			if (number >= 1 && number <= 9)
			{
				parts.AddLast(smalls[number]);
			}

			return ListTostring(parts);
		}

		/* Convert a linked list of strings to a string, dividing it up with spaces. */
		public static string ListTostring(LinkedList<string> parts)
		{
			StringBuilder sb = new StringBuilder();
			Queue<string> q = new Queue<string>(parts);
			while (q.Count > 1)
			{
				sb.Append(q.Dequeue());
				sb.Append(" ");
			}
			sb.Append(q.Dequeue());
			return sb.ToString();
		}

		

		public override void Run()
        {
			/* numbers between 100000 and 1000000 */
			for (int i = 0; i < 8; i++)
			{
				int value = (int)(-1 * Math.Pow(10, i));
				string s = Convert(value);
				Console.WriteLine(value + ": " + s);
			}

			/* numbers between 0 and 100 */
			for (int i = 0; i < 10; i++)
			{
				int value = AssortedMethods.RandomIntInRange(0, 100);
				string s = Convert(value);
				Console.WriteLine(value + ": " + s);
			}

			/* numbers between 100 and 1000 */
			for (int i = 0; i < 10; i++)
			{
				int value = AssortedMethods.RandomIntInRange(100, 1000);
				string s = Convert(value);
				Console.WriteLine(value + ": " + s);
			}

			/* numbers between 1000 and 100000 */
			for (int i = 0; i < 10; i++)
			{
				int value = AssortedMethods.RandomIntInRange(1000, 100000);
				string s = Convert(value);
				Console.WriteLine(value + ": " + s);
			}


			/* numbers between 100000 and 100000000 */
			for (int i = 0; i < 10; i++)
			{
				int value = AssortedMethods.RandomIntInRange(100000, 100000000);
				string s = Convert(value);
				Console.WriteLine(value + ": " + s);
			}

			/* numbers between 100000000 and 1000000000 */
			for (int i = 0; i < 10; i++)
			{
				int value = AssortedMethods.RandomIntInRange(100000000, 1000000000);
				string s = Convert(value);
				Console.WriteLine(value + ": " + s);
			}

			/* numbers between 1000000000 and Integer.MAX_VALUE */
			for (int i = 0; i < 10; i++)
			{
				int value = AssortedMethods.RandomIntInRange(1000000000, int.MaxValue);
				string s = Convert(value);
				Console.WriteLine(value + ": " + s);
			}
		}
    }
}
