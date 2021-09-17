using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_12_XML_Encoding
{
	public class Element
	{
		public IList<Attribute> Attributes { get; private set; }
		public IList<Element> Children { get; private set; }
		public string Name { get; private set; }
		public string Value { get; private set; }

		public Element(string n)
		{
			Name = n;
			Attributes = new List<Attribute>();
			Children = new List<Element>();
		}

		public Element(string n, string v)
		{
			Name = n;
			Value = v;
			Attributes = new List<Attribute>();
			Children = new List<Element>();
		}

		public string GetNameCode()
		{
			if (Name == "family")
			{
				return "1";
			}
			else if (Name == "person")
			{
				return "2";
			}
			else if (Name == "firstName")
			{
				return "3";
			}
			else if (Name == "lastName")
			{
				return "4";
			}
			else if (Name == "state")
			{
				return "5";
			}
			return "--";
		}

		public void Insert(Attribute attribute)
		{
			Attributes.Add(attribute);
		}

		public void Insert(Element child)
		{
			Children.Add(child);
		}
	}

}
