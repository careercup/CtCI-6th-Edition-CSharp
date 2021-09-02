using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_02_Call_Center
{
	public class Caller
	{
		private string name;
		private int userId;
		public Caller(int id, string nm)
		{
			name = nm;
			userId = id;
		}
	}
}
