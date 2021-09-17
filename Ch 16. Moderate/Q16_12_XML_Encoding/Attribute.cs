using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_12_XML_Encoding
{
	public class Attribute
	{
		public string Tag { get; private set; }
		public string Value { get; private set; }
		public Attribute(string t, string v)
		{
			Tag = t;
			Value = v;
		}

		public string GetTagCode()
		{
			if (Tag == "family")
			{
				return "1";
			}
			else if (Tag == "person")
			{
				return "2";
			}
			else if (Tag == "firstName")
			{
				return "3";
			}
			else if (Tag == "lastName")
			{
				return "4";
			}
			else if (Tag == "state")
			{
				return "5";
			}
			return "--";
		}
	}
}
