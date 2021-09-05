using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_14_Boolean_Evaluation
{
    // optimization
    // memo
    public class Q8_14_Boolean_EvaluationB : Question
    {
		public static int Count { get; private set; } = 0;

		public static int CountEvalB(string s, bool result)
		{
			return CountEval(s, result, new Dictionary<string, int>());
		}

		public static int CountEval(string s, bool result, Dictionary<string, int> memo)
		{
			Count++;
			if (s.Length == 0) return 0;
			if (s.Length == 1) return StringToBool(s) == result ? 1 : 0;
			if (memo.ContainsKey(result + s)) return memo[result + s];

			int ways = 0;

			for (int i = 1; i < s.Length; i += 2)
			{
				char c = s[i];
				string left = s.Substring(0, i);
				string right = s.Substring(i + 1);
				int leftTrue = CountEval(left, true, memo);
				int leftFalse = CountEval(left, false, memo);
				int rightTrue = CountEval(right, true, memo);
				int rightFalse = CountEval(right, false, memo);
				int total = (leftTrue + leftFalse) * (rightTrue + rightFalse);

				int totalTrue = 0;
				if (c == '^')
				{
					totalTrue = leftTrue * rightFalse + leftFalse * rightTrue;
				}
				else if (c == '&')
				{
					totalTrue = leftTrue * rightTrue;
				}
				else if (c == '|')
				{
					totalTrue = leftTrue * rightTrue + leftFalse * rightTrue + leftTrue * rightFalse;
				}

				int subWays = result ? totalTrue : total - totalTrue;
				ways += subWays;
			}

			memo[result + s] = ways;
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

			Console.WriteLine(CountEvalB(expression, result));
			Console.WriteLine(Count);
		}
    }
}
