using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_07_Chat_Server
{
	public class PrivateChat : Conversation
	{
	public PrivateChat(User user1, User user2)
	{
		participants.Add(user1);
		participants.Add(user2);
	}

	public User GetOtherParticipant(User primary)
	{
		if (participants[0] == primary)
		{
			return participants[1];
		}
		else if (participants[1] == primary)
		{
			return participants[0];
		}
		return null;
	}
}
}
