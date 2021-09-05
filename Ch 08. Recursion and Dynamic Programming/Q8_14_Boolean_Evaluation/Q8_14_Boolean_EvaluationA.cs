using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_14_Boolean_Evaluation
{
    // brute force
    public class Q8_14_Boolean_EvaluationA : Question
    {
        public static int Count { get; private set; } = 0;

        public static int CountEvalA(string s, bool result)
		{
			Count++;
			if (s.Length == 0) return 0;
			if (s.Length == 1) return StringToBool(s) == result ? 1 : 0;

			int ways = 0;

			for (int i = 1; i < s.Length; i += 2)
			{
				char c = s[i];
				string left = s.Substring(0, i);
				string right = s.Substring(i + 1);
				int leftTrue = CountEvalA(left, true);
				int leftFalse = CountEvalA(left, false);
				int rightTrue = CountEvalA(right, true);
				int rightFalse = CountEvalA(right, false);
				int total = (leftTrue + leftFalse) * (rightTrue + rightFalse);

				int totalTrue = 0;
				if (c == '^')
				{ // required: one true and one false
					totalTrue = leftTrue * rightFalse + leftFalse * rightTrue;
				}
				else if (c == '&')
				{ // required: both true
					totalTrue = leftTrue * rightTrue;
				}
				else if (c == '|')
				{ // required: anything but both false
					totalTrue = leftTrue * rightTrue + leftFalse * rightTrue + leftTrue * rightFalse;
				}

				int subWays = result ? totalTrue : total - totalTrue;
				ways += subWays;
			}

			return ways;
		}

		public static bool StringToBool(string c)
		{
			return c.Equals("1");
		}

		public override void Run()
        {
			string expression = "0^0|1&1^1|0|1";
			bool result = true;

			Console.WriteLine(CountEvalA(expression, result));
			Console.WriteLine(Count);
		}
    }
}
