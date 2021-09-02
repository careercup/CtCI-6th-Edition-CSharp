using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_09_Circular_Array
{
    public class Q7_09_Circular_Array : Question
    {
        public override void Run()
        {
			int size = 10;
			CircularArray<string> array = new CircularArray<string>(size);
			for (int i = 0; i < size; i++)
			{
				array.Set(i, i.ToString());
			}

			array.Rotate(3);
			for (int i = 0; i < size; i++)
			{
				Console.WriteLine(array.Get(i));
			}

			Console.WriteLine("");

			array.Rotate(2);
			foreach (string s in array)
			{
				Console.WriteLine(s);
			}
		}
    }
}
