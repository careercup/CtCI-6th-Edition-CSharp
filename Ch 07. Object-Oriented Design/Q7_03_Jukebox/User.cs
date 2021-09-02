using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_03_Jukebox
{
	public class User
	{
		private string name;

		private long ID;
		public User(string name, long iD)
		{
			this.name = name;
			ID = iD;
		}

		public string GetName() { return name; }
		public void SetName(string name) { this.name = name; }
		public long GetID() { return ID; }
		public void SetID(long iD) { ID = iD; }
		
		public User GetUser() { return this; }

		public static User AddUser(string name, long iD)
		{
			return new User(name, iD);
		}
	}
}
