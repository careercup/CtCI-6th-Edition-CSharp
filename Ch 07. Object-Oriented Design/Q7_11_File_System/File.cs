using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_11_File_System
{
	public class File: Entry
	{
	private string content;
	private int size;

	public File(string n, Directory p, int sz):base(n,p)
	{
		size = sz;
	}

	public override int Size()
	{
		return size;
	}

	public string GetContents()
	{
		return content;
	}

	public void SetContents(String c)
	{
		content = c;
	}
}
}
