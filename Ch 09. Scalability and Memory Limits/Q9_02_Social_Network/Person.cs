using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_09._Scalability_and_Memory_Limits.Q9_02_Social_Network
{
	public class Person
	{
		private IList<int> friends = new List<int>();
		private int personID;
		private string info;

		public string GetInfo() { return info; }
		public void SetInfo(string info)
		{
			this.info = info;
		}

		public IList<int> GetFriends()
		{
			return friends;
		}

		public int GetID() { return personID; }
		public void AddFriend(int id) { friends.Add(id); }

		public Person(int id)
		{
			this.personID = id;
		}
	}
}
