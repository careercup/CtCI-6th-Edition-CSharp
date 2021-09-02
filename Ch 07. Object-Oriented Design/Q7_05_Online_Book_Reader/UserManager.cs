using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_05_Online_Book_Reader
{
	public class UserManager
	{
		private Dictionary<int, User> users;

		public User addUser(int id, string details, int accountType)
		{
			if (users.ContainsKey(id))
			{
				return null;
			}
			User user = new User(id, details, accountType);
			users[id] = user;
			return user;
		}

		public bool remove(User u)
		{
			return remove(u.getID());
		}

		public bool remove(int id)
		{
			if (!users.ContainsKey(id))
			{
				return false;
			}
			users.Remove(id);
			return true;
		}

		public User find(int id)
		{
			return users[id];
		}
	}
}
