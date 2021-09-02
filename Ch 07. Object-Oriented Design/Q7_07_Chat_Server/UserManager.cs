using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_07_Chat_Server
{
	/* UserManager serves as the central place for the core user actions. */
	public class UserManager
	{
		private static UserManager instance;
		private Dictionary<int, User> usersById = new Dictionary<int, User>();
		private Dictionary<string, User> usersByAccountName = new Dictionary<string, User>();
		private Dictionary<int, User> onlineUsers = new Dictionary<int, User>();

		public static UserManager GetInstance()
		{
			if (instance == null)
			{
				instance = new UserManager();
			}
			return instance;
		}

		public void AddUser(User fromUser, string toAccountName)
		{
			User toUser = usersByAccountName[toAccountName];
			AddRequest req = new AddRequest(fromUser, toUser, new DateTime());
			toUser.ReceivedAddRequest(req);
			fromUser.SentAddRequest(req);
		}

		public void ApproveAddRequest(AddRequest req)
		{
			req.status = RequestStatus.Accepted;
			User from = req.GetFromUser();
			User to = req.getToUser();
			from.AddContact(to);
			to.AddContact(from);
		}

		public void RejectAddRequest(AddRequest req)
		{
			req.status = RequestStatus.Rejected;
			User from = req.GetFromUser();
			User to = req.getToUser();
			from.RemoveAddRequest(req);
			to.RemoveAddRequest(req);
		}

		public void UserSignedOn(string accountName)
		{
			User user = usersByAccountName[accountName];
			if (user != null)
			{
				user.SetStatus(new UserStatus(UserStatusType.Available, ""));
				onlineUsers[user.GetId()] = user;
			}
		}

		public void UserSignedOff(string accountName)
		{
			User user = usersByAccountName[accountName];
			if (user != null)
			{
				user.SetStatus(new UserStatus(UserStatusType.Offline, ""));
				onlineUsers.Remove(user.GetId());
			}
		}
	}
}
