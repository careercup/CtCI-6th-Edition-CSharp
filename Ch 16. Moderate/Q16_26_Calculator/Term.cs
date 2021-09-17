using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_26_Calculator
{
    public class Term
    {
        private double value;
        private Operator opr = Operator.BLANK;


        public Term(double v, Operator op)
        {
            value = v;
            opr = op;
        }

        public double GetNumber()
        {
            return value;
        }

        public Operator GetOperator()
        {
            return opr;
        }

        public void SetNumber(double v)
        {
            value = v;
        }

        public static IList<Term> ParseTermSequence(string sequence)
        {
            IList<Term> terms = new List<Term>();
            int offset = 0;
            while (offset < sequence.Length)
            {
                Operator op = Operator.BLANK;
                if (offset > 0)
                {
                    op = ParseOperator(sequence[offset]);
                    if (op == Operator.BLANK)
                    {
                        return null;
                    }
                    offset++;
                }
                try
                {
                    int value = ParseNextNumber(sequence, offset);
                    offset += value.ToString().Length;
                    Term term = new Term(value, op);
                    terms.Add(term);
                }
                catch (FormatException ex)
                {
                    return null;
                }
            }
            return terms;
        }

        public static Operator ParseOperator(char op)
        {
            switch (op)
            {
                case '+': return Operator.ADD;
                case '-': return Operator.SUBTRACT;
                case '*': return Operator.MULTIPLY;
                case '/': return Operator.DIVIDE;
            }
            return Operator.BLANK;
        }

        public static int ParseNextNumber(string sequence, int offset)
        {
            StringBuilder sb = new StringBuilder();
            while (offset < sequence.Length && char.IsDigit(sequence[offset]))
            {
                sb.Append(sequence[offset]);
                offset++;
            }
            return int.Parse(sb.ToString());
        }
    }
}
