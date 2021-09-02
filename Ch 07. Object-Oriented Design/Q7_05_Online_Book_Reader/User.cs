using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_05_Online_Book_Reader
{
	public class User
	{
		private int userId;
		private string details;
		private int accountType;

		public void renewMembership() { }

		public User(int id, string details, int accountType)
		{
			userId = id;
			this.details = details;
			this.accountType = accountType;
		}

		/* getters and setters */
		public int getID() { return userId; }
		public void setID(int id) { userId = id; }
		public string getDetails() { return details; }
		public void setDetails(string details) { this.details = details; }
		public int getAccountType() { return accountType; }
		public void setAccountType(int accountType)
		{
			this.accountType = accountType;
		}
	}
}
