using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_07_Chat_Server
{
	public class User
	{
		private int id;
		private UserStatus status = null;
		private Dictionary<int, PrivateChat> privateChats = new Dictionary<int, PrivateChat>();
		private IList<GroupChat> groupChats = new List<GroupChat>();
		private Dictionary<int, AddRequest> receivedAddRequests = new Dictionary<int, AddRequest>();
		private Dictionary<int, AddRequest> sentAddRequests = new Dictionary<int, AddRequest>();

		private Dictionary<int, User> contacts = new Dictionary<int, User>();
		private string accountName;
		private string fullName;

		public User(int id, string accountName, string fullName)
		{
			this.accountName = accountName;
			this.fullName = fullName;
			this.id = id;
		}

		public bool SendMessageToUser(User toUser, string content)
		{
			PrivateChat chat = privateChats.ContainsKey(toUser.GetId()) ? privateChats[toUser.GetId()] : null;
			if (chat == null)
			{
				chat = new PrivateChat(this, toUser);
				privateChats[toUser.GetId()] = chat;
			}
			Message message = new Message(content, new DateTime());
			return chat.AddMessage(message);
		}

		public bool SendMessageToGroupChat(int groupId, string content)
		{
			GroupChat chat = groupChats.Count < groupId ? groupChats[groupId] : null;
			if (chat != null)
			{
				Message message = new Message(content, new DateTime());
				return chat.AddMessage(message);
			}
			return false;
		}

		public void SetStatus(UserStatus status)
		{
			this.status = status;
		}

		public UserStatus GetStatus()
		{
			return status;
		}

		public bool AddContact(User user)
		{
			if (contacts.ContainsKey(user.GetId()))
			{
				return false;
			}
			else
			{
				contacts[user.GetId()]= user;
				return true;
			}
		}

		public void ReceivedAddRequest(AddRequest req)
		{
			int senderId = req.GetFromUser().GetId();
			if (!receivedAddRequests.ContainsKey(senderId))
			{
				receivedAddRequests[senderId] = req;
			}
		}

		public void SentAddRequest(AddRequest req)
		{
			int receiverId = req.GetFromUser().GetId();
			if (!sentAddRequests.ContainsKey(receiverId))
			{
				sentAddRequests[receiverId] = req;
			}
		}

		public void RemoveAddRequest(AddRequest req)
		{
			if (req.getToUser() == this)
			{
				var key = receivedAddRequests.First(p => p.Value == req).Key;
				receivedAddRequests.Remove(key);
			}
			else if (req.GetFromUser() == this)
			{
				var key = sentAddRequests.First(p => p.Value == req).Key;
				sentAddRequests.Remove(key);
			}
		}

		public void RequestAddUser(string accountName)
		{
			UserManager.GetInstance().AddUser(this, accountName);
		}

		public void AddConversation(PrivateChat conversation)
		{
			User otherUser = conversation.GetOtherParticipant(this);
			privateChats[otherUser.GetId()] = conversation;
		}

		public void AddConversation(GroupChat conversation)
		{
			groupChats.Add(conversation);
		}

		public int GetId()
		{
			return id;
		}

		public string GetAccountName()
		{
			return accountName;
		}

		public string GetFullName()
		{
			return fullName;
		}
	}
}
