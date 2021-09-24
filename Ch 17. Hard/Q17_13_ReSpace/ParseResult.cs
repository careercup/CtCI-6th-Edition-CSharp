using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_13_ReSpace
{
	public class ParseResult
	{
		public int Invalid { get; private set; } = int.MaxValue;
		public string Parsed { get; private set; } = string.Empty;
		public ParseResult(int inv, string p)
		{
			Invalid = inv;
			Parsed = p;
		}

		public ParseResult Clone()
		{
			return new ParseResult(this.Invalid, this.Parsed);
		}

		public static ParseResult Min(ParseResult r1, ParseResult r2)
		{
			if (r1 == null)
			{
				return r2;
			}
			else if (r2 == null)
			{
				return r1;
			}

			return r2.Invalid < r1.Invalid ? r2 : r1;
		}
	}
}
