using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_12_XML_Encoding
{
    public class Q16_12_XML_Encoding_OO_A : Question
    {
		public static void Encode(Element root, StringBuilder sb)
		{
			Encode(root.GetNameCode(), sb);
			foreach (Attribute a in root.Attributes)
			{
				Encode(a, sb);
			}
			EncodeEnd(sb);
			if (root.Value != null && root.Value != "")
			{
				Encode(root.Value, sb);
			}
			else
			{
				foreach (Element e in root.Children)
				{
					Encode(e, sb);
				}
			}
			EncodeEnd(sb);
		}

		public static void Encode(string v, StringBuilder sb)
		{
			v = v.Replace("0", "\\0");
			sb.Append(v);
			sb.Append(" ");
		}

		public static void EncodeEnd(StringBuilder sb)
		{
			sb.Append("0");
			sb.Append(" ");
		}

		public static void Encode(Attribute attr, StringBuilder sb)
		{
			Encode(attr.GetTagCode(), sb);
			Encode(attr.Value, sb);
		}
	

		public static string EncodeTostring(Element root)
		{
			StringBuilder sb = new StringBuilder();
			Encode(root, sb);
			return sb.ToString();
		}

		public override void Run()
        {
			Element root = new Element("family");
			Attribute a1 = new Attribute("lastName", "mcdowell");
			Attribute a2 = new Attribute("state", "CA");
			root.Insert(a1);
			root.Insert(a2);

			Element child = new Element("person", "Some Message");
			Attribute a3 = new Attribute("firstName", "Gayle");
			child.Insert(a3);

			root.Insert(child);

			string s = EncodeTostring(root);
			Console.WriteLine(s);
		}
    }
}
