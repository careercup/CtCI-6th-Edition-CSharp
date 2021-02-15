
using System;
using System.Collections.Generic;

namespace Chapter09
{
	public class Person 
	{
		private List<int> _friends = new List<int>();
	
		public string Info {get; set;}
		public int Id { get; private set; }

		public List<int> GetFriends() 
		{
			return _friends;
		}
		
		public void AddFriend(int id) 
		{ 
			_friends.Add(id); 
		}
		
		public Person(int id) 
		{
			Id = id;
		}
	}
}


