using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_26_Calculator
{
	// 方案1
	// Time complexity: O(N)
	// N: 初始字串長度
	public class Q16_26_CalculatorA : Question
    {
		/* Compute the result of the arithmetic sequence. This
		   works by reading left to right and applying each term to
		   a result. When we see a multiplication or division, we 
		   instead apply this sequence to a temporary variable. */
		public static double ComputeA(string sequence)
		{
			IList<Term> terms = Term.ParseTermSequence(sequence);
			if (terms == null) return int.MinValue;

			double result = 0;
			Term processing = null;
			for (int i = 0; i < terms.Count; i++)
			{
				Term current = terms[i];
				Term next = i + 1 < terms.Count ? terms[i + 1] : null;

				/* Apply the current term to “processing”. */
				processing = CollapseTerm(processing, current);

				/* If next term is + or -, then this cluster is done 
				 * and we should apply “processing” to “result”. */
				if (next == null || next.GetOperator() == Operator.ADD || next.GetOperator() == Operator.SUBTRACT)
				{
					result = ApplyOp(result, processing.GetOperator(), processing.GetNumber());
					processing = null;
				}
			}

			return result;
		}

		public static Term CollapseTerm(Term primary, Term secondary)
		{
			if (primary == null) return secondary;
			if (secondary == null) return primary;

			double value = ApplyOp(primary.GetNumber(), secondary.GetOperator(), secondary.GetNumber());
			primary.SetNumber(value);
			return primary;
		}

		public static double ApplyOp(double left, Operator op, double right)
		{
			if (op == Operator.ADD)
			{
				return left + right;
			}
			else if (op == Operator.SUBTRACT)
			{
				return left - right;
			}
			else if (op == Operator.MULTIPLY)
			{
				return left * right;
			}
			else if (op == Operator.DIVIDE)
			{
				return left / right;
			}
			else
			{
				return right;
			}
		}

		

		public override void Run()
        {
			string expression = "6/5*3+4*5/2-12/6*3/3+3+3";
			double result = ComputeA(expression);
			Console.WriteLine(result);
		}
    }
}
