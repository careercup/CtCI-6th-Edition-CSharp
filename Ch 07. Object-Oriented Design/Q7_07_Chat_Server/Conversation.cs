using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_07_Chat_Server
{
	public abstract class Conversation
	{
		protected IList<User> participants = new List<User>();
		protected int id;
		protected IList<Message> messages = new List<Message>();

		public IList<Message> GetMessages()
		{
			return messages;
		}

		public bool AddMessage(Message m)
		{
			messages.Add(m);
			return true;
		}

		public int GetId()
		{
			return id;
		}
	}
}
